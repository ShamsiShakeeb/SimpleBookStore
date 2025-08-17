using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimpleBookStore.BLL.Services.LogService;
using SimpleBookStore.DAL.Repositories.BookRepository;
using SimpleBookStore.DAL.Repositories.UserBookRepository;
using SimpleBookStore.DAL.StoreEntity;
using SimpleBookStore.DAL.UnitOfWork;
using SimpleBookStore.Model.Request;
using SimpleBookStore.Model.Response;
using SimpleBookStore.Utility;
using SimpleReviewStore.DAL.Repositories.ReviewRepository;
using System.Globalization;

namespace SimpleBookStore.BLL.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly UserManager<User> _userManager;
        private readonly IUserBookRepository _userBookRepository;
        private readonly ILogService _logService;
        private readonly IStoreUnitOfWork _storeUnitOfWork;
        public BookService(IBookRepository bookRepository,
            IReviewRepository reviewRepository,
            UserManager<User> userManager,
            IUserBookRepository userBookRepository,
            ILogService logService,
            IStoreUnitOfWork storeUnitOfWork)
        {
            _bookRepository = bookRepository;
            _reviewRepository = reviewRepository;
            _userManager = userManager;
            _userBookRepository = userBookRepository;
            _logService = logService;
            _storeUnitOfWork = storeUnitOfWork;
        }

        public async Task<List<Book>> GetBookList()
        {
            var result = await _bookRepository.GetListAsync();
            return result;
        }
        public async Task<List<BookInfoResponseModel>> GetBookDetailInfo()
        {
            var result = await (from b in _bookRepository.Get()
                                join r in _reviewRepository.Get()
                                on b.Id equals r.BID
                                join u in _userManager.Users
                                on r.UID equals u.Id
                                select new BookInfoResponseModel
                                {
                                    Title = b.Title,
                                    Author = b.Author,
                                    ISBN = b.ISBN,
                                    Price = b.Price,
                                    PublishDate = b.PublishedDate.ToString("yyyy/MM/dd"),
                                    Stock = b.Stock,
                                    BookId = b.Id,
                                    UserName = u.UserName,
                                    Email = u.Email,
                                    UserId = u.Id,
                                    Rating = r.Rating,
                                    Comment = r.Comment,
                                    ReviewId = r.Id
                                }).ToListAsync();
            return result;
        }
        public async Task<ResponseModel> BuyBookAsync(BuyBookRequestModel model)
        {
            return await _storeUnitOfWork.CommitAsync<ResponseModel>(async () =>
            {
                var bookInfo = await _bookRepository.GetEntityAsync(x => x.Id == model.BookId);

                if (bookInfo is null)
                {
                    await _logService.InsertLog(
                        new LogRequestModel() 
                        { Success = false, 
                          Message = "Book Not Found", 
                          ErrorMessage = string.Format("No Record Found Regarding this book Id: {0}. " +
                          "Operation Done By: {1}" , model.BookId,model.UserId)
                        });
                    return new ResponseModel()
                    {
                        Success = false,
                        Message = "Book Not Found",
                        ErrorMessage = "No Record Found Regarding this book Id"
                    };
                }

                else if (bookInfo.Stock == 0)
                {
                    await _logService.InsertLog(
                        new LogRequestModel()
                        {
                            Success = false,
                            Message = "Recently this Book is not available",
                            ErrorMessage = string.Format("No Record Found Regarding this book Id: {0}. " +
                            "Operation Done By: {1}", model.BookId, model.UserId)
                        });
                    return new ResponseModel()
                    {
                        Success = false,
                        Message = "Recently this Book is not available",
                        ErrorMessage = null
                    };
                }

                var insertModel = new UserBook()
                {
                    BookId = model.BookId,
                    UserId = model.UserId
                };

                var result = await _userBookRepository.InsertAsync(insertModel);

                if (!result.success)
                {
                    await _logService.InsertLog(
                       new LogRequestModel()
                       {
                           Success = false,
                           Message = "Internal Error",
                           ErrorMessage = string.Format("Error Occurd For BuyBookAsync Method, Book Id: {0}, User Id: {1} Exception: {2}"
                           , model.BookId, model.UserId, result.errorMessage)
                       });
                    return new ResponseModel()
                    {
                        Success = false,
                        Message = result.message,
                        ErrorMessage = result.errorMessage
                    };
                }

                 bookInfo.Stock -= 1;
                _bookRepository.Update(bookInfo);

                return new ResponseModel() { 
                    Success = true, 
                    Message = "Book purchased successfully", 
                    ErrorMessage = null 
                };
            });
        }
        public async Task<ResponseModel> ParseBooksFromExcelAsync(IFormFile file)
        {
            var books = new List<Book>();

            if (file == null || file.Length == 0)
            {
                await _logService.InsertLog(
                 new LogRequestModel()
                 {
                     Success = false,
                     Message = "Not Excel File Uploaded or Excel Process Failed",
                     ErrorMessage = "Not Excel File Uploaded or Excel Process Failed at ParseBooksFromExcelAsync Method",
                 });

                return new ResponseModel()
                {
                    Success = false,
                    Message = "Not Excel File Found",
                    ErrorMessage = "No Excel File Found"
                };
            }

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var workbook = new XLWorkbook(stream))
                {
                    var worksheet = workbook.Worksheet(1);
                    var rows = worksheet.RangeUsed().RowsUsed().Skip(1); 

                    foreach (var row in rows)
                    {
                        var book = new Book
                        {
                            Title = row.Cell(1).GetString(),
                            Author = row.Cell(2).GetString(),
                            ISBN = row.Cell(3).GetString(),
                            Price = decimal.TryParse(row.Cell(4).GetString(), out var price) ? price : 0,
                            PublishedDate = DateTime.TryParse(row.Cell(5).GetString(), CultureInfo.InvariantCulture, DateTimeStyles.None, out var date) ? date : DateTime.MinValue,
                            Createdby = Constant.Role.SuperAdmin,
                            CreatedDate = DateTime.UtcNow.AddHours(6)
                        };

                        books.Add(book);
                    }
                }
            }

            return await _storeUnitOfWork.CommitAsync<ResponseModel>(async () =>
            {
                var result = await _bookRepository.InsertRangeAsync(books);
                return new ResponseModel()
                {
                    Success = result.success,
                    Message = result.message,
                    ErrorMessage = result.errorMessage
                };
            });
        }

    }
}

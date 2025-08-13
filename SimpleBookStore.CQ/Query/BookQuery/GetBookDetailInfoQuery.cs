using KhatiExtendedEF.Extensions;
using KhatiExtendedEF.Model;
using KhatiExtendedEF.Repositories;
using KhatiMediaTr;
using Microsoft.AspNetCore.Identity;
using SimpleBookStore.DAL.StoreEntity;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.CQ.Query.BookQuery
{
    public class GetBookDetailInfoQuery : IEventHandler
    {
        private readonly IRepository<Book> _repositoryBook;
        private readonly IRepository<Review> _repositoryReview;
        private readonly UserManager<User> _userManager;

        public GetBookDetailInfoQuery(IRepository<Book> repositoryBook,
            IRepository<Review> repositoryReview,
            UserManager<User> userManager)
        {
            _repositoryBook = repositoryBook;
            _repositoryReview = repositoryReview;
            _userManager = userManager;
        }

        public async Task<PaginationResponseModel<BookInfoResponseModel>> Handler(int pageSize = 10, int pageIndex = 1)
        {
            var data = (from b in _repositoryBook.Get()
                        join r in _repositoryReview.Get()
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
                        });

            var pagination = await data.PaginationAsync(pageSize, pageIndex);

            return pagination;
        }
    }
}

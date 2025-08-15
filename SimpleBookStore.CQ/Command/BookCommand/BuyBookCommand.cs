using KhatiExtendedEF.Repositories;
using KhatiExtendedEF.UnitOfWork;
using KhatiMediaTr;
using SimpleBookStore.CQ.Command.LogCommand;
using SimpleBookStore.DAL.StoreEntity;
using SimpleBookStore.Model.Request;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.CQ.Command.BookCommand
{
    public class BuyBookCommand : IEventHandler
    {
        private readonly IRepository<Book> _repositoryBook;
        private readonly IRepository<UserBook> _repositoryUserBook;
        private readonly IUnitOfWork<IStoreEntity> _storeUnitWork;
        private readonly IMediaTr<AddLogCommand, Task> _logCommand;
        public BuyBookCommand(IRepository<Book> repositoryBook,
            IRepository<UserBook> repositoryUserBook,
            IUnitOfWork<IStoreEntity> storeUnitWork,
            IMediaTr<AddLogCommand, Task> logCommand)
        {
            _repositoryBook = repositoryBook;
            _repositoryUserBook = repositoryUserBook;
            _storeUnitWork = storeUnitWork;
            _logCommand = logCommand;
        }
        public async Task<ResponseModel> Handler(BuyBookRequestModel model)
        {
            var bookInfo = await _repositoryBook.GetEntity(x => x.Id == model.BookId);

            if (bookInfo is null)
            {
                await _logCommand.Send(new LogRequestModel()
                {
                    Success = false,
                    Message = "Book Not Found",
                    ErrorMessage = string.Format("No Record Found Regarding this book Id: {0}. " +
                      "Operation Done By: {1}", model.BookId, model.UserId)
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
                await _logCommand.Send(new LogRequestModel()
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

            var response = await _storeUnitWork.Commit(async () =>
            {
                var insertModel = new UserBook()
                {
                    BookId = model.BookId,
                    UserId = model.UserId
                };

                await _repositoryUserBook.InsertAsync(insertModel);

                bookInfo.Stock -= 1;
                _repositoryBook.Update(bookInfo);
            });

            return new ResponseModel()
            {
                Success = response.success,
                Message = response.message,
                ErrorMessage = response.errorMessage
            };
        }

    }
}
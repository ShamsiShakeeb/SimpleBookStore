using KhatiExtendedEF.Repositories;
using KhatiMediaTr;
using SimpleBookStore.CQ.Command.LogCommand;
using SimpleBookStore.DAL.LogEntity;
using SimpleBookStore.DAL.StoreEntity;
using SimpleBookStore.Model.Request;

namespace SimpleBookStore.CQ.Command.BookCommand
{
    public class BuyBookCommand : IEventHandler
    {
        private readonly IRepository<Book> _repositoryBook;
        private readonly IRepository<User_Book> _repositoryUserBook;
        private readonly IMediaTr<AddLogCommand, Task> _logCommand;
        public BuyBookCommand(IRepository<Book> repositoryBook,
            IRepository<User_Book> repositoryUserBook,
            IMediaTr<AddLogCommand, Task> logCommand)
        {
            _repositoryBook = repositoryBook;
            _repositoryUserBook = repositoryUserBook;
            _logCommand = logCommand;
        }
        public async Task<(bool success, string message, string errorMessage)> Handler(BuyBookRequestModel model)
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
                return (false, "Book Not Found", "No Record Found Regarding this book Id");
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
                return (false, "Recently this Book is not available", null);
            }

            return await _repositoryUserBook.Commit(async () =>
            {
                var insertModel = new User_Book()
                {
                    BookId = model.BookId,
                    UserId = model.UserId
                };

                var result = await _repositoryUserBook.InsertAsync(insertModel);

                bookInfo.Stock -= 1;
                _repositoryBook.Update(bookInfo);
            });
        }

    }
}
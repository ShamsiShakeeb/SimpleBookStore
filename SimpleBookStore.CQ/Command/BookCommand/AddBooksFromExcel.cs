using KhatiExcel.Feature;
using KhatiExtendedEF.Repositories;
using KhatiExtendedEF.UnitOfWork;
using KhatiMediaTr;
using Microsoft.AspNetCore.Http;
using SimpleBookStore.CQ.Command.LogCommand;
using SimpleBookStore.DAL.StoreEntity;

namespace SimpleBookStore.CQ.Command.BookCommand
{
    public class AddBooksFromExcel : IEventHandler
    {
        private readonly IRepository<Book> _repositoryBook;
        private readonly IUnitOfWork<IStoreEntity> _storeUnitWork;
        private readonly IMediaTr<AddLogCommand, Task> _logCommand;
        private readonly ILoadExcel _loadExcel;
        public AddBooksFromExcel(IRepository<Book> repositoryBook,
            IUnitOfWork<IStoreEntity> storeUnitWork,
            IMediaTr<AddLogCommand, Task> logCommand,
            ILoadExcel loadExcel)
        {
            _repositoryBook = repositoryBook;
            _storeUnitWork = storeUnitWork;
            _logCommand = logCommand;
            _loadExcel = loadExcel;
        }
        public async Task<(bool success,string message,string errorMessage)> Handler(IFormFile file)
        {
            var result = _loadExcel.Fetch(file, "Sheet1");
            List<Book> books = new List<Book>();
            foreach (var r in result.data)
            {
                var book = new Book()
                {
                    Title = r.Where(x => x.ColumnName.Trim() == "Title").Select(x => x.ColumnValue).FirstOrDefault(),
                    Author = r.Where(x => x.ColumnName.Trim() == "Author").Select(x => x.ColumnValue).FirstOrDefault(),
                    ISBN = r.Where(x => x.ColumnName.Trim() == "ISBN").Select(x => x.ColumnValue).FirstOrDefault(),
                    Price = r.Where(x => x.ColumnName.Trim() == "Price").Select(x => Convert.ToDecimal(x.ColumnValue))
                    .FirstOrDefault(),
                    PublishedDate = r.Where(x => x.ColumnName.Trim() == "PublishedDate").Select(x => DateTime.Parse(x.ColumnValue))
                    .FirstOrDefault()
                };
                books.Add(book);
            }
            return await _storeUnitWork.Commit(async () =>
            {
                await _repositoryBook.InsertRangeAsync(books);
            });
        }
    }
}

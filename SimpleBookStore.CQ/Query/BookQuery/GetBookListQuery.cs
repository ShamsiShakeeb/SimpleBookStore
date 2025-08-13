using KhatiExtendedEF.Extensions;
using KhatiExtendedEF.Model;
using KhatiExtendedEF.Repositories;
using KhatiMediaTr;
using SimpleBookStore.DAL.StoreEntity;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.CQ.Query.BookQuery
{
    public class GetBookListQuery : IEventHandler
    {
        private readonly IRepository<Book> _repositoryBook;
        public GetBookListQuery(IRepository<Book> repositoryBook)
        {
            _repositoryBook = repositoryBook;
        }
        public async Task<PaginationResponseModel<BookResponseModel>> Handler(int pageSize = 10,int pageIndex = 1)
        {
            var data = _repositoryBook.Get(x => true).Select(x=> new BookResponseModel()
            {
                Id = x.Id,
                Title = x.Title,
                Author = x.Author,
                ISBN = x.ISBN,
                Price = x.Price,
                Stock = x.Stock,
                PublishedDate = x.PublishedDate,
            });

            var pagination = await data.PaginationAsync(pageSize, pageIndex);

            return pagination;
        }
    }
}

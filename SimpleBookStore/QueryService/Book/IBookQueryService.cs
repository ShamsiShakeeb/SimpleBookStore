using KhatiExtendedEF.Model;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.QueryService.Book
{
    public interface IBookQueryService
    {
        Task<PaginationResponseModel<BookResponseModel>> BookListAsync(int pageSize, int pageIndex);
        Task<PaginationResponseModel<BookInfoResponseModel>> BookDetailsAsync(int pageSize, int pageIndex);
    }
}

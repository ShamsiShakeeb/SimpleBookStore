using KhatiExtendedEF.Model;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.CQFeature.QueryFeature.Book
{
    public interface IBookQueryFeature
    {
        Task<PaginationResponseModel<BookResponseModel>> BookListAsync(int pageSize, int pageIndex);
        Task<PaginationResponseModel<BookInfoResponseModel>> BookDetailsAsync(int pageSize, int pageIndex);
    }
}

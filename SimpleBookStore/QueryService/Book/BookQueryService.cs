using KhatiExtendedEF.Model;
using KhatiMediaTr;
using SimpleBookStore.CQ.Query.BookQuery;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.QueryService.Book
{
    public class BookQueryService : IBookQueryService
    {
        private readonly IMediaTr<GetBookListQuery, Task<PaginationResponseModel<BookResponseModel>>> _bookList;
        private readonly IMediaTr<GetBookDetailInfoQuery, Task<PaginationResponseModel<BookInfoResponseModel>>> _bookDetails;
        public BookQueryService(IMediaTr<GetBookListQuery, Task<PaginationResponseModel<BookResponseModel>>> bookList,
            IMediaTr<GetBookDetailInfoQuery, Task<PaginationResponseModel<BookInfoResponseModel>>> bookDetails)
        {
            _bookList = bookList;
            _bookDetails = bookDetails;
        }

        public async Task<PaginationResponseModel<BookResponseModel>> BookListAsync(int pageSize, int pageIndex)
        {
            return await _bookList.Send(new object[] { pageSize, pageIndex });
        }
        public async Task<PaginationResponseModel<BookInfoResponseModel>> BookDetailsAsync(int pageSize, int pageIndex)
        {
            return await _bookDetails.Send(new object[] { pageSize, pageIndex });
        }
    }
}

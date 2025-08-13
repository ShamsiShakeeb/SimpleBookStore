using KhatiExtendedEF.Model;
using KhatiMediaTr;
using Microsoft.AspNetCore.Mvc;
using SimpleBookStore.CQ.Command.BookCommand;
using SimpleBookStore.CQ.Query.BookQuery;
using SimpleBookStore.CustomFiltering;
using SimpleBookStore.Model.Request;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BookController : Controller
    {
        private readonly IMediaTr<GetBookListQuery, Task<PaginationResponseModel<BookResponseModel>>> _bookList;
        private readonly IMediaTr<GetBookDetailInfoQuery, Task<PaginationResponseModel<BookInfoResponseModel>>> _bookDetails;
        private readonly IMediaTr<BuyBookCommand, Task<(bool success, string message, string errorMessage)>> _buyBook;
        private readonly IMediaTr<AddBooksFromExcel, Task<(bool success, string message, string errorMessage)>> _addBookExcel;
        public BookController(IMediaTr<GetBookListQuery, Task<PaginationResponseModel<BookResponseModel>>> bookList,
            IMediaTr<GetBookDetailInfoQuery, Task<PaginationResponseModel<BookInfoResponseModel>>> bookDetails,
            IMediaTr<BuyBookCommand, Task<(bool success, string message, string errorMessage)>> buyBook,
            IMediaTr<AddBooksFromExcel, Task<(bool success, string message, string errorMessage)>> addBookExcel)
        {
            _bookList = bookList;
            _bookDetails = bookDetails;
            _buyBook = buyBook;
            _addBookExcel = addBookExcel;
        }

        [AuthorizationFilter("Person")]
        [HttpGet]
        [Route("{pageSize}/{pageIndex}")]
        public async Task<IActionResult> BookList(int pageSize, int pageIndex)
        {
            var result = await _bookList.Send(new object[] { pageSize , pageIndex });
            return Ok(result);
        }

        [AuthorizationFilter("Person")]
        [HttpGet]
        [Route("{pageSize}/{pageIndex}")]
        public async Task<IActionResult> BookDetails(int pageSize, int pageIndex)
        {
            var result = await _bookDetails.Send(new object[] { pageSize, pageIndex });
            return Ok(result);
        }

        [AuthorizationFilter("Person")]
        [HttpPost]
        public async Task<IActionResult> BuyBook(BuyBookRequestModel model)
        {
            var result = await _buyBook.Send(model);
            if (!result.success)
                return BadRequest(new { result.success, result.message });
            return Ok(new { result.success, result.message });
        }

        [AuthorizationFilter("SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> BookBulkUpload(IFormFile file)
        {
            var result = await _addBookExcel.Send(new object[] { file });
            if (!result.success)
                return BadRequest(new { result.success, result.message });
            return Ok(new { result.success, result.message });
        }
    }
}

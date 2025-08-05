using Microsoft.AspNetCore.Mvc;
using SimpleBookStore.BLL.Services.BookService;
using SimpleBookStore.CustomFiltering;
using SimpleBookStore.Model.Request;

namespace SimpleBookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [AuthorizationFilter("Person")]
        [HttpGet]
        public async Task<IActionResult> BookList()
        {
            var result = await _bookService.GetBookList();
            return Ok(result);
        }

        [AuthorizationFilter("Person")]
        [HttpGet]
        public async Task<IActionResult> BookDetails()
        {
            var result = await _bookService.GetBookDetailInfo();
            return Ok(result);
        }

        [AuthorizationFilter("Person")]
        [HttpPost]
        public async Task<IActionResult> BuyBook(BuyBookRequestModel model)
        {
            var result = await _bookService.BuyBookAsync(model);
            if (!result.success)
                return BadRequest(new { result.success , result.message });
            return Ok(new { result.success , result.message});
        }

        [AuthorizationFilter("SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> BookBulkUpload(IFormFile file)
        {
            var result = await _bookService.ParseBooksFromExcelAsync(file);
            if (!result.success)
                return BadRequest(new { result.success, result.message });
            return Ok(new { result.success, result.message });
        }
    }
}

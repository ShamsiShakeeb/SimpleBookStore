using Microsoft.AspNetCore.Mvc;
using SimpleBookStore.CQFeature.QueryFeature.Book;
using SimpleBookStore.CustomFiltering;

namespace SimpleBookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [AuthorizationFilter("Person")]
    public class BookInformationController : ControllerBase
    {
        private readonly IBookQueryFeature _bookQueryService;
        public BookInformationController(IBookQueryFeature bookQueryService)
        {
            _bookQueryService = bookQueryService;
        }

        [HttpGet]
        [Route("{pageSize}/{pageIndex}")]
        public async Task<IActionResult> BookList(int pageSize, int pageIndex)
        {
            var result = await _bookQueryService.BookListAsync(pageSize, pageIndex);
            return Ok(result);
        }

        [HttpGet]
        [Route("{pageSize}/{pageIndex}")]
        public async Task<IActionResult> BookDetails(int pageSize, int pageIndex)
        {
            var result = await _bookQueryService.BookDetailsAsync(pageSize,pageIndex);
            return Ok(result);
        }
    }
}

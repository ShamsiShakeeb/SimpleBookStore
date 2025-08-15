using KhatiExtendedEF.Model;
using KhatiMediaTr;
using Microsoft.AspNetCore.Mvc;
using SimpleBookStore.CQ.Query.BookQuery;
using SimpleBookStore.CustomFiltering;
using SimpleBookStore.Model.Response;
using SimpleBookStore.QueryService.Book;

namespace SimpleBookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [AuthorizationFilter("Person")]
    public class BookInformationController : ControllerBase
    {
        private readonly IBookQueryService _bookQueryService;
        public BookInformationController(IBookQueryService bookQueryService)
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

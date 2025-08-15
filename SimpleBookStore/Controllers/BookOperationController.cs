using KhatiMediaTr;
using Microsoft.AspNetCore.Mvc;
using SimpleBookStore.CQ.Command.BookCommand;
using SimpleBookStore.CustomFiltering;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.Controllers
{
    [ApiController]
    [AuthorizationFilter("SuperAdmin")]
    [Route("api/[controller]/[action]")]
    public class BookOperationController : ControllerBase
    {
        private readonly IMediaTr<AddBooksFromExcel, Task<ResponseModel>> _addBookExcel;
        public BookOperationController(IMediaTr<AddBooksFromExcel, Task<ResponseModel>> addBookExcel)
        {
            _addBookExcel = addBookExcel;
        }

        [HttpPost]
        public async Task<IActionResult> BookBulkUpload(IFormFile file)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Errors = ModelState.Values.SelectMany(v => v.Errors) });

            var result = await _addBookExcel.Send(new object[] { file });
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

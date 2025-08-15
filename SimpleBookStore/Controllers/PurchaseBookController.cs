using KhatiMediaTr;
using Microsoft.AspNetCore.Mvc;
using SimpleBookStore.CQ.Command.BookCommand;
using SimpleBookStore.CustomFiltering;
using SimpleBookStore.Model.Request;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.Controllers
{
    [AuthorizationFilter("Person")]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PurchaseBookController : ControllerBase
    {
        private readonly IMediaTr<BuyBookCommand, Task<ResponseModel>> _buyBook;
        public PurchaseBookController(IMediaTr<BuyBookCommand, Task<ResponseModel>> buyBook)
        {
            _buyBook = buyBook;
        }

        [HttpPost]
        public async Task<IActionResult> BuyBook(BuyBookRequestModel model)
        {
            if (!ModelState.IsValid)
               return BadRequest(new { Errors = ModelState.Values.SelectMany(v => v.Errors) });

            var result = await _buyBook.Send(model);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

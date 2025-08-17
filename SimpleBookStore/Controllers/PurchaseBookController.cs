using Microsoft.AspNetCore.Mvc;
using SimpleBookStore.CQFeature.CommandFeature.BookStore;
using SimpleBookStore.CustomFiltering;
using SimpleBookStore.Model.Request;

namespace SimpleBookStore.Controllers
{
    [AuthorizationFilter("Person")]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PurchaseBookController : ControllerBase
    {
        private readonly IBookStoreCommandFeature _bookStoreCommandFeature;
        public PurchaseBookController(IBookStoreCommandFeature bookStoreCommandFeature)
        {
            _bookStoreCommandFeature = bookStoreCommandFeature;
        }

        [HttpPost]
        public async Task<IActionResult> BuyBook(BuyBookRequestModel model)
        {
            if (!ModelState.IsValid)
               return BadRequest(new { Errors = ModelState.Values.SelectMany(v => v.Errors) });

            var result = await _bookStoreCommandFeature.BuyBookAsync(model);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

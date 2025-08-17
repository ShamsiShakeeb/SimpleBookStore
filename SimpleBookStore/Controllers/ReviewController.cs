using Microsoft.AspNetCore.Mvc;
using SimpleBookStore.CQFeature.CommandFeature.BookStore;
using SimpleBookStore.CustomFiltering;
using SimpleBookStore.Model.Request;

namespace SimpleBookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [AuthorizationFilter("Person")]
    public class ReviewController : ControllerBase
    {
        private readonly IBookStoreCommandFeature _bookStoreCommandFeature;
        public ReviewController(IBookStoreCommandFeature bookStoreCommandFeature)
        {
            _bookStoreCommandFeature = bookStoreCommandFeature;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitReview(ReviewRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, message = string.Join("\n", ModelState.Values.SelectMany(v => v.Errors)) });

            var result = await _bookStoreCommandFeature.SubmitReviewAsync(model);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

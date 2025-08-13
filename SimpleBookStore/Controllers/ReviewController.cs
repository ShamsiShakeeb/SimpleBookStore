using KhatiMediaTr;
using Microsoft.AspNetCore.Mvc;
using SimpleBookStore.CQ.Command.ReviewCommand;
using SimpleBookStore.CustomFiltering;
using SimpleBookStore.Model.Request;

namespace SimpleBookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [AuthorizationFilter("Person")]
    public class ReviewController : Controller
    {
        private readonly IMediaTr<GiveReviewCommand, Task<(bool success, string message, string errorMessage)>> _giveReview;
        public ReviewController(IMediaTr<GiveReviewCommand, Task<(bool success, string message, string errorMessage)>> giveReview)
        {
            _giveReview = giveReview;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitReview(ReviewRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, message = string.Join("\n", ModelState.Values.SelectMany(v => v.Errors)) });

            var result = await _giveReview.Send(model);
            if (!result.success)
                return BadRequest(new { result.success, result.message });
            return Ok(new { result.success, result.message });
        }
    }
}

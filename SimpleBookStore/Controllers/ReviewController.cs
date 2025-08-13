//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
//using SimpleBookStore.BLL.Services.ReviewService;
//using SimpleBookStore.CustomFiltering;
//using SimpleBookStore.Model.Request;

//namespace SimpleBookStore.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]/[action]")]
//    public class ReviewController : Controller
//    {
//        private readonly IReviewService _reviewService;
//        public ReviewController(IReviewService reviewService)
//        {
//            _reviewService = reviewService;
//        }

//        [AuthorizationFilter("Person")]
//        [HttpPost]
//        public async Task<IActionResult> SubmitReview(ReviewRequestModel model)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(new { success = false, message = string.Join("\n", ModelState.Values.SelectMany(v => v.Errors)) });

//            var result = await _reviewService.GiveReview(model);
//            if (!result.success)
//                return BadRequest(new { result.success, result.message });
//            return Ok(new { result.success, result.message });
//        }
//    }
//}

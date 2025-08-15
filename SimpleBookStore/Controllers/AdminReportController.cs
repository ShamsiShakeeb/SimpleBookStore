using Microsoft.AspNetCore.Mvc;
using SimpleBookStore.CustomFiltering;
using SimpleBookStore.QueryService.Report;

namespace SimpleBookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [AuthorizationFilter("SuperAdmin")]
    public class AdminReportController : ControllerBase
    {
        private readonly IReportQueryService _reportQueryService;
        public AdminReportController(IReportQueryService reportQueryService)
        {
            _reportQueryService = reportQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> CommentCountByUsers()
        {
            var result = await _reportQueryService.CommentCountByUsersAsync();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> UserBookStats()
        {
            var result = await _reportQueryService.UserBookStatsAsync();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

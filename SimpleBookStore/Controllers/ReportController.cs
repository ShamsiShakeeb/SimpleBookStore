using Microsoft.AspNetCore.Mvc;
using SimpleBookStore.CQFeature.QueryFeature.Report;
using SimpleBookStore.CustomFiltering;

namespace SimpleBookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [AuthorizationFilter("SuperAdmin")]
    public class ReportController : ControllerBase
    {
        private readonly IReportQueryFeature _reportQueryService;
        public ReportController(IReportQueryFeature reportQueryService)
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

        [HttpGet]
        public async Task<IActionResult> DownloadCommentByUserReport()
        {
            var result = await _reportQueryService.DownloadCommentCountByUsersReportAsync();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

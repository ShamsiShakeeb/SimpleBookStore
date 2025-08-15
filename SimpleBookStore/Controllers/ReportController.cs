using Microsoft.AspNetCore.Mvc;
using SimpleBookStore.BLL.Services.ReportService;
using SimpleBookStore.CustomFiltering;

namespace SimpleBookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [AuthorizationFilter("SuperAdmin")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<IActionResult> CommentCountByUsers()
        {
            var result = await _reportService.GetCommentCountByUsers();
            if (!result.success)
                return BadRequest(new { result.success, result.message });
            return Ok(new { result.report });
        }

        [HttpGet]
        public async Task<IActionResult> UserBookStats()
        {
            var result = await _reportService.UserBookStats();
            if (!result.success)
                return BadRequest(new { result.success, result.message });
            return Ok(new { result.report });
        }

        [HttpGet]
        public async Task<IActionResult> DownloadCommentByUserReport()
        {
            var result = await _reportService.DownloadCommentByUserReport();
            if(!result.success)
                return BadRequest(new { result.success, result.message});

            return Ok(new { result.success, result.base64, result.message });
        }
    }
}

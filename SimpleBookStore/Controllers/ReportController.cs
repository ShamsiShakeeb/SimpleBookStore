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
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> UserBookStats()
        {
            var result = await _reportService.UserBookStats();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> DownloadCommentByUserReport()
        {
            var result = await _reportService.DownloadCommentByUserReport();
            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

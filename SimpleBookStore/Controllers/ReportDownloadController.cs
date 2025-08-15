using KhatiMediaTr;
using Microsoft.AspNetCore.Mvc;
using SimpleBookStore.CQ.Query.ReportQuery;
using SimpleBookStore.CustomFiltering;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ReportDownloadController : ControllerBase
    {
        private readonly IMediaTr<DownloadCommentByUserReportQuery, Task<ResponseModel<string>>> _downloadCommentByUserReport;
        public ReportDownloadController(IMediaTr<DownloadCommentByUserReportQuery, Task<ResponseModel<string>>> downloadCommentByUserReport)
        {
            _downloadCommentByUserReport = downloadCommentByUserReport;
        }

        [AuthorizationFilter("SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> CommentByUserReport()
        {
            var result = await _downloadCommentByUserReport.Send();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

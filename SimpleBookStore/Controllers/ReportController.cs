using KhatiMediaTr;
using Microsoft.AspNetCore.Mvc;
using SimpleBookStore.CQ.Query.ReportQuery;
using SimpleBookStore.CustomFiltering;
using SimpleBookStore.Model.Report;

namespace SimpleBookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [AuthorizationFilter("SuperAdmin")]
    public class ReportController : ControllerBase
    {
        private readonly IMediaTr<GetCommentCountByUserQuery, 
            Task<(bool success, List<CommentCountByUserReport> report, string message, string errorMessage)>> _getCommentCountByUser;

        private readonly IMediaTr<GetUserBookStatsQuery,
            Task<(bool success, List<UserBookStatsReport> report, string message, string errorMessage)>> _getUserBookStat;

        private readonly IMediaTr<DownloadCommentByUserReportQuery,
            Task<(bool success, string base64, string message, string errorMessage)>> _downloadCommentByUserReport;
        public ReportController(IMediaTr<GetCommentCountByUserQuery,
            Task<(bool success, List<CommentCountByUserReport> report, string message, string errorMessage)>> getCommentCountByUser,

            IMediaTr<GetUserBookStatsQuery,
            Task<(bool success, List<UserBookStatsReport> report, string message, string errorMessage)>> getUserBookStat,

            IMediaTr<DownloadCommentByUserReportQuery,
            Task<(bool success, string base64, string message, string errorMessage)>> downloadCommentByUserReport)
        {
            _getCommentCountByUser = getCommentCountByUser;
            _getUserBookStat = getUserBookStat;
            _downloadCommentByUserReport = downloadCommentByUserReport;
        }

        [HttpGet]
        public async Task<IActionResult> CommentCountByUsers()
        {
            var result = await _getCommentCountByUser.Send();
            if (!result.success)
                return BadRequest(new { result.success, result.message });
            return Ok(new { result.report });
        }

        [HttpGet]
        public async Task<IActionResult> UserBookStats()
        {
            var result = await _getUserBookStat.Send();
            if (!result.success)
                return BadRequest(new { result.success, result.message });
            return Ok(new { result.report });
        }

        [HttpGet]
        public async Task<IActionResult> DownloadCommentByUserReport()
        {
            var result = await _downloadCommentByUserReport.Send();
            if (!result.success)
                return BadRequest(new { result.success, result.message });

            return Ok(new { result.success, result.base64, result.message });
        }
    }
}

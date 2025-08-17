using KhatiMediaTr;
using SimpleBookStore.CQ.Query.ReportQuery;
using SimpleBookStore.Model.Report;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.CQFeature.QueryFeature.Report
{
    public class ReportQueryFeature : IReportQueryFeature
    {
        private readonly IMediaTr<GetCommentCountByUserQuery, Task<(bool success, List<CommentCountByUserReport> report, string message, string errorMessage)>> _getCommentCountByUser;
        private readonly IMediaTr<GetUserBookStatsQuery, Task<(bool success, List<UserBookStatsReport> report, string message, string errorMessage)>> _getUserBookStat;
        private readonly IMediaTr<DownloadCommentByUserReportQuery, Task<(bool success, string base64, string message, string errorMessage)>> _downloadCommentByUserReport;
        public ReportQueryFeature(IMediaTr<GetCommentCountByUserQuery, Task<(bool success, List<CommentCountByUserReport> report, string message, string errorMessage)>> getCommentCountByUser,
            IMediaTr<GetUserBookStatsQuery, Task<(bool success, List<UserBookStatsReport> report, string message, string errorMessage)>> getUserBookStat,
            IMediaTr<DownloadCommentByUserReportQuery, Task<(bool success, string base64, string message, string errorMessage)>> downloadCommentByUserReport)
        {
            _getCommentCountByUser = getCommentCountByUser;
            _getUserBookStat = getUserBookStat;
            _downloadCommentByUserReport = downloadCommentByUserReport;
        }
        public async Task<ResponseModel<List<CommentCountByUserReport>>> CommentCountByUsersAsync()
        {
            var result = await _getCommentCountByUser.Send();
            return new ResponseModel<List<CommentCountByUserReport>>()
            {
                Success = result.success,
                Message = result.message,
                ErrorMessage = result.errorMessage,
                Data = result.report
            };
        }
        public async Task<ResponseModel<List<UserBookStatsReport>>> UserBookStatsAsync()
        {
            var result = await _getUserBookStat.Send();
            return new ResponseModel<List<UserBookStatsReport>>()
            {
                Success = result.success,
                Data = result.report,
                Message = result.message,
                ErrorMessage = result.errorMessage,
            };
        }
        public async Task<ResponseModel<string>> DownloadCommentCountByUsersReportAsync()
        {
            var result = await _downloadCommentByUserReport.Send();
            return new ResponseModel<string>()
            {
                Success = result.success,
                Message = result.message,
                Data = result.base64,
                ErrorMessage = result.errorMessage,
            };
        }
    }
}

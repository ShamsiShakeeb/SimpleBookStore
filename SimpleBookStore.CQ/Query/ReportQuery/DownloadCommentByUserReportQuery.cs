using KhatiExcel.Feature;
using KhatiMediaTr;
using SimpleBookStore.Model.Report;

namespace SimpleBookStore.CQ.Query.ReportQuery
{
    public class DownloadCommentByUserReportQuery : IEventHandler
    {
        private readonly IMediaTr<GetCommentCountByUserQuery, Task<(bool success,
            List<CommentCountByUserReport> report, string message, string errorMessage)>> _getCommentByUserQuery;

        private readonly ILoadExcel _loadExcel;
        public DownloadCommentByUserReportQuery(IMediaTr<GetCommentCountByUserQuery, Task<(bool success,
            List<CommentCountByUserReport> report, string message, string errorMessage)>> getCommentByUserQuery,
            ILoadExcel loadExcel)
        {
            _getCommentByUserQuery = getCommentByUserQuery;
            _loadExcel = loadExcel;
        }
        public async Task<(bool success, string base64, string message, string errorMessage)> Handler()
        {
            var result = await _getCommentByUserQuery.Send();

            if (!result.success)
              return (result.success, null, result.message, result.errorMessage);

            var excelResult = _loadExcel.ListToExcelBase64("Sheet1", 
                new List<string>() { "UID", "UserName", "Email", "Gender", "CommentCount" }, 
                result.report);

            return excelResult;
        }
    }
}

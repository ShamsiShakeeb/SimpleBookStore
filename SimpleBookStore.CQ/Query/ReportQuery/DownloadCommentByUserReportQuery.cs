using KhatiExcel.Feature;
using KhatiMediaTr;
using SimpleBookStore.Model.Report;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.CQ.Query.ReportQuery
{
    public class DownloadCommentByUserReportQuery : IEventHandler
    {
        private readonly IMediaTr<GetCommentCountByUserQuery, Task<ResponseModel<List<CommentCountByUserReport>>>> _getCommentByUserQuery;

        private readonly ILoadExcel _loadExcel;
        public DownloadCommentByUserReportQuery(IMediaTr<GetCommentCountByUserQuery, Task<ResponseModel<List<CommentCountByUserReport>>>> getCommentByUserQuery,
            ILoadExcel loadExcel)
        {
            _getCommentByUserQuery = getCommentByUserQuery;
            _loadExcel = loadExcel;
        }
        public async Task<ResponseModel<string>> Handler()
        {
            var result = await _getCommentByUserQuery.Send();

            if (!result.Success)
              return new ResponseModel<string>()
              {
                  Success = result.Success,
                  ErrorMessage = result.ErrorMessage,
                  Message = result.Message,
                  Data = null
              };

            var excelResult = _loadExcel.ListToExcelBase64("Sheet1", 
                new List<string>() { "UID", "UserName", "Email", "Gender", "CommentCount" }, 
                result.Data);

            return new ResponseModel<string>()
            {
                Success = excelResult.success,
                ErrorMessage = excelResult.errorMessage,
                Message = excelResult.message,
                Data = excelResult.base64
            };
        }
    }
}

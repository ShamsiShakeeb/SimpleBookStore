using ClosedXML.Excel;
using SimpleBookStore.DAL.DTO;
using SimpleBookStore.DAL.Repositories.ReportRepository;
using SimpleBookStore.Model.Report;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.BLL.Services.ReportService
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public async Task<ResponseModel<List<CommentCountByUserReport>>> GetCommentCountByUsers()
        {
            var result = await _reportRepository.GetCommentCountByUsers();
            return new ResponseModel<List<CommentCountByUserReport>>()
            {
                Success = result.success,
                Data = result.report,
                Message = result.message,
                ErrorMessage = result.errorMessage
            };
        }
        public async Task<ResponseModel<List<UserBookStatsReport>>> UserBookStats()
        {
            var result = await _reportRepository.UserBookStats();
            return new ResponseModel<List<UserBookStatsReport>>()
            {
                Success = result.success,
                Data = result.report,
                Message = result.message,
                ErrorMessage = result.errorMessage
            };
        }
        public async Task<ResponseModel<string>> DownloadCommentByUserReport()
        {
            var result = await _reportRepository.GetCommentCountByUsers();
            if (!result.success)
                return new ResponseModel<string>()
                {
                    Success = result.success,
                    Data = null,
                    ErrorMessage= result.errorMessage,
                    Message = result.message
                };
            var base64 = GenerateExcelBase64(result.report);
            return new ResponseModel<string>()
            {
                Success = true,
                Data = base64,
                Message = "Base64 Generated",
                ErrorMessage = null
            };
        }
        private static string GenerateExcelBase64(List<CommentCountByUserReport> reportData)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Comment Report");

                worksheet.Cell(1, 1).Value = "UID";
                worksheet.Cell(1, 2).Value = "UserName";
                worksheet.Cell(1, 3).Value = "Email";
                worksheet.Cell(1, 4).Value = "Gender";
                worksheet.Cell(1, 5).Value = "Comment Count";

                for (int i = 0; i < reportData.Count; i++)
                {
                    var item = reportData[i];
                    worksheet.Cell(i + 2, 1).Value = item.UID;
                    worksheet.Cell(i + 2, 2).Value = item.UserName;
                    worksheet.Cell(i + 2, 3).Value = item.Email;
                    worksheet.Cell(i + 2, 4).Value = item.Gender;
                    worksheet.Cell(i + 2, 5).Value = item.CommentCount;
                }

                worksheet.Columns().AdjustToContents();
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var bytes = stream.ToArray();
                    return Convert.ToBase64String(bytes);
                }
            }
        }
    }
}

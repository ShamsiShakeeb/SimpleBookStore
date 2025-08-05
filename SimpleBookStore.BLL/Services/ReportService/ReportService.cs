using ClosedXML.Excel;
using SimpleBookStore.DAL.DTO;
using SimpleBookStore.DAL.Repositories.ReportRepository;
using SimpleBookStore.Model.Report;

namespace SimpleBookStore.BLL.Services.ReportService
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public async Task<(bool success, List<CommentCountByUserReport> report, string message, string errorMessage)> GetCommentCountByUsers()
        {
            return await _reportRepository.GetCommentCountByUsers();
        }
        public async Task<(bool success, List<UserBookStatsReport> report, string message, string errorMessage)> UserBookStats()
        {
            return await _reportRepository.UserBookStats();
        }

        public async Task<(bool success,string base64,string message,string errorMessage)> DownloadCommentByUserReport()
        {
            var result = await _reportRepository.GetCommentCountByUsers();
            if (!result.success)
                return (result.success, null, result.message, result.errorMessage);
            var base64 = GenerateExcelBase64(result.report);
            return (true, base64 , "Base64 Generated" , null);
        }

        private string GenerateExcelBase64(List<CommentCountByUserReport> reportData)
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

using SimpleBookStore.DAL.DTO;
using SimpleBookStore.Model.Report;

namespace SimpleBookStore.BLL.Services.ReportService
{
    public interface IReportService
    {
        Task<(bool success, List<CommentCountByUserReport> report, string message, string errorMessage)> GetCommentCountByUsers();
        Task<(bool success, List<UserBookStatsReport> report, string message, string errorMessage)> UserBookStats();
        Task<(bool success, string base64, string message, string errorMessage)> DownloadCommentByUserReport();
    }
}

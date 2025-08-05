using SimpleBookStore.DAL.DTO;
using SimpleBookStore.Model.Report;

namespace SimpleBookStore.DAL.Repositories.ReportRepository
{
    public interface IReportRepository
    {
        Task<(bool success, List<CommentCountByUserReport> report, string message, string errorMessage)> GetCommentCountByUsers();
        Task<(bool success, List<UserBookStatsReport> report, string message, string errorMessage)> UserBookStats();
    }
}

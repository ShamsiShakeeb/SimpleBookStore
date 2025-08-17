using SimpleBookStore.DAL.DTO;
using SimpleBookStore.Model.Report;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.BLL.Services.ReportService
{
    public interface IReportService
    {
        Task<ResponseModel<List<CommentCountByUserReport>>> GetCommentCountByUsers();
        Task<ResponseModel<List<UserBookStatsReport>>> UserBookStats();
        Task<ResponseModel<string>> DownloadCommentByUserReport();
    }
}

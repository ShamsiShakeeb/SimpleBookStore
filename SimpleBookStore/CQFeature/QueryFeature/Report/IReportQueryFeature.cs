using SimpleBookStore.Model.Report;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.CQFeature.QueryFeature.Report
{
    public interface IReportQueryFeature
    {
        Task<ResponseModel<List<CommentCountByUserReport>>> CommentCountByUsersAsync();
        Task<ResponseModel<List<UserBookStatsReport>>> UserBookStatsAsync();
        Task<ResponseModel<string>> DownloadCommentCountByUsersReportAsync();
    }
}

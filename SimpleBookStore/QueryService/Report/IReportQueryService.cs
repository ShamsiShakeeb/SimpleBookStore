using SimpleBookStore.Model.Report;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.QueryService.Report
{
    public interface IReportQueryService
    {
        Task<ResponseModel<List<CommentCountByUserReport>>> CommentCountByUsersAsync();
        Task<ResponseModel<List<UserBookStatsReport>>> UserBookStatsAsync();
    }
}

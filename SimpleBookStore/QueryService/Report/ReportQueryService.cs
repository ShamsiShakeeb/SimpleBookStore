using KhatiMediaTr;
using SimpleBookStore.CQ.Query.ReportQuery;
using SimpleBookStore.Model.Report;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.QueryService.Report
{
    public class ReportQueryService : IReportQueryService
    {
        private readonly IMediaTr<GetCommentCountByUserQuery, Task<ResponseModel<List<CommentCountByUserReport>>>> _getCommentCountByUser;
        private readonly IMediaTr<GetUserBookStatsQuery, Task<ResponseModel<List<UserBookStatsReport>>>> _getUserBookStat;
        public ReportQueryService(IMediaTr<GetCommentCountByUserQuery, Task<ResponseModel<List<CommentCountByUserReport>>>> getCommentCountByUser,
            IMediaTr<GetUserBookStatsQuery, Task<ResponseModel<List<UserBookStatsReport>>>> getUserBookStat)
        {
            _getCommentCountByUser = getCommentCountByUser;
            _getUserBookStat = getUserBookStat;
        }
        public async Task<ResponseModel<List<CommentCountByUserReport>>> CommentCountByUsersAsync()
        {
            return await _getCommentCountByUser.Send();
        }
        public async Task<ResponseModel<List<UserBookStatsReport>>> UserBookStatsAsync()
        {
            return await _getUserBookStat.Send();
        }
    }
}

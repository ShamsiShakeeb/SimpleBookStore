using KhatiMediaTr;
using SimpleBookStore.DAL.ADO.Context;
using SimpleBookStore.Model.Report;

namespace SimpleBookStore.CQ.Query.ReportQuery
{
    public class GetCommentCountByUserQuery : IEventHandler
    {
        private readonly IStoreAdoContext _storeAdoContext;
        public GetCommentCountByUserQuery(IStoreAdoContext storeAdoContext)
        {
            _storeAdoContext = storeAdoContext;
        }
        public async Task<(bool success, List<CommentCountByUserReport> report, string message, string errorMessage)> Handler()
        {

            var query = @"WITH cte AS (
                             SELECT [UID],
                                    COUNT(Comment) AS CommentCount
                             FROM Review
                             GROUP BY [UID]
                         )
                         SELECT c.UID,
                                au.UserName,
                                au.Email,
                                au.Gender,
                                c.CommentCount
                         FROM cte c
                         INNER JOIN AspNetUsers au
                             ON c.UID = au.Id
                         INNER JOIN AspNetUserRoles aur
                             ON au.Id = aur.UserId
                         INNER JOIN AspNetRoles ar
                             ON aur.RoleId = ar.Id
                         WHERE ar.Name NOT IN (@RoleName)";

            var result = await _storeAdoContext.SqlReadAsync<List<CommentCountByUserReport>>(query,

                new Dictionary<string, object>
                {
                    { "@RoleName", Utility.Constant.Role.SuperAdmin }
                });

            return (result.Success, result.Data, result.Message, result.Exception);
        }
    }
}

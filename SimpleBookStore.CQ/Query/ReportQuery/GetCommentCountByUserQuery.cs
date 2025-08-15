using KhatiMediaTr;
using SimpleBookStore.DAL.ADO.Context;
using SimpleBookStore.Model.Report;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.CQ.Query.ReportQuery
{
    public class GetCommentCountByUserQuery : IEventHandler
    {
        private readonly IStoreAdoContext _storeAdoContext;
        public GetCommentCountByUserQuery(IStoreAdoContext storeAdoContext)
        {
            _storeAdoContext = storeAdoContext;
        }
        public async Task<ResponseModel<List<CommentCountByUserReport>>> Handler()
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

            return new ResponseModel<List<CommentCountByUserReport>>()
            {
                Success = result.Success,
                Data = result.Data,
                Message = result.Message,
                ErrorMessage = result.Exception?.ToString()
            };
        }
    }
}

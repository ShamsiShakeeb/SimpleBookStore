using KhatiMediaTr;
using SimpleBookStore.DAL.ADO.Context;
using SimpleBookStore.Model.Report;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.CQ.Query.ReportQuery
{
    public class GetUserBookStatsQuery : IEventHandler
    {
        private readonly IStoreAdoContext _storeAdoContext;
        public GetUserBookStatsQuery(IStoreAdoContext storeAdoContext)
        {
            _storeAdoContext = storeAdoContext;
        }

        public async Task<ResponseModel<List<UserBookStatsReport>>> Handler()
        {

            var query = @"SELECT 
                          ub.UserId,
                          (SELECT UserName FROM AspNetUsers au WHERE au.Id = ub.UserId) AS UserName,
                          (SELECT Email FROM AspNetUsers au WHERE au.Id = ub.UserId) AS Email,
                          (SELECT Age FROM AspNetUsers au WHERE au.Id = ub.UserId) AS Age,
                          (SELECT Gender FROM AspNetUsers au WHERE au.Id = ub.UserId) AS Gender,
                          COUNT(BookId) AS BookBuyCount
                          FROM UserBook ub
                          inner join AspNetUserRoles aur
                          on ub.UserId = aur.UserId
                          inner join AspNetRoles ar
                          on aur.RoleId = ar.Id
                          where ar.Name not in (@RoleName)
                          GROUP BY ub.UserId";

            var result = await _storeAdoContext.SqlReadAsync<List<UserBookStatsReport>>(query,

                new Dictionary<string, object>
                {
                    { "@RoleName", Utility.Constant.Role.SuperAdmin }
                });

            return new ResponseModel<List<UserBookStatsReport>>()
            {
                Success = result.Success,
                Data = result.Data,
                Message = result.Message,
                ErrorMessage = result.Exception?.ToString()
            };
        }
    }
}

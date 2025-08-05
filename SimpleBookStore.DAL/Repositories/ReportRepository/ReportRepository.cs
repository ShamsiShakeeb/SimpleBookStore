using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SimpleBookStore.DAL.DbContextSet;
using SimpleBookStore.DAL.DTO;
using SimpleBookStore.Model.Report;

namespace SimpleBookStore.DAL.Repositories.ReportRepository
{
    public class ReportRepository : IReportRepository
    {
        private readonly IConfiguration _configuration;
        private readonly StoreContext _storeContext;
        public ReportRepository(IConfiguration configuration,
            StoreContext storeContext)
        {
            _configuration = configuration;
            _storeContext = storeContext;
        }
        public async Task<(bool success, List<CommentCountByUserReport> report, string message,string errorMessage)> GetCommentCountByUsers()
        {
            var commentCounts = new List<CommentCountByUserReport>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("StoreConnection")))
            {
                string sqlQuery = string.Format(@"
                                    with cte as (select [UID],
                                    Count(Comment) as CommentCount from Review
                                    group by [UID])
                                    
                                    select c.UID,au.UserName,au.Email,au.Gender,c.CommentCount from cte c
                                    inner join AspNetUsers au
                                    on c.UID = au.Id
                                    inner join AspNetUserRoles aur
                                    on au.Id = aur.UserId
                                    inner join AspNetRoles ar
                                    on aur.RoleId = ar.Id
                                    where ar.Name not in ('{0}')
                                  ",Utility.Constant.Role.SuperAdmin);

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    try
                    {
                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                var model = new CommentCountByUserReport
                                {
                                    UID = reader.GetString(0), 
                                    UserName = reader.GetString(1),
                                    Email = reader.GetString(2),
                                    Gender = reader.IsDBNull(3) ? null : reader.GetString(3),
                                    CommentCount = reader.GetInt32(4)
                                };
                                commentCounts.Add(model);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return (false, null, ex.Message, ex.ToString());
                    }
                }
            }
            return (true, commentCounts,"Data Fetched Successfully",null);
        }

        public async Task<(bool success, List<UserBookStatsReport> report, string message, string errorMessage)> UserBookStats()
        {
            try
            {
                var result = await _storeContext.Set<UserBookStatsReport>()
                            .FromSqlRaw(string.Format(@"
                                            SELECT 
                                            ub.UserId,
                                            (SELECT UserName FROM AspNetUsers au WHERE au.Id = ub.UserId) AS UserName,
                                            (SELECT Email FROM AspNetUsers au WHERE au.Id = ub.UserId) AS Email,
                                            (SELECT Age FROM AspNetUsers au WHERE au.Id = ub.UserId) AS Age,
                                            (SELECT Gender FROM AspNetUsers au WHERE au.Id = ub.UserId) AS Gender,
                                            COUNT(BookId) AS BookBuyCount
                                            FROM User_Book ub
                                            inner join AspNetUserRoles aur
                                            on ub.UserId = aur.UserId
                                            inner join AspNetRoles ar
                                            on aur.RoleId = ar.Id
                                            where ar.Name not in ('{0}')
                                            GROUP BY ub.UserId
                                        ",Utility.Constant.Role.SuperAdmin))
                            .ToListAsync();
                return (true, result, "Data Fetched Successfully", null);
            }
            catch(Exception ex)
            {
                return (false, null, ex.Message, ex.ToString());
            }
        }
    }
}

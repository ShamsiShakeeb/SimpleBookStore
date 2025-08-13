using KhatiExtendedEF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleBookStore.DAL.LogEntity;

namespace SimpleBookStore.DAL.DbContextSet
{
    public class LogContext : DatabaseContext<ILogEntity>
    {
        private readonly IConfiguration _configuration;
        public LogContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        public override string connectionString() => _configuration.GetConnectionString("LogConnection");
    }
}

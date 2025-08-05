using Microsoft.EntityFrameworkCore;
using SimpleBookStore.DAL.LogEntity;

namespace SimpleBookStore.DAL.DbContextSet
{
    public class LogContext : DbContext
    {
        public LogContext(DbContextOptions<LogContext> options) : base(options)
        {
        }
        public DbSet<Logs> Logs { get; set; }
    }
}

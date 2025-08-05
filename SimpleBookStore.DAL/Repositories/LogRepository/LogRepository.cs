using SimpleBookStore.DAL.DbContextSet;
using SimpleBookStore.DAL.LogEntity;

namespace SimpleBookStore.DAL.Repositories.LogRepository
{
    public class LogRepository : ILogRepository
    {
        private readonly LogContext _context;
        public LogRepository(LogContext context)
        {
            _context = context;
        }
        public async Task InsertLog(Logs log)
        {
            await _context.Logs.AddAsync(log);
            await _context.SaveChangesAsync();
        }
    }
}

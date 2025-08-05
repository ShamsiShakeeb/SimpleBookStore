using SimpleBookStore.DAL.LogEntity;

namespace SimpleBookStore.DAL.Repositories.LogRepository
{
    public interface ILogRepository
    {
        Task InsertLog(Logs log);
    }
}

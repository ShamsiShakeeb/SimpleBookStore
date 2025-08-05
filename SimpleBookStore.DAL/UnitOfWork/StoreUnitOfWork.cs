using SimpleBookStore.DAL.DbContextSet;

namespace SimpleBookStore.DAL.UnitOfWork
{
    public class StoreUnitOfWork : IStoreUnitOfWork
    {
        private readonly StoreContext _context;
        public StoreUnitOfWork(StoreContext context)
        {
            _context = context;
        }
        public async Task<T> CommitAsync<T>(Func<Task<T>> action)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var result = await action();
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}

namespace SimpleBookStore.DAL.UnitOfWork
{
    public interface IStoreUnitOfWork
    {
        Task<T> CommitAsync<T>(Func<Task<T>> action);
    }
}

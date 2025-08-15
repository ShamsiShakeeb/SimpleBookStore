using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleBookStore.DAL.StoreEntity;
using System.Linq.Expressions;

namespace SimpleBookStore.DAL.Repositories.UserBookRepository
{
    public interface IUserBookRepository
    {
        Task<(bool success, EntityEntry entity, string message, string errorMessage)> InsertAsync(UserBook model);
        Task<(bool success, string message, string errorMessage)> InsertRangeAsync(List<UserBook> model);
        (bool success, EntityEntry entity, string message, string errorMessage) Update(UserBook model);
        (bool success, string message, string errorMessage) UpdateRange(List<UserBook> model);
        (bool success, EntityEntry entity, string message, string errorMessage) Delete(UserBook model);
        (bool success, string message, string errorMessage) DeleteRange(List<UserBook> model);
        Task<UserBook> GetEntityAsync(Expression<Func<UserBook, bool>> expression);
        Task<List<UserBook>> GetListAsync(Expression<Func<UserBook, bool>> expression = null);
        IQueryable<UserBook> Get();
    }
}

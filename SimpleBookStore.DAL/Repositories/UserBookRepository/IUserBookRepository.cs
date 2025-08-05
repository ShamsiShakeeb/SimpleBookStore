using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleBookStore.DAL.StoreEntity;
using System.Linq.Expressions;

namespace SimpleBookStore.DAL.Repositories.UserBookRepository
{
    public interface IUserBookRepository
    {
        Task<(bool success, EntityEntry entity, string message, string errorMessage)> InsertAsync(User_Book model);
        Task<(bool success, string message, string errorMessage)> InsertRangeAsync(List<User_Book> model);
        (bool success, EntityEntry entity, string message, string errorMessage) Update(User_Book model);
        (bool success, string message, string errorMessage) UpdateRange(List<User_Book> model);
        (bool success, EntityEntry entity, string message, string errorMessage) Delete(User_Book model);
        (bool success, string message, string errorMessage) DeleteRange(List<User_Book> model);
        Task<User_Book> GetEntityAsync(Expression<Func<User_Book, bool>> expression);
        Task<List<User_Book>> GetListAsync(Expression<Func<User_Book, bool>> expression = null);
        IQueryable<User_Book> Get();
    }
}

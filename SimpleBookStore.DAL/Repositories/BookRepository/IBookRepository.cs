using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleBookStore.DAL.StoreEntity;
using System.Linq.Expressions;

namespace SimpleBookStore.DAL.Repositories.BookRepository
{
    public interface IBookRepository
    {
        Task<(bool success, EntityEntry entity, string message, string errorMessage)> InsertAsync(Book model);
        Task<(bool success, string message, string errorMessage)> InsertRangeAsync(List<Book> model);
        (bool success, EntityEntry entity, string message, string errorMessage) Update(Book model);
        (bool success, string message, string errorMessage) UpdateRange(List<Book> model);
        (bool success, EntityEntry entity, string message, string errorMessage) Delete(Book model);
        (bool success, string message, string errorMessage) DeleteRange(List<Book> model);
        Task<Book> GetEntityAsync(Expression<Func<Book, bool>> expression);
        Task<List<Book>> GetListAsync(Expression<Func<Book, bool>> expression = null);
        IQueryable<Book> Get();
    }
}

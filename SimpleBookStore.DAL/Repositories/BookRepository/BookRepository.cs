using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleBookStore.DAL.DbContextSet;
using SimpleBookStore.DAL.StoreEntity;
using System.Linq.Expressions;

namespace SimpleBookStore.DAL.Repositories.BookRepository
{
    public class BookRepository : IBookRepository
    {
        private readonly StoreContext _context;
        public BookRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<(bool success, EntityEntry entity, string message, string errorMessage)> InsertAsync(Book model)
        {
            try
            {
                var entity = await _context.Book.AddAsync(model);
                return (true, entity, "Data Inserted Successfully", null);
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message, ex.ToString());
            }
        }
        public async Task<(bool success,string message,string errorMessage)> InsertRangeAsync(List<Book> model)
        {
            try
            {
                await _context.Book.AddRangeAsync(model);
                return (true, "Data Inserted Successfully", null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex.ToString());
            }
        }
        public (bool success, EntityEntry entity, string message, string errorMessage) Update(Book model)
        {
            try
            {
                var entity = _context.Book.Update(model);
                return (true, entity, "Data Updated Successfully", null);
            }
            catch(Exception ex)
            {
                return (false, null, ex.Message, ex.ToString());
            }
        }
        public (bool success, string message, string errorMessage) UpdateRange(List<Book> model)
        {
            try
            {
                _context.Book.UpdateRange(model);
                return (true, "Data Updated Successfully", null);
            }
            catch(Exception ex)
            {
                return (false, ex.Message, ex.ToString());
            }
        }
        public (bool success, EntityEntry entity, string message, string errorMessage) Delete(Book model)
        {
            try
            {
                var entity = _context.Book.Remove(model);
                return (true, entity, "Data Removed Successfully", null);
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message, ex.ToString());
            }
        }
        public (bool success, string message, string errorMessage) DeleteRange(List<Book> model)
        {
            try
            {
                _context.Book.RemoveRange(model);
                return (true, "Data Removed Successfully", null);
            }
            catch(Exception ex)
            {
                return (false, ex.Message, ex.ToString());
            }
        }
        public async Task<Book> GetEntityAsync(Expression<Func<Book, bool>> expression)
        {
            var model = await _context.Book.Where(expression).AsNoTracking().FirstOrDefaultAsync();
            return model;
        }
        public async Task<List<Book>> GetListAsync(Expression<Func<Book, bool>> expression = null)
        {
            if (expression != null)
                return await _context.Book.Where(expression).AsNoTracking().ToListAsync();
            else
                return await _context.Book.AsNoTracking().ToListAsync();
        }
        public IQueryable<Book> Get()
        {
            var model = _context.Book.AsNoTracking().AsQueryable();
            return model;
        }
    }
}

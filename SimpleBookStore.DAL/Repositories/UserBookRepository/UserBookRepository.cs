
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleBookStore.DAL.DbContextSet;
using SimpleBookStore.DAL.StoreEntity;
using System.Linq.Expressions;

namespace SimpleBookStore.DAL.Repositories.UserBookRepository
{
    public class UserBookRepository : IUserBookRepository
    {
        private readonly StoreContext _context;
        public UserBookRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<(bool success, EntityEntry entity, string message, string errorMessage)> InsertAsync(User_Book model)
        {
            try
            {
                var entity = await _context.User_Book.AddAsync(model);
                return (true, entity, "Data Inserted Successfully", null);
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message, ex.ToString());
            }
        }
        public async Task<(bool success, string message, string errorMessage)> InsertRangeAsync(List<User_Book> model)
        {
            try
            {
                await _context.User_Book.AddRangeAsync(model);
                return (true, "Data Inserted Successfully", null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex.ToString());
            }
        }
        public (bool success, EntityEntry entity, string message, string errorMessage) Update(User_Book model)
        {
            try
            {
                var entity = _context.User_Book.Update(model);
                return (true, entity, "Data Updated Successfully", null);
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message, ex.ToString());
            }
        }
        public (bool success, string message, string errorMessage) UpdateRange(List<User_Book> model)
        {
            try
            {
                _context.User_Book.UpdateRange(model);
                return (true, "Data Updated Successfully", null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex.ToString());
            }
        }
        public (bool success, EntityEntry entity, string message, string errorMessage) Delete(User_Book model)
        {
            try
            {
                var entity = _context.User_Book.Remove(model);
                return (true, entity, "Data Removed Successfully", null);
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message, ex.ToString());
            }
        }
        public (bool success, string message, string errorMessage) DeleteRange(List<User_Book> model)
        {
            try
            {
                _context.User_Book.RemoveRange(model);
                return (true, "Data Removed Successfully", null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex.ToString());
            }
        }
        public async Task<User_Book> GetEntityAsync(Expression<Func<User_Book, bool>> expression)
        {
            var model = await _context.User_Book.Where(expression).AsNoTracking().FirstOrDefaultAsync();
            return model;
        }
        public async Task<List<User_Book>> GetListAsync(Expression<Func<User_Book, bool>> expression = null)
        {
            var list = new List<User_Book>();
            if (expression != null)
                list = await _context.User_Book.Where(expression).AsNoTracking().ToListAsync();
            else
                list = await _context.User_Book.AsNoTracking().ToListAsync();
            return list;
        }
        public IQueryable<User_Book> Get()
        {
            var model = _context.User_Book.AsNoTracking().AsQueryable();
            return model;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleBookStore.DAL.DbContextSet;
using SimpleBookStore.DAL.StoreEntity;
using System.Linq.Expressions;

namespace SimpleReviewStore.DAL.Repositories.ReviewRepository
{
    public class ReviewRepository : IReviewRepository
    { 
        private readonly StoreContext _context;
        public ReviewRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<(bool success, EntityEntry entity, string message, string errorMessage)> InsertAsync(Review model)
        {
            try
            {
                var entity = await _context.Review.AddAsync(model);
                return (true, entity, "Data Inserted Successfully", null);
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message, ex.ToString());
            }
        }
        public async Task<(bool success, string message, string errorMessage)> InsertRangeAsync(List<Review> model)
        {
            try
            {
                await _context.Review.AddRangeAsync(model);
                return (true, "Data Inserted Successfully", null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex.ToString());
            }
        }
        public (bool success, EntityEntry entity, string message, string errorMessage) Update(Review model)
        {
            try
            {
                var entity = _context.Review.Update(model);
                return (true, entity, "Data Updated Successfully", null);
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message, ex.ToString());
            }
        }
        public (bool success, string message, string errorMessage) UpdateRange(List<Review> model)
        {
            try
            {
                _context.Review.UpdateRange(model);
                return (true, "Data Updated Successfully", null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex.ToString());
            }
        }
        public (bool success, EntityEntry entity, string message, string errorMessage) Delete(Review model)
        {
            try
            {
                var entity = _context.Review.Remove(model);
                return (true, entity, "Data Removed Successfully", null);
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message, ex.ToString());
            }
        }
        public (bool success, string message, string errorMessage) DeleteRange(List<Review> model)
        {
            try
            {
                _context.Review.RemoveRange(model);
                return (true, "Data Removed Successfully", null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex.ToString());
            }
        }
        public async Task<Review> GetEntityAsync(Expression<Func<Review, bool>> expression)
        {
            var model = await _context.Review.Where(expression).AsNoTracking().FirstOrDefaultAsync();
            return model;
        }
        public async Task<List<Review>> GetListAsync(Expression<Func<Review, bool>> expression = null)
        {
            var list = new List<Review>();
            if (expression != null)
                list = await _context.Review.Where(expression).AsNoTracking().ToListAsync();
            else
                list = await _context.Review.AsNoTracking().ToListAsync();
            return list;
        }
        public IQueryable<Review> Get()
        {
            var model = _context.Review.AsNoTracking().AsQueryable();
            return model;
        }
    }
}

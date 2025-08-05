using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleBookStore.DAL.StoreEntity;
using System.Linq.Expressions;

namespace SimpleReviewStore.DAL.Repositories.ReviewRepository
{
    public interface IReviewRepository
    {
        Task<(bool success, EntityEntry entity, string message, string errorMessage)> InsertAsync(Review model);
        Task<(bool success, string message, string errorMessage)> InsertRangeAsync(List<Review> model);
        (bool success, EntityEntry entity, string message, string errorMessage) Update(Review model);
        (bool success, string message, string errorMessage) UpdateRange(List<Review> model);
        (bool success, EntityEntry entity, string message, string errorMessage) Delete(Review model);
        (bool success, string message, string errorMessage) DeleteRange(List<Review> model);
        Task<Review> GetEntityAsync(Expression<Func<Review, bool>> expression);
        Task<List<Review>> GetListAsync(Expression<Func<Review, bool>> expression = null);
        IQueryable<Review> Get();
    }
}

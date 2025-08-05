using SimpleBookStore.Model.Request;

namespace SimpleBookStore.BLL.Services.ReviewService
{
    public interface IReviewService
    {
        Task<(bool success, string message, string errorMessage)> GiveReview(ReviewRequestModel model);
    }
}

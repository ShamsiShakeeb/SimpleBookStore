using SimpleBookStore.Model.Request;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.BLL.Services.ReviewService
{
    public interface IReviewService
    {
        Task<ResponseModel> GiveReview(ReviewRequestModel model);
    }
}

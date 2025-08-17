using SimpleBookStore.Model.Request;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.CQFeature.CommandFeature.BookStore
{
    public interface IBookStoreCommandFeature
    {
        Task<ResponseModel> BuyBookAsync(BuyBookRequestModel model);
        Task<ResponseModel> SubmitReviewAsync(ReviewRequestModel model);
    }
}

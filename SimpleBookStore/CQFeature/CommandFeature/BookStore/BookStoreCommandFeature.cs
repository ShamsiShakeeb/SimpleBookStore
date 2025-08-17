using KhatiMediaTr;
using SimpleBookStore.CQ.Command.BookCommand;
using SimpleBookStore.CQ.Command.ReviewCommand;
using SimpleBookStore.Model.Request;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.CQFeature.CommandFeature.BookStore
{
    public class BookStoreCommandFeature : IBookStoreCommandFeature
    {
        private readonly IMediaTr<BuyBookCommand, Task<(bool success, string message, string errorMessage)>> _buyBook;
        private readonly IMediaTr<GiveReviewCommand, Task<(bool success, string message, string errorMessage)>> _giveReview;
        public BookStoreCommandFeature(IMediaTr<BuyBookCommand, Task<(bool success, string message, string errorMessage)>> buyBook,
            IMediaTr<GiveReviewCommand, Task<(bool success, string message, string errorMessage)>> giveReview)
        {
            _buyBook = buyBook;
            _giveReview = giveReview;
        }
        public async Task<ResponseModel> BuyBookAsync(BuyBookRequestModel model)
        {
            var result = await _buyBook.Send(model);
            return new ResponseModel()
            {
                Success = result.success,
                ErrorMessage = result.errorMessage,
                Message = result.message
            };
        }
        public async Task<ResponseModel> SubmitReviewAsync(ReviewRequestModel model)
        {
            var result = await _giveReview.Send(model);
            return new ResponseModel()
            {
                Success = result.success,
                Message = result.message,
                ErrorMessage = result.errorMessage
            };
        }
    }
}

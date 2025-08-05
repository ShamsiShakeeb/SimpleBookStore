using Microsoft.AspNetCore.Identity;
using SimpleBookStore.BLL.Services.LogService;
using SimpleBookStore.DAL.StoreEntity;
using SimpleBookStore.DAL.UnitOfWork;
using SimpleBookStore.Model.Request;
using SimpleReviewStore.DAL.Repositories.ReviewRepository;
using static System.Reflection.Metadata.BlobBuilder;

namespace SimpleBookStore.BLL.Services.ReviewService
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly UserManager<User> _userManager;
        private readonly ILogService _logService;
        private readonly IStoreUnitOfWork _storeUnitOfWork;
        public ReviewService(IReviewRepository reviewRepository,
            UserManager<User> userManager,
            ILogService logService,
            IStoreUnitOfWork storeUnitOfWork)
        {
            _reviewRepository = reviewRepository;
            _userManager = userManager;
            _logService = logService;
            _storeUnitOfWork = storeUnitOfWork;
        }
        public async Task<(bool success, string message, string errorMessage)> GiveReview(ReviewRequestModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UID);

            if (user == null)
            {
                await _logService.InsertLog(
                    new LogRequestModel()
                    {
                        Success = false,
                        Message = "User Not Found",
                        ErrorMessage = string.Format("User Not Found at GiveReview Method" +
                        "Operation Done By: {0}", model.UID)
                    });
                return (false, "User not found", "Invalid UID");
            }

            var result = await _storeUnitOfWork.CommitAsync<(bool success, string message, string errorMessage)>(async () =>
            {
                var insertModel = new Review()
                {
                    UID = model.UID,
                    BID = model.BID,
                    Comment = model.Comment,
                    Rating = model.Rating,
                    Createdby = user.UserName,
                    CreatedDate = model.CreatedDate,
                };

                var result = await _reviewRepository.InsertAsync(insertModel);
                return (result.success,result.message,result.errorMessage);
            });
            

            if (!result.success)
            {
                await _logService.InsertLog(
                    new LogRequestModel()
                    {
                        Success = false,
                        Message = result.message,
                        ErrorMessage = string.Format("Internal Error at GiveReview Method Operation Done By {0} Exception: {1}"
                        ,model.UID,result.errorMessage)
                    });
            }

            return (result.success, result.message, null);
        }
    }
}

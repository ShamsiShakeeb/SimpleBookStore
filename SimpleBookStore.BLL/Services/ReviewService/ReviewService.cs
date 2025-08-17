using Microsoft.AspNetCore.Identity;
using SimpleBookStore.BLL.Services.LogService;
using SimpleBookStore.DAL.StoreEntity;
using SimpleBookStore.DAL.UnitOfWork;
using SimpleBookStore.Model.Request;
using SimpleBookStore.Model.Response;
using SimpleReviewStore.DAL.Repositories.ReviewRepository;

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
        public async Task<ResponseModel> GiveReview(ReviewRequestModel model)
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
                return new ResponseModel()
                {
                    Success = false,
                    Message = "User not found",
                    ErrorMessage = "Invalid UID"
                };
            }

            var result = await _storeUnitOfWork.CommitAsync<ResponseModel>(async () =>
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
                return new ResponseModel()
                {
                    Success = result.success,
                    Message = result.message,
                    ErrorMessage = result.errorMessage
                };
            });
            

            if (!result.Success)
            {
                await _logService.InsertLog(
                    new LogRequestModel()
                    {
                        Success = false,
                        Message = result.Message,
                        ErrorMessage = string.Format("Internal Error at GiveReview Method Operation Done By {0} Exception: {1}"
                        ,model.UID,result.ErrorMessage)
                    });
            }

            return new ResponseModel()
            {
                Success = result.Success,
                Message = result.Message,
                ErrorMessage = result.ErrorMessage
            };
        }
    }
}

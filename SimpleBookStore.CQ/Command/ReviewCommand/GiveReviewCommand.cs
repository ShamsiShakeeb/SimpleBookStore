using KhatiExtendedEF.Repositories;
using KhatiExtendedEF.UnitOfWork;
using KhatiMediaTr;
using Microsoft.AspNetCore.Identity;
using SimpleBookStore.CQ.Command.LogCommand;
using SimpleBookStore.DAL.StoreEntity;
using SimpleBookStore.Model.Request;

namespace SimpleBookStore.CQ.Command.ReviewCommand
{
    public class GiveReviewCommand : IEventHandler
    {
        private readonly IRepository<Review> _reviewRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMediaTr<AddLogCommand, Task> _logCommand;
        private readonly IUnitOfWork<IStoreEntity> _storeUnitOfWork;
        public GiveReviewCommand(IRepository<Review> reviewRepository,
            UserManager<User> userManager,
            IMediaTr<AddLogCommand, Task> logCommand,
            IUnitOfWork<IStoreEntity> storeUnitOfWork)
        {
            _reviewRepository = reviewRepository;
            _userManager = userManager;
            _logCommand = logCommand;
            _storeUnitOfWork = storeUnitOfWork;
        }
        public async Task<(bool success, string message, string errorMessage)> Handler(ReviewRequestModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UID);

            if (user == null)
            {
                await _logCommand.Send(
                    new LogRequestModel()
                    {
                        Success = false,
                        Message = "User Not Found",
                        ErrorMessage = string.Format("User Not Found at GiveReview Method" +
                        "Operation Done By: {0}", model.UID)
                    });
                return (false, "User not found", "Invalid UID");
            }

            var result = await _storeUnitOfWork.Commit(async () =>
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
                await _reviewRepository.InsertAsync(insertModel);
            });


            if (!result.success)
            {
                await _logCommand.Send(
                    new LogRequestModel()
                    {
                        Success = false,
                        Message = result.message,
                        ErrorMessage = string.Format("Internal Error at GiveReview Method Operation Done By {0} Exception: {1}"
                        , model.UID, result.errorMessage)
                    });
            }

            return (result.success, result.message, null);
        }
    }
}

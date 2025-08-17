using KhatiMediaTr;
using SimpleBookStore.CQ.Command.UserCommand;
using SimpleBookStore.Model.Request;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.CQFeature.CommandFeature.Auth
{
    public class AuthCommandFeature : IAuthCommandFeature
    {
        private readonly IMediaTr<OnBoardUserCommand, Task<RegistrationResponseModel>> _onboardUser;
        private readonly IMediaTr<ValidateUserCommand, Task<(bool success, LoginResponseModel response, string message, string errorMessage)>> _validateUser;
        public AuthCommandFeature(IMediaTr<OnBoardUserCommand, Task<RegistrationResponseModel>> onboardUser,
            IMediaTr<ValidateUserCommand, Task<(bool success, LoginResponseModel response, string message, string errorMessage)>> validateUser)
        {
            _onboardUser = onboardUser;
            _validateUser = validateUser;
        }
        public async Task<RegistrationResponseModel> UserRegistrationAsync(RegistrationRequestModel model)
        {
            var result = await _onboardUser.Send(new object[] { model, Utility.Constant.Role.Person });
            return result;
        }
        public async Task<RegistrationResponseModel> SuperAdminRegistrationAsync(RegistrationRequestModel model)
        {
            var result = await _onboardUser.Send(new object[] { model, Utility.Constant.Role.SuperAdmin });
            return result;
        }
        public async Task<ResponseModel<LoginResponseModel>> TokenRequestAsync(LoginRequestModel model)
        {
            var result = await _validateUser.Send(model);
            return new ResponseModel<LoginResponseModel>()
            {
                Success = result.success,
                ErrorMessage = result.errorMessage,
                Message = result.message,
                Data = result.response
            };
        }
    }
}

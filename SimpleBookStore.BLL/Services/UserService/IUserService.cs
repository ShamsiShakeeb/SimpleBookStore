using SimpleBookStore.Model.Request;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.BLL.Services.UserService
{
    public interface IUserService
    {
        Task<RegistrationResponseModel> OnBoardUser(RegistrationRequestModel model, string role);
        Task<ResponseModel<LoginResponseModel>> ValidateUser(LoginRequestModel model);
    }
}

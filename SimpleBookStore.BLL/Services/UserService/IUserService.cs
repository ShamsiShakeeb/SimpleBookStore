using SimpleBookStore.Model.Request;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.BLL.Services.UserService
{
    public interface IUserService
    {
        Task<RegistrationResponseModel> OnBoardUser(RegistrationRequestModel model, string role);
        Task<(bool success, LoginResponseModel response, string message)> ValidateUser(string userName, string password);
    }
}

using SimpleBookStore.Model.Request;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.CQFeature.CommandFeature.Auth
{
    public interface IAuthCommandFeature
    {
        Task<RegistrationResponseModel> UserRegistrationAsync(RegistrationRequestModel model);
        Task<RegistrationResponseModel> SuperAdminRegistrationAsync(RegistrationRequestModel model);
        Task<ResponseModel<LoginResponseModel>> TokenRequestAsync(LoginRequestModel model);
    }
}

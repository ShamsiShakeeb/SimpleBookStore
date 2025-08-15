using KhatiMediaTr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SimpleBookStore.CQ.Command.UserCommand;
using SimpleBookStore.Model.Request;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediaTr<OnBoardUserCommand,Task<RegistrationResponseModel>> _onboardUser;
        private readonly IMediaTr<ValidateUserCommand, 
            Task<(bool success, LoginResponseModel response, string message)>> _validateUser;
        public AccountController(IMediaTr<OnBoardUserCommand, Task<RegistrationResponseModel>> onboardUser,
            IMediaTr<ValidateUserCommand,
            Task<(bool success, LoginResponseModel response, string message)>> validateUser)
        {
            _onboardUser = onboardUser;
            _validateUser = validateUser;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegistration(RegistrationRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _onboardUser.Send(new object[] { model, Utility.Constant.Role.Person });
                if (!result.Success)
                    return BadRequest(new { success = result.Success, message = result.Message });
            }
            else
            {
                List<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors).ToList();
                return BadRequest(new { success = false, message = "Validation Error", errors = allErrors });
            }
            return Ok(new { success = true, message = "Registration Done!" });

        }

        [HttpPost]
        public async Task<IActionResult> SuperAdminRegistration(RegistrationRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _onboardUser.Send(new object[] { model, Utility.Constant.Role.SuperAdmin });
                if (!result.Success)
                    return BadRequest(new { success = result.Success, message = result.Message });
            }
            else
            {
                List<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors).ToList();
                return BadRequest(new { success = false, message = "Validation Error", errors = allErrors });
            }
            return Ok(new { success = true, message = "Registration Done!" });
        }

        [HttpPost]
        public async Task<IActionResult> TokenRequest(LoginRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return Unauthorized(new { success = false, message = "Token Generation Failed" });
            }

            var result = await _validateUser.Send(model);

            if (!result.success)
                return Unauthorized(new { success = result.success, message = result.message });

            return Ok(new { success = result.success, response = result.response, message = result.message });
        }

    }
}

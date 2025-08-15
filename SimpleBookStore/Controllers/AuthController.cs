using KhatiMediaTr;
using Microsoft.AspNetCore.Mvc;
using SimpleBookStore.CQ.Command.UserCommand;
using SimpleBookStore.Model.Request;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediaTr<ValidateUserCommand,Task<ResponseModel<LoginResponseModel>>> _validateUser;
        public AuthController(IMediaTr<ValidateUserCommand, Task<ResponseModel<LoginResponseModel>>> validateUser)
        {
            _validateUser = validateUser;
        }

        [HttpPost]
        public async Task<IActionResult> TokenRequest(LoginRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return Unauthorized(new { success = false, message = "Token Generation Failed" });
            }

            var result = await _validateUser.Send(model);

            if (!result.Success)
                return Unauthorized(result);

            return Ok(result);
        }

    }
}

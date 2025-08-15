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
    public class RegistrationController : ControllerBase
    {
        private readonly IMediaTr<OnBoardUserCommand, Task<RegistrationResponseModel>> _onboardUser;
        public RegistrationController(IMediaTr<OnBoardUserCommand, Task<RegistrationResponseModel>> onboardUser)
        {
            _onboardUser = onboardUser;
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
    }
}

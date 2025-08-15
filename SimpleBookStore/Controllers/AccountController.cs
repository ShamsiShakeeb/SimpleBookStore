using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SimpleBookStore.BLL.Services.UserService;
using SimpleBookStore.Model.Request;

namespace SimpleBookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegistration(RegistrationRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.OnBoardUser(model,Utility.Constant.Role.Person);
                if (!result.Success)
                    return BadRequest(new { success = result.Success, message = result.Message });
            }
            else
            {
                List<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors).ToList();
                return BadRequest(new { success = false, message = "Validation Error", errors = allErrors });
            }
            return Ok(new { success = true, message="Registration Done!" });

        }

        [HttpPost]
        public async Task<IActionResult> SuperAdminRegistration(RegistrationRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.OnBoardUser(model, Utility.Constant.Role.SuperAdmin);
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
                return Unauthorized(new { success = false, message = "Token Generation Failed"});
            }

            var result = await _userService.ValidateUser(model.UserName, model.Password);

            if (!result.success)
                return Unauthorized(new { success = result.success, message = result.message });

            return Ok(new { success = result.success, response = result.response, message = result.message });
        }
        
    }
}

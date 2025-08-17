using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SimpleBookStore.CQFeature.CommandFeature.Auth;
using SimpleBookStore.Model.Request;

namespace SimpleBookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthCommandFeature _authCommandFeature;
        public AccountController(IAuthCommandFeature authCommandFeature)
        {
            _authCommandFeature = authCommandFeature;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegistration(RegistrationRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authCommandFeature.UserRegistrationAsync(model);
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
                var result = await _authCommandFeature.SuperAdminRegistrationAsync(model);
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

            var result = await _authCommandFeature.TokenRequestAsync(model);

            if (!result.Success)
                return Unauthorized(result);

            return Ok(result);
        }

    }
}

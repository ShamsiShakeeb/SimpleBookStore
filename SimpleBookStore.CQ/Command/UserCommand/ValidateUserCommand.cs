using KhatiMediaTr;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SimpleBookStore.DAL.StoreEntity;
using SimpleBookStore.Model.Request;
using SimpleBookStore.Model.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SimpleBookStore.CQ.Command.UserCommand
{
    public class ValidateUserCommand : IEventHandler
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signManager;
        public ValidateUserCommand(UserManager<User> userManager,
            SignInManager<User> signManager)
        {
            _userManager = userManager;
            _signManager = signManager;
        }
        public async Task<(bool success, LoginResponseModel response, string message, string errorMessage)> Handler(LoginRequestModel model)
        {
            var response = new LoginResponseModel();

            var login = await _signManager.PasswordSignInAsync(model.UserName, model.Password, true, false);

            if (!login.Succeeded)
                return (false, null, "Login Failed", "Login Failed");

            var user = await _userManager.FindByNameAsync(model.UserName);
            response.UserId = user.Id;
            response.Token = await GenerateTokenAsync(user);
            return (true, response, "Token Generated", null);
        }
        private async Task<string> GenerateTokenAsync(User user)
        {
            if (user is null || user.UserName is null)
            {
                return null;
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Utility.Constant.JwtDescription.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var roles = await _userManager.GetRolesAsync(user);
            var rolesCommaSeparated = string.Join(',', roles);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim("UserId",user.Id),
                new Claim(ClaimTypes.Role,rolesCommaSeparated),
            };
            var token = new JwtSecurityToken(Utility.Constant.JwtDescription.Issuer,
                Utility.Constant.JwtDescription.Audience,
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

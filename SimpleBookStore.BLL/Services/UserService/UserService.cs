using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SimpleBookStore.DAL.StoreEntity;
using SimpleBookStore.Model.Request;
using SimpleBookStore.Model.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SimpleBookStore.BLL.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserService(UserManager<User> userManager,
            SignInManager<User> signManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signManager = signManager;
            _roleManager = roleManager;
        }
        public async Task<RegistrationResponseModel> OnBoardUser(RegistrationRequestModel model, string role)
        {
            var response = new RegistrationResponseModel();

            try
            {
                var user = new User()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Age = model.Age,
                    Gender = model.Gender,
                    Address = model.Address,
                };
                var isExist = await _roleManager.RoleExistsAsync(role);

                if (!isExist)
                {
                    var roleCreation = await _roleManager.CreateAsync(new IdentityRole(role));

                    if (!roleCreation.Succeeded)
                    {
                        response.Success = roleCreation.Succeeded;
                        response.Message = string.Join("\n", roleCreation.Errors.Select(x => x.Description));
                        return response;
                    }
                }

                var userCreation = await _userManager.CreateAsync(user, model.Password);

                if (!userCreation.Succeeded)
                {
                    response.Success = userCreation.Succeeded;
                    response.Message = string.Join("\n", userCreation.Errors.Select(x=> x.Description));
                    return response;
                }

                var addRole = await _userManager.AddToRoleAsync(user, role);

                if (!addRole.Succeeded)
                {
                    response.Success = addRole.Succeeded;
                    response.Message = string.Join("\n", addRole.Errors.Select(x=> x.Description));
                    return response;
                }

                response.Success = true;
                response.Message = "User OnBoard Done";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<(bool success, LoginResponseModel response, string message)> ValidateUser(string userName, string password)
        {
            var response = new LoginResponseModel();

            var login = await _signManager.PasswordSignInAsync(userName,password, true, false);

            if(!login.Succeeded)
                return (false, null, "Login Failed");

            var user = await _userManager.FindByNameAsync(userName);
            response.UserId = user.Id;
            response.Token = await GenerateTokenAsync(user);
            
            return (true,response,"Token Generated");
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

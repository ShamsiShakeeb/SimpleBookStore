using KhatiMediaTr;
using Microsoft.AspNetCore.Identity;
using SimpleBookStore.DAL.StoreEntity;
using SimpleBookStore.Model.Request;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.CQ.Command.UserCommand
{
    public class OnBoardUserCommand : IEventHandler
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public OnBoardUserCommand(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<RegistrationResponseModel> Handler(RegistrationRequestModel model, string role)
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
                    response.Message = string.Join("\n", userCreation.Errors.Select(x => x.Description));
                    return response;
                }

                var addRole = await _userManager.AddToRoleAsync(user, role);

                if (!addRole.Succeeded)
                {
                    response.Success = addRole.Succeeded;
                    response.Message = string.Join("\n", addRole.Errors.Select(x => x.Description));
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
    }
}

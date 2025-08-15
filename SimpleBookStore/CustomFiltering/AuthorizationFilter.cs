using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using static SimpleBookStore.Utility.Constant;

namespace SimpleBookStore.CustomFiltering
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method | System.AttributeTargets.Class, AllowMultiple = true)]
    public class AuthorizationFilterAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string roles;
        public AuthorizationFilterAttribute(string roles)
        {
            this.roles = roles;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var token = context.HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtDescription.Key);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = JwtDescription.Issuer,
                    ValidAudience = JwtDescription.Audience
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                var listOfRoles = jwtToken.Claims
                    .Where(x => x.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")
                    .Select(x => x.Value)
                    .FirstOrDefault();

                if (listOfRoles == null)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                var rolesName = listOfRoles.Split(',').ToList();

                var passedRoles = this.roles.Split(',').ToList();

                var roleExist = (from a in rolesName
                                 join b in passedRoles
                                 on a equals b
                                 select new { b }).ToList();

                if (roleExist.Count == 0)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                context.Result = new UnauthorizedResult();
                return;
            }
            await next();
        }
    }
}

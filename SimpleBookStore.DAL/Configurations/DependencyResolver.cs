using KhatiExtendedEF.Resolver;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SimpleBookStore.DAL.DbContextSet;

namespace SimpleBookStore.DAL.Configurations
{
    public static class DependencyResolver
    {
        public static IServiceCollection DAL(this IServiceCollection services)
        {
            services.ExtendedEF<StoreContext>();

            services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<StoreContext>()
            .AddDefaultTokenProviders();

            services.ExtendedEF<LogContext>();

            return services;
        }
    }
}

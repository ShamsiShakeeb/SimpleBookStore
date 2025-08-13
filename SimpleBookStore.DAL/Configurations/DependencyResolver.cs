using KhatiExtendedADO;
using KhatiExtendedEF.Resolver;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SimpleBookStore.DAL.ADO.Context;
using SimpleBookStore.DAL.DbContextSet;
using SimpleBookStore.DAL.StoreEntity;

namespace SimpleBookStore.DAL.Configurations
{
    public static class DependencyResolver
    {
        public static IServiceCollection DAL(this IServiceCollection services)
        {
            services.ExtendedEF<StoreContext>();

            services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<StoreContext>()
            .AddDefaultTokenProviders();

            services.ExtendedEF<LogContext>();

            services.AdoDependency();
            services.AddSingleton<IStoreAdoContext, StoreAdoContext>();

            return services;
        }
    }
}

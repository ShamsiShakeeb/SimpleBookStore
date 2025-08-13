using KhatiExcel.DependencyResolver;
using KhatiMediaTr;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleBookStore.CQ.Configuration
{
    public static class DependencyResolver
    {
        public static IServiceCollection CQ(this IServiceCollection services)
        {
            services.AddMediaTr();
            services.ExcelFeature();
            return services;
        }
    }
}

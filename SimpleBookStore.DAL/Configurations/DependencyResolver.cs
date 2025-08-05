using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleBookStore.DAL.DbContextSet;
using SimpleBookStore.DAL.Repositories.BookRepository;
using SimpleBookStore.DAL.Repositories.LogRepository;
using SimpleBookStore.DAL.Repositories.ReportRepository;
using SimpleBookStore.DAL.Repositories.UserBookRepository;
using SimpleBookStore.DAL.UnitOfWork;
using SimpleReviewStore.DAL.Repositories.ReviewRepository;

namespace SimpleBookStore.DAL.Configurations
{
    public static class DependencyResolver
    {
        public static IServiceCollection DAL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("StoreConnection")));

            services.AddDbContext<LogContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("LogConnection")));

            services.AddScoped<IBookRepository,BookRepository>();
            services.AddScoped<IReviewRepository,ReviewRepository>();
            services.AddScoped<IUserBookRepository,UserBookRepository>();
            services.AddScoped<IStoreUnitOfWork,StoreUnitOfWork>();
            services.AddScoped<IReportRepository,ReportRepository>();
            services.AddScoped<ILogRepository,LogRepository>();

            return services;
        }
    }
}

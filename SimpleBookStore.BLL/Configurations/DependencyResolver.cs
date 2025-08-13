//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using SimpleBookStore.BLL.Services.BookService;
//using SimpleBookStore.BLL.Services.LogService;
//using SimpleBookStore.BLL.Services.ReportService;
//using SimpleBookStore.BLL.Services.ReviewService;
//using SimpleBookStore.BLL.Services.UserService;

//namespace SimpleBookStore.BLL.Configurations
//{
//    public static class DependencyResolver
//    {
//        public static IServiceCollection BLL(this IServiceCollection services, IConfiguration configuration)
//        {
//            services.AddScoped<IUserService,UserService>();
//            services.AddScoped<IReportService,ReportService>();
//            services.AddScoped<IBookService,BookService>();
//            services.AddScoped<IReviewService,ReviewService>();
//            services.AddScoped<ILogService,LogService>();
//            return services;
//        }
//    }
//}

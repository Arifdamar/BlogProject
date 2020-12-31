using ArifOmer.BlogApp.Business.Abstract;
using ArifOmer.BlogApp.Business.Concrete;
using ArifOmer.BlogApp.Business.CustomLogger;
using ArifOmer.BlogApp.DataAccess.Abstract;
using ArifOmer.BlogApp.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ArifOmer.BlogApp.Business.Containers.MicrosoftIoC
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IBlogDal, EfBlogRepository>();
            services.AddScoped<IBlogService, BlogManager>();

            services.AddScoped<ICategoryDal, EfCategoryRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddTransient<ICustomLogger, NLogLogger>();
        }
    }
}

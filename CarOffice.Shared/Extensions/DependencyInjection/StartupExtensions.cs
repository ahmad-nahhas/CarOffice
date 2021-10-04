using CarOffice.Shared.Repositories.Base;
using CarOffice.Shared.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarOffice.Shared.Extensions.DependencyInjection
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddRequiredServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CarOfficeDbContext>(options =>
            {
                options.UseLazyLoadingProxies().UseSqlServer(connectionString);
            });

            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));

            return services;
        }
    }
}
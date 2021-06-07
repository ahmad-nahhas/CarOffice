using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;

namespace CarOffice.Shared.Extensions.Identity
{
    public static class IdentityExtensions
    {
        public static async Task SeedAdministrationInfo(this IApplicationBuilder applicationBuilder,
                                                             IConfiguration configuration)
        {
            using var serviceScope = applicationBuilder.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>().CreateScope();

            var serviceProvider = serviceScope.ServiceProvider;

            var dbContext = serviceProvider.GetService<CarOfficeDbContext>();

            if (dbContext.Database.GetPendingMigrations().Any())
            {
                await dbContext.Database.MigrateAsync();

                using var userManager = serviceProvider
                    .GetRequiredService<UserManager<IdentityUser>>();

                var email = configuration["AdminInfo:UserName"];
                var phone = configuration["AdminInfo:PhoneNumber"];
                var password = configuration["AdminInfo:Password"];

                var admin = new IdentityUser
                {
                    UserName = email,
                    Email = email,
                    PhoneNumber = phone
                };

                await userManager.CreateAsync(admin, password);
            }
        }
    }
}
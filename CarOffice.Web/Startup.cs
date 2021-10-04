using CarOffice.Shared;
using CarOffice.Shared.Extensions.DependencyInjection;
using CarOffice.Shared.Extensions.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarOffice.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<CarOfficeDbContext>();
            services.AddRequiredServices(Configuration.GetConnectionString("DefaultConnection"));
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");
            app.SeedAdministrationInfo(Configuration).Wait();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints
                => endpoints.MapDefaultControllerRoute());
        }
    }
}
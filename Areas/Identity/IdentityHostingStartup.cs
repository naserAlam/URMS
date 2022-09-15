using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using URMS.Areas.Identity.Data;
using URMS.Data;

[assembly: HostingStartup(typeof(URMS.Areas.Identity.IdentityHostingStartup))]
namespace URMS.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
            //    //services.AddDbContext<URMSDbContext>(options =>
            //    //    options.UseSqlServer(
            //    //        context.Configuration.GetConnectionString("URMSDbContextConnection")));

            //    services.AddDefaultIdentity<URMSUser>(options => 
            //    {
            //        options.SignIn.RequireConfirmedAccount = false;
            //        options.Password.RequireLowercase = false;
            //        options.Password.RequireUppercase = false;
            //        options.Password.RequireNonAlphanumeric = false;
            //    })
            //        .AddEntityFrameworkStores<URMSDbContext>();
            //});
        }
    }
}
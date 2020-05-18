using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScaffoldIdentiti.Data;

[assembly: HostingStartup(typeof(ScaffoldIdentiti.Areas.Identity.IdentityHostingStartup))]
namespace ScaffoldIdentiti.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ScaffoldIdentitiContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ScaffoldIdentitiContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ScaffoldIdentitiContext>();
            });
        }
    }
}
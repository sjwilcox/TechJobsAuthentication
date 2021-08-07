using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechJobsAuthentication.Data;

[assembly: HostingStartup(typeof(TechJobsAuthentication.Areas.Identity.IdentityHostingStartup))]
namespace TechJobsAuthentication.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                string connectionString = "server=localhost;userid=techjobs_auth;password=ILoveTechJobs;database=techjobs_auth;";
                var serverVersion = new MySqlServerVersion(new Version(8, 0, 25));

                services.AddDbContext<JobDbContext>(options =>
                    options.UseMySql(connectionString, serverVersion));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<JobDbContext>();
            });
        }
    }
}
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.InMemory;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Data;

namespace IntegrationTests
{
    public class ApiWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");

            builder.ConfigureServices(services =>
            {

                var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                    typeof(DbContextOptions<ApplicationDbContext>));
                if (descriptor != null)
                    services.Remove(descriptor);
                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryMartianRobotsTest");
                });

                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                using (var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    try
                    {
                        appContext.Database.EnsureCreated();
                        MartianRobotsContextSeed.SeedAsync(appContext).Wait();
                    }
                    catch (Exception ex)
                    {
                        //Log errors or do anything I think it's needed
                        throw;
                    }
                }
            });

            //public IConfiguration Configuration { get; private set; }

            //protected override void ConfigureWebHost(IWebHostBuilder builder)
            //{
            //    builder.ConfigureAppConfiguration(config =>
            //    {
            //        Configuration = new ConfigurationBuilder()
            //            .AddJsonFile("appsettings.json")
            //            .Build();

            //        config.AddConfiguration(Configuration);
            //    });

            //    builder.ConfigureServices(services =>
            //    {
            //        
            //    });
            //}

        }
    }
}

using Application.Common.Interfaces;
using Infrastructure.Data;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            //    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            bool.TryParse(configuration.GetSection("UseInMemoryDatabase").Value, out bool memoryDatabase);

            if (memoryDatabase)
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("InMemoryMartianRobotsTest"));

                
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)), ServiceLifetime.Transient);

                //services.AddDbContext<ApplicationDbContext>(options =>
                //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                //        builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            services.AddScoped<MartianRobotsContextSeed>();

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            return services;
        }
    }
}

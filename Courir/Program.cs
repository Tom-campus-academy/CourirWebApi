namespace Courir
{
    using System;

    using Courir.DataAccess;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            Seed(host);
            host.Run();
        }

        /// <summary>
        /// Allow us to create database, create table and play seed when needed
        /// </summary>
        /// <param name="host"></param>
        public static void Seed(IHost host)
        {
            using IServiceScope serviceScope = host.Services.GetService<IServiceScopeFactory>().CreateScope();
            IConfiguration configuration = serviceScope.ServiceProvider.GetService<IConfiguration>();
            bool isProduction = Convert.ToBoolean(configuration["IsProduction"]);
            serviceScope.ServiceProvider.GetService<CourirContext>().Database.Migrate();
            serviceScope.ServiceProvider.GetService<CourirContext>().EnsureSeedData(isProduction).GetAwaiter().GetResult();
        }
    }
}
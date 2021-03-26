namespace Courir
{
    using Courir.Business;
    using Courir.DataAccess;
    using Courir.IBusiness;
    using Courir.IDataAccess;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContextPool<CourirContext>(options => options
                .UseMySql(this.Configuration["ConnectionString"]));
            services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            this.RegisterDataAccess(services);
            this.RegisterBusiness(services);
        }

        private void RegisterBusiness(IServiceCollection services)
        {
            services.AddScoped<IModelBusiness, ModelBusiness>();
            services.AddScoped<IStockBusiness, StockBusiness>();
        }

        private void RegisterDataAccess(IServiceCollection services)
        {
            services.AddScoped<IModelDataAccess, ModelDataAccess>();
            services.AddScoped<IStockDataAccess, StockDataAccess>();
        }
    }
}
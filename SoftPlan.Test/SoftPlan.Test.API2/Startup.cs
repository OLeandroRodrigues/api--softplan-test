using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SoftPlan.Test.Application;
using SoftPlan.Test.Application.Interfaces;
using SoftPlan.Test.Data;
using SoftPlan.Test.Data.Repository;
using SoftPllan.Test.Domain.Interfaces.Repositories;
using SoftPllan.Test.Domain.Interfaces.Services;
using SoftPllan.Test.Domain.Services;

namespace SoftPlan.Test.API2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SoftPlan Juros : API2 ",
                    Version = "v1",
                    Description = "Desafio t?cnico",
                });
            });

            services.AddDbContext<Context>(ServiceLifetime.Scoped);
            services.AddScoped(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            services.AddScoped<IJurosAppService, JurosAppService>();

            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<IServiceJuros, ServiceJuros>();

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IRepositoryJuros, RepositoryJuros>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "SoftPlan Test"));
        }
    }
}

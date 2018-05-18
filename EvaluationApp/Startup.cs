using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvaluationApp.AppServices.EmployeeAuthentication;
using EvaluationApp.AppServices.Evaluations;
using EvaluationApp.AppServices.EvaluationsForms;
using EvaluationApp.DomainModel.Repository.Shared;
using EvaluationApp.Infrastructure.EmployeeAuthenticationService;
using EvaluationApp.Infrastructure.EvaluationFormsService;
using EvaluationApp.Infrastructure.EvaluationsService;
using EvaluationApp.Infrastructure.Persistence.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EvaluationApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPersistenceContext, PersistenceContext>();
            var dataService = services.BuildServiceProvider().GetService<IPersistenceContext>();
            if (dataService != null)
            {
                dataService.InitializeContext(services, Configuration);
            }

            // Add application services.
            services.AddScoped<IEvaluationFormsService, EvaluationFormsService>();
            services.AddScoped<IEvaluationsService, EvaluationsService>();
            services.AddScoped<IEmployeesService, EmployeesService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

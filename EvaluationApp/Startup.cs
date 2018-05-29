using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppServices.EmployeeAuthentication;
using AppServices.EvaluationForms;
using AppServices.Evaluations;
using AppServices.EvaluationsForms;
using AppServices.EvaluationStatistics;
using DomainModel.Repository.Shared;
using Infrastructure.EmployeeAuthenticationService;
using Infrastructure.EvaluationFormsService;
using Infrastructure.EvaluationsService;
using Infrastructure.Persistence.EF;
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
            services.AddScoped<IEvaluationStatisticsService, EvaluationStatisticsService>();
            services.AddScoped<IFormsAPIService, FormsAPIService>();

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

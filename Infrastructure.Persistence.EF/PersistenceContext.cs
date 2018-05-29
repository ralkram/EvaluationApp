using DomainModel.Domain;
using DomainModel.Repository.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Persistence.EF
{
    public class PersistenceContext : IPersistenceContext
    {
        private EvaluationDbContext context = null;

        public IEvaluationsRepository Evaluations { get; set; }

        public IEvaluationScaleRepository EvaluationScales { get; set; }

        public PersistenceContext(IServiceProvider serviceProvider)
        {
            InitializeDbContext(serviceProvider);
        }

        private void InitializeDbContext(IServiceProvider serviceProvider)
        {
            context = serviceProvider.GetService<EvaluationDbContext>();
            if (context != null)
            {
                Evaluations = new EvaluationsRepository(context);
                EvaluationScales = new EvaluationScaleRepository(context);
            }
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            if (context != null)
                context.Dispose();
        }

        public void InitializeContext(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<EvaluationDbContext>(options =>
                                    options.UseLazyLoadingProxies()
                                    .UseSqlServer(config.GetConnectionString("EvaluationDb")));

            InitializeDbContext(services.BuildServiceProvider());
        }

        public void InitializeData()
        {
            // Add here evaluation scales and options

            if (!context.EvaluationScales.Any(es => es.Name == "Grades"))
            {
                context.EvaluationScales.Add(new EvaluationScale
                {
                    Name = "Grades",
                    EvaluationScaleOptions = new List<EvaluationScaleOption>
                    {
                        new EvaluationScaleOption { Name = "Fail", Value = 1},
                        new EvaluationScaleOption { Name = "Very Poor", Value = 2},
                        new EvaluationScaleOption { Name = "Poor", Value = 3},
                        new EvaluationScaleOption { Name = "Fair", Value = 4},
                        new EvaluationScaleOption { Name = "Fairly Good", Value = 5},
                        new EvaluationScaleOption { Name = "Very Good", Value = 6},
                        new EvaluationScaleOption { Name = "Excellent", Value = 7}
                    }
                });
            }

            if (!context.EvaluationScales.Any(es => es.Name == "Agreement"))
            {
                context.EvaluationScales.Add(new EvaluationScale
                {
                    Name = "Agreement",
                    EvaluationScaleOptions = new List<EvaluationScaleOption>
                    {
                        new EvaluationScaleOption { Name = "Agree", Value = 1},
                        new EvaluationScaleOption { Name = "Disagree", Value = 2},
                    }
                });
            }

            context.SaveChanges();
        }
    }
}

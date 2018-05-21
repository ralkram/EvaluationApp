using DomainModel.Repository.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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

        public void InitializeData(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();
        }
    }
}

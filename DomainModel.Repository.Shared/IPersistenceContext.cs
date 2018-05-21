using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Repository.Shared
{
    public interface IPersistenceContext : IDisposable
    {
        IEvaluationsRepository Evaluations { get; }
        IEvaluationScaleRepository EvaluationScales { get;}
        int Complete();
        void InitializeContext(IServiceCollection services, IConfiguration config);
        void InitializeData(IServiceProvider serviceProvider);
    }
}

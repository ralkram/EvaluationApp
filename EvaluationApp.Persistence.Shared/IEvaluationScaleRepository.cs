using EvaluationApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationApp.Persistence.Shared
{
    public interface IEvaluationScaleRepository : IRepository<EvaluationScale>
    {
        EvaluationScaleOption GetEvaluationScaleOptionById(int id);
        IEnumerable<EvaluationScaleOption> GetEvaluationScaleOptionsFromScale(int scaleId);
    }
}

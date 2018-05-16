using EvaluationApp.Domain;
using EvaluationApp.Persistence.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EvaluationApp.Persistence.EF
{
    public class EvaluationScaleRepository : Repository<EvaluationScale>, IEvaluationScaleRepository
    {
        private EvaluationDbContext LocalContext
        {
            get
            {
                return Context as EvaluationDbContext;
            }
        }

        public EvaluationScaleRepository(DbContext context) : base(context)
        {

        }

        public EvaluationScaleOption GetEvaluationScaleOptionById(int id)
        {
            var evaluationScaleOption = LocalContext
                                        .EvaluationScales
                                        .Include(es => es.EvaluationScaleOptions)
                                        .Select(es => es.EvaluationScaleOptions
                                                        .Where(eso=>eso.Id == id)
                                                        .FirstOrDefault())
                                         .FirstOrDefault();

            return evaluationScaleOption;
        }

        public IEnumerable<EvaluationScaleOption> GetEvaluationScaleOptionsFromScale(int scaleId)
        {
            var evaluationScaleOptions = LocalContext.EvaluationScales.FirstOrDefault(es => es.Id == scaleId).EvaluationScaleOptions;

            return evaluationScaleOptions;
        }
    }
}

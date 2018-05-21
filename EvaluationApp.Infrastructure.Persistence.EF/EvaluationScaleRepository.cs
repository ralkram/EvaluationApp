using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DomainModel.Domain;
using DomainModel.Repository.Shared;

namespace Infrastructure.Persistence.EF
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

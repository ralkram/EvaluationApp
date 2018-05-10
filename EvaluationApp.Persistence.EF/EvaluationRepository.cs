using EvaluationApp.Domain;
using EvaluationApp.Domain.FormMockup;
using EvaluationApp.Persistence.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationApp.Persistence.EF
{
    public class EvaluationRepository : Repository<Evaluation>, IEvaluationRepository 
    {
        public EvaluationRepository(EvaluationDbContext context)
            : base(context)
        {

        }

        public IEnumerable<Evaluation> GetCompletedEvaluationsForEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Evaluation> GetInProgressEvaluationsForEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        //public void StartEvaluation(Evaluation evaluation)
        //{
        //    EvaluationDbContext.Evaluations.Add(evaluation);
        //}

        public EvaluationDbContext EvaluationDbContext
        {
            get
            {
                return Context as EvaluationDbContext;
            }
        }
    }
}

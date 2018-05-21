using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DomainModel.Repository.Shared;
using DomainModel.Domain;

namespace Infrastructure.Persistence.EF
{
    public class EvaluationsRepository : Repository<Evaluation>, IEvaluationsRepository 
    {
        public EvaluationsRepository(EvaluationDbContext context)
            : base(context)
        {

        }

        public IEnumerable<Evaluation> GetCompletedEvaluationsForEvaluator(int evaluatorId)
        {
            var completedEvaluations = EvaluationDbContext.Evaluations.Where(e => e.CreatedBy == evaluatorId && e.IsCompleted == true);

            return completedEvaluations;
        }

        public IEnumerable<Evaluation> GetInProgressEvaluationsForEvaluator(int evaluatorId)
        {
            var inProgressEvaluations = EvaluationDbContext.Evaluations.Where(e => e.CreatedBy == evaluatorId && e.IsCompleted == false);

            return inProgressEvaluations;
        }

        public IEnumerable<Evaluation> GetCompletedEvaluationsForEmployee(int employeeId)
        {
            var completedEvaluations = EvaluationDbContext.Evaluations.Where(e => e.EmployeeId == employeeId && e.IsCompleted == true);

            return completedEvaluations;
        }

        public IEnumerable<Evaluation> GetInProgressEvaluationsForEmployee(int employeeId)
        {
            var inProgressEvaluations = EvaluationDbContext.Evaluations.Where(e => e.EmployeeId == employeeId && e.IsCompleted == false);

            return inProgressEvaluations;
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

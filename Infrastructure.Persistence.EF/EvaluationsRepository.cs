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

        public IEnumerable<Evaluation> GetCompletedEvaluationsForEvaluator(string evaluatorUserName)
        {
            var completedEvaluations = EvaluationDbContext.Evaluations.Where(e => e.CreatedBy == evaluatorUserName && e.IsCompleted == true);

            return completedEvaluations;
        }

        public IEnumerable<Evaluation> GetInProgressEvaluationsForEvaluator(string evaluatorUserName)
        {
            var inProgressEvaluations = EvaluationDbContext.Evaluations.Where(e => e.CreatedBy == evaluatorUserName && e.IsCompleted == false);

            return inProgressEvaluations;
        }

        public IEnumerable<Evaluation> GetCompletedEvaluationsForEmployee(string employeeUserName)
        {
            var completedEvaluations = EvaluationDbContext.Evaluations.Where(e => e.EmployeeId == employeeUserName && e.IsCompleted == true);

            return completedEvaluations;
        }

        public IEnumerable<Evaluation> GetInProgressEvaluationsForEmployee(string employeeUserName)
        {
            var inProgressEvaluations = EvaluationDbContext.Evaluations.Where(e => e.EmployeeId == employeeUserName && e.IsCompleted == false);

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

using EvaluationApp.Core.Shared;
using EvaluationApp.Domain;
using EvaluationApp.Persistence.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationApp.Core
{
    public class EvaluationsService : IEvaluationsService
    {
        private readonly IPersistenceContext persistenceContext;

        public EvaluationsService(IPersistenceContext persistenceContext)
        {
            this.persistenceContext = persistenceContext;
        }

        public ICollection<Evaluation> GetCompletedEvaluations(int employeeId)
        {
            ICollection<Evaluation> evaluations = new List<Evaluation>();

            evaluations.Add(new Evaluation
            {
                Id = 1,
                EvaluationName = "Core Skills",
                FormName = "Core Technical .NET",
                EmployeeId = 1,
                LastEvaluatorId = 3
            });

            evaluations.Add(new Evaluation
            {
                Id = 2,
                EvaluationName = "Core Skills",
                FormName = "Core Technical .NET",
                EmployeeId = 2,
                LastEvaluatorId = 3
            });

            evaluations.Add(new Evaluation
            {
                Id = 3,
                EvaluationName = "Philadelphia Project",
                FormName = "Core Technical .NET",
                EmployeeId = 3,
                LastEvaluatorId = 3
            });

            return evaluations;
        }

        public ICollection<Evaluation> GetInProgressEvaluations(int employeeId)
        {
            ICollection<Evaluation> evaluations = new List<Evaluation>();

            evaluations.Add(new Evaluation
            {
                Id = 1,
                EvaluationName = "Core Skills",
                FormName = "Core Technical .NET",
                EmployeeId = 1,
                LastEvaluatorId = 3
            });

            evaluations.Add(new Evaluation
            {
                Id = 2,
                EvaluationName = "Core Skills",
                FormName = "Core Technical .NET",
                EmployeeId = 2,
                LastEvaluatorId = 3
            });

            evaluations.Add(new Evaluation
            {
                Id = 3,
                EvaluationName = "Philadelphia Project",
                FormName = "Core Technical .NET",
                EmployeeId = 3,
                LastEvaluatorId = 3
            });

            return evaluations;
        }

       

        public void StartEvaluation(Evaluation evaluation)
        {
            persistenceContext.Evaluations.Insert(evaluation);
            persistenceContext.Complete();
        }

        public void ContinueEvaluation(int evaluationId)
        {
            throw new NotImplementedException();
        }

        public Evaluation GetEvaluationForm()
        {
            throw new NotImplementedException();
        }
    }
}

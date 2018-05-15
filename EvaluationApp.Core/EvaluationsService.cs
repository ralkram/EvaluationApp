using EvaluationApp.Core.Shared;
using EvaluationApp.Domain;
using EvaluationApp.Domain.FormMockup;
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

        public ICollection<Evaluation> GetCompletedEvaluationsForEvaluator(int evaluatorId)
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

        public ICollection<Evaluation> GetInProgressEvaluationsForEvaluator(int evaluatorId)
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

        public Evaluation GetEvaluationById(int evaluationId)
        {
            return persistenceContext.Evaluations.GetById(evaluationId);
        }

        public ICollection<Domain.Section> MapFormSectionsToEvaluationSections(ICollection<Domain.FormMockup.Section> formSections)
        {
            List<Domain.Section> sections = new List<Domain.Section>();

            foreach (var section in formSections)
            {
                var criteria = new List<Domain.Criteria>();
                var evalScale = new List<Domain.EvaluationScaleOption>();

                foreach (var item in section.EvaluationScale.EvaluationScaleOptions)
                {
                    evalScale.Add(new Domain.EvaluationScaleOption
                    {
                        Name = item.Name,
                        Value = item.Value
                    });
                }

                foreach (var item in section.Criteria)
                {
                    criteria.Add(new Domain.Criteria
                    {
                        Name = item.Name,
                        Grade = new Domain.EvaluationScaleOption()
                    });
                }
                sections.Add(new Domain.Section
                {
                    Name = section.Name,
                    CreatedBy = section.CreatedBy,
                    Criteria = criteria,
                    EvaluationScale = new Domain.EvaluationScale
                    {
                        Id = 1,
                        Name = section.EvaluationScale.Name,
                        EvaluationScaleOptions = evalScale
                    }
                });
            }

            return sections;
        }
    }
}

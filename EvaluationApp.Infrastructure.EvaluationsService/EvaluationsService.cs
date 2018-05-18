using EvaluationApp.AppServices.Evaluations;
using EvaluationApp.DomainModel.Domain;
using EvaluationApp.DomainModel.Repository.Shared;
using System;
using System.Collections.Generic;

namespace EvaluationApp.Infrastructure.EvaluationsService
{
    public class EvaluationsService : IEvaluationsService
    {
        private readonly IPersistenceContext persistenceContext;

        public EvaluationsService(IPersistenceContext persistenceContext)
        {
            this.persistenceContext = persistenceContext;
        }

        public IEnumerable<Evaluation> GetCompletedEvaluationsForEvaluator(int evaluatorId)
        {
            IEnumerable<Evaluation> evaluations = persistenceContext.Evaluations.GetCompletedEvaluationsForEvaluator(evaluatorId);

            return evaluations;
        }

        public IEnumerable<Evaluation> GetInProgressEvaluationsForEvaluator(int evaluatorId)
        {
            IEnumerable<Evaluation> evaluations = persistenceContext.Evaluations.GetInProgressEvaluationsForEvaluator(evaluatorId);

            return evaluations;
        }

        public void InsertEvaluation(Evaluation evaluation)
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

        public ICollection<DomainModel.Domain.Section> MapFormSectionsToEvaluationSections(ICollection<Domain.FormMockup.Section> formSections)
        {
            List<Section> sections = new List<Section>();

            foreach (var section in formSections)
            {
                var criteria = new List<Criteria>();
                var evalScale = new List<EvaluationScaleOption>();

                foreach (var item in section.EvaluationScale.EvaluationScaleOptions)
                {
                    evalScale.Add(new EvaluationScaleOption
                    {
                        Name = item.Name,
                        Value = item.Value
                    });
                }

                foreach (var item in section.Criteria)
                {
                    criteria.Add(new Criteria
                    {
                        Name = item.Name,
                        Grade = null
                    });
                }

                sections.Add(new Section
                {
                    Name = section.Name,
                    CreatedBy = section.CreatedBy,
                    Criteria = criteria,
                    EvaluationScale = persistenceContext.EvaluationScales.GetById(section.EvaluationScale.Id)
                });
            }

            return sections;
        }

        public IEnumerable<Evaluation> GetInProgressEvaluationsForEmployee(int employeeId)
        {
            IEnumerable<Evaluation> evaluations = persistenceContext.Evaluations.GetInProgressEvaluationsForEmployee(employeeId);

            return evaluations;
        }

        public IEnumerable<Evaluation> GetCompletedEvaluationsForEmployee(int employeeId)
        {
            IEnumerable<Evaluation> evaluations = persistenceContext.Evaluations.GetCompletedEvaluationsForEmployee(employeeId);

            return evaluations;
        }

        public void Delete(int evaluationId)
        {
            Evaluation evaluation = persistenceContext.Evaluations.GetById(evaluationId);
            persistenceContext.Evaluations.Delete(evaluation);
            persistenceContext.Complete();
        }

        public void UpdateEvaluation(Evaluation evaluation)
        {
            var evaluationToUpdate = persistenceContext.Evaluations.GetById(evaluation.Id);

            evaluationToUpdate.Sections = evaluation.Sections;
            persistenceContext.Complete();
        }

        public EvaluationScaleOption GetEvaluationScaleOption(int optionId)
        {
            var evaluationScaleOption = persistenceContext.EvaluationScales.GetEvaluationScaleOptionById(optionId);

            return evaluationScaleOption;
        }

        public IEnumerable<DomainModel.Domain.EvaluationScaleOption> GetEvaluationScaleOptionsFromScale(int scaleId)
        {
            var evaluationScaleOptions = persistenceContext.EvaluationScales.GetEvaluationScaleOptionsFromScale(scaleId);

            return evaluationScaleOptions;
        }
    }
}

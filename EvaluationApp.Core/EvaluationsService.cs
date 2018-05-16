﻿using EvaluationApp.Core.Shared;
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

        public void UpdateEvaluation(Evaluation evaluation, int evaluationId)
        {
            var evaluationToUpdate = persistenceContext.Evaluations.GetById(evaluationId);

            evaluationToUpdate.Sections = evaluation.Sections;
            persistenceContext.Complete();
        }

        public Domain.EvaluationScaleOption GetEvaluationScaleOption(int optionId)
        {
            var evaluationScaleOption = persistenceContext.EvaluationScales.GetEvaluationScaleOptionById(optionId);

            return evaluationScaleOption;
        }

        public IEnumerable<Domain.EvaluationScaleOption> GetEvaluationScaleOptionsFromScale(int scaleId)
        {
            var evaluationScaleOptions = persistenceContext.EvaluationScales.GetEvaluationScaleOptionsFromScale(scaleId);

            return evaluationScaleOptions;
        }
    }
}

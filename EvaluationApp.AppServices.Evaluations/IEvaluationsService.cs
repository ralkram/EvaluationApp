﻿using EvaluationApp.DomainModel.Domain;
using System;
using System.Collections.Generic;

namespace EvaluationApp.AppServices.Evaluations
{
    public interface IEvaluationsService
    {
        Evaluation GetEvaluationById(int evaluationId);
        IEnumerable<Evaluation> GetInProgressEvaluationsForEvaluator(int evaluatorId);
        IEnumerable<Evaluation> GetCompletedEvaluationsForEvaluator(int evaluatorId);

        IEnumerable<Evaluation> GetInProgressEvaluationsForEmployee(int employeeId);
        IEnumerable<Evaluation> GetCompletedEvaluationsForEmployee(int employeeId);

        void UpdateEvaluation(Evaluation evaluation);
        void InsertEvaluation(Evaluation evaluation);
        void ContinueEvaluation(int evaluationId);
        ICollection<DomainModel.Domain.Section> MapFormSectionsToEvaluationSections(ICollection<Domain.FormMockup.Section> sections);
        Evaluation GetEvaluationForm();

        void Delete(int evaluationId);

        EvaluationScaleOption GetEvaluationScaleOption(int optionId);
        IEnumerable<EvaluationScaleOption> GetEvaluationScaleOptionsFromScale(int scaleId);


    }
}

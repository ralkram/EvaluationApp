using EvaluationApp.DomainModel.Domain;
using System;
using System.Collections.Generic;

namespace AppServices.Evaluations
{
    public interface IEvaluationsService
    {
        Evaluation GetEvaluationById(int evaluationId);
        IEnumerable<Evaluation> GetInProgressEvaluationsForEvaluator(int evaluatorId);
        IEnumerable<Evaluation> GetCompletedEvaluationsForEvaluator(int evaluatorId);

        IEnumerable<Evaluation> GetInProgressEvaluationsForEmployee(int employeeId);
        IEnumerable<Evaluation> GetCompletedEvaluationsForEmployee(int employeeId);

        void UpdateEvaluation(Evaluation evaluation);

        void UpdateEvaluationInfo();
        void UpdateEvaluationData(EvaluationData evaluationData);

        void InsertEvaluation(Evaluation evaluation);
        ICollection<EvaluationApp.DomainModel.Domain.Section> MapFormSectionsToEvaluationSections(ICollection<EvaluationApp.Domain.FormMockup.Section> sections);

        void Delete(int evaluationId);

        EvaluationScaleOption GetEvaluationScaleOption(int optionId);
        IEnumerable<EvaluationScaleOption> GetEvaluationScaleOptionsFromScale(int scaleId);
    }
}

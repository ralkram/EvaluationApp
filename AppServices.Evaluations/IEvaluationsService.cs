using DomainModel.Domain;
using EvaluationFormsManager.DataTransferObjects;
using System;
using System.Collections.Generic;

namespace AppServices.Evaluations
{
    public interface IEvaluationsService
    {
        Evaluation GetEvaluationById(int evaluationId);
        IEnumerable<Evaluation> GetInProgressEvaluationsForEvaluator(string evaluatorUserName);
        IEnumerable<Evaluation> GetCompletedEvaluationsForEvaluator(string evaluatorUserName);

        IEnumerable<Evaluation> GetInProgressEvaluationsForEmployee(string employeeUserName);
        IEnumerable<Evaluation> GetCompletedEvaluationsForEmployee(string employeeUserName);

        void UpdateEvaluation(Evaluation evaluation);

        void UpdateEvaluationInfo();
        void UpdateEvaluationData(EvaluationData evaluationData);

        void InsertEvaluation(Evaluation evaluation);
        ICollection<DomainModel.Domain.Section> MapFormSectionsToEvaluationSections(ICollection<SectionDTO> sections);

        void Delete(int evaluationId);

        EvaluationScaleOption GetEvaluationScaleOption(int optionId);
        IEnumerable<EvaluationScaleOption> GetEvaluationScaleOptionsFromScale(int scaleId);
    }
}

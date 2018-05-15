using EvaluationApp.Domain;
using EvaluationApp.Domain.FormMockup;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationApp.Core.Shared
{
    public interface IEvaluationsService
    {
        Evaluation GetEvaluationById(int evaluationId);
        ICollection<Evaluation> GetInProgressEvaluations(int employeeId);
        ICollection<Evaluation> GetCompletedEvaluations(int employeeId);        

        void StartEvaluation(Evaluation evaluation);
        void ContinueEvaluation(int evaluationId);
        ICollection<EvaluationApp.Domain.Section> MapFormSectionsToEvaluationSections(ICollection<Domain.FormMockup.Section> sections);
        Evaluation GetEvaluationForm();
    }
}

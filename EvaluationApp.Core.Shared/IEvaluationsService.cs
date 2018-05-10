using EvaluationApp.Domain;
using EvaluationApp.Domain.FormMockup;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationApp.Core.Shared
{
    public interface IEvaluationsService
    {
        ICollection<Evaluation> GetInProgressEvaluations(int employeeId);
        ICollection<Evaluation> GetCompletedEvaluations(int employeeId);

        void StartEvaluation(Evaluation evaluation);
        void ContinueEvaluation(int evaluationId);
        Evaluation GetEvaluationForm();
    }
}

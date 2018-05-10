using EvaluationApp.Domain;
using EvaluationApp.Domain.EmployeeMockup;
using EvaluationApp.Domain.FormMockup;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationApp.Core.Shared
{
    public interface IEvaluationFormsService
    {
        ICollection<Form> GetForms(int userId);
        ICollection<Employee> GetEmployees();
        ICollection<Evaluation> GetInProgressEvaluations();
        ICollection<Evaluation> GetCompletedEvaluations();

        void StartEvaluation(Evaluation evaluation);
        void ContinueEvaluation(int evaluationId);
        Evaluation GetEvaluationForm();
    }
}

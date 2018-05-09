using EvaluationApp.Domain;
using EvaluationApp.Domain.EmployeeMockup;
using EvaluationApp.Domain.FormMockup;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationApp.Core.Shared
{
    public interface IEvaluationFormService
    {
        ICollection<Form> GetForms(int userId);
        ICollection<Employee> GetEmployees();
        ICollection<Evaluation> GetInProgressEvaluations();
        ICollection<Evaluation> GetCompletedEvaluations();

        void StartEvaluation(Form form, Employee employee);
        void ContinueEvaluation(int evaluationId);
        Evaluation GetEvaluationForm();
    }
}

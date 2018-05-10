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
        ICollection<Form> GetEvaluationFormsForEmployee(int employeeId);
        Form GetEvaluationForm(int formId);
    }
}

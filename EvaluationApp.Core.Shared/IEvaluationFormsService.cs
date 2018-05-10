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
        ICollection<Form> GetAllSharedFormsForEmployee(int employeeId);
        ICollection<Form> GetEnabledSharedFormsForEmployee(int employeeId);

        Form GetEvaluationForm(int formId);
    }
}

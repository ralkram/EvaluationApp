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
    }
}

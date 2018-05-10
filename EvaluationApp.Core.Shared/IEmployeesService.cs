using EvaluationApp.Domain.EmployeeMockup;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationApp.Core.Shared
{
    public interface IEmployeesService
    {
        Employee GetEmployeeInfo(int employeeId);
        ICollection<Employee> GetEmployeesToEvaluate(int employeeId);
    }
}

using IdentityServer.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppServices.EmployeeAuthentication
{
    public interface IEmployeesService
    {
        Employee GetEmployeeInfo(int employeeId);
        ICollection<Employee> GetEmployeesToEvaluate(int employeeId);
    }
}

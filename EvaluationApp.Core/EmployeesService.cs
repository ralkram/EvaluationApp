using EvaluationApp.Core.Shared;
using IdentityServer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvaluationApp.Core
{
    public class EmployeesService : IEmployeesService
    {
        // MOCKUP METHOD, TO BE IMPLEMENTED
        public Employee GetEmployeeInfo(int employeeId)
        {
            ICollection<Employee> employees = new List<Employee>();
            employees.Add(new Employee
            {
                Id = 1,
                Name = "Paige Turner",
                Position = new Position { Id = 1, RoleName = "Team Lead" },
                Team = new Team { Id = 1, Name = "Team 1" }
            });

            employees.Add(new Employee
            {
                Id = 2,
                Name = "Sam Samuels",
                Position = new Position { Id = 2, RoleName = "Developer" },
                Team = new Team { Id = 2, Name = "Team 2" }
            });

            employees.Add(new Employee
            {
                Id = 3,
                Name = "Leana Stevens",
                Position = new Position { Id = 3, RoleName = "QA Engineer" },
                Team = new Team { Id = 3, Name = "Team 3" }
            });
            employees.Add(new Employee
            {
                Id = 4,
                Name = "John Smith",
                Position = new Position { Id = 1, RoleName = "Team Lead" },
                Team = new Team { Id = 2, Name = "Team 2" }
            });
            var employee = (from x in employees.OfType<Employee>() where x.Id == employeeId select x).FirstOrDefault();
            return employee;
        }

        // MOCKUP METHOD, TO BE IMPLEMENTED
        public ICollection<Employee> GetEmployeesToEvaluate(int employeeId)
        {
            ICollection<Employee> employees = new List<Employee>();
            employees.Add(new Employee
            {
                Id = 2,
                Name = "Sam Samuels",
                Position = new Position { Id = 2, RoleName = "Developer" },
                Team = new Team { Id = 2, Name = "Team 2" }
            });

            employees.Add(new Employee
            {
                Id = 3,
                Name = "Leana Stevens",
                Position = new Position { Id = 3, RoleName = "QA Engineer" },
                Team = new Team { Id = 3, Name = "Team 3" }
            });
            employees.Add(new Employee
            {
                Id = 4,
                Name = "John Smith",
                Position = new Position { Id = 1, RoleName = "Team Lead" },
                Team = new Team { Id = 2, Name = "Team 2" }
            });

            return employees;
        }
    }
}

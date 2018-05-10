using EvaluationApp.Core.Shared;
using EvaluationApp.Domain.EmployeeMockup;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationApp.Core
{
    public class EmployeesService : IEmployeesService
    {
        public Employee GetEmployeeInfo(int employeeId)
        {
            if (employeeId == 1)
            {
                return new Employee
                {
                    Id = 1,
                    Name = "Paige Turner",
                    Position = new Position { Id = 1, Name = "Team Lead" },
                    Team = new Team { Id = 1, Name = "Team 1" }
                };
            }
            else if (employeeId == 2)
            {
                return new Employee
                {
                    Id = 1,
                    Name = "Sam Samuels",
                    Position = new Position { Id = 2, Name = "Developer" },
                    Team = new Team { Id = 2, Name = "Team 2" }
                };
            }
            else if (employeeId == 3)
            {
                return new Employee
                {
                    Id = 1,
                    Name = "Leana Stevens",
                    Position = new Position { Id = 3, Name = "QA Engineer" },
                    Team = new Team { Id = 2, Name = "Team 3" }
                };
            }
            return new Employee
            {
                Id = 4,
                Name = "John Smith",
                Position = new Position { Id = 1, Name = "Team Lead" },
                Team = new Team { Id = 2, Name = "Team 2" }
            };
        }
    }
}

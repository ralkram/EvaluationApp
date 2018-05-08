using System;

namespace EvaluationApp.Domain.EmployeeMockup
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public Position Position { get; set; }

        public virtual Team Team { get; set; }
    }
}

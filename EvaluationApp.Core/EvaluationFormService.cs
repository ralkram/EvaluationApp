using EvaluationApp.Core.Shared;
using EvaluationApp.Domain.FormMockup;
using EvaluationApp.Domain.EmployeeMockup;
using System;
using System.Collections.Generic;
using System.Text;
using EvaluationApp.Domain;

namespace EvaluationApp.Core
{
    public class EvaluationFormService : IEvaluationFormService
    {
        public ICollection<Evaluation> GetCompletedEvaluations()
        {
            ICollection<Evaluation> evaluations = new List<Evaluation>();

            evaluations.Add(new Evaluation
            {
                Id = 1,
                EvaluationName = "Core Skills",
                FormName = "Core Technical .NET",
                Employee = new Employee { Name = "Sam Samuels" },
                LastEvaluator = new Employee { Name = "Paige Turner" }
            });

            evaluations.Add(new Evaluation
            {
                Id = 2,
                EvaluationName = "Core Skills",
                FormName = "Core Technical .NET",
                Employee = new Employee { Name = "Cassey Chambers" },
                LastEvaluator = new Employee { Name = "Paige Turner" }
            });

            evaluations.Add(new Evaluation
            {
                Id = 3,
                EvaluationName = "Philadelphia Project",
                FormName = "Core Technical .NET",
                Employee = new Employee { Name = "Lena Stevens" },
                LastEvaluator = new Employee { Name = "Paige Turner" }
            });

            return evaluations;
        }

        public ICollection<Employee> GetEmployees()
        {
            ICollection<Employee> employees = new List<Employee>();
            employees.Add(new Employee
            {
                Id = 1,
                Name = "Paige Turner",
                Position = new Position { Id = 1, Name = "Team Lead" },
                Team = new Team { Id = 1, Name = "Team 1" }
            });

            employees.Add(new Employee
            {
                Id = 1,
                Name = "Sam Samuels",
                Position = new Position { Id = 1, Name = "Developer" },
                Team = new Team { Id = 1, Name = "Team 2" }
            });

            employees.Add(new Employee
            {
                Id = 1,
                Name = "Leana Stevens",
                Position = new Position { Id = 1, Name = "QA Engineer" },
                Team = new Team { Id = 1, Name = "Team 3" }
            });

            return employees;
        }

        public ICollection<Form> GetForms(int userId)
        {
            ICollection<Form> forms = new List<Form>();

            ICollection<EvaluationApp.Domain.FormMockup.Criteria> criteria_1 = new List<EvaluationApp.Domain.FormMockup.Criteria>();
            criteria_1.Add(new EvaluationApp.Domain.FormMockup.Criteria { Id = 1, Name = "Naming + proper comments", ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0) });
            criteria_1.Add(new EvaluationApp.Domain.FormMockup.Criteria { Id = 2, Name = "Method Cohesion", ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0) });
            criteria_1.Add(new EvaluationApp.Domain.FormMockup.Criteria { Id = 3, Name = "Class Cohesion", ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0) });

            ICollection<EvaluationApp.Domain.FormMockup.Criteria> criteria_2 = new List<EvaluationApp.Domain.FormMockup.Criteria>();
            criteria_2.Add(new EvaluationApp.Domain.FormMockup.Criteria { Id = 4, Name = "Class Coupling", ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0) });
            criteria_2.Add(new EvaluationApp.Domain.FormMockup.Criteria { Id = 5, Name = "Open Close Criterion", ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0) });

            ICollection<EvaluationApp.Domain.FormMockup.Section> sections = new List<EvaluationApp.Domain.FormMockup.Section>();
            sections.Add(new EvaluationApp.Domain.FormMockup.Section
            {
                Id = 1,
                Name = "Software Engineering",
                Description = "Basic Software Engineering Principles",
                ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0),
                Criteria = criteria_1
            });

            sections.Add(new EvaluationApp.Domain.FormMockup.Section
            {
                Id = 2,
                Name = "Programming",
                Description = "Basic Programming Principles",
                ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0),
                Criteria = criteria_2
            });


            forms.Add(new Form
            {
                Id = 1,
                Name = "Philadelphia Project",
                Description = "Form to be used for evaluating skills specific for the Philadelphia Project",
                Importance = new EvaluationApp.Domain.FormMockup.Importance { Id = 1, Name = "Very important", Level = 5 },
                Status = true,
                CreatedDate = new DateTime(2018, 5, 14, 16, 32, 0),
                ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0),
                Sections = sections
            });

            forms.Add(new Form
            {
                Id = 1,
                Name = "Core Technical .NET",
                Description = "Form for all technicall staff using .NET technologies.",
                Importance = new EvaluationApp.Domain.FormMockup.Importance { Id = 1, Name = "Very important", Level = 5 },
                Status = true,
                CreatedDate = new DateTime(2018, 5, 14, 16, 32, 0),
                ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0),
                Sections = sections
            });

            forms.Add(new Form
            {
                Id = 1,
                Name = "Team Lead Evaluation",
                Description = "Evaluates team lead specific skills.",
                Importance = new EvaluationApp.Domain.FormMockup.Importance { Id = 1, Name = "Very important", Level = 5 },
                Status = false,
                CreatedDate = new DateTime(2018, 5, 14, 16, 32, 0),
                ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0),
                Sections = sections
            });

            return forms;
        }

        public ICollection<Evaluation> GetInProgressEvaluations()
        {
            ICollection<Evaluation> evaluations = new List<Evaluation>();

            evaluations.Add(new Evaluation
            {
                Id = 1,
                EvaluationName = "Core Skills",
                FormName = "Core Technical .NET",
                Employee = new Employee { Name = "Sam Samuels"},
                LastEvaluator = new Employee { Name = "Paige Turner"}
            });

            evaluations.Add(new Evaluation
            {
                Id = 2,
                EvaluationName = "Core Skills",
                FormName = "Core Technical .NET",
                Employee = new Employee { Name = "Cassey Chambers" },
                LastEvaluator = new Employee { Name = "Paige Turner" }
            });

            evaluations.Add(new Evaluation
            {
                Id = 3,
                EvaluationName = "Philadelphia Project",
                FormName = "Core Technical .NET",
                Employee = new Employee { Name = "Lena Stevens" },
                LastEvaluator = new Employee { Name = "Paige Turner" }
            });

            return evaluations;
        }
    }
}

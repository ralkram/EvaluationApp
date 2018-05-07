using EvaluationApp.Core.Shared;
using EvaluationApp.Domain.FormMockup;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationApp.Core
{
    public class EvaluationFormService : IEvaluationFormService
    {
        public ICollection<Form> GetForms(int userId)
        {
            ICollection<Form> forms = new List<Form>();

            ICollection<Criteria> criterias_1 = new List<Criteria>();
            criterias_1.Add(new Criteria { Id = 1, Name = "Naming + proper comments", ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0)});
            criterias_1.Add(new Criteria { Id = 2, Name = "Method Cohesion", ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0) });
            criterias_1.Add(new Criteria { Id = 3, Name = "Class Cohesion", ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0) });

            ICollection<Criteria> criterias_2 = new List<Criteria>();
            criterias_2.Add(new Criteria { Id = 4, Name = "Class Coupling", ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0) });
            criterias_2.Add(new Criteria { Id = 5, Name = "Open Close Criterion", ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0) });

            ICollection<Section> sections = new List<Section>();
            sections.Add(new Section
            {
                Id = 1,
                Name = "Software Engineering",
                Description = "Basic Software Engineering Principles",
                ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0),
                Criterias = criterias_1
            });

            sections.Add(new Section
            {
                Id = 2,
                Name = "Programming",
                Description = "Basic Programming Principles",
                ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0),
                Criterias = criterias_2
            });


            forms.Add(new Form
            {
                Id = 1,
                Name = "Philadelphia Project",
                Description = "Form to be used for evaluating skills specific for the Philadelphia Project",
                Importance = new Importance { Id = 1, Name = "Very important", Level = 5 },
                Status = true, CreatedDate = new DateTime(2018, 5, 14, 16, 32, 0),
                ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0),
                Sections = sections
            });

            return forms;
        }
    }
}

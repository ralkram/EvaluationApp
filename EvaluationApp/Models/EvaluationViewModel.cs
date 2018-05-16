using EvaluationApp.Domain;
using EvaluationApp.Domain.FormMockup;
using IdentityServer.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationApp.Models
{
    public class EvaluationViewModel
    {
        public int Id { get; set; }

        public string EvaluationName { get; set; }

        public string FormName { get; set; }
        public IEnumerable<SelectListItem> Forms { get; set; }

        public string EvaluationGrade { get; set; }
        public ICollection<SelectListItem> EvaluationGrades { get; set; }

        public Form SelectedForm { get; set; }
        public bool IsCompleted { get; set; }
        public ICollection<EvaluationApp.Domain.Section> Sections { get; set; }

        public string EmployeeName { get; set; }

        public Employee Employee { get; set; }
        public Employee LastEvaluator { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}

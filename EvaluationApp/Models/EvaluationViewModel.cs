using EvaluationApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationApp.Models
{
    public class EvaluationViewModel
    {
        public string EvaluationName { get; set; }

        public string FormName { get; set; }

        public bool IsCompleted { get; set; }

        public ICollection<Section> Sections { get; set; }

        public string EmployeeName { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationApp.Models
{
    public class StartEvaluationViewModel
    {
        public string Name { get; set; }
        public int SelectedForm { get; set; }
        public bool IsFormEnabled { get; set; }
        public int SelectedEmployee { get; set; }
        public bool IsEmployeeEnabled { get; set; }
        public ICollection<SelectListItem> EmployeesList { get; set; }
        public ICollection<SelectListItem> FormsList { get; set; }
    }
}

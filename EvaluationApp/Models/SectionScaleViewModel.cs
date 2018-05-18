using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EvaluationApp.Models
{
    public class SectionScaleViewModel
    {
        public int SectionId { get; set; }
        public ICollection<SelectListItem> ScaleOptions{get; set;}
    }
}

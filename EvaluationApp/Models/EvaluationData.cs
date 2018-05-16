using EvaluationApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationApp.Models
{
    public class EvaluationData
    {
        public int Id { get; set; }       
        public ICollection<Section> Sections { get; set; }
    }
}

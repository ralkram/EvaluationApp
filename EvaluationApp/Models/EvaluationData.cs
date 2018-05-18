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
        public bool IsCompleted { get; set; }
        public ICollection<CriteriaData> CriteriaData { get; set; }
    }
}

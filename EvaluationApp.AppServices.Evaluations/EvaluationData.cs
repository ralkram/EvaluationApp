using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationApp.AppServices.Evaluations
{
    public class EvaluationData
    {
        public int Id { get; set; }
        public bool IsCompleted { get; set; }
        public ICollection<CriteriaData> CriteriaData { get; set; }
    }
}

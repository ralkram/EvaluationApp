using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationApp.DomainModel.Domain
{
    public class EvaluationScaleOption
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public int EvaluationScaleId { get; set; }
        public virtual EvaluationScale EvaluationScale { get; set; }
    }
}

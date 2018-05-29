using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Domain
{
    public class Criteria
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

        public virtual EvaluationScaleOption Grade { get; set; }
    }
}

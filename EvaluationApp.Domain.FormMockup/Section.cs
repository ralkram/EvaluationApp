using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationApp.Domain.FormMockup
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Criteria> Criteria { get; set; }

        public virtual EvaluationScale EvaluationScale { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}

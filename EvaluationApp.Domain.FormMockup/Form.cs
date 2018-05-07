using System;
using System.Collections.Generic;

namespace EvaluationApp.Domain.FormMockup
{
    public class Form
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Importance Importance { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Section> Sections { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}

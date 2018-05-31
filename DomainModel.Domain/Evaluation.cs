using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Domain
{
    public class Evaluation
    {
        public int Id { get; set; }
        public string EvaluationName { get; set; }
        public string FormName { get; set; }
        public int FormId { get; set; }
        public string Description { get; set; }
        public virtual Importance Importance { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Section> Sections { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public string EmployeeId { get; set; }
        public string LastEvaluatorId { get; set; }

        public bool IsCompleted { get; set; }
    }
}

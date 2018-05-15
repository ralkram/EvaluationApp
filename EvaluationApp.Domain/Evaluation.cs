using EvaluationApp.Domain.EmployeeMockup;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationApp.Domain
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

        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public int EmployeeId { get; set; }
        public int LastEvaluatorId { get; set; }

        public bool IsCompleted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AppServices.EvaluationStatistics
{
    public class EvaluationFormStatistics
    {
        public int FormId { get; set; }
        public ICollection<SectionStatistics> SectionStatistics { get; set; }
    }
}

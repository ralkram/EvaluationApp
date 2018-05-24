using System;
using System.Collections.Generic;
using System.Text;

namespace AppServices.EvaluationStatistics
{
    public class ProgressForm
    {
        public int FormId { get; set; }
        public ICollection<ProgressSection> ProgressSections { get; set; }
    }
}

using DomainModel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppServices.EvaluationStatistics
{
    public class SectionStatistics
    {
        public string Name { get; set; }
        public EvaluationScale EvaluationScale { get; set; }
        public ICollection<SectionStatisticsEntry> SectionStatisticsEntries { get; set; }

    }
}

using DomainModel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppServices.EvaluationStatistics
{
    public class SectionStatisticsEntry
    {
        public DateTime Date { get; set; }
        public EvaluationScaleOption AverageGrade { get; set; }
    }
}

using DomainModel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppServices.EvaluationStatistics
{
    public class ProgressEvaluation
    {
        public DateTime Date { get; set; }
        public EvaluationScaleOption SectionAverageGrade { get; set; }
    }
}

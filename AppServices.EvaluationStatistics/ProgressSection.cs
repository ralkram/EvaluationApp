using DomainModel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppServices.EvaluationStatistics
{
    public class ProgressSection
    {
        public EvaluationScale EvaluationScale { get; set; }
        public EvaluationScaleOption SectionAverageGrade { get; set; }
    }
}

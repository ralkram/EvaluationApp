using DomainModel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppServices.EvaluationStatistics
{
    public class ProgressSection
    {
        public string Name { get; set; }
        public EvaluationScale EvaluationScale { get; set; }
        public ICollection<ProgressEvaluation> ProgressEvaluations { get; set; }

        public IDictionary<string, ProgressEvaluation> SectionGrades { get; set; }
    }
}

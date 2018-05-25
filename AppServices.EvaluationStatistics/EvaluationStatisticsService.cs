using AppServices.Evaluations;
using DomainModel.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AppServices.EvaluationStatistics
{
    public class EvaluationStatisticsService : IEvaluationStatisticsService
    {
        private IEvaluationsService evaluationsService;

        public EvaluationStatisticsService(IEvaluationsService evaluationsService)
        {
            this.evaluationsService = evaluationsService;
        }

        private EvaluationScaleOption GetAverageOnSection(Section section)
        {
            float averageGradeValuePrecise = 0;
            int gradesTakenIntoAccount = 0;

            foreach (Criteria criteria in section.Criteria)
            {
                if (criteria != null && criteria.Grade != null && criteria.Grade.Value != 0)
                {
                    gradesTakenIntoAccount++;
                    averageGradeValuePrecise = ((averageGradeValuePrecise * (gradesTakenIntoAccount - 1)) + criteria.Grade.Value) / gradesTakenIntoAccount;
                }
            }

            int averageGradeValue = (int)Math.Ceiling(averageGradeValuePrecise);

            EvaluationScale evaluationScale = section.EvaluationScale;
            EvaluationScaleOption sectionAverageGrade = evaluationScale.EvaluationScaleOptions.FirstOrDefault(eso => eso.Value == averageGradeValue);

            return sectionAverageGrade;
        }

        public EvaluationFormStatistics GetStatisticsForFormAndEmployee(int formId, int employeeId)
        {
            IEnumerable<Evaluation> evaluations = evaluationsService.GetCompletedEvaluationsForEmployee(employeeId).Where(e => e.FormId == formId);

            if (evaluations != null)
            {
                //EvaluationFormStatistics progressForm = new EvaluationFormStatistics { FormId = formId };

                //progressForm.SectionStatistics = new List<SectionStatistics>();

                //foreach (Section section in evaluations.First().Sections)
                //{
                //    SectionStatistics progressSection = new SectionStatistics { Name = section.Name, EvaluationScale = section.EvaluationScale };
                //    progressSection.SectionStatisticsEntries = new List<SectionStatisticsEntry>();


                //    var sectionEvaluations = evaluations.SelectMany(e => e.Sections.Where(s => s.Name.Equals(section.Name)));


                //    foreach (Section sectionEvaluation in sectionEvaluations)
                //    {


                //        SectionStatisticsEntry progressEvaluation = new SectionStatisticsEntry { Date = sectionEvaluation.Evaluation.ModifiedDate, AverageGrade = sectionAverageGrade };
                //        progressSection.SectionStatisticsEntries.Add(progressEvaluation);
                //    }
                //    progressForm.SectionStatistics.Add(progressSection);
                //}

                EvaluationFormStatistics progressForm = new EvaluationFormStatistics { FormId = formId };

                IDictionary<string, SectionStatistics> stats = new Dictionary<string, SectionStatistics>();

                SectionStatistics currentSectionStats;

                foreach (Evaluation evaluation in evaluations)
                {
                    foreach (Section currentSection in evaluation.Sections)
                    {
                        if (stats.ContainsKey(currentSection.Name))
                        {
                            currentSectionStats = stats[currentSection.Name];
                        }
                        else
                        {
                            currentSectionStats = new SectionStatistics { Name = currentSection.Name, EvaluationScale = currentSection.EvaluationScale };
                            currentSectionStats.SectionStatisticsEntries = new List<SectionStatisticsEntry>();
                            stats.Add(currentSection.Name, currentSectionStats);
                        }

                        currentSectionStats.SectionStatisticsEntries.Add(
                            new SectionStatisticsEntry
                            {
                                Date = evaluation.ModifiedDate,
                                AverageGrade = GetAverageOnSection(currentSection)
                            });
                    }
                }
                progressForm.SectionStatistics = stats.Values.ToList();

                return progressForm;
            }
            else
            {
                return null;
            }
        }
    }
}

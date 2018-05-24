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

        public ProgressForm GetStatisticsForFormAndEmployee(int formId, int employeeId)
        {
            IEnumerable<Evaluation> evaluations = evaluationsService.GetCompletedEvaluationsForEmployee(employeeId).Where(e => e.FormId == formId);

            if (evaluations != null)
            {
                ProgressForm progressForm = new ProgressForm { FormId = formId };

                progressForm.ProgressSections = new List<ProgressSection>();

                foreach (Section section in evaluations.First().Sections)
                {
                    ProgressSection progressSection = new ProgressSection { Name = section.Name, EvaluationScale = section.EvaluationScale };
                    progressSection.ProgressEvaluations = new List<ProgressEvaluation>();

                    var sectionEvaluations = evaluations.Select(e => e.Sections.Where(s => s.Name == section.Name));

                    foreach (Section sectionEvaluation in sectionEvaluations)
                    {

                        float averageGradeValuePrecise = 0;
                        int gradesTakenIntoAccount = 0;

                        foreach (Criteria criteria in sectionEvaluation.Criteria)
                        {
                            if (criteria.Grade.Value != 0)
                            {
                                gradesTakenIntoAccount++;
                                averageGradeValuePrecise = ((averageGradeValuePrecise * (gradesTakenIntoAccount - 1)) + criteria.Grade.Value) / gradesTakenIntoAccount;
                            }
                        }

                        int averageGradeValue = (int)Math.Ceiling(averageGradeValuePrecise);

                        EvaluationScale evaluationScale = sectionEvaluation.EvaluationScale;
                        EvaluationScaleOption sectionAverageGrade = evaluationScale.EvaluationScaleOptions.FirstOrDefault(eso => eso.Value == averageGradeValue);

                        ProgressEvaluation progressEvaluation = new ProgressEvaluation { Date = sectionEvaluation.Evaluation.ModifiedDate, SectionAverageGrade = sectionAverageGrade };
                        progressSection.ProgressEvaluations.Add(progressEvaluation);
                    }
                    progressForm.ProgressSections.Add(progressSection);
                }

                //progressForm.ProgressEvaluations = new List<ProgressEvaluation>();

                //foreach (Evaluation evaluation in evaluations)
                //{
                //    ProgressEvaluation progressEvaluation = new ProgressEvaluation();
                //    progressEvaluation.ProgressSections = new List<ProgressSection>();

                //    foreach (Section section in evaluation.Sections)
                //    {
                //        float averageGradeValuePrecise = 0;
                //        int gradesTakenIntoAccount = 0;

                //        foreach (Criteria criteria in section.Criteria)
                //        {
                //            if (criteria.Grade.Value != 0)
                //            {
                //                gradesTakenIntoAccount++;
                //                averageGradeValuePrecise = ((averageGradeValuePrecise * (gradesTakenIntoAccount - 1)) + criteria.Grade.Value) / gradesTakenIntoAccount;
                //            }
                //        }

                //        int averageGradeValue = (int)Math.Ceiling(averageGradeValuePrecise);

                //        EvaluationScale evaluationScale = section.EvaluationScale;
                //        EvaluationScaleOption sectionAverageGrade = evaluationScale.EvaluationScaleOptions.FirstOrDefault(eso => eso.Value == averageGradeValue);

                //        ProgressSection progressSection = new ProgressSection { EvaluationScale = evaluationScale, SectionAverageGrade = sectionAverageGrade };

                //        progressEvaluation.ProgressSections.Add(progressSection);
                //    }
                //    progressForm.ProgressEvaluations.Add(progressEvaluation);
                //}


                return progressForm;
            }
            else
            {
                return null;
            }
        }
    }
}

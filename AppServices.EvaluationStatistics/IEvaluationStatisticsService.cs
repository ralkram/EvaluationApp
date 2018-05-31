using System;

namespace AppServices.EvaluationStatistics
{
    public interface IEvaluationStatisticsService
    {
         EvaluationFormStatistics GetStatisticsForFormAndEmployee(int formId, string employeeUserName);
    }
}

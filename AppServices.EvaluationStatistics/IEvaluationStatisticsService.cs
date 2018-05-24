using System;

namespace AppServices.EvaluationStatistics
{
    public interface IEvaluationStatisticsService
    {
         ProgressForm GetStatisticsForFormAndEmployee(int formId, int employeeId);
    }
}

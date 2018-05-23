using System;

namespace AppServices.EvaluationStatistics
{
    public interface IEvaluationStatisticsService
    {
        public ProgressForm GetStatisticsForFormAndEmployee(int formId, int employeeId);
    }
}

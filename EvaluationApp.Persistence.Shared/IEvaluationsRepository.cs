using EvaluationApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationApp.Persistence.Shared
{
    public interface IEvaluationsRepository: IRepository<Evaluation>
    {
        IEnumerable<Evaluation> GetCompletedEvaluationsForEmployee(int employeeId);
        IEnumerable<Evaluation> GetInProgressEvaluationsForEmployee(int employeeId);
        //void StartEvaluation(Evaluation evaluation);
    }
}

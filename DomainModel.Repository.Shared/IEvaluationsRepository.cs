using DomainModel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Repository.Shared
{
    public interface IEvaluationsRepository: IRepository<Evaluation>
    {
        IEnumerable<Evaluation> GetCompletedEvaluationsForEvaluator(string evaluatorUserName);
        IEnumerable<Evaluation> GetInProgressEvaluationsForEvaluator(string evaluatorUserName);

        IEnumerable<Evaluation> GetCompletedEvaluationsForEmployee(string employeeUserName);
        IEnumerable<Evaluation> GetInProgressEvaluationsForEmployee(string employeeUserName);
    }
}

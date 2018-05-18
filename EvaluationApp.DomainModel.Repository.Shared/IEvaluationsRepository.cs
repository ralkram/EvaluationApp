﻿using EvaluationApp.DomainModel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationApp.DomainModel.Repository.Shared
{
    public interface IEvaluationsRepository: IRepository<Evaluation>
    {
        IEnumerable<Evaluation> GetCompletedEvaluationsForEvaluator(int evaluatorId);
        IEnumerable<Evaluation> GetInProgressEvaluationsForEvaluator(int evaluatorId);

        IEnumerable<Evaluation> GetCompletedEvaluationsForEmployee(int employeeId);
        IEnumerable<Evaluation> GetInProgressEvaluationsForEmployee(int employeeId);

        //void StartEvaluation(Evaluation evaluation);
    }
}

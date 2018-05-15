﻿using EvaluationApp.Domain;
using EvaluationApp.Domain.FormMockup;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationApp.Core.Shared
{
    public interface IEvaluationsService
    {
        Evaluation GetEvaluationById(int evaluationId);
        ICollection<Evaluation> GetInProgressEvaluationsForEvaluator(int evaluatorId);
        ICollection<Evaluation> GetCompletedEvaluationsForEvaluator(int evaluatorId);

        ICollection<Evaluation> GetInProgressEvaluationsForEmployee(int employeeId);
        ICollection<Evaluation> GetCompletedEvaluationsForEmployee(int employeeId);

        void StartEvaluation(Evaluation evaluation);
        void ContinueEvaluation(int evaluationId);
        Evaluation GetEvaluationForm();
    }
}

USE [aspnet-EvaluationDb];
GO
DELETE FROM EvaluationScaleOption where EvaluationScaleId IS NULL
GO
DELETE FROM Criteria Where SectionId in (SElect Id FROM Section where EvaluationId >= 11015)
GO
DELETE FROM Section Where EvaluationId >= 11015 
GO
DELETE FROM Evaluations Where Id >= 11015
GO
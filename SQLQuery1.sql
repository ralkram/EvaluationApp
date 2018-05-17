USE [aspnet-EvaluationDb]
GO

DELETE FROM Criteria
DELETE FROM Section
DELETE FROM Evaluations
DELETE FROM EvaluationScaleOption
DELETE FROM EvaluationScale


GO
SET IDENTITY_INSERT [dbo].[EvaluationScale] ON 
GO
INSERT [dbo].[EvaluationScale] ([Id], [Name], [Description]) VALUES (1, N'Basic 6 Point Rating Scale', NULL)
GO
INSERT [dbo].[EvaluationScale] ([Id], [Name], [Description]) VALUES (2, N'Basic 5 Point Effectiveness Rating Scale', NULL)
GO
SET IDENTITY_INSERT [dbo].[EvaluationScale] OFF
GO
SET IDENTITY_INSERT [dbo].[EvaluationScaleOption] ON 
GO
INSERT [dbo].[EvaluationScaleOption] ([Id], [Name], [Description], [Value], [EvaluationScaleId]) VALUES (2, N'Strongly
Disagree', NULL, 1, 1)
GO
INSERT [dbo].[EvaluationScaleOption] ([Id], [Name], [Description], [Value], [EvaluationScaleId]) VALUES (3, N'Disagree', NULL, 2, 1)
GO
INSERT [dbo].[EvaluationScaleOption] ([Id], [Name], [Description], [Value], [EvaluationScaleId]) VALUES (4, N'Slightly
Disagree', NULL, 3, 1)
GO
INSERT [dbo].[EvaluationScaleOption] ([Id], [Name], [Description], [Value], [EvaluationScaleId]) VALUES (5, N'Slightly
Agree', NULL, 4, 1)
GO
INSERT [dbo].[EvaluationScaleOption] ([Id], [Name], [Description], [Value], [EvaluationScaleId]) VALUES (6, N'Agree', NULL, 5, 1)
GO
INSERT [dbo].[EvaluationScaleOption] ([Id], [Name], [Description], [Value], [EvaluationScaleId]) VALUES (7, N'Strongly Agree', NULL, 6, 1)
GO
INSERT [dbo].[EvaluationScaleOption] ([Id], [Name], [Description], [Value], [EvaluationScaleId]) VALUES (8, N'Needs Significant Development', NULL, 1, 2)
GO
INSERT [dbo].[EvaluationScaleOption] ([Id], [Name], [Description], [Value], [EvaluationScaleId]) VALUES (9, N'Needs Some Development', NULL, 2, 2)
GO
INSERT [dbo].[EvaluationScaleOption] ([Id], [Name], [Description], [Value], [EvaluationScaleId]) VALUES (10, N'Capable and Effective', NULL, 3, 2)
GO
INSERT [dbo].[EvaluationScaleOption] ([Id], [Name], [Description], [Value], [EvaluationScaleId]) VALUES (11, N'Very Effective', NULL, 4, 2)
GO
INSERT [dbo].[EvaluationScaleOption] ([Id], [Name], [Description], [Value], [EvaluationScaleId]) VALUES (12, N'Not Observed', NULL, 0, 2)
GO
SET IDENTITY_INSERT [dbo].[EvaluationScaleOption] OFF
GO
SET IDENTITY_INSERT [dbo].[Evaluations] ON 
GO
INSERT [dbo].[Evaluations] ([Id], [EvaluationName], [FormName], [Description], [ImportanceId], [Status], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate], [EmployeeId], [LastEvaluatorId], [IsCompleted], [FormId]) VALUES (1, N'Core skills - May 2018', N'Philadelphia Project', N'Form to be used for evaluating skills specific for the Philadelphia Project', NULL, 1, 1, 3, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, 1, 1, 1)
GO
INSERT [dbo].[Evaluations] ([Id], [EvaluationName], [FormName], [Description], [ImportanceId], [Status], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate], [EmployeeId], [LastEvaluatorId], [IsCompleted], [FormId]) VALUES (8, N'Core skills - May 2018', N'Philadelphia Project', N'Form to be used for evaluating skills specific for the Philadelphia Project', NULL, 1, 1, 3, CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 2, 1, 1, 1)
GO
INSERT [dbo].[Evaluations] ([Id], [EvaluationName], [FormName], [Description], [ImportanceId], [Status], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate], [EmployeeId], [LastEvaluatorId], [IsCompleted], [FormId]) VALUES (9, N'Communication skills - May 2018', N'Communication Form', N'Form for evaluating basic communication skills within a team', NULL, 1, 1, 3, CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 1, 1, 1, 2)
GO
INSERT [dbo].[Evaluations] ([Id], [EvaluationName], [FormName], [Description], [ImportanceId], [Status], [CreatedBy], [ModifiedBy], [CreatedDate], [ModifiedDate], [EmployeeId], [LastEvaluatorId], [IsCompleted], [FormId]) VALUES (10, N'Communication skills - May 2018', N'Communication Form', N'Form for evaluating basic communication skills within a team', NULL, 1, 1, 3, CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 2, 1, 0, 2)
GO
SET IDENTITY_INSERT [dbo].[Evaluations] OFF
GO
SET IDENTITY_INSERT [dbo].[Section] ON 
GO
INSERT [dbo].[Section] ([Id], [Name], [Description], [EvaluationScaleId], [ModifiedDate], [CreatedBy], [ModifiedBy], [EvaluationId]) VALUES (2, N'Software Engineering', N'Basic Software Engineering Principles', 1, CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 3, 3, 1)
GO
INSERT [dbo].[Section] ([Id], [Name], [Description], [EvaluationScaleId], [ModifiedDate], [CreatedBy], [ModifiedBy], [EvaluationId]) VALUES (4, N'Programming', N'Basic Programming Principles', 1, CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 3, 3, 1)
GO
INSERT [dbo].[Section] ([Id], [Name], [Description], [EvaluationScaleId], [ModifiedDate], [CreatedBy], [ModifiedBy], [EvaluationId]) VALUES (10, N'Software Engineering', N'Basic Software Engineering Principles', 1, CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 3, 3, 8)
GO
INSERT [dbo].[Section] ([Id], [Name], [Description], [EvaluationScaleId], [ModifiedDate], [CreatedBy], [ModifiedBy], [EvaluationId]) VALUES (11, N'Teamwork Analysis', N'Teamwork Analysis', 2, CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 3, 3, 9)
GO
INSERT [dbo].[Section] ([Id], [Name], [Description], [EvaluationScaleId], [ModifiedDate], [CreatedBy], [ModifiedBy], [EvaluationId]) VALUES (12, N'Teamwork Analysis', N'Teamwork Analysis', 2, CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 3, 3, 10)
GO
INSERT [dbo].[Section] ([Id], [Name], [Description], [EvaluationScaleId], [ModifiedDate], [CreatedBy], [ModifiedBy], [EvaluationId]) VALUES (13, N'Listening', N'Listening', 2, CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 3, 3, 10)
GO
INSERT [dbo].[Section] ([Id], [Name], [Description], [EvaluationScaleId], [ModifiedDate], [CreatedBy], [ModifiedBy], [EvaluationId]) VALUES (14, N'Respectful', N'Respectful', 2, CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 3, 3, 10)
GO
INSERT [dbo].[Section] ([Id], [Name], [Description], [EvaluationScaleId], [ModifiedDate], [CreatedBy], [ModifiedBy], [EvaluationId]) VALUES (15, N'Reliable', N'Reliable', 2, CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 3, 3, 10)
GO
SET IDENTITY_INSERT [dbo].[Section] OFF
GO
SET IDENTITY_INSERT [dbo].[Criteria] ON 
GO
INSERT [dbo].[Criteria] ([Id], [Name], [ModifiedDate], [CreatedBy], [ModifiedBy], [GradeId], [SectionId]) VALUES (7, N'Naming + proper comments', CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 3, 3, 5, 2)
GO
INSERT [dbo].[Criteria] ([Id], [Name], [ModifiedDate], [CreatedBy], [ModifiedBy], [GradeId], [SectionId]) VALUES (14, N'Method Cohesion', CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 3, 3, 6, 2)
GO
INSERT [dbo].[Criteria] ([Id], [Name], [ModifiedDate], [CreatedBy], [ModifiedBy], [GradeId], [SectionId]) VALUES (15, N'Class Cohesion', CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 3, 3, 7, 2)
GO
INSERT [dbo].[Criteria] ([Id], [Name], [ModifiedDate], [CreatedBy], [ModifiedBy], [GradeId], [SectionId]) VALUES (16, N'Class Coupling', CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 3, 3, 5, 4)
GO
INSERT [dbo].[Criteria] ([Id], [Name], [ModifiedDate], [CreatedBy], [ModifiedBy], [GradeId], [SectionId]) VALUES (17, N'Open Close Criterion', CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 3, 3, 6, 4)
GO
INSERT [dbo].[Criteria] ([Id], [Name], [ModifiedDate], [CreatedBy], [ModifiedBy], [GradeId], [SectionId]) VALUES (18, N'Naming + proper comments', CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 3, 3, 5, 10)
GO
INSERT [dbo].[Criteria] ([Id], [Name], [ModifiedDate], [CreatedBy], [ModifiedBy], [GradeId], [SectionId]) VALUES (19, N'Method Cohesion', CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 3, 3, 6, 10)
GO
INSERT [dbo].[Criteria] ([Id], [Name], [ModifiedDate], [CreatedBy], [ModifiedBy], [GradeId], [SectionId]) VALUES (20, N'Patience', CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 3, 3, 4, 11)
GO
INSERT [dbo].[Criteria] ([Id], [Name], [ModifiedDate], [CreatedBy], [ModifiedBy], [GradeId], [SectionId]) VALUES (21, N'Involvement', CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 3, 3, 3, 11)
GO
INSERT [dbo].[Criteria] ([Id], [Name], [ModifiedDate], [CreatedBy], [ModifiedBy], [GradeId], [SectionId]) VALUES (22, N'Patience', CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 3, 3, 3, 12)
GO
INSERT [dbo].[Criteria] ([Id], [Name], [ModifiedDate], [CreatedBy], [ModifiedBy], [GradeId], [SectionId]) VALUES (23, N'Involvement', CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 3, 3, 4, 12)
GO
INSERT [dbo].[Criteria] ([Id], [Name], [ModifiedDate], [CreatedBy], [ModifiedBy], [GradeId], [SectionId]) VALUES (24, N'Ask questions for clarification', CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 3, 3, NULL, 13)
GO
INSERT [dbo].[Criteria] ([Id], [Name], [ModifiedDate], [CreatedBy], [ModifiedBy], [GradeId], [SectionId]) VALUES (25, N'Demonstrate concern', CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 3, 3, 4, 13)
GO
INSERT [dbo].[Criteria] ([Id], [Name], [ModifiedDate], [CreatedBy], [ModifiedBy], [GradeId], [SectionId]) VALUES (26, N'Using nonverbal cues', CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 3, 3, NULL, 13)
GO
INSERT [dbo].[Criteria] ([Id], [Name], [ModifiedDate], [CreatedBy], [ModifiedBy], [GradeId], [SectionId]) VALUES (27, N'Make eye contact', CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 3, 3, NULL, 14)
GO
INSERT [dbo].[Criteria] ([Id], [Name], [ModifiedDate], [CreatedBy], [ModifiedBy], [GradeId], [SectionId]) VALUES (28, N'Stick to deadlines', CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 3, 3, NULL, 15)
GO
INSERT [dbo].[Criteria] ([Id], [Name], [ModifiedDate], [CreatedBy], [ModifiedBy], [GradeId], [SectionId]) VALUES (29, N'Complete asigned tasks', CAST(N'2001-01-01T00:00:00.0000000' AS DateTime2), 3, 3, 4, 15)
GO
SET IDENTITY_INSERT [dbo].[Criteria] OFF
GO


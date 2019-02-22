CREATE TABLE [Valid].[LearnerEmploymentStatus] (
    [UKPRN]          INT          NOT NULL,
    [LearnRefNumber] VARCHAR (12) NOT NULL,
    [EmpStat]        INT          NOT NULL,
    [DateEmpStatApp] DATE         NOT NULL,
    [EmpId]          INT          NULL,
    [AgreeId]        VARCHAR (6)  NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [DateEmpStatApp] ASC)
);
GO

ALTER TABLE [Valid].[LearnerEmploymentStatus] ADD CONSTRAINT [FK_LearnerEmploymentStatus_Learner] FOREIGN KEY([UKPRN], [LearnRefNumber])
REFERENCES [Valid].[Learner] ([UKPRN], [LearnRefNumber])
GO

ALTER TABLE [Valid].[LearnerEmploymentStatus] CHECK CONSTRAINT [FK_LearnerEmploymentStatus_Learner]
GO
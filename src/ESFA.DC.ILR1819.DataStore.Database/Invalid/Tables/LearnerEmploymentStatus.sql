CREATE TABLE [Invalid].[LearnerEmploymentStatus] (
    [LearnerEmploymentStatus_Id] INT           NOT NULL,
    [Learner_Id]                 INT           NULL,
    [UKPRN]                      INT           NOT NULL,
    [LearnRefNumber]             VARCHAR (100) NULL,
    [EmpStat]                    BIGINT        NULL,
    [DateEmpStatApp]             DATE          NULL,
    [EmpId]                      BIGINT        NULL,
    [AgreeId]                    VARCHAR (100) NULL, 
    CONSTRAINT [PK_LearnerEmploymentStatus] PRIMARY KEY ([UKPRN] ASC,[LearnerEmploymentStatus_Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Parent_Invalid_LearnerEmploymentStatus]
    ON [Invalid].[LearnerEmploymentStatus]([Learner_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Invalid_LearnerEmploymentStatus]
    ON [Invalid].[LearnerEmploymentStatus]([LearnRefNumber] ASC, [DateEmpStatApp] ASC);


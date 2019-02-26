CREATE TABLE [Invalid].[LearnerFAM] (
    [LearnerFAM_Id]  INT            NOT NULL,
    [Learner_Id]     INT            NULL,
    [UKPRN]          INT            NOT NULL,
    [LearnRefNumber] VARCHAR (100)  NULL,
    [LearnFAMType]   VARCHAR (1000) NULL,
    [LearnFAMCode]   BIGINT         NULL, 
    CONSTRAINT [PK_LearnerFAM] PRIMARY KEY ([UKPRN] ASC, [LearnerFAM_Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Parent_Invalid_LearnerFAM]
    ON [Invalid].[LearnerFAM]([Learner_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Invalid_LearnerFAM]
    ON [Invalid].[LearnerFAM]([LearnRefNumber] ASC);


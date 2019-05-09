CREATE TABLE [Invalid].[LearnerHE] (
    [LearnerHE_Id]   INT            NOT NULL,
    [Learner_Id]     INT            NULL,
    [UKPRN]          INT            NOT NULL,
    [LearnRefNumber] VARCHAR (100)  NULL,
    [UCASPERID]      VARCHAR (1000) NULL,
    [TTACCOM]        BIGINT         NULL, 
    CONSTRAINT [PK_LearnerHE] PRIMARY KEY ([UKPRN] ASC, [LearnerHE_Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Parent_Invalid_LearnerHE]
    ON [Invalid].[LearnerHE]([Learner_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Invalid_LearnerHE]
    ON [Invalid].[LearnerHE]([LearnRefNumber] ASC);


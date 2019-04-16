CREATE TABLE [Invalid].[LLDDandHealthProblem] (
    [LLDDandHealthProblem_Id] INT           NOT NULL,
    [Learner_Id]              INT           NULL,
    [UKPRN]                   INT           NOT NULL,
    [LearnRefNumber]          VARCHAR (100) NULL,
    [LLDDCat]                 BIGINT        NULL,
    [PrimaryLLDD]             BIGINT        NULL, 
    CONSTRAINT [PK_LLDDandHealthProblem] PRIMARY KEY ([UKPRN] ASC, [LLDDandHealthProblem_Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Parent_Invalid_LLDDandHealthProblem]
    ON [Invalid].[LLDDandHealthProblem]([Learner_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Invalid_LLDDandHealthProblem]
    ON [Invalid].[LLDDandHealthProblem]([LearnRefNumber] ASC, [LLDDCat] ASC);


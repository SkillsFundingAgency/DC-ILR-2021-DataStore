CREATE TABLE [Valid].[LLDDandHealthProblem] (
    [UKPRN]          INT          NOT NULL,
    [LearnRefNumber] VARCHAR (12) NOT NULL,
    [LLDDCat]        INT          NOT NULL,
    [PrimaryLLDD]    INT          NULL,
    [LLDDandHealthProblem_ID] BIGINT NOT NULL, 
    PRIMARY KEY CLUSTERED ([UKPRN], [LearnRefNumber], [LLDDCat],[LLDDandHealthProblem_ID])
);
GO

ALTER TABLE [Valid].[LLDDandHealthProblem] ADD CONSTRAINT [FK_LLDDandHealthProblem_Learner] FOREIGN KEY([UKPRN], [LearnRefNumber])
REFERENCES [Valid].[Learner] ([UKPRN], [LearnRefNumber]);
GO

ALTER TABLE [Valid].[LLDDandHealthProblem] CHECK CONSTRAINT [FK_LLDDandHealthProblem_Learner];
GO
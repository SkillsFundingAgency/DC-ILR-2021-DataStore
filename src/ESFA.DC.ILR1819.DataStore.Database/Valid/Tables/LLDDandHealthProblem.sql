CREATE TABLE [Valid].[LLDDandHealthProblem] (
    [UKPRN]          INT          NOT NULL,
    [LearnRefNumber] VARCHAR (12) NOT NULL,
    [LLDDCat]        INT          NOT NULL,
    [PrimaryLLDD]    INT          NULL,
    [LLDDandHealthProblem_ID] BIGINT NOT NULL, 
    PRIMARY KEY CLUSTERED ([LLDDandHealthProblem_ID], [LLDDCat], [LearnRefNumber], [UKPRN])
);


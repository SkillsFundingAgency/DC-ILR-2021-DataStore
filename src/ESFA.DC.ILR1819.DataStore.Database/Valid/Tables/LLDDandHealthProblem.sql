CREATE TABLE [Valid].[LLDDandHealthProblem] (
    [UKPRN]          INT          NOT NULL,
    [LearnRefNumber] VARCHAR (12) NOT NULL,
    [LLDDCat]        INT          NOT NULL,
    [PrimaryLLDD]    INT          NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [LLDDCat] ASC)
);


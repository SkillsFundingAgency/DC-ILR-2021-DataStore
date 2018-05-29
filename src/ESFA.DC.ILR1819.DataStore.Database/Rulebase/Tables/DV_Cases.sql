CREATE TABLE [Rulebase].[DV_Cases] (
    [UKPRN]          INT          NOT NULL,
    [LearnRefNumber] VARCHAR (12) NOT NULL,
    [CaseData]       XML          NOT NULL, 
    CONSTRAINT [PK_DV_Cases] PRIMARY KEY ([UKPRN], [LearnRefNumber])
);


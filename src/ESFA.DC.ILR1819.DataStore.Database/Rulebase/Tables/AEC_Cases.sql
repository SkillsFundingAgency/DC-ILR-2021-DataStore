CREATE TABLE [Rulebase].[AEC_Cases] (
    [LearnRefNumber] VARCHAR (12) NOT NULL,
    [UKPRN]          INT          NOT NULL,
    [CaseData]       XML          NOT NULL, 
    CONSTRAINT [PK_AEC_Cases] PRIMARY KEY ([LearnRefNumber], [UKPRN])
);


CREATE TABLE [Rulebase].[ESF_Cases] (
    [UKPRN]          INT          NOT NULL,
    [LearnRefNumber] VARCHAR (12) NOT NULL,
    [CaseData]       XML          NOT NULL, 
    CONSTRAINT [PK_ESF_Cases] PRIMARY KEY ([UKPRN], [LearnRefNumber])
);


CREATE TABLE [Rulebase].[FM35_Cases] (
    [UKPRN]          INT          NOT NULL,
    [LearnRefNumber] VARCHAR (12) NOT NULL,
    [CaseData]       XML          NOT NULL,
    CONSTRAINT [PK_FM35_Cases] PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC)
);


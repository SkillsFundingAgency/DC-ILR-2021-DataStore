CREATE TABLE [Rulebase].[VAL_Cases] (
    [UKPRN]      INT NOT NULL,
    [Learner_Id] INT NOT NULL,
    [CaseData]   XML NOT NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [Learner_Id] ASC)
);


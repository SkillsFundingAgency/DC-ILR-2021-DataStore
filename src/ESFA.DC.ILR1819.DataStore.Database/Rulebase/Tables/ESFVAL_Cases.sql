CREATE TABLE [Rulebase].[ESFVAL_Cases] (
    [Learner_Id] INT NOT NULL,
    [UKPRN]      INT NULL,
    [CaseData]   XML NOT NULL,
    PRIMARY KEY CLUSTERED ([Learner_Id] ASC)
);


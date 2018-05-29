CREATE TABLE [Rulebase].[VALDP_Cases] (
    [UKPRN]                               INT NOT NULL,
    [LearnerDestinationAndProgression_Id] INT NOT NULL,
    [CaseData]                            XML NOT NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnerDestinationAndProgression_Id] ASC)
);


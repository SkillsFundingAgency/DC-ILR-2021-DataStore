CREATE TABLE [Rulebase].[AEC_Learner] (
    [UKPRN]                                         INT             NOT NULL,
    [LearnRefNumber]                                VARCHAR (12)    NOT NULL,
	[ULN]											BIGINT			NOT NULL
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC)
);
GO

ALTER TABLE [Rulebase].[AEC_Learner] ADD CONSTRAINT [FK_AECLearner_AECglobal] FOREIGN KEY([UKPRN])
REFERENCES [Rulebase].[AEC_global] ([UKPRN]);
GO

ALTER TABLE [Rulebase].[AEC_Learner] CHECK CONSTRAINT [FK_AECLearner_AECglobal]
GO
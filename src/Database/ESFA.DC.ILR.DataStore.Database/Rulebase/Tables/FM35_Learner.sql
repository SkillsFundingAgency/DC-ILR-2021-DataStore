CREATE TABLE [Rulebase].[FM35_Learner] (
    [UKPRN]                     INT             NOT NULL,
    [LearnRefNumber]            VARCHAR (12)    NOT NULL
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC)
);
GO

ALTER TABLE [Rulebase].[FM35_Learner] ADD CONSTRAINT [FK_FM35Learner_FM35global] FOREIGN KEY([UKPRN])
REFERENCES [Rulebase].[FM35_global] ([UKPRN]);
GO

ALTER TABLE [Rulebase].[FM35_Learner] CHECK CONSTRAINT [FK_FM35Learner_FM35global]
GO


ALTER TABLE [Rulebase].[FM35_Learner]  WITH NOCHECK ADD  CONSTRAINT [FK_FM35_Learner_ValidLearner] FOREIGN KEY([UKPRN], [LearnRefNumber])
REFERENCES [Valid].[Learner] ([UKPRN], [LearnRefNumber])
GO

ALTER TABLE [Rulebase].[FM35_Learner] CHECK CONSTRAINT [FK_FM35_Learner_ValidLearner]
GO

CREATE TABLE [Rulebase].[ALB_Learner] (
    [UKPRN]          INT          NOT NULL,
    [LearnRefNumber] VARCHAR (12) NOT NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC)
);
GO

ALTER TABLE [Rulebase].[ALB_Learner] ADD CONSTRAINT [FK_ALBLearner_ALBglobal] FOREIGN KEY([UKPRN])
REFERENCES [Rulebase].[ALB_global] ([UKPRN]);
GO

ALTER TABLE [Rulebase].[ALB_Learner] CHECK CONSTRAINT [FK_ALBLearner_ALBglobal]
GO


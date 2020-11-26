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

ALTER TABLE [Rulebase].[ALB_Learner]  WITH NOCHECK ADD  CONSTRAINT [FK_ALB_Learner_ValidLearner] FOREIGN KEY([UKPRN], [LearnRefNumber])
REFERENCES [Valid].[Learner] ([UKPRN], [LearnRefNumber])
GO

ALTER TABLE [Rulebase].[ALB_Learner] CHECK CONSTRAINT [FK_ALB_Learner_ValidLearner]
GO
  


CREATE TABLE [Rulebase].[ALB_Learner_Period] (
    [UKPRN]          INT          NOT NULL,
    [LearnRefNumber] VARCHAR (12) NOT NULL,
    [Period]         INT          NOT NULL,
    [ALBSeqNum]      INT          NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [Period] ASC)
);
GO

ALTER TABLE [Rulebase].[ALB_Learner_Period] ADD CONSTRAINT [FK_ALBLearnerPeriod_ALBLearner] FOREIGN KEY([UKPRN], [LearnRefNumber])
REFERENCES [Rulebase].[ALB_Learner] ([UKPRN], [LearnRefNumber]);
GO

ALTER TABLE [Rulebase].[ALB_Learner_Period] CHECK CONSTRAINT [FK_ALBLearnerPeriod_ALBLearner]


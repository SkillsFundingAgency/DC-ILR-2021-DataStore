﻿CREATE TABLE [Rulebase].[ESF_Learner] (
    [UKPRN]          INT          NOT NULL,
    [LearnRefNumber] VARCHAR (12) NOT NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC)
);
GO

ALTER TABLE [Rulebase].[ESF_Learner] ADD CONSTRAINT [FK_ESFLearner_ESFglobal] FOREIGN KEY([UKPRN])
REFERENCES [Rulebase].[ESF_global] ([UKPRN]);
GO

ALTER TABLE [Rulebase].[ESF_Learner] CHECK CONSTRAINT [FK_ESFLearner_ESFglobal]
GO

ALTER TABLE [Rulebase].[ESF_Learner]  WITH NOCHECK ADD  CONSTRAINT [FK_ESF_Learner_ValidLearner] FOREIGN KEY([UKPRN], [LearnRefNumber])
REFERENCES [Valid].[Learner] ([UKPRN], [LearnRefNumber])
GO

ALTER TABLE [Rulebase].[ESF_Learner] CHECK CONSTRAINT [FK_ESF_Learner_ValidLearner]
GO

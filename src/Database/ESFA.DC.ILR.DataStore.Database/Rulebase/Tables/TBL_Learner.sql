﻿CREATE TABLE [Rulebase].[TBL_Learner] (
    [UKPRN]                     INT             NOT NULL,
    [LearnRefNumber]            VARCHAR (12)    NOT NULL
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC)
);
GO

ALTER TABLE [Rulebase].[TBL_Learner] ADD CONSTRAINT [FK_TBLLearner_TBLglobal] FOREIGN KEY([UKPRN])
REFERENCES [Rulebase].[TBL_global] ([UKPRN]);
GO

ALTER TABLE [Rulebase].[TBL_Learner] CHECK CONSTRAINT [FK_TBLLearner_TBLglobal]
GO


ALTER TABLE [Rulebase].[TBL_Learner]  WITH NOCHECK ADD  CONSTRAINT [FK_TBL_Learner_ValidLearner] FOREIGN KEY([UKPRN], [LearnRefNumber])
REFERENCES [Valid].[Learner] ([UKPRN], [LearnRefNumber])
GO

ALTER TABLE [Rulebase].[TBL_Learner] CHECK CONSTRAINT [FK_TBL_Learner_ValidLearner]
GO
  

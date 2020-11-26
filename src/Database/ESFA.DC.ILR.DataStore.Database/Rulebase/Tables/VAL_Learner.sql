CREATE TABLE [Rulebase].[VAL_Learner] (
    [UKPRN]          INT          NOT NULL,
    [LearnRefNumber] VARCHAR (12) NOT NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC)
);
GO

ALTER TABLE [Rulebase].[VAL_Learner] ADD CONSTRAINT [VALLearner_VALglobal] FOREIGN KEY([UKPRN])
REFERENCES [Rulebase].[VAL_global] ([UKPRN]);
GO

ALTER TABLE [Rulebase].[VAL_Learner] CHECK CONSTRAINT [VALLearner_VALglobal]
GO
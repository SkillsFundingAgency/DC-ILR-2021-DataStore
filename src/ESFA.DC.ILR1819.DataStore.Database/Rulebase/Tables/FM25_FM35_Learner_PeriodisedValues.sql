CREATE TABLE [Rulebase].[FM25_FM35_Learner_PeriodisedValues] (
    [UKPRN]          INT             NOT NULL,
    [LearnRefNumber] VARCHAR (12)    NOT NULL,
    [AttributeName]  VARCHAR (100)   NOT NULL,
    [Period_1]       DECIMAL (15, 5) NULL,
    [Period_2]       DECIMAL (15, 5) NULL,
    [Period_3]       DECIMAL (15, 5) NULL,
    [Period_4]       DECIMAL (15, 5) NULL,
    [Period_5]       DECIMAL (15, 5) NULL,
    [Period_6]       DECIMAL (15, 5) NULL,
    [Period_7]       DECIMAL (15, 5) NULL,
    [Period_8]       DECIMAL (15, 5) NULL,
    [Period_9]       DECIMAL (15, 5) NULL,
    [Period_10]      DECIMAL (15, 5) NULL,
    [Period_11]      DECIMAL (15, 5) NULL,
    [Period_12]      DECIMAL (15, 5) NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [AttributeName] ASC), 
    CONSTRAINT [FK_FM25_FM35_Learner_PeriodisedValues_FM25_Learner] FOREIGN KEY ([UKPRN], [LearnRefNumber]) REFERENCES [Rulebase].[FM25_Learner]([UKPRN], [LearnRefNumber])
);
GO

ALTER TABLE [Rulebase].[FM25_FM35_Learner_PeriodisedValues] ADD CONSTRAINT [FK_FM25FM35LearnerPeriodisedValues_FM25FM35global] FOREIGN KEY([UKPRN])
REFERENCES [Rulebase].[FM25_FM35_global] ([UKPRN]);
GO

ALTER TABLE [Rulebase].[FM25_FM35_Learner_PeriodisedValues] CHECK CONSTRAINT [FK_FM25FM35LearnerPeriodisedValues_FM25FM35global]
GO
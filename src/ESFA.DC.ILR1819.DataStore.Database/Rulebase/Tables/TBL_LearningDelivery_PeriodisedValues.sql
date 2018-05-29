CREATE TABLE [Rulebase].[TBL_LearningDelivery_PeriodisedValues] (
    [UKPRN]          INT             NOT NULL,
    [LearnRefNumber] VARCHAR (12)    NOT NULL,
    [AimSeqNumber]   INT             NOT NULL,
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
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [AimSeqNumber] ASC, [AttributeName] ASC)
);


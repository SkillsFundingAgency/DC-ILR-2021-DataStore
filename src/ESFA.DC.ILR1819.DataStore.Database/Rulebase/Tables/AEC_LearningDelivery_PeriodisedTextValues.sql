CREATE TABLE [Rulebase].[AEC_LearningDelivery_PeriodisedTextValues] (
    [UKPRN]          INT           NOT NULL,
    [LearnRefNumber] VARCHAR (12)  NOT NULL,
    [AimSeqNumber]   INT           NOT NULL,
    [AttributeName]  VARCHAR (100) NOT NULL,
    [Period_1]       VARCHAR (255) NULL,
    [Period_2]       VARCHAR (255) NULL,
    [Period_3]       VARCHAR (255) NULL,
    [Period_4]       VARCHAR (255) NULL,
    [Period_5]       VARCHAR (255) NULL,
    [Period_6]       VARCHAR (255) NULL,
    [Period_7]       VARCHAR (255) NULL,
    [Period_8]       VARCHAR (255) NULL,
    [Period_9]       VARCHAR (255) NULL,
    [Period_10]      VARCHAR (255) NULL,
    [Period_11]      VARCHAR (255) NULL,
    [Period_12]      VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [AimSeqNumber] ASC, [AttributeName] ASC)
);


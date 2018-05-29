CREATE TABLE [Rulebase].[ESF_LearningDeliveryDeliverable_Period] (
    [UKPRN]                      INT             NOT NULL,
    [LearnRefNumber]             VARCHAR (12)    NOT NULL,
    [AimSeqNumber]               INT             NOT NULL,
    [DeliverableCode]            VARCHAR (5)     NOT NULL,
    [Period]                     INT             NOT NULL,
    [AchievementEarnings]        DECIMAL (10, 5) NULL,
    [AdditionalProgCostEarnings] DECIMAL (10, 5) NULL,
    [DeliverableVolume]          BIGINT          NULL,
    [ProgressionEarnings]        DECIMAL (10, 5) NULL,
    [ReportingVolume]            INT             NULL,
    [StartEarnings]              DECIMAL (10, 5) NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [AimSeqNumber] ASC, [DeliverableCode] ASC, [Period] ASC)
);


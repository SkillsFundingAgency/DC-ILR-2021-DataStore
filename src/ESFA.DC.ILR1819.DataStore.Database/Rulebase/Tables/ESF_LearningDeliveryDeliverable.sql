CREATE TABLE [Rulebase].[ESF_LearningDeliveryDeliverable] (
    [UKPRN]               INT             NOT NULL,
    [LearnRefNumber]      VARCHAR (12)    NOT NULL,
    [AimSeqNumber]        INT             NOT NULL,
    [DeliverableCode]     VARCHAR (5)     NOT NULL,
    [DeliverableUnitCost] DECIMAL (10, 5) NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [AimSeqNumber] ASC, [DeliverableCode] ASC)
);


CREATE TABLE [Rulebase].[ALB_LearningDelivery_Period] (
    [UKPRN]                   INT             NOT NULL,
    [LearnRefNumber]          VARCHAR (12)    NOT NULL,
    [AimSeqNumber]            INT             NOT NULL,
    [Period]                  INT             NOT NULL,
    [ALBCode]                 INT             NULL,
    [ALBSupportPayment]       DECIMAL (10, 5) NULL,
    [AreaUpliftBalPayment]    DECIMAL (10, 5) NULL,
    [AreaUpliftOnProgPayment] DECIMAL (10, 5) NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [AimSeqNumber] ASC, [Period] ASC)
);


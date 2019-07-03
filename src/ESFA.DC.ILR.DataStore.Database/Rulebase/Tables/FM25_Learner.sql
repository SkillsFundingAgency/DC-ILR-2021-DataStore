CREATE TABLE [Rulebase].[FM25_Learner] (
    [UKPRN]                     INT             NOT NULL,
    [LearnRefNumber]            VARCHAR (12)    NOT NULL,
    [AcadMonthPayment]          INT             NULL,
    [AcadProg]                  BIT             NULL,
    [ActualDaysILCurrYear]      INT             NULL,
    [AreaCostFact1618Hist]      DECIMAL (10, 5) NULL,
    [Block1DisadvUpliftNew]     DECIMAL (10, 5) NULL,
    [Block2DisadvElementsNew]   DECIMAL (10, 5) NULL,
    [ConditionOfFundingEnglish] VARCHAR (100)   NULL,
    [ConditionOfFundingMaths]   VARCHAR (100)   NULL,
    [CoreAimSeqNumber]          INT             NULL,
    [FullTimeEquiv]             DECIMAL (10, 5) NULL,
    [FundLine]                  VARCHAR (100)   NULL,
    [LearnerActEndDate]         DATE            NULL,
    [LearnerPlanEndDate]        DATE            NULL,
    [LearnerStartDate]          DATE            NULL,
    [NatRate]                   DECIMAL (10, 5) NULL,
    [OnProgPayment]             DECIMAL (10, 5) NULL,
    [PlannedDaysILCurrYear]     INT             NULL,
    [ProgWeightHist]            DECIMAL (10, 5) NULL,
    [ProgWeightNew]             DECIMAL (10, 5) NULL,
    [PrvDisadvPropnHist]        DECIMAL (10, 5) NULL,
    [PrvHistLrgProgPropn]       DECIMAL (10, 5) NULL,
    [PrvRetentFactHist]         DECIMAL (10, 5) NULL,
    [RateBand]                  VARCHAR (50)    NULL,
    [RetentNew]                 DECIMAL (10, 5) NULL,
    [StartFund]                 BIT             NULL,
    [ThresholdDays]             INT             NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC)
);
GO

ALTER TABLE [Rulebase].[FM25_Learner] ADD CONSTRAINT [FK_FM25Learner_FM25global] FOREIGN KEY([UKPRN])
REFERENCES [Rulebase].[FM25_global] ([UKPRN]);
GO

ALTER TABLE [Rulebase].[FM25_Learner] CHECK CONSTRAINT [FK_FM25Learner_FM25global]
GO
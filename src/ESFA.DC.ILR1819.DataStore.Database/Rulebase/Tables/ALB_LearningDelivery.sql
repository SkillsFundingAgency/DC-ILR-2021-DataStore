CREATE TABLE [Rulebase].[ALB_LearningDelivery] (
    [UKPRN]                   INT             NOT NULL,
    [LearnRefNumber]          VARCHAR (12)    NOT NULL,
    [AimSeqNumber]            INT             NOT NULL,
    [Achieved]                BIT             NULL,
    [ActualNumInstalm]        INT             NULL,
    [AdvLoan]                 BIT             NULL,
    [ApplicFactDate]          DATE            NULL,
    [ApplicProgWeightFact]    VARCHAR (1)     NULL,
    [AreaCostFactAdj]         DECIMAL (10, 5) NULL,
    [AreaCostInstalment]      DECIMAL (10, 5) NULL,
    [FundLine]                VARCHAR (50)    NULL,
    [FundStart]               BIT             NULL,
    [LiabilityDate]           DATE            NULL,
    [LoanBursAreaUplift]      BIT             NULL,
    [LoanBursSupp]            BIT             NULL,
    [OutstndNumOnProgInstalm] INT             NULL,
    [PlannedNumOnProgInstalm] INT             NULL,
    [WeightedRate]            DECIMAL (10, 4) NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [AimSeqNumber] ASC)
);


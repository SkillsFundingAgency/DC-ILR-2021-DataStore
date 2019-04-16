CREATE TABLE [Rulebase].[AEC_global] (
    [UKPRN]           INT           NOT NULL,
    [LARSVersion]     VARCHAR (100) NULL,
    [RulebaseVersion] VARCHAR (10)  NULL,
    [Year]            VARCHAR (4)   NULL, 
    CONSTRAINT [PK_AEC_global] PRIMARY KEY ([UKPRN])
);


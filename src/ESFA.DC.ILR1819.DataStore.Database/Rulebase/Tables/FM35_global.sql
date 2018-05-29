CREATE TABLE [Rulebase].[FM35_global] (
    [UKPRN]                       VARCHAR (8)   NOT NULL,
    [CurFundYr]                   VARCHAR (9)   NULL,
    [LARSVersion]                 VARCHAR (100) NULL,
    [OrgVersion]                  VARCHAR (100) NULL,
    [PostcodeDisadvantageVersion] VARCHAR (50)  NULL,
    [RulebaseVersion]             VARCHAR (10)  NULL,
    CONSTRAINT [PK_FM35_Global] PRIMARY KEY CLUSTERED ([UKPRN] ASC)
);


CREATE TABLE [Rulebase].[VAL_global] (
    [UKPRN]           INT          NOT NULL,
    [EmployerVersion] VARCHAR (50) NULL,
    [LARSVersion]     VARCHAR (50) NULL,
    [OrgVersion]      VARCHAR (50) NULL,
    [PostcodeVersion] VARCHAR (50) NULL,
    [RulebaseVersion] VARCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC)
);


CREATE TABLE [Rulebase].[VALDP_ValidationError] (
    [UKPRN]          INT            NOT NULL,
    [ErrorString]    VARCHAR (2000) NULL,
    [FieldValues]    VARCHAR (2000) NULL,
    [LearnRefNumber] VARCHAR (100)  NOT NULL,
    [RuleId]         VARCHAR (50)   NULL, 
    CONSTRAINT [PK_VALDP_ValidationError] PRIMARY KEY ([UKPRN], [LearnRefNumber])
);


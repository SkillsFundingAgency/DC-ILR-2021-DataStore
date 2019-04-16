CREATE TABLE [Rulebase].[VALFD_ValidationError] (
    [UKPRN]          INT            NOT NULL,
    [AimSeqNumber]   BIGINT         NOT NULL,
    [ErrorString]    VARCHAR (2000) NULL,
    [FieldValues]    VARCHAR (2000) NULL,
    [LearnRefNumber] VARCHAR (100)  NOT NULL,
    [RuleId]         VARCHAR (50)   NULL, 
    CONSTRAINT [PK_VALFD_ValidationError] PRIMARY KEY ([UKPRN], [AimSeqNumber], [LearnRefNumber])
);


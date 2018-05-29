CREATE TABLE [Valid].[LearnerHEFinancialSupport] (
    [UKPRN]          INT          NOT NULL,
    [LearnRefNumber] VARCHAR (12) NOT NULL,
    [FINTYPE]        INT          NOT NULL,
    [FINAMOUNT]      INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [FINTYPE] ASC)
);


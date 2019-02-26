CREATE TABLE [Rulebase].[ESF_DPOutcome] (
    [UKPRN]                       INT          NOT NULL,
    [LearnRefNumber]              VARCHAR (12) NOT NULL,
    [OutCode]                     INT          NOT NULL,
    [OutType]                     VARCHAR (30) NOT NULL,
    [OutStartDate]                DATE         NOT NULL,
    [OutcomeDateForProgression]   DATE         NULL,
    [PotentialESFProgressionType] BIT          NULL,
    [ProgressionType]             VARCHAR (50) NULL,
    [ReachedSixMonthPoint]        BIT          NULL,
    [ReachedThreeMonthPoint]      BIT          NULL,
    [ReachedTwelveMonthPoint]     BIT          NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [OutCode] ASC, [OutType] ASC, [OutStartDate] ASC)
);


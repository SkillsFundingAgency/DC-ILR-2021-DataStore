CREATE TABLE [DataLock].[ValidationError] (
    [Ukprn]                  BIGINT       NOT NULL,
    [LearnRefNumber]         VARCHAR (12) NOT NULL,
    [AimSeqNumber]           INT          NULL,
    [RuleId]                 VARCHAR (50) NOT NULL,
    [PriceEpisodeIdentifier] VARCHAR (25) NOT NULL,
    [CollectionPeriodName]   VARCHAR (8)  NOT NULL,
    [CollectionPeriodMonth]  INT          NOT NULL,
    [CollectionPeriodYear]   INT          NOT NULL, 
    CONSTRAINT [PK_ValidationError] PRIMARY KEY ([Ukprn], [LearnRefNumber], [RuleId], [PriceEpisodeIdentifier])
);


GO
CREATE NONCLUSTERED INDEX [IDX_ValidationError_UkPrn]
    ON [DataLock].[ValidationError]([Ukprn] ASC);


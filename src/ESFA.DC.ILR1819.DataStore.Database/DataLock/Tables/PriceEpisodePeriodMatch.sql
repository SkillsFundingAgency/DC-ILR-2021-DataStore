CREATE TABLE [DataLock].[PriceEpisodePeriodMatch] (
    [Ukprn]                  BIGINT       NOT NULL,
    [PriceEpisodeIdentifier] VARCHAR (25) NOT NULL,
    [LearnRefNumber]         VARCHAR (12) NOT NULL,
    [AimSeqNumber]           INT          NULL,
    [CommitmentId]           BIGINT       NOT NULL,
    [VersionId]              VARCHAR (25) NOT NULL,
    [Period]                 INT          NOT NULL,
    [Payable]                BIT          NOT NULL,
    [TransactionType]        INT          NOT NULL,
    [CollectionPeriodName]   VARCHAR (8)  NOT NULL,
    [CollectionPeriodMonth]  INT          NOT NULL,
    [CollectionPeriodYear]   INT          NOT NULL,
    [TransactionTypesFlag]   INT          NOT NULL, 
    CONSTRAINT [PK_PriceEpisodePeriodMatch] PRIMARY KEY ([Ukprn], [PriceEpisodeIdentifier], [LearnRefNumber], [VersionId], [Period], [TransactionTypesFlag])
);


GO
CREATE NONCLUSTERED INDEX [IDX_PriceEpisodePeriodMatch_UkPrn]
    ON [DataLock].[PriceEpisodePeriodMatch]([Ukprn] ASC);


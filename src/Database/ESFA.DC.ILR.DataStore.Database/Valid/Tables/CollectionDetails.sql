CREATE TABLE [Valid].[CollectionDetails] (
    [UKPRN]               INT         NOT NULL,
    [Collection]          VARCHAR (3) NOT NULL,
    [Year]                VARCHAR (4) NOT NULL,
    [FilePreparationDate] DATE        NULL, 
    CONSTRAINT [PK_CollectionDetails] PRIMARY KEY ([UKPRN], [Collection], [Year])
);


CREATE TABLE [dbo].[ProcessingData] (
    [Id]             BIGINT            IDENTITY (1, 1) NOT NULL,
    [UKPRN]          INT            NOT NULL,
    [FileDetailsID]  BIGINT            NOT NULL,
    [ProcessingStep] NVARCHAR (100) NOT NULL,
    [ExecutionTime]  NVARCHAR (20)  NOT NULL, 
    CONSTRAINT [PK_ProcessingData] PRIMARY KEY ([Id])
);


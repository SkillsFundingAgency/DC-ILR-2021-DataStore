CREATE TABLE [Valid].[DPOutcome] (
    [UKPRN]          INT          NOT NULL,
    [LearnRefNumber] VARCHAR (12) NOT NULL,
    [OutType]        VARCHAR (3)  NOT NULL,
    [OutCode]        INT          NOT NULL,
    [OutStartDate]   DATE         NOT NULL,
    [OutEndDate]     DATE         NULL,
    [OutCollDate]    DATE         NOT NULL, 
    CONSTRAINT [PK_DPOutcome] PRIMARY KEY ([UKPRN], [LearnRefNumber])
);


GO
CREATE NONCLUSTERED INDEX [IX_Valid_DPOutcome]
    ON [Valid].[DPOutcome]([UKPRN] ASC, [LearnRefNumber] ASC, [OutType] ASC, [OutCode] ASC, [OutStartDate] ASC);


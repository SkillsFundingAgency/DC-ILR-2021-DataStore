CREATE TABLE [Valid].[AppFinRecord] (
    [UKPRN]          INT          NOT NULL,
    [LearnRefNumber] VARCHAR (12) NOT NULL,
    [AimSeqNumber]   INT          NOT NULL,
    [AFinType]       VARCHAR (3)  NOT NULL,
    [AFinCode]       INT          NOT NULL,
    [AFinDate]       DATE         NOT NULL,
    [AFinAmount]     INT          NOT NULL, 
    CONSTRAINT [PK_AppFinRecord] PRIMARY KEY ([UKPRN], [LearnRefNumber], [AimSeqNumber], [AFinType], [AFinCode], [AFinDate])
);
GO

CREATE NONCLUSTERED INDEX [IX_Valid_AppFinRecord]
    ON [Valid].[AppFinRecord]([UKPRN] ASC, [LearnRefNumber] ASC, [AimSeqNumber] ASC, [AFinType] ASC);
GO

ALTER TABLE [Valid].[AppFinRecord] ADD CONSTRAINT [FK_AppFinRecord_LearningDelivery] FOREIGN KEY([UKPRN], [LearnRefNumber], [AimSeqNumber])
REFERENCES [Valid].[LearningDelivery] ([UKPRN], [LearnRefNumber], [AimSeqNumber])
GO

ALTER TABLE [Valid].[AppFinRecord] CHECK CONSTRAINT [FK_AppFinRecord_LearningDelivery]
GO

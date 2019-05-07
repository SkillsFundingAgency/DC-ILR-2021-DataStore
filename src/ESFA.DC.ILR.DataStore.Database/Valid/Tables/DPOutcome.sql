CREATE TABLE [Valid].[DPOutcome] (
    [UKPRN]          INT          NOT NULL,
    [LearnRefNumber] VARCHAR (12) NOT NULL,
    [OutType]        VARCHAR (3)  NOT NULL,
    [OutCode]        INT          NOT NULL,
    [OutStartDate]   DATE         NOT NULL,
    [OutEndDate]     DATE         NULL,
    [OutCollDate]    DATE         NOT NULL,
    CONSTRAINT [PK_DPOutcome] PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [OutType] ASC, [OutCode] ASC, [OutStartDate] ASC, [OutCollDate] ASC)
);
GO

ALTER TABLE [Valid].[DPOutcome] ADD CONSTRAINT [FK_DPOutcome_LearnerDestinationandProgression] FOREIGN KEY([UKPRN], [LearnRefNumber])
REFERENCES [Valid].[LearnerDestinationandProgression] ([UKPRN], [LearnRefNumber]);
GO

ALTER TABLE [Valid].[DPOutcome] CHECK CONSTRAINT [FK_DPOutcome_LearnerDestinationandProgression];
GO
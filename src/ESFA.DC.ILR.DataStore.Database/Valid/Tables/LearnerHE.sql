CREATE TABLE [Valid].[LearnerHE] (
    [UKPRN]          INT          NOT NULL,
    [LearnRefNumber] VARCHAR (12) NOT NULL,
    [UCASPERID]      VARCHAR (10) NULL,
    [TTACCOM]        INT          NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC)
);
GO

ALTER TABLE [Valid].[LearnerHE] ADD CONSTRAINT [FK_LearnerHE_Learner] FOREIGN KEY([UKPRN], [LearnRefNumber])
REFERENCES [Valid].[Learner] ([UKPRN], [LearnRefNumber]);
GO

ALTER TABLE [Valid].[LearnerHE] CHECK CONSTRAINT [FK_LearnerHE_Learner];
GO
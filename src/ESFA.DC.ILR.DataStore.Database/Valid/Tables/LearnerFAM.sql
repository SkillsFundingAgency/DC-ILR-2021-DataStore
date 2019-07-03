CREATE TABLE [Valid].[LearnerFAM] (
    [UKPRN]          INT          NOT NULL,
    [LearnRefNumber] VARCHAR (12) NOT NULL,
    [LearnFAMType]   VARCHAR (3)  NOT NULL,
    [LearnFAMCode]   INT          NOT NULL, 
    CONSTRAINT [PK_LearnerFAM] PRIMARY KEY ([LearnFAMCode], [LearnFAMType], [LearnRefNumber], [UKPRN])
);


GO
CREATE NONCLUSTERED INDEX [IX_Valid_LearnerFAM]
    ON [Valid].[LearnerFAM]([UKPRN] ASC, [LearnRefNumber] ASC);

GO
	ALTER TABLE [Valid].[LearnerFAM] ADD CONSTRAINT [FK_LearnerFAM_Learner] FOREIGN KEY([UKPRN], [LearnRefNumber])
REFERENCES [Valid].[Learner] ([UKPRN], [LearnRefNumber]);
GO

ALTER TABLE [Valid].[LearnerFAM] CHECK CONSTRAINT [FK_LearnerFAM_Learner]
GO
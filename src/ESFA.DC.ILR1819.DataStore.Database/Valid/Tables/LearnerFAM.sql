CREATE TABLE [Valid].[LearnerFAM] (
    [UKPRN]          INT          NOT NULL,
    [LearnRefNumber] VARCHAR (12) NOT NULL,
    [LearnFAMType]   VARCHAR (3)  NULL,
    [LearnFAMCode]   INT          NOT NULL, 
    CONSTRAINT [PK_LearnerFAM] PRIMARY KEY ([LearnRefNumber], [UKPRN], [LearnFAMCode])
);


GO
CREATE NONCLUSTERED INDEX [IX_Valid_LearnerFAM]
    ON [Valid].[LearnerFAM]([UKPRN] ASC, [LearnRefNumber] ASC);


CREATE TABLE [Valid].[LearnerHEFinancialSupport] (
    [UKPRN]          INT          NOT NULL,
    [LearnRefNumber] VARCHAR (12) NOT NULL,
    [FINTYPE]        INT          NOT NULL,
    [FINAMOUNT]      INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [FINTYPE] ASC)
);
GO

ALTER TABLE [Valid].[LearnerHEFinancialSupport] ADD CONSTRAINT [FK_LearnerHEFinancialSupport_LearnerHE] FOREIGN KEY([UKPRN], [LearnRefNumber])
REFERENCES [Valid].[LearnerHE] ([UKPRN], [LearnRefNumber]);
GO

ALTER TABLE [Valid].[LearnerHEFinancialSupport] CHECK CONSTRAINT [FK_LearnerHEFinancialSupport_LearnerHE];
GO

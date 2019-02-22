CREATE TABLE [Valid].[ContactPreference] (
    [UKPRN]          INT          NOT NULL,
    [LearnRefNumber] VARCHAR (12) NOT NULL,
    [ContPrefType]   VARCHAR (3)  NOT NULL,
    [ContPrefCode]   INT          NOT NULL,
    CONSTRAINT [PK_ContactPref] PRIMARY KEY CLUSTERED ([UKPRN] ASC, [LearnRefNumber] ASC, [ContPrefType] ASC, [ContPrefCode] ASC)
);
GO

CREATE NONCLUSTERED INDEX [IX_Valid_ContactPreference]
    ON [Valid].[ContactPreference]([LearnRefNumber] ASC, [ContPrefType] ASC);
GO

ALTER TABLE [Valid].[ContactPreference] ADD CONSTRAINT [FK_ContactPreference_Learner] FOREIGN KEY([UKPRN], [LearnRefNumber])
REFERENCES [Valid].[Learner] ([UKPRN], [LearnRefNumber]);
GO

ALTER TABLE [Valid].[ContactPreference] CHECK CONSTRAINT [FK_ContactPreference_Learner];
GO
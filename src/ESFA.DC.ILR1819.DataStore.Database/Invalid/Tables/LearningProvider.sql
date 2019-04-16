CREATE TABLE [Invalid].[LearningProvider] (
    [LearningProvider_Id] INT NOT NULL,
    [UKPRN]               INT NOT NULL, 
    CONSTRAINT [PK_LearningProvider] PRIMARY KEY ([UKPRN] ASC, [LearningProvider_Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Invalid_LearningProvider]
    ON [Invalid].[LearningProvider]([UKPRN] ASC);


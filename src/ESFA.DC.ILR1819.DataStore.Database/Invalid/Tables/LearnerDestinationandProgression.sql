CREATE TABLE [Invalid].[LearnerDestinationandProgression] (
    [LearnerDestinationandProgression_Id] INT           NOT NULL,
    [UKPRN]                               INT           NOT NULL,
    [LearnRefNumber]                      VARCHAR (100) NULL,
    [ULN]                                 BIGINT        NULL, 
    CONSTRAINT [PK_LearnerDestinationandProgression] PRIMARY KEY ([UKPRN] ASC,[LearnerDestinationandProgression_Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Invalid_LearnerDestinationandProgression]
    ON [Invalid].[LearnerDestinationandProgression]([LearnRefNumber] ASC);


CREATE TABLE [Invalid].[AppFinRecord] (
    [AppFinRecord_Id]     INT           NOT NULL,
    [UKPRN]               INT           NOT NULL,
    [LearningDelivery_Id] INT           NULL,
    [LearnRefNumber]      VARCHAR (100) NOT NULL,
    [AimSeqNumber]        BIGINT        NOT NULL,
    [AFinType]            VARCHAR (100) NOT NULL,
    [AFinCode]            BIGINT        NULL,
    [AFinDate]            DATE          NULL,
    [AFinAmount]          BIGINT        NULL, 
    CONSTRAINT [PK_AppFinRecord] PRIMARY KEY ([UKPRN] ASC, [AppFinRecord_Id] ASC) 
);


GO
CREATE NONCLUSTERED INDEX [IX_Parent_Invalid_AppFinRecord]
    ON [Invalid].[AppFinRecord]([LearningDelivery_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Invalid_AppFinRecord]
    ON [Invalid].[AppFinRecord]([LearnRefNumber] ASC, [AimSeqNumber] ASC, [AFinType] ASC);


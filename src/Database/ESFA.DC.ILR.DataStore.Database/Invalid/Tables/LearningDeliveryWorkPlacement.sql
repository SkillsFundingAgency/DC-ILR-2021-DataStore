CREATE TABLE [Invalid].[LearningDeliveryWorkPlacement] (
    [LearningDeliveryWorkPlacement_Id] INT           NOT NULL,
    [LearningDelivery_Id]              INT           NULL,
    [UKPRN]                            INT           NOT NULL,
    [LearnRefNumber]                   VARCHAR (100) NULL,
    [AimSeqNumber]                     BIGINT        NULL,
    [WorkPlaceStartDate]               DATE          NULL,
    [WorkPlaceEndDate]                 DATE          NULL,
    [WorkPlaceHours]                   BIGINT        NULL,
    [WorkPlaceMode]                    BIGINT        NULL,
    [WorkPlaceEmpId]                   BIGINT        NULL, 
    CONSTRAINT [PK_LearningDeliveryWorkPlacement] PRIMARY KEY ([UKPRN] ASC,[LearningDeliveryWorkPlacement_Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Parent_Invalid_LearningDeliveryWorkPlacement]
    ON [Invalid].[LearningDeliveryWorkPlacement]([LearningDelivery_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Invalid_LearningDeliveryWorkPlacement]
    ON [Invalid].[LearningDeliveryWorkPlacement]([LearnRefNumber] ASC, [AimSeqNumber] ASC, [WorkPlaceStartDate] ASC, [WorkPlaceMode] ASC, [WorkPlaceEmpId] ASC);


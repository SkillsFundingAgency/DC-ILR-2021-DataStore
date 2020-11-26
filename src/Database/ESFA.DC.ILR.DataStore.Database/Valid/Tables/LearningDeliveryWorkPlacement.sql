CREATE TABLE [Valid].[LearningDeliveryWorkPlacement] (
    [UKPRN]              INT          NOT NULL,
    [LearnRefNumber]     VARCHAR (12) NOT NULL,
    [AimSeqNumber]       INT          NOT NULL,
    [WorkPlaceStartDate] DATE         NOT NULL,
    [WorkPlaceEndDate]   DATE         NULL,
    [WorkPlaceHours]     INT          NULL,
    [WorkPlaceMode]      INT          NOT NULL,
    [WorkPlaceEmpId]     INT          NULL,
    CONSTRAINT [PK_LearningDeliveryWorkPlacement] PRIMARY KEY ([UKPRN], [LearnRefNumber], [AimSeqNumber], [WorkPlaceStartDate])
);
GO

CREATE NONCLUSTERED INDEX [IX_Valid_LearningDeliveryWorkPlacement]
    ON [Valid].[LearningDeliveryWorkPlacement]([UKPRN] ASC, [LearnRefNumber] ASC, [AimSeqNumber] ASC, [WorkPlaceStartDate] ASC, [WorkPlaceMode] ASC);
GO

ALTER TABLE [Valid].[LearningDeliveryWorkPlacement] ADD CONSTRAINT [FK_LearningDeliveryWorkPlacement_LearningDelivery] FOREIGN KEY([UKPRN], [LearnRefNumber], [AimSeqNumber])
REFERENCES [Valid].[LearningDelivery] ([UKPRN], [LearnRefNumber], [AimSeqNumber])
GO

ALTER TABLE [Valid].[LearningDeliveryWorkPlacement] CHECK CONSTRAINT [FK_LearningDeliveryWorkPlacement_LearningDelivery]
GO
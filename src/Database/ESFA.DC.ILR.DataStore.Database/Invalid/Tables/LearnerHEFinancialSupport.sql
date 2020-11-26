CREATE TABLE [Invalid].[LearnerHEFinancialSupport] (
    [LearnerHEFinancialSupport_Id] INT           NOT NULL,
    [LearnerHE_Id]                 INT           NULL,
    [UKPRN]                        INT           NOT NULL,
    [LearnRefNumber]               VARCHAR (100) NULL,
    [FINTYPE]                      BIGINT        NULL,
    [FINAMOUNT]                    BIGINT        NULL, 
    CONSTRAINT [PK_LearnerHEFinancialSupport] PRIMARY KEY ([UKPRN] ASC, [LearnerHEFinancialSupport_Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Parent_Invalid_LearnerHEFinancialSupport]
    ON [Invalid].[LearnerHEFinancialSupport]([LearnerHE_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Invalid_LearnerHEFinancialSupport]
    ON [Invalid].[LearnerHEFinancialSupport]([LearnRefNumber] ASC, [FINTYPE] ASC);


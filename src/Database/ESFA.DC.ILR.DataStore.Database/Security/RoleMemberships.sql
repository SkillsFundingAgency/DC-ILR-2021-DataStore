
GO
--ALTER ROLE [db_datareader] ADD MEMBER [ILR2021DataStore_RO_User];
GO
--ALTER ROLE [db_datawriter] ADD MEMBER [ILR2021DataStore_RW_User];
GO
--ALTER ROLE [db_datareader] ADD MEMBER [ILR2021DataStore_RW_User];
GO

ALTER ROLE [DataProcessing] ADD MEMBER [ILR2021DataStore_RW_User];
GO

ALTER ROLE [DataViewing] ADD MEMBER [ILR2021DataStore_RO_User];
GO
ALTER ROLE [DataViewing] ADD MEMBER [User_DSCI];
GO
ALTER ROLE [DataViewing] ADD MEMBER [MatchClaim_RO_User];
GO

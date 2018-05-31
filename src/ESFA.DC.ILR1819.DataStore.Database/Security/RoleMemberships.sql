--ALTER ROLE [db_owner] ADD MEMBER [SearchUser];

GO
ALTER ROLE [db_datareader] ADD MEMBER [ILR1819DataStore_RO_User];
GO
ALTER ROLE [db_datawriter] ADD MEMBER [ILR1819DataStore_RW_User];
GO
ALTER ROLE [db_datareader] ADD MEMBER [ILR1819DataStore_RW_User];
GO



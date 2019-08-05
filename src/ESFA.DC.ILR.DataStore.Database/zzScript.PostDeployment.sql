/*
Post-Deployment Script 
--------------------------------------------------------------------------------------
*/

-- Set ExtendedProperties fro DB.
	:r .\z.ExtendedProperties.sql
GO

REVOKE REFERENCES ON SCHEMA::[dbo] FROM [DataProcessor];
REVOKE REFERENCES ON SCHEMA::[Invalid] FROM [DataProcessor];
REVOKE REFERENCES ON SCHEMA::[Valid] FROM [DataProcessor];
REVOKE REFERENCES ON SCHEMA::[Rulebase] FROM [DataProcessor];
REVOKE REFERENCES ON SCHEMA::[DataLock] FROM [DataProcessor];
GO

REVOKE REFERENCES ON SCHEMA::[dbo] FROM [DataViewer];
REVOKE REFERENCES ON SCHEMA::[Invalid] FROM [DataViewer];
REVOKE REFERENCES ON SCHEMA::[Valid] FROM [DataViewer];
REVOKE REFERENCES ON SCHEMA::[Rulebase] FROM [DataViewer];
REVOKE REFERENCES ON SCHEMA::[DataLock] FROM [DataViewer];
GO

RAISERROR('		   Update User Account Passwords',10,1) WITH NOWAIT;
GO
ALTER ROLE [db_datareader] DROP MEMBER [User_DSCI];
GO
RAISERROR('			     RO User',10,1) WITH NOWAIT;
ALTER USER [ILR1920DataStore_RO_User] WITH PASSWORD = N'$(ROUserPassword)';
GO
RAISERROR('			     RW User',10,1) WITH NOWAIT;
ALTER USER [ILR1920DataStore_RW_User] WITH PASSWORD = N'$(RWUserPassword)';
GO
RAISERROR('			     DSCI User',10,1) WITH NOWAIT;
ALTER USER [User_DSCI] WITH PASSWORD = N'$(DSCIUserPassword)';
GO
RAISERROR('			     DSCI User',10,1) WITH NOWAIT;
ALTER USER [MatchClaim_RO_User] WITH PASSWORD = N'$(MatchClaimROPassword)';
GO
RAISERROR('Completed',10,1) WITH NOWAIT;
GO


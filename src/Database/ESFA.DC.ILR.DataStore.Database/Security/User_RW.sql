﻿CREATE USER [ILR2021DataStore_RW_User]
    WITH PASSWORD = N'$(RWUserPassword)';
GO

GRANT CONNECT TO [ILR2021DataStore_RW_User]

GO

CREATE TABLE [dbo].[VersionInfo] (
    [Version] INT  DEFAULT ((0)) NOT NULL,
    [Date]    DATE NOT NULL, 
    CONSTRAINT [PK_VersionInfo] PRIMARY KEY ([Version])
);


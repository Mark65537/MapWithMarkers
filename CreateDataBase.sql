CREATE DATABASE GMapDB
GO
CREATE TABLE [GMapDB].[dbo].[MarkersTable]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[latitude] text NOT NULL,
    [longitude] text NOT NULL	
)

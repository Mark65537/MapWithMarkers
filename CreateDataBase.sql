CREATE DATABASE GMapDB
GO
CREATE TABLE [GMapDB].[dbo].[MarkersTable]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[latitude] float NOT NULL,
    [longitude] float NOT NULL	
)
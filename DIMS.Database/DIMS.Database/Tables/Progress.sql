CREATE TABLE [dbo].[Progress]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [UserName] NCHAR(10) NULL, 
    [TaskName] NCHAR(10) NULL, 
    [TrackNote] NCHAR(10) NULL, 
    [TrackDate] DATE NULL
)

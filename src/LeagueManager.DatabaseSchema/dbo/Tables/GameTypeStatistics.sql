CREATE TABLE [dbo].[GameStatistics]
(
    [Id]        UNIQUEIDENTIFIER CONSTRAINT [DF_GameTypeStatistics_Id] DEFAULT (newsequentialid()) NOT NULL, 
	[GameTypeId] UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR(50) NOT NULL,
	[Type] VARCHAR(50) NOT NULL,
    CONSTRAINT [PK_GameStatistics] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_GameTypeStatistics_ToGameType] FOREIGN KEY ([GameTypeId]) REFERENCES [GameTypes]([Id]),
    CONSTRAINT [IX_GameStatistics_GameTypeId_Name] UNIQUE NONCLUSTERED ([GameTypeId] ASC, [Name] ASC)
)

CREATE TABLE [dbo].[GameTeamTimeStatistics]
(
    [Id]        UNIQUEIDENTIFIER CONSTRAINT [DF_GameTeamTimeStatistics_Id] DEFAULT (newsequentialid()) NOT NULL, 
    [GameTeamId] UNIQUEIDENTIFIER NOT NULL,
    [Name] VARCHAR(50) NOT NULL, 
    [Value] TIME NULL, 
    CONSTRAINT [FK_GameTeamTimeStatistics_ToGameTeamXref] FOREIGN KEY ([GameTeamId]) REFERENCES [GameTeamXref]([Id]),
    CONSTRAINT [IX_GameTeamTimeStatistics_GameTeamId_Name] UNIQUE NONCLUSTERED ([GameTeamId] ASC, [Name] ASC)
)

CREATE TABLE [dbo].[GameTeamIntegerStatistics]
(
    [Id]        UNIQUEIDENTIFIER CONSTRAINT [DF_GameTeamIntegerStatistics_Id] DEFAULT (newsequentialid()) NOT NULL, 
    [GameTeamId] UNIQUEIDENTIFIER NOT NULL,
    [Name] VARCHAR(50) NOT NULL, 
    [Value] INT NULL, 
    CONSTRAINT [FK_GameTeamIntegerStatistics_ToGameTeamXref] FOREIGN KEY ([GameTeamId]) REFERENCES [GameTeamXref]([Id]),
    CONSTRAINT [IX_GameTeamIntegerStatistics_GameTeamId_Name] UNIQUE NONCLUSTERED ([GameTeamId] ASC, [Name] ASC)
);

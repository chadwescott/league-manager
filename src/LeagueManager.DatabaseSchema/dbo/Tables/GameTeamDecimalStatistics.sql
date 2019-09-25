CREATE TABLE [dbo].[GameTeamDecimalStatistics]
(
    [Id]        UNIQUEIDENTIFIER CONSTRAINT [DF_GameTeamDecimalStatistics_Id] DEFAULT (newsequentialid()) NOT NULL, 
    [GameTeamId] UNIQUEIDENTIFIER NOT NULL,
    [Name] VARCHAR(50) NOT NULL, 
    [Value] FLOAT NULL, 
    CONSTRAINT [FK_GameTeamDecimalStatistics_ToGameTeamXref] FOREIGN KEY ([GameTeamId]) REFERENCES [GameTeamXref]([Id])
)

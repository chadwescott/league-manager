CREATE TABLE [dbo].[GameRounds]
(
    [Id]        UNIQUEIDENTIFIER CONSTRAINT [DF_GameRounds_Id] DEFAULT (newsequentialid()) NOT NULL, 
    [GameId] UNIQUEIDENTIFIER NOT NULL, 
    [Number] INT NOT NULL, 
    CONSTRAINT [PK_GameRounds] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_GameRounds_ToGames] FOREIGN KEY ([GameId]) REFERENCES [dbo].[Games] ([Id]),
    CONSTRAINT [IX_GameRounds_GameId_Number] UNIQUE NONCLUSTERED ([GameId] ASC, [Number] ASC)
)

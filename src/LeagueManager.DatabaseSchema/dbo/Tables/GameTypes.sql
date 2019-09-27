CREATE TABLE [dbo].[GameTypes]
(
    [Id]        UNIQUEIDENTIFIER CONSTRAINT [DF_GameTypes_Id] DEFAULT (newsequentialid()) NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [MinimumTeams] INT NOT NULL, 
    [MaximumTeams] INT NOT NULL, 
    [MinimumTeamSize] INT NOT NULL, 
    [MaximumTeamSize] INT NOT NULL, 
    [ScoreSystemId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [PK_GameTypes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Games_ToScoreSystems] FOREIGN KEY ([ScoreSystemId]) REFERENCES [dbo].[ScoreSystems] ([Id])
)

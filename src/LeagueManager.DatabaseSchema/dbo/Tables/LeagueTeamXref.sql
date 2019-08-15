CREATE TABLE [dbo].[LeagueTeamXref]
(
    [Id]       UNIQUEIDENTIFIER CONSTRAINT [DF_LeagueTeamXref_Id] DEFAULT (newsequentialid()) NOT NULL,
    [LeagueId]   UNIQUEIDENTIFIER NOT NULL,
    [TeamId]   UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_LeagueTeamXref] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LeagueTeamXref_Leagues] FOREIGN KEY ([LeagueId]) REFERENCES [dbo].[Leagues] ([Id]),
    CONSTRAINT [FK_LeagueTeamXref_Teams] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Teams] ([Id])
)


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_LeagueTeamXref]
    ON [dbo].[LeagueTeamXref]([LeagueId] ASC, [TeamId] ASC);


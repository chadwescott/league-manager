CREATE TABLE [dbo].[LeaguePlayerXref]
(
    [Id]       UNIQUEIDENTIFIER CONSTRAINT [DF_LeaguePlayerXref_Id] DEFAULT (newsequentialid()) NOT NULL,
    [LeagueId]   UNIQUEIDENTIFIER NOT NULL,
    [PlayerId]   UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_LeaguePlayerXref] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_LeaguePlayerXref_Leagues] FOREIGN KEY ([LeagueId]) REFERENCES [dbo].[Leagues] ([Id]),
    CONSTRAINT [FK_LeaguePlayerXref_Players] FOREIGN KEY ([PlayerId]) REFERENCES [dbo].[Players] ([Id])
)


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_LeaguePlayerXref]
    ON [dbo].[LeaguePlayerXref]([LeagueId] ASC, [PlayerId] ASC);


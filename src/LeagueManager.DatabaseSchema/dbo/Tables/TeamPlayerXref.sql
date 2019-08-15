CREATE TABLE [dbo].[TeamPlayerXref] (
    [Id]       UNIQUEIDENTIFIER CONSTRAINT [DF_TeamPlayers_Id] DEFAULT (newsequentialid()) NOT NULL,
    [TeamId]   UNIQUEIDENTIFIER NOT NULL,
    [PlayerId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_TeamPlayers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TeamPlayerXref_Players] FOREIGN KEY ([PlayerId]) REFERENCES [dbo].[Players] ([Id]),
    CONSTRAINT [FK_TeamPlayerXref_Teams] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Teams] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_TeamPlayers]
    ON [dbo].[TeamPlayerXref]([PlayerId] ASC, [TeamId] ASC);


CREATE TABLE [dbo].[TeamPlayers] (
    [Id]       UNIQUEIDENTIFIER CONSTRAINT [DF_TeamPlayers_Id] DEFAULT (newsequentialid()) NOT NULL,
    [TeamId]   UNIQUEIDENTIFIER NOT NULL,
    [PlayerId] UNIQUEIDENTIFIER NOT NULL,
    [NoShow]   BIT              CONSTRAINT [DF_TeamPlayers_NoShow] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_TeamPlayers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TeamPlayers_Players] FOREIGN KEY ([PlayerId]) REFERENCES [dbo].[Players] ([Id]),
    CONSTRAINT [FK_TeamPlayers_Teams] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Teams] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_TeamPlayers]
    ON [dbo].[TeamPlayers]([PlayerId] ASC, [TeamId] ASC);


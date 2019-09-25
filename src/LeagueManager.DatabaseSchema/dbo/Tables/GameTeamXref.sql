CREATE TABLE [dbo].[GameTeamXref] (
    [Id]       UNIQUEIDENTIFIER CONSTRAINT [DF_GameTeamXref_Id] DEFAULT (newsequentialid()) NOT NULL,
    [GameId]   UNIQUEIDENTIFIER NOT NULL,
    [TeamId]   UNIQUEIDENTIFIER NOT NULL,
    [Outcome]  CHAR (1)         NULL,
    CONSTRAINT [PK_GameTeamXref] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_GameTeamXref_Games] FOREIGN KEY ([GameId]) REFERENCES [dbo].[Games] ([Id]),
    CONSTRAINT [FK_GameTeamXref_Teams] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Teams] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_GameTeamXref]
    ON [dbo].[GameTeamXref]([GameId] ASC, [TeamId] ASC);


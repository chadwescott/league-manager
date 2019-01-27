CREATE TABLE [dbo].[GameTeamsXref] (
    [Id]       UNIQUEIDENTIFIER CONSTRAINT [DF_GameTeamsXref_Id] DEFAULT (newsequentialid()) NOT NULL,
    [GameId]   UNIQUEIDENTIFIER NOT NULL,
    [TeamId]   UNIQUEIDENTIFIER NOT NULL,
    [Score]    INT              NULL,
    [Outcome]  CHAR (1)         NULL,
    [Complete] BIT              CONSTRAINT [DF_GameTeamsXref_Complete] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_GameTeamsXref] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_GameTeamsXref_Games] FOREIGN KEY ([GameId]) REFERENCES [dbo].[Games] ([Id]),
    CONSTRAINT [FK_GameTeamsXref_Teams] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Teams] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_GameTeamsXref]
    ON [dbo].[GameTeamsXref]([GameId] ASC, [TeamId] ASC);


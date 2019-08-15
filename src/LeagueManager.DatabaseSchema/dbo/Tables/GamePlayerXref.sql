CREATE TABLE [dbo].[GamePlayerXref] (
    [Id]       UNIQUEIDENTIFIER CONSTRAINT [DF_GamePlayerXref_Id] DEFAULT (newsequentialid()) NOT NULL,
    [GameId]   UNIQUEIDENTIFIER NOT NULL,
    [PlayerId]   UNIQUEIDENTIFIER NOT NULL,
    [Score]    INT              NULL,
    [Outcome]  CHAR (1)         NULL,
    CONSTRAINT [PK_GamePlayerXref] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_GamePlayerXref_Games] FOREIGN KEY ([GameId]) REFERENCES [dbo].[Games] ([Id]),
    CONSTRAINT [FK_GamePlayerXref_Players] FOREIGN KEY ([PlayerId]) REFERENCES [dbo].[Players] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_GamePlayerXref]
    ON [dbo].[GamePlayerXref]([GameId] ASC, [PlayerId] ASC);


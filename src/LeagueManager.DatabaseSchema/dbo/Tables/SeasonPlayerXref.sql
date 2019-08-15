CREATE TABLE [dbo].[SeasonPlayerXref]
(
    [Id]       UNIQUEIDENTIFIER CONSTRAINT [DF_SeasonPlayerXref_Id] DEFAULT (newsequentialid()) NOT NULL,
    [SeasonId]   UNIQUEIDENTIFIER NOT NULL,
    [PlayerId]   UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_SeasonPlayerXref] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SeasonPlayerXref_Seasons] FOREIGN KEY ([SeasonId]) REFERENCES [dbo].[Seasons] ([Id]),
    CONSTRAINT [FK_SeasonPlayerXref_Players] FOREIGN KEY ([PlayerId]) REFERENCES [dbo].[Players] ([Id])
)


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SeasonPlayerXref]
    ON [dbo].[SeasonPlayerXref]([SeasonId] ASC, [PlayerId] ASC);


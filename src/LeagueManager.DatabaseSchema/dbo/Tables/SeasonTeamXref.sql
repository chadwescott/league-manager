CREATE TABLE [dbo].[SeasonTeamXref]
(
    [Id]       UNIQUEIDENTIFIER CONSTRAINT [DF_SeasonTeamXref_Id] DEFAULT (newsequentialid()) NOT NULL,
    [SeasonId]   UNIQUEIDENTIFIER NOT NULL,
    [TeamId]   UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_SeasonTeamXref] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SeasonTeamXref_Seasons] FOREIGN KEY ([SeasonId]) REFERENCES [dbo].[Seasons] ([Id]),
    CONSTRAINT [FK_SeasonTeamXref_Teams] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Teams] ([Id])
)


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SeasonTeamXref]
    ON [dbo].[SeasonTeamXref]([SeasonId] ASC, [TeamId] ASC);


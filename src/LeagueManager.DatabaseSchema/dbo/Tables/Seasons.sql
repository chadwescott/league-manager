CREATE TABLE [dbo].[Seasons] (
    [Id]        UNIQUEIDENTIFIER CONSTRAINT [DF_Seasons_Id] DEFAULT (newsequentialid()) NOT NULL,
    [LeagueId]  UNIQUEIDENTIFIER NOT NULL,
    [Name]      NVARCHAR (100)   NOT NULL,
    [SortOrder] INT              NOT NULL,
    CONSTRAINT [PK__Seasons__3214EC070EB4476C] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Seasons_ToLeagues] FOREIGN KEY ([LeagueId]) REFERENCES [dbo].[Leagues] ([Id]),
    CONSTRAINT [IX_Seasons_LeagueId_SortOrder] UNIQUE NONCLUSTERED ([LeagueId] ASC, [SortOrder] ASC)
);





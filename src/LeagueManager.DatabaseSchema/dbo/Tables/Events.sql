CREATE TABLE [dbo].[Events] (
    [Id]        UNIQUEIDENTIFIER CONSTRAINT [DF_Events_Id] DEFAULT (newsequentialid()) NOT NULL,
    [LeagueId]  UNIQUEIDENTIFIER NULL,
    [SeasonId]  UNIQUEIDENTIFIER NULL,
    [Name]      VARCHAR (200)    NOT NULL,
    [StartTime] DATETIME         NOT NULL,
    CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Events_Leagues] FOREIGN KEY ([LeagueId]) REFERENCES [dbo].[Leagues] ([Id]),
    CONSTRAINT [FK_Events_Seasons] FOREIGN KEY ([SeasonId]) REFERENCES [dbo].[Seasons] ([Id])
);






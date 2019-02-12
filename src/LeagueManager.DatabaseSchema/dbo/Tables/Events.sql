CREATE TABLE [dbo].[Events] (
    [Id]        UNIQUEIDENTIFIER CONSTRAINT [DF_Events_Id] DEFAULT (newsequentialid()) NOT NULL,
    [SeasonId]  UNIQUEIDENTIFIER NOT NULL,
    [Name]      VARCHAR (200)    NOT NULL,
    [StartTime] DATETIME         NOT NULL,
    CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Events_Seasons] FOREIGN KEY ([SeasonId]) REFERENCES [dbo].[Seasons] ([Id])
);






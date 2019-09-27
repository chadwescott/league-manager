CREATE TABLE [dbo].[Games] (
    [Id]        UNIQUEIDENTIFIER CONSTRAINT [DF_Games_Id] DEFAULT (newsequentialid()) NOT NULL,
    [GameTypeId]   UNIQUEIDENTIFIER NULL,
    [EventId]   UNIQUEIDENTIFIER NULL,
    [Number]    INT              NOT NULL,
    [StartTime] DATETIME         NULL,
    [Complete] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK__Games] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Games_ToGameTypes] FOREIGN KEY ([GameTypeId]) REFERENCES [dbo].[GameTypes] ([Id]),
    CONSTRAINT [FK_Games_ToEvents] FOREIGN KEY ([EventId]) REFERENCES [dbo].[Events] ([Id])
);

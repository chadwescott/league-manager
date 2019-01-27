CREATE TABLE [dbo].[Games] (
    [Id]        UNIQUEIDENTIFIER DEFAULT (newsequentialid()) NOT NULL,
    [EventId]   UNIQUEIDENTIFIER NOT NULL,
    [Number]    INT              NOT NULL,
    [StartTime] DATETIME         NULL,
    CONSTRAINT [PK__Games] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Games_ToEvents] FOREIGN KEY ([EventId]) REFERENCES [dbo].[Events] ([Id])
);



GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Games_EventId_Number]
    ON [dbo].[Games]([EventId] ASC, [Number] ASC);


CREATE TABLE [dbo].[Sessions] (
    [Id]        UNIQUEIDENTIFIER CONSTRAINT [DF_Games_Id] DEFAULT (newsequentialid()) NOT NULL,
    [DayOfWeek] VARCHAR (10)     NOT NULL,
    [StartTime] DATETIME         NOT NULL,
    CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED ([Id] ASC)
);


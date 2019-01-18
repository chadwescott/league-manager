CREATE TABLE [dbo].[Events] (
    [Id]        UNIQUEIDENTIFIER CONSTRAINT [DF_Games_Id] DEFAULT (newsequentialid()) NOT NULL,
    [Name] VARCHAR (200)     NOT NULL,
    [StartTime] DATETIME         NOT NULL,
    CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED ([Id] ASC)
);


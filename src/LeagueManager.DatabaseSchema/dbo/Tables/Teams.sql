CREATE TABLE [dbo].[Teams] (
    [Id]         UNIQUEIDENTIFIER CONSTRAINT [DF_GamePlayersXref_Id] DEFAULT (newsequentialid()) NOT NULL,
    [EventId]    UNIQUEIDENTIFIER NOT NULL,
    [Name]       VARCHAR (50)     NULL,
    [TeamNumber] INT              NOT NULL,
    [Wins]       INT              CONSTRAINT [DF_Teams_Wins] DEFAULT ((0)) NOT NULL,
    [Losses]     INT              CONSTRAINT [DF_Teams_Losses] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_GamePlayersXref] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Teams_Events] FOREIGN KEY ([EventId]) REFERENCES [dbo].[Events] ([Id])
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Teams]
    ON [dbo].[Teams]([EventId] ASC, [TeamNumber] ASC);


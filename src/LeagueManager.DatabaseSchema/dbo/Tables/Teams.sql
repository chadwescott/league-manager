CREATE TABLE [dbo].[Teams] (
    [Id]         UNIQUEIDENTIFIER CONSTRAINT [DF_GamePlayersXref_Id] DEFAULT (newsequentialid()) NOT NULL,
    [SessionId]  UNIQUEIDENTIFIER NOT NULL,
    [TeamNumber] INT              NOT NULL,
    [Wins]       INT              NULL,
    [Losses]     INT              NULL,
    CONSTRAINT [PK_GamePlayersXref] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Teams_Sessions] FOREIGN KEY ([SessionId]) REFERENCES [dbo].[Sessions] ([Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Teams]
    ON [dbo].[Teams]([SessionId] ASC, [TeamNumber] ASC);


CREATE TABLE [dbo].[Teams] (
    [Id]         UNIQUEIDENTIFIER CONSTRAINT [DF_GamePlayersXref_Id] DEFAULT (newsequentialid()) NOT NULL,
    [Name]       VARCHAR (50)     NULL,
    CONSTRAINT [PK_GamePlayersXref] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO


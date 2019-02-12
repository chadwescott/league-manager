CREATE TABLE [dbo].[Leagues] (
    [Id]   UNIQUEIDENTIFIER CONSTRAINT [DF_Leagues_Id] DEFAULT (newsequentialid()) NOT NULL,
    [Name] NVARCHAR (100)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);



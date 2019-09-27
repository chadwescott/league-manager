CREATE TABLE [dbo].[ScoreSystems]
(
    [Id]        UNIQUEIDENTIFIER CONSTRAINT [DF_ScoreSystems_Id] DEFAULT (newsequentialid()) NOT NULL, 
    [Name] VARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_ScoreSystems] PRIMARY KEY ([Id]), 
)

GO

CREATE UNIQUE INDEX [IX_ScoreSystems_Name] ON [dbo].[ScoreSystems] ([Name])

CREATE TABLE [dbo].[Seasons]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newsequentialid(), 
    [LeagueId] UNIQUEIDENTIFIER NOT NULL , 
    [Name] NVARCHAR(100) NOT NULL, 
    CONSTRAINT [FK_Seasons_ToLeagues] FOREIGN KEY ([LeagueId]) REFERENCES [Leagues]([Id])
)

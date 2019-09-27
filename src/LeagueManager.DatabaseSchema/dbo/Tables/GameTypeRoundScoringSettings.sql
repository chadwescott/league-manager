CREATE TABLE [dbo].[GameTypeRoundSettings]
(
    [Id]        UNIQUEIDENTIFIER CONSTRAINT [DF_GameTypeRoundettings_Id] DEFAULT (newsequentialid()) NOT NULL, 
    [GameTypeId] UNIQUEIDENTIFIER NOT NULL,
    [RoundLabel] NVARCHAR(50) NOT NULL, 
    [RoundLimit] INT NULL, 
    CONSTRAINT [PK_GameTypeRoundSettings] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_GameTypeRoundSettings_ToGameType] FOREIGN KEY ([GameTypeId]) REFERENCES [GameTypes]([Id]),
    CONSTRAINT [IX_GameTypeRoundSettingss_GameTypeId] UNIQUE NONCLUSTERED ([GameTypeId] ASC)
)

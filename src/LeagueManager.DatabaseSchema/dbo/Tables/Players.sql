CREATE TABLE [dbo].[Players] (
    [Id]        UNIQUEIDENTIFIER CONSTRAINT [DF_Table_1_id] DEFAULT (newsequentialid()) NOT NULL,
    [FirstName] VARCHAR (50)     NULL,
    [LastName]  VARCHAR (50)     NOT NULL,
    [Nickname]  VARCHAR (50)     NULL,
    [Email]     NVARCHAR (255)   NULL,
    CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Players]
    ON [dbo].[Players]([FirstName] ASC, [LastName] ASC, [Nickname] ASC);


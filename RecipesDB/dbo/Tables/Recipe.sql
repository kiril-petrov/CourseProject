CREATE TABLE [dbo].[Recipe] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (200) NOT NULL,
    [Description] TEXT           NOT NULL,
    [ChefID]      INT            NOT NULL,
    CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Recipe_Chef] FOREIGN KEY ([ChefID]) REFERENCES [dbo].[Chef] ([ID]) ON DELETE CASCADE
);


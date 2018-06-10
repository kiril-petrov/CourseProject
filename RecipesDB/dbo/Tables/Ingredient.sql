CREATE TABLE [dbo].[Ingredient] (
    [ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Ingredients] PRIMARY KEY CLUSTERED ([ID] ASC)
);


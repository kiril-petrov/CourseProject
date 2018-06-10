CREATE TABLE [dbo].[IngredientLinks] (
    [RecipeID]     INT           NOT NULL,
    [IngredientID] INT           NOT NULL,
    [Amount]       NVARCHAR (50) NULL,
    CONSTRAINT [PK_IngredientLinks] PRIMARY KEY CLUSTERED ([RecipeID] ASC, [IngredientID] ASC),
    CONSTRAINT [FK_IngredientLinks_Ingredient] FOREIGN KEY ([IngredientID]) REFERENCES [dbo].[Ingredient] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_IngredientLinks_Recipe] FOREIGN KEY ([RecipeID]) REFERENCES [dbo].[Recipe] ([ID]) ON DELETE CASCADE
);


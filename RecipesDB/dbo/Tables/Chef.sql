﻿CREATE TABLE [dbo].[Chef] (
    [ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Chefs] PRIMARY KEY CLUSTERED ([ID] ASC)
);


CREATE TABLE [dbo].[Product] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [Name]              VARCHAR (100) NOT NULL,
    [Description]       VARCHAR (400) NOT NULL,
    [Price]             INT           NOT NULL,
    [Image]             VARCHAR (500) NOT NULL,
    [SizeId]            INT           NOT NULL,
    [ProductCategoryId] INT           NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Product_ProductCategory] FOREIGN KEY ([ProductCategoryId]) REFERENCES [dbo].[ProductCategory] ([Id]),
    CONSTRAINT [FK_Product_Size] FOREIGN KEY ([SizeId]) REFERENCES [dbo].[Size] ([Id])
);




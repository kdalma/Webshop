CREATE TABLE [dbo].[ProductPurchase] (
    [PurchaseId] INT NOT NULL,
    [ProductId]  INT NOT NULL,
    CONSTRAINT [PK_ProductPurchase] PRIMARY KEY CLUSTERED ([PurchaseId] ASC, [ProductId] ASC),
    CONSTRAINT [FK_ProductPurchase_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]),
    CONSTRAINT [FK_ProductPurchase_Purchase] FOREIGN KEY ([PurchaseId]) REFERENCES [dbo].[Purchase] ([Id])
);




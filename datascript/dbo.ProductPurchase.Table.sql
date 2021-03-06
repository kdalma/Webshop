USE [WebshopDB]
GO
/****** Object:  Table [dbo].[ProductPurchase]    Script Date: 2018. 06. 12. 12:56:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductPurchase](
	[PurchaseId] [int] NOT NULL,
	[ProductId] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProductPurchase]  WITH CHECK ADD  CONSTRAINT [FK_ProductPurchase_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductPurchase] CHECK CONSTRAINT [FK_ProductPurchase_Product]
GO
ALTER TABLE [dbo].[ProductPurchase]  WITH CHECK ADD  CONSTRAINT [FK_ProductPurchase_Purchase] FOREIGN KEY([PurchaseId])
REFERENCES [dbo].[Purchase] ([Id])
GO
ALTER TABLE [dbo].[ProductPurchase] CHECK CONSTRAINT [FK_ProductPurchase_Purchase]
GO

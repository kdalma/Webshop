USE [WebshopDB]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 2018. 06. 12. 12:56:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

INSERT [dbo].[ProductCategory] ([Id], [Name]) VALUES (10, N'Dzsekik és kabátok')
INSERT [dbo].[ProductCategory] ([Id], [Name]) VALUES (13, N'Ingek és blúzok')
INSERT [dbo].[ProductCategory] ([Id], [Name]) VALUES (14, N'Felsők')
INSERT [dbo].[ProductCategory] ([Id], [Name]) VALUES (15, N'Ruhák')
INSERT [dbo].[ProductCategory] ([Id], [Name]) VALUES (16, N'Szoknyák')
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF

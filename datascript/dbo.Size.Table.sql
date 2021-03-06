USE [WebshopDB]
GO
/****** Object:  Table [dbo].[Size]    Script Date: 2018. 06. 12. 12:56:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Size](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](5) NOT NULL,
 CONSTRAINT [PK_Size] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Size] ON 

INSERT [dbo].[Size] ([Id], [Value]) VALUES (1, N'XS')
INSERT [dbo].[Size] ([Id], [Value]) VALUES (2, N'S')
INSERT [dbo].[Size] ([Id], [Value]) VALUES (3, N'M')
INSERT [dbo].[Size] ([Id], [Value]) VALUES (4, N'L')
INSERT [dbo].[Size] ([Id], [Value]) VALUES (5, N'XL')
SET IDENTITY_INSERT [dbo].[Size] OFF

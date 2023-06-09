USE [QuanLiQuanAn]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 3/29/2023 9:58:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[username] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[Phone] [nchar](10) NULL,
	[Role] [int] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 3/29/2023 9:58:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateCheckIn] [datetime2](3) NULL,
	[DateCheckOut] [datetime2](3) NULL,
	[IdTable] [int] NULL,
	[TotalPrice] [int] NULL,
	[Phone] [nchar](10) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillInfo]    Script Date: 3/29/2023 9:58:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdBill] [int] NULL,
	[IdFood] [int] NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_BillInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 3/29/2023 9:58:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Category] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Food]    Script Date: 3/29/2023 9:58:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IdCate] [int] NULL,
	[Price] [int] NULL,
 CONSTRAINT [PK_Food] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableFood]    Script Date: 3/29/2023 9:58:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableFood](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_TableFood] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([Id], [Name], [username], [password], [Phone], [Role]) VALUES (1, N'Le Van Duc', N'mra', N'123', N'0919988340', 1)
INSERT [dbo].[Account] ([Id], [Name], [username], [password], [Phone], [Role]) VALUES (2, N'Anh Duc', N'mrb', N'123', N'0919988341', 2)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([Id], [DateCheckIn], [DateCheckOut], [IdTable], [TotalPrice], [Phone], [Status]) VALUES (37, CAST(N'2023-03-29T09:42:59.4590000' AS DateTime2), CAST(N'2023-03-29T09:43:56.3300000' AS DateTime2), 1, 1290000, N'0919988340', 1)
INSERT [dbo].[Bill] ([Id], [DateCheckIn], [DateCheckOut], [IdTable], [TotalPrice], [Phone], [Status]) VALUES (38, CAST(N'2023-03-29T09:42:59.0000000' AS DateTime2), CAST(N'2023-03-29T09:48:32.9860000' AS DateTime2), 10, 600000, N'0919988340', 1)
INSERT [dbo].[Bill] ([Id], [DateCheckIn], [DateCheckOut], [IdTable], [TotalPrice], [Phone], [Status]) VALUES (39, CAST(N'2023-03-29T09:46:01.7590000' AS DateTime2), CAST(N'2023-03-29T09:47:03.1260000' AS DateTime2), 2, 450000, N'0919988340', 1)
INSERT [dbo].[Bill] ([Id], [DateCheckIn], [DateCheckOut], [IdTable], [TotalPrice], [Phone], [Status]) VALUES (40, CAST(N'2023-03-29T09:52:04.4830000' AS DateTime2), NULL, 1, NULL, N'0919988340', 3)
SET IDENTITY_INSERT [dbo].[Bill] OFF
GO
SET IDENTITY_INSERT [dbo].[BillInfo] ON 

INSERT [dbo].[BillInfo] ([Id], [IdBill], [IdFood], [Quantity]) VALUES (24, 37, 5, 2)
INSERT [dbo].[BillInfo] ([Id], [IdBill], [IdFood], [Quantity]) VALUES (25, 39, 2, 3)
INSERT [dbo].[BillInfo] ([Id], [IdBill], [IdFood], [Quantity]) VALUES (26, 39, 15, 3)
INSERT [dbo].[BillInfo] ([Id], [IdBill], [IdFood], [Quantity]) VALUES (27, 38, 2, 6)
SET IDENTITY_INSERT [dbo].[BillInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Category]) VALUES (1, N'Hải Sản')
INSERT [dbo].[Category] ([Id], [Category]) VALUES (2, N'Thịt')
INSERT [dbo].[Category] ([Id], [Category]) VALUES (3, N'Nước')
INSERT [dbo].[Category] ([Id], [Category]) VALUES (4, N'Đồ ăn nhẹ')
INSERT [dbo].[Category] ([Id], [Category]) VALUES (6, N'Cơm')
INSERT [dbo].[Category] ([Id], [Category]) VALUES (7, N'Cơm cháy')
INSERT [dbo].[Category] ([Id], [Category]) VALUES (8, N'Cơm cháy')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Food] ON 

INSERT [dbo].[Food] ([Id], [Name], [IdCate], [Price]) VALUES (2, N'Rô phi rán', 1, 100000)
INSERT [dbo].[Food] ([Id], [Name], [IdCate], [Price]) VALUES (3, N'Bạch tuộc', 1, 350000)
INSERT [dbo].[Food] ([Id], [Name], [IdCate], [Price]) VALUES (4, N'Tôm hấp', 1, 400000)
INSERT [dbo].[Food] ([Id], [Name], [IdCate], [Price]) VALUES (5, N'Nhím biển', 1, 645000)
INSERT [dbo].[Food] ([Id], [Name], [IdCate], [Price]) VALUES (6, N'Gà rừng', 2, 360000)
INSERT [dbo].[Food] ([Id], [Name], [IdCate], [Price]) VALUES (7, N'Thịt lợn rừng', 2, 427000)
INSERT [dbo].[Food] ([Id], [Name], [IdCate], [Price]) VALUES (8, N'Thịt heo quay', 2, 367000)
INSERT [dbo].[Food] ([Id], [Name], [IdCate], [Price]) VALUES (9, N'Thịt bò kobe', 2, 589000)
INSERT [dbo].[Food] ([Id], [Name], [IdCate], [Price]) VALUES (10, N'Coca', 3, 12000)
INSERT [dbo].[Food] ([Id], [Name], [IdCate], [Price]) VALUES (11, N'7up', 3, 12000)
INSERT [dbo].[Food] ([Id], [Name], [IdCate], [Price]) VALUES (12, N'Dasani', 3, 10000)
INSERT [dbo].[Food] ([Id], [Name], [IdCate], [Price]) VALUES (13, N'Pepsi', 3, 12000)
INSERT [dbo].[Food] ([Id], [Name], [IdCate], [Price]) VALUES (14, N'Kem', 4, 20000)
INSERT [dbo].[Food] ([Id], [Name], [IdCate], [Price]) VALUES (15, N'Dưa hấu', 4, 50000)
INSERT [dbo].[Food] ([Id], [Name], [IdCate], [Price]) VALUES (16, N'Dưa gangz', 4, 66666)
INSERT [dbo].[Food] ([Id], [Name], [IdCate], [Price]) VALUES (17, N'Cơm gà', 6, 50000)
INSERT [dbo].[Food] ([Id], [Name], [IdCate], [Price]) VALUES (18, N'cua', 1, 100000)
SET IDENTITY_INSERT [dbo].[Food] OFF
GO
SET IDENTITY_INSERT [dbo].[TableFood] ON 

INSERT [dbo].[TableFood] ([Id], [Name], [Status]) VALUES (1, N'Bàn 1', N'Đã đặt')
INSERT [dbo].[TableFood] ([Id], [Name], [Status]) VALUES (2, N'Bàn 2', N'Bàn trống')
INSERT [dbo].[TableFood] ([Id], [Name], [Status]) VALUES (3, N'Bàn 3', N'Bàn trống')
INSERT [dbo].[TableFood] ([Id], [Name], [Status]) VALUES (4, N'Bàn 4', N'Bàn trống')
INSERT [dbo].[TableFood] ([Id], [Name], [Status]) VALUES (5, N'Bàn 5', N'Bàn trống')
INSERT [dbo].[TableFood] ([Id], [Name], [Status]) VALUES (6, N'Bàn 6', N'Bàn trống')
INSERT [dbo].[TableFood] ([Id], [Name], [Status]) VALUES (7, N'Bàn 7', N'Bàn trống')
INSERT [dbo].[TableFood] ([Id], [Name], [Status]) VALUES (8, N'Bàn 8 ', N'Bàn trống')
INSERT [dbo].[TableFood] ([Id], [Name], [Status]) VALUES (9, N'Bàn 9', N'Bàn trống')
INSERT [dbo].[TableFood] ([Id], [Name], [Status]) VALUES (10, N'Bàn 10', N'Bàn trống')
INSERT [dbo].[TableFood] ([Id], [Name], [Status]) VALUES (11, N'Bàn 11', N'Bàn trống')
SET IDENTITY_INSERT [dbo].[TableFood] OFF
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_TableFood] FOREIGN KEY([IdTable])
REFERENCES [dbo].[TableFood] ([Id])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_TableFood]
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD  CONSTRAINT [FK_BillInfo_Bill] FOREIGN KEY([IdBill])
REFERENCES [dbo].[Bill] ([Id])
GO
ALTER TABLE [dbo].[BillInfo] CHECK CONSTRAINT [FK_BillInfo_Bill]
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD  CONSTRAINT [FK_BillInfo_Food] FOREIGN KEY([IdFood])
REFERENCES [dbo].[Food] ([Id])
GO
ALTER TABLE [dbo].[BillInfo] CHECK CONSTRAINT [FK_BillInfo_Food]
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD  CONSTRAINT [FK_Food_Category] FOREIGN KEY([IdCate])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Food] CHECK CONSTRAINT [FK_Food_Category]
GO

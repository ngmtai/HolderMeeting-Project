USE [HolderMeeting]
GO
/****** Object:  Table [dbo].[Vote]    Script Date: 01/08/2015 10:04:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vote](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](400) NULL,
	[IsActive] [bit] NULL,
	[Order] [int] NULL,
	[CreateDate] [date] NULL,
	[CreateUser] [nvarchar](100) NULL,
	[UpdateDate] [date] NULL,
	[UpdateUser] [nvarchar](100) NULL,
 CONSTRAINT [PK_Vote] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Vote] ON
INSERT [dbo].[Vote] ([Id], [DisplayName], [IsActive], [Order], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser]) VALUES (2, N'aBc def', 1, 7, CAST(0x64390B00 AS Date), NULL, CAST(0x65390B00 AS Date), NULL)
INSERT [dbo].[Vote] ([Id], [DisplayName], [IsActive], [Order], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser]) VALUES (4, N'sdfdsfsd', 1, 30, CAST(0x6D390B00 AS Date), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Vote] OFF
/****** Object:  Table [dbo].[Company]    Script Date: 01/08/2015 10:04:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [int] NOT NULL,
	[DisplayName] [nvarchar](300) NULL,
	[TotalShare] [decimal](18, 0) NULL,
	[About] [nvarchar](500) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Company] ([Id], [DisplayName], [TotalShare], [About]) VALUES (1, N'aBc', CAST(1000000 AS Decimal(18, 0)), N'aBc dEf')
/****** Object:  Table [dbo].[Holder]    Script Date: 01/08/2015 10:04:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Holder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NULL,
	[Name] [nvarchar](200) NULL,
	[TotalShare] [decimal](18, 0) NULL,
	[AuthorizerName] [nvarchar](200) NULL,
	[IsActive] [bit] NULL,
	[IsConfirm] [bit] NULL,
	[CompanyId] [int] NULL,
	[CreateDate] [date] NULL,
	[CreateUser] [nvarchar](100) NULL,
	[UpdateDate] [date] NULL,
	[UpdateUser] [nvarchar](100) NULL,
	[CMND] [nvarchar](20) NULL,
 CONSTRAINT [PK_Holder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Holder] ON
INSERT [dbo].[Holder] ([Id], [Code], [Name], [TotalShare], [AuthorizerName], [IsActive], [IsConfirm], [CompanyId], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [CMND]) VALUES (1, N'123', N'aBc', CAST(12356 AS Decimal(18, 0)), N'aBc', 1, 1, 1, CAST(0x55390B00 AS Date), N'Admin', CAST(0x67390B00 AS Date), NULL, N'123455')
INSERT [dbo].[Holder] ([Id], [Code], [Name], [TotalShare], [AuthorizerName], [IsActive], [IsConfirm], [CompanyId], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [CMND]) VALUES (2, N'CD001', N'aBc', CAST(10000 AS Decimal(18, 0)), N'1234', 1, 1, 1, CAST(0x63390B00 AS Date), N'aBc', CAST(0x6F390B00 AS Date), NULL, N'2345232')
INSERT [dbo].[Holder] ([Id], [Code], [Name], [TotalShare], [AuthorizerName], [IsActive], [IsConfirm], [CompanyId], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [CMND]) VALUES (3, N'CD001', N'aBc', CAST(20000 AS Decimal(18, 0)), N'aBc def', 1, 1, 1, CAST(0x63390B00 AS Date), N'aBc', CAST(0x64390B00 AS Date), NULL, N'4556534')
INSERT [dbo].[Holder] ([Id], [Code], [Name], [TotalShare], [AuthorizerName], [IsActive], [IsConfirm], [CompanyId], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [CMND]) VALUES (4, N'CD002', N'dEf', CAST(20000 AS Decimal(18, 0)), N'aBc', 1, 1, 1, CAST(0x63390B00 AS Date), N'aBc', CAST(0x74390B00 AS Date), NULL, N'6657434')
SET IDENTITY_INSERT [dbo].[Holder] OFF
/****** Object:  Table [dbo].[Holder_Vote]    Script Date: 01/08/2015 10:04:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Holder_Vote](
	[HolderId] [int] NOT NULL,
	[VoteId] [int] NOT NULL,
	[AnswerType] [int] NULL,
	[AnswerName] [nvarchar](500) NULL,
	[TotalShare] [decimal](18, 0) NULL,
	[IsActive] [bit] NULL,
	[CreateDate] [date] NULL,
	[CreateUser] [nvarchar](100) NULL,
	[UpdateDate] [date] NULL,
	[UpdateUser] [nvarchar](100) NULL,
 CONSTRAINT [PK_Holder_Vote] PRIMARY KEY CLUSTERED 
(
	[HolderId] ASC,
	[VoteId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Holder_Vote] ([HolderId], [VoteId], [AnswerType], [AnswerName], [TotalShare], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser]) VALUES (1, 2, 1, N'Đồng ý', CAST(2000 AS Decimal(18, 0)), 1, CAST(0x74390B00 AS Date), NULL, NULL, NULL)
INSERT [dbo].[Holder_Vote] ([HolderId], [VoteId], [AnswerType], [AnswerName], [TotalShare], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser]) VALUES (1, 4, 0, N'Không đồng ý', CAST(10000 AS Decimal(18, 0)), 1, CAST(0x74390B00 AS Date), NULL, NULL, NULL)
/****** Object:  ForeignKey [FK_Holder_Company]    Script Date: 01/08/2015 10:04:12 ******/
ALTER TABLE [dbo].[Holder]  WITH CHECK ADD  CONSTRAINT [FK_Holder_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[Holder] CHECK CONSTRAINT [FK_Holder_Company]
GO
/****** Object:  ForeignKey [FK_Holder_Vote_Holder]    Script Date: 01/08/2015 10:04:12 ******/
ALTER TABLE [dbo].[Holder_Vote]  WITH CHECK ADD  CONSTRAINT [FK_Holder_Vote_Holder] FOREIGN KEY([HolderId])
REFERENCES [dbo].[Holder] ([Id])
GO
ALTER TABLE [dbo].[Holder_Vote] CHECK CONSTRAINT [FK_Holder_Vote_Holder]
GO
/****** Object:  ForeignKey [FK_Holder_Vote_Vote]    Script Date: 01/08/2015 10:04:12 ******/
ALTER TABLE [dbo].[Holder_Vote]  WITH CHECK ADD  CONSTRAINT [FK_Holder_Vote_Vote] FOREIGN KEY([VoteId])
REFERENCES [dbo].[Vote] ([Id])
GO
ALTER TABLE [dbo].[Holder_Vote] CHECK CONSTRAINT [FK_Holder_Vote_Vote]
GO

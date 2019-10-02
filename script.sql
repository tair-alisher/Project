CREATE TABLE [dbo].[Clients](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[BirhtDate] [date] NULL,
	[PhoneNumber] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[SocialNumber] [varchar](14) NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([ID], [Name], [BirhtDate], [PhoneNumber], [Address], [SocialNumber]) VALUES (1, N'Тестовый клиент1', CAST(N'1991-03-08' AS Date), N'123', N'г.Баткен', N'12345678901234')
INSERT [dbo].[Clients] ([ID], [Name], [BirhtDate], [PhoneNumber], [Address], [SocialNumber]) VALUES (2, N'Тестовый клиент2', CAST(N'1996-04-20' AS Date), N'456', N'г.Бишкек', N'98765432101234')
INSERT [dbo].[Clients] ([ID], [Name], [BirhtDate], [PhoneNumber], [Address], [SocialNumber]) VALUES (3, N'Тестовый клиент3', CAST(N'1995-08-04' AS Date), N'789', N'г.Нарын', N'12345543211234')
INSERT [dbo].[Clients] ([ID], [Name], [BirhtDate], [PhoneNumber], [Address], [SocialNumber]) VALUES (4, N'Тестовый клиент4', CAST(N'1989-02-25' AS Date), N'012', N'с.Комсомольское', N'12345671234567')
SET IDENTITY_INSERT [dbo].[Clients] OFF
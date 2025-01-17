USE [KanBankasi]
GO
/****** Object:  Table [dbo].[Donor]    Script Date: 12.01.2024 23:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donor](
	[donorID] [int] IDENTITY(1,1) NOT NULL,
	[ad] [nvarchar](50) NULL,
	[soyad] [nvarchar](50) NULL,
	[tc] [nvarchar](11) NULL,
	[cinsiyet] [nvarchar](50) NULL,
	[yas] [nvarchar](50) NULL,
	[tel] [nvarchar](11) NULL,
	[adres] [nvarchar](90) NULL,
	[kanGrup] [nvarchar](50) NULL,
 CONSTRAINT [PK_Donor] PRIMARY KEY CLUSTERED 
(
	[donorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hasta]    Script Date: 12.01.2024 23:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hasta](
	[hastaID] [int] IDENTITY(1,1) NOT NULL,
	[ad] [nvarchar](50) NULL,
	[soyad] [nvarchar](50) NULL,
	[tc] [nvarchar](11) NULL,
	[cinsiyet] [nvarchar](50) NULL,
	[yas] [nvarchar](50) NULL,
	[tel] [nvarchar](11) NULL,
	[adres] [nvarchar](50) NULL,
	[kanGrup] [nvarchar](50) NULL,
 CONSTRAINT [PK_Hasta] PRIMARY KEY CLUSTERED 
(
	[hastaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KanBagisi]    Script Date: 12.01.2024 23:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KanBagisi](
	[kanBagisiID] [int] IDENTITY(1,1) NOT NULL,
	[ad] [nvarchar](50) NULL,
	[soyad] [nvarchar](50) NULL,
	[tc] [nvarchar](11) NULL,
	[cinsiyet] [nvarchar](50) NULL,
	[adet] [int] NULL,
	[kanGrup] [nvarchar](50) NULL,
	[donorID] [int] NULL,
	[kullaniciID] [int] NULL,
	[kanStoguID] [int] NULL,
 CONSTRAINT [PK_KanBagisi] PRIMARY KEY CLUSTERED 
(
	[kanBagisiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KanStogu]    Script Date: 12.01.2024 23:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KanStogu](
	[kanStoguID] [int] IDENTITY(1,1) NOT NULL,
	[kanGrup] [nvarchar](50) NULL,
	[kanStok] [int] NULL,
 CONSTRAINT [PK_KanStogu] PRIMARY KEY CLUSTERED 
(
	[kanStoguID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanici]    Script Date: 12.01.2024 23:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanici](
	[kullaniciID] [int] IDENTITY(1,1) NOT NULL,
	[ad] [nvarchar](50) NULL,
	[soyad] [nvarchar](50) NULL,
	[telefon] [nvarchar](50) NULL,
	[cinsiyet] [nchar](10) NULL,
	[email] [nvarchar](50) NULL,
	[adres] [nvarchar](500) NULL,
	[kullaniciAdi] [nvarchar](50) NULL,
	[sifre] [nvarchar](50) NULL,
 CONSTRAINT [PK_Kullanici] PRIMARY KEY CLUSTERED 
(
	[kullaniciID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transfer]    Script Date: 12.01.2024 23:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transfer](
	[transferID] [int] IDENTITY(1,1) NOT NULL,
	[kanGrup] [nvarchar](50) NULL,
	[kanStok] [int] NULL,
 CONSTRAINT [PK_Transfer] PRIMARY KEY CLUSTERED 
(
	[transferID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransferBagis]    Script Date: 12.01.2024 23:22:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransferBagis](
	[transferBagisID] [int] IDENTITY(1,1) NOT NULL,
	[ad] [nvarchar](50) NULL,
	[soyad] [nvarchar](50) NULL,
	[tc] [nvarchar](11) NULL,
	[cinsiyet] [nvarchar](50) NULL,
	[adet] [int] NULL,
	[kanGrup] [nvarchar](50) NULL,
	[hastaID] [int] NULL,
	[transferID] [int] NULL,
 CONSTRAINT [PK_TransferBagis] PRIMARY KEY CLUSTERED 
(
	[transferBagisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Donor] ON 

INSERT [dbo].[Donor] ([donorID], [ad], [soyad], [tc], [cinsiyet], [yas], [tel], [adres], [kanGrup]) VALUES (1, N'Ahmet', N'Demir', N'15987463159', N'Erkek', N'25', N'05963159841', N'Düzce', N'A+')
INSERT [dbo].[Donor] ([donorID], [ad], [soyad], [tc], [cinsiyet], [yas], [tel], [adres], [kanGrup]) VALUES (3, N'Ela', N'Ünal', N'15963487156', N'Kadın', N'21', N'05987413652', N'Düzce', N'0+')
INSERT [dbo].[Donor] ([donorID], [ad], [soyad], [tc], [cinsiyet], [yas], [tel], [adres], [kanGrup]) VALUES (4, N'Nimet', N'Alkan', N'19535713429', N'Kadın', N'42', N'05526894398', N'İzmir', N'A+')
INSERT [dbo].[Donor] ([donorID], [ad], [soyad], [tc], [cinsiyet], [yas], [tel], [adres], [kanGrup]) VALUES (6, N'Ali', N'Dere', N'12369578498', N'Kadın', N'26', N'05987461359', N'Düzce', N'AB+')
INSERT [dbo].[Donor] ([donorID], [ad], [soyad], [tc], [cinsiyet], [yas], [tel], [adres], [kanGrup]) VALUES (7, N'Mehmet', N'Kaya', N'26987564123', N'Erkek', N'29', N'05698741563', N'düzce', N'B+')
SET IDENTITY_INSERT [dbo].[Donor] OFF
GO
SET IDENTITY_INSERT [dbo].[Hasta] ON 

INSERT [dbo].[Hasta] ([hastaID], [ad], [soyad], [tc], [cinsiyet], [yas], [tel], [adres], [kanGrup]) VALUES (1, N'Hadise', N'Açık', N'24931597536', N'Kadın', N'35', N'05529618347', N'Bursa', N'AB+')
INSERT [dbo].[Hasta] ([hastaID], [ad], [soyad], [tc], [cinsiyet], [yas], [tel], [adres], [kanGrup]) VALUES (2, N'Sevda', N'Dal', N'29615739514', N'Kadın', N'25', N'0552152453', N'Bolu', N'A-')
INSERT [dbo].[Hasta] ([hastaID], [ad], [soyad], [tc], [cinsiyet], [yas], [tel], [adres], [kanGrup]) VALUES (3, N'Erdem', N'Nalcı', N'59648763159', N'Erkek', N'28', N'05987463159', N'Ankara', N'B+')
INSERT [dbo].[Hasta] ([hastaID], [ad], [soyad], [tc], [cinsiyet], [yas], [tel], [adres], [kanGrup]) VALUES (4, N'Ali', N'Dere', N'29786431597', N'Erkek', N'35', N'05987463159', N'Ankara', N'0+')
SET IDENTITY_INSERT [dbo].[Hasta] OFF
GO
SET IDENTITY_INSERT [dbo].[KanBagisi] ON 

INSERT [dbo].[KanBagisi] ([kanBagisiID], [ad], [soyad], [tc], [cinsiyet], [adet], [kanGrup], [donorID], [kullaniciID], [kanStoguID]) VALUES (1, N'Ahmet', N'Demir', N'15987463159', N'erkek', 1, N'A+', 1, 1, 1)
INSERT [dbo].[KanBagisi] ([kanBagisiID], [ad], [soyad], [tc], [cinsiyet], [adet], [kanGrup], [donorID], [kullaniciID], [kanStoguID]) VALUES (2, N'Ahmet', N'Demir', N'15987463159', NULL, NULL, N'A+', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[KanBagisi] OFF
GO
SET IDENTITY_INSERT [dbo].[KanStogu] ON 

INSERT [dbo].[KanStogu] ([kanStoguID], [kanGrup], [kanStok]) VALUES (1, N'A+', 25)
INSERT [dbo].[KanStogu] ([kanStoguID], [kanGrup], [kanStok]) VALUES (2, N'0+', 39)
INSERT [dbo].[KanStogu] ([kanStoguID], [kanGrup], [kanStok]) VALUES (3, N'B+', 75)
INSERT [dbo].[KanStogu] ([kanStoguID], [kanGrup], [kanStok]) VALUES (4, N'AB+', 35)
INSERT [dbo].[KanStogu] ([kanStoguID], [kanGrup], [kanStok]) VALUES (5, N'A-', 96)
INSERT [dbo].[KanStogu] ([kanStoguID], [kanGrup], [kanStok]) VALUES (6, N'B-', 48)
INSERT [dbo].[KanStogu] ([kanStoguID], [kanGrup], [kanStok]) VALUES (7, N'0-', 52)
INSERT [dbo].[KanStogu] ([kanStoguID], [kanGrup], [kanStok]) VALUES (8, N'AB-', 85)
SET IDENTITY_INSERT [dbo].[KanStogu] OFF
GO
SET IDENTITY_INSERT [dbo].[Kullanici] ON 

INSERT [dbo].[Kullanici] ([kullaniciID], [ad], [soyad], [telefon], [cinsiyet], [email], [adres], [kullaniciAdi], [sifre]) VALUES (1, N'Türkan', N'Ergün', N'05253625362', N'Kadın     ', N'turkan@gmail.com', N'İstanbul', N'Türkan', N'123')
INSERT [dbo].[Kullanici] ([kullaniciID], [ad], [soyad], [telefon], [cinsiyet], [email], [adres], [kullaniciAdi], [sifre]) VALUES (2, N'Selin', N'Kaya', N'0545633861', N'Kadın     ', N'selin@gmail.com', N'İzmir', N'Selin', N'1234')
INSERT [dbo].[Kullanici] ([kullaniciID], [ad], [soyad], [telefon], [cinsiyet], [email], [adres], [kullaniciAdi], [sifre]) VALUES (3, N'Merve', N'Çalhan', N'05987463159', N'Kadın     ', N'merve@gmail.com', N'Ankara', N'Merve', N'12345')
SET IDENTITY_INSERT [dbo].[Kullanici] OFF
GO
SET IDENTITY_INSERT [dbo].[Transfer] ON 

INSERT [dbo].[Transfer] ([transferID], [kanGrup], [kanStok]) VALUES (1, N'A+', 84)
INSERT [dbo].[Transfer] ([transferID], [kanGrup], [kanStok]) VALUES (2, N'0+', 65)
INSERT [dbo].[Transfer] ([transferID], [kanGrup], [kanStok]) VALUES (3, N'B+', 56)
INSERT [dbo].[Transfer] ([transferID], [kanGrup], [kanStok]) VALUES (4, N'AB+', 59)
INSERT [dbo].[Transfer] ([transferID], [kanGrup], [kanStok]) VALUES (5, N'A-', 51)
INSERT [dbo].[Transfer] ([transferID], [kanGrup], [kanStok]) VALUES (6, N'B-', 75)
INSERT [dbo].[Transfer] ([transferID], [kanGrup], [kanStok]) VALUES (7, N'0-', 75)
INSERT [dbo].[Transfer] ([transferID], [kanGrup], [kanStok]) VALUES (8, N'AB-', 95)
SET IDENTITY_INSERT [dbo].[Transfer] OFF
GO
SET IDENTITY_INSERT [dbo].[TransferBagis] ON 

INSERT [dbo].[TransferBagis] ([transferBagisID], [ad], [soyad], [tc], [cinsiyet], [adet], [kanGrup], [hastaID], [transferID]) VALUES (1, N'Melehat', N'Kara', N'42821893547', N'kadın', 1, N'A+', 1, 1)
INSERT [dbo].[TransferBagis] ([transferBagisID], [ad], [soyad], [tc], [cinsiyet], [adet], [kanGrup], [hastaID], [transferID]) VALUES (2, N'Melehat', N'Kara', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TransferBagis] ([transferBagisID], [ad], [soyad], [tc], [cinsiyet], [adet], [kanGrup], [hastaID], [transferID]) VALUES (3, N'Melehat', N'Kara', N'42821893547', N'kadın', 1, N'A+', 1, 1)
INSERT [dbo].[TransferBagis] ([transferBagisID], [ad], [soyad], [tc], [cinsiyet], [adet], [kanGrup], [hastaID], [transferID]) VALUES (4, N'Melehat', N'Kara', N'42821893547', N'kadın', 1, N'A+', 1, 1)
SET IDENTITY_INSERT [dbo].[TransferBagis] OFF
GO
ALTER TABLE [dbo].[KanBagisi]  WITH CHECK ADD  CONSTRAINT [FK_KanBagisi_Donor] FOREIGN KEY([donorID])
REFERENCES [dbo].[Donor] ([donorID])
GO
ALTER TABLE [dbo].[KanBagisi] CHECK CONSTRAINT [FK_KanBagisi_Donor]
GO
ALTER TABLE [dbo].[KanBagisi]  WITH CHECK ADD  CONSTRAINT [FK_KanBagisi_KanStogu] FOREIGN KEY([kanStoguID])
REFERENCES [dbo].[KanStogu] ([kanStoguID])
GO
ALTER TABLE [dbo].[KanBagisi] CHECK CONSTRAINT [FK_KanBagisi_KanStogu]
GO
ALTER TABLE [dbo].[KanBagisi]  WITH CHECK ADD  CONSTRAINT [FK_KanBagisi_Kullanici] FOREIGN KEY([kullaniciID])
REFERENCES [dbo].[Kullanici] ([kullaniciID])
GO
ALTER TABLE [dbo].[KanBagisi] CHECK CONSTRAINT [FK_KanBagisi_Kullanici]
GO
ALTER TABLE [dbo].[TransferBagis]  WITH CHECK ADD  CONSTRAINT [FK_TransferBagis_Hasta] FOREIGN KEY([hastaID])
REFERENCES [dbo].[Hasta] ([hastaID])
GO
ALTER TABLE [dbo].[TransferBagis] CHECK CONSTRAINT [FK_TransferBagis_Hasta]
GO
ALTER TABLE [dbo].[TransferBagis]  WITH CHECK ADD  CONSTRAINT [FK_TransferBagis_Transfer] FOREIGN KEY([transferID])
REFERENCES [dbo].[Transfer] ([transferID])
GO
ALTER TABLE [dbo].[TransferBagis] CHECK CONSTRAINT [FK_TransferBagis_Transfer]
GO

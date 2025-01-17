USE [StokTakip]
GO
/****** Object:  Table [dbo].[Kategori]    Script Date: 26.10.2023 22:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategori](
	[kategoriID] [int] IDENTITY(1,1) NOT NULL,
	[ad] [nvarchar](50) NULL,
	[aciklama] [nvarchar](50) NULL,
 CONSTRAINT [PK_Kategori] PRIMARY KEY CLUSTERED 
(
	[kategoriID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanici]    Script Date: 26.10.2023 22:01:04 ******/
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
	[yetki] [nvarchar](50) NULL,
 CONSTRAINT [PK_Kullanici] PRIMARY KEY CLUSTERED 
(
	[kullaniciID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musteri]    Script Date: 26.10.2023 22:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteri](
	[musteriID] [int] IDENTITY(1,1) NOT NULL,
	[ad] [nvarchar](50) NULL,
	[soyad] [nvarchar](50) NULL,
	[dogumYeri] [nvarchar](50) NULL,
	[dogumTarihi] [smalldatetime] NULL,
	[tcNo] [nvarchar](50) NULL,
	[cinsiyet] [nchar](10) NULL,
	[telefon] [nvarchar](50) NULL,
	[adres] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Musteri] PRIMARY KEY CLUSTERED 
(
	[musteriID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Satis]    Script Date: 26.10.2023 22:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Satis](
	[satisID] [int] IDENTITY(1,1) NOT NULL,
	[urunID] [int] NULL,
	[adet] [int] NULL,
	[fiyat] [decimal](18, 2) NULL,
	[tarih] [datetime] NULL,
	[kullaniciID] [int] NULL,
	[musteriID] [int] NULL,
 CONSTRAINT [PK_Satis] PRIMARY KEY CLUSTERED 
(
	[satisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Urun]    Script Date: 26.10.2023 22:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urun](
	[urunID] [int] IDENTITY(1,1) NOT NULL,
	[ad] [nvarchar](50) NULL,
	[marka] [nvarchar](50) NULL,
	[fiyat] [decimal](18, 2) NULL,
	[stok] [int] NULL,
	[populer] [bit] NULL,
	[kategoriID] [int] NULL,
 CONSTRAINT [PK_Urun] PRIMARY KEY CLUSTERED 
(
	[urunID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Kategori] ON 

INSERT [dbo].[Kategori] ([kategoriID], [ad], [aciklama]) VALUES (1, N'Cilt Bakım', N'Serum-Yüz Temizleme Jeli-Maske-Nemlendirici')
INSERT [dbo].[Kategori] ([kategoriID], [ad], [aciklama]) VALUES (2, N'Makyaj', N'Göz Makyajı-Dudak Makyajı-Maskara')
INSERT [dbo].[Kategori] ([kategoriID], [ad], [aciklama]) VALUES (3, N'Saç', N'Şampuan-Bakım Kremi-Saç Spreyi')
INSERT [dbo].[Kategori] ([kategoriID], [ad], [aciklama]) VALUES (3010, N'lsdfıjfls', N'flskdhşlfh')
SET IDENTITY_INSERT [dbo].[Kategori] OFF
GO
SET IDENTITY_INSERT [dbo].[Kullanici] ON 

INSERT [dbo].[Kullanici] ([kullaniciID], [ad], [soyad], [telefon], [cinsiyet], [email], [adres], [kullaniciAdi], [sifre], [yetki]) VALUES (1, N'Türkan', N'Ergün', N'05253625362', N'Kadın     ', N'turkan@gmail.com', N'İstanbul', N'Türkan', N'123', N'Müdür')
INSERT [dbo].[Kullanici] ([kullaniciID], [ad], [soyad], [telefon], [cinsiyet], [email], [adres], [kullaniciAdi], [sifre], [yetki]) VALUES (2, N'Selin', N'Kaya', N'0545633861', N'Kadın     ', N'selin@gmail.com', N'İzmir', N'Selin', N'1234', N'Müdür Yardımcısı')
SET IDENTITY_INSERT [dbo].[Kullanici] OFF
GO
SET IDENTITY_INSERT [dbo].[Musteri] ON 

INSERT [dbo].[Musteri] ([musteriID], [ad], [soyad], [dogumYeri], [dogumTarihi], [tcNo], [cinsiyet], [telefon], [adres], [email]) VALUES (1, N'Bahar', N'Ak', N'Kars', CAST(N'2000-02-12T00:00:00' AS SmallDateTime), N'17524863987', N'kadın     ', N'05532145698', N'Kars', N'bahr@gmail.com')
INSERT [dbo].[Musteri] ([musteriID], [ad], [soyad], [dogumYeri], [dogumTarihi], [tcNo], [cinsiyet], [telefon], [adres], [email]) VALUES (2, N'Ali', N'Gök', N'Trabzon', CAST(N'1980-02-12T00:00:00' AS SmallDateTime), N'22156145616', N'erkek     ', N'05163266322', N'Mardin', N'ali61@gmail.com')
INSERT [dbo].[Musteri] ([musteriID], [ad], [soyad], [dogumYeri], [dogumTarihi], [tcNo], [cinsiyet], [telefon], [adres], [email]) VALUES (3, N'Pınar', N'Deniz', N'İzmir', CAST(N'1990-03-24T00:00:00' AS SmallDateTime), N'14863257963', N'kadın     ', N'05567621863', N'İstanbul', N'pınar34@gmail.com')
SET IDENTITY_INSERT [dbo].[Musteri] OFF
GO
SET IDENTITY_INSERT [dbo].[Satis] ON 

INSERT [dbo].[Satis] ([satisID], [urunID], [adet], [fiyat], [tarih], [kullaniciID], [musteriID]) VALUES (1, 1, 5, CAST(181.00 AS Decimal(18, 2)), CAST(N'2023-12-12T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Satis] ([satisID], [urunID], [adet], [fiyat], [tarih], [kullaniciID], [musteriID]) VALUES (2, 1, 4, CAST(45.00 AS Decimal(18, 2)), CAST(N'2023-12-12T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Satis] ([satisID], [urunID], [adet], [fiyat], [tarih], [kullaniciID], [musteriID]) VALUES (11, 5, 1, CAST(600.00 AS Decimal(18, 2)), CAST(N'2023-10-19T00:00:00.000' AS DateTime), 2, 2)
INSERT [dbo].[Satis] ([satisID], [urunID], [adet], [fiyat], [tarih], [kullaniciID], [musteriID]) VALUES (12, 5, 480, CAST(2000.00 AS Decimal(18, 2)), CAST(N'2023-10-19T00:00:00.000' AS DateTime), 1, 3)
SET IDENTITY_INSERT [dbo].[Satis] OFF
GO
SET IDENTITY_INSERT [dbo].[Urun] ON 

INSERT [dbo].[Urun] ([urunID], [ad], [marka], [fiyat], [stok], [populer], [kategoriID]) VALUES (1, N'Yüz Tonik', N'Nivea ', CAST(100.00 AS Decimal(18, 2)), 500, 0, 1)
INSERT [dbo].[Urun] ([urunID], [ad], [marka], [fiyat], [stok], [populer], [kategoriID]) VALUES (2, N'Yüz Maskesi', N' Beaulis', CAST(150.00 AS Decimal(18, 2)), 90, 0, 1)
INSERT [dbo].[Urun] ([urunID], [ad], [marka], [fiyat], [stok], [populer], [kategoriID]) VALUES (3, N'Saç Bakım Toniği', N'Urban ', CAST(300.00 AS Decimal(18, 2)), 250, 1, 3)
INSERT [dbo].[Urun] ([urunID], [ad], [marka], [fiyat], [stok], [populer], [kategoriID]) VALUES (4, N'Eyeliner ', N'Flormar', CAST(120.00 AS Decimal(18, 2)), 200, 1, 2)
INSERT [dbo].[Urun] ([urunID], [ad], [marka], [fiyat], [stok], [populer], [kategoriID]) VALUES (5, N'Kapatıcı', N'Maybelline', CAST(600.00 AS Decimal(18, 2)), 500, 1, 2)
INSERT [dbo].[Urun] ([urunID], [ad], [marka], [fiyat], [stok], [populer], [kategoriID]) VALUES (6, N'Cilt Bakım Serumu', N'The Purest', CAST(350.00 AS Decimal(18, 2)), 400, 1, 1)
INSERT [dbo].[Urun] ([urunID], [ad], [marka], [fiyat], [stok], [populer], [kategoriID]) VALUES (7, N'Yüz Temizleme Jeli', N'Ziaja', CAST(200.00 AS Decimal(18, 2)), 300, 0, 1)
INSERT [dbo].[Urun] ([urunID], [ad], [marka], [fiyat], [stok], [populer], [kategoriID]) VALUES (8, N'Cilt Bakım Kremi', N'Janssen', CAST(800.00 AS Decimal(18, 2)), 500, 1, 1)
INSERT [dbo].[Urun] ([urunID], [ad], [marka], [fiyat], [stok], [populer], [kategoriID]) VALUES (9, N'Saç Güzelleştirici Krem', N'Elseve', CAST(150.00 AS Decimal(18, 2)), 250, 0, 3)
INSERT [dbo].[Urun] ([urunID], [ad], [marka], [fiyat], [stok], [populer], [kategoriID]) VALUES (10, N'Şampuan', N'Elidor', CAST(80.00 AS Decimal(18, 2)), 100, 1, 3)
INSERT [dbo].[Urun] ([urunID], [ad], [marka], [fiyat], [stok], [populer], [kategoriID]) VALUES (11, N'Saç Bakım Yağı', N'Mixup', CAST(120.00 AS Decimal(18, 2)), 300, 0, 3)
INSERT [dbo].[Urun] ([urunID], [ad], [marka], [fiyat], [stok], [populer], [kategoriID]) VALUES (12, N'Saç Spreyi', N'Morfose', CAST(160.00 AS Decimal(18, 2)), 350, 1, 3)
INSERT [dbo].[Urun] ([urunID], [ad], [marka], [fiyat], [stok], [populer], [kategoriID]) VALUES (13, N'Allık', N'Golden Rose', CAST(400.00 AS Decimal(18, 2)), 700, 1, 2)
INSERT [dbo].[Urun] ([urunID], [ad], [marka], [fiyat], [stok], [populer], [kategoriID]) VALUES (14, N'Likit Ruj', N'TheBalm', CAST(600.00 AS Decimal(18, 2)), 500, 1, 2)
INSERT [dbo].[Urun] ([urunID], [ad], [marka], [fiyat], [stok], [populer], [kategoriID]) VALUES (15, N'Maskara', N'Maybelline', CAST(400.00 AS Decimal(18, 2)), 600, 1, 2)
SET IDENTITY_INSERT [dbo].[Urun] OFF
GO
ALTER TABLE [dbo].[Satis]  WITH CHECK ADD  CONSTRAINT [FK_Satis_Kullanici] FOREIGN KEY([kullaniciID])
REFERENCES [dbo].[Kullanici] ([kullaniciID])
GO
ALTER TABLE [dbo].[Satis] CHECK CONSTRAINT [FK_Satis_Kullanici]
GO
ALTER TABLE [dbo].[Satis]  WITH CHECK ADD  CONSTRAINT [FK_Satis_Musteri] FOREIGN KEY([musteriID])
REFERENCES [dbo].[Musteri] ([musteriID])
GO
ALTER TABLE [dbo].[Satis] CHECK CONSTRAINT [FK_Satis_Musteri]
GO
ALTER TABLE [dbo].[Satis]  WITH CHECK ADD  CONSTRAINT [FK_Satis_Urun] FOREIGN KEY([urunID])
REFERENCES [dbo].[Urun] ([urunID])
GO
ALTER TABLE [dbo].[Satis] CHECK CONSTRAINT [FK_Satis_Urun]
GO
ALTER TABLE [dbo].[Urun]  WITH CHECK ADD  CONSTRAINT [FK_Urun_Kategori] FOREIGN KEY([kategoriID])
REFERENCES [dbo].[Kategori] ([kategoriID])
GO
ALTER TABLE [dbo].[Urun] CHECK CONSTRAINT [FK_Urun_Kategori]
GO

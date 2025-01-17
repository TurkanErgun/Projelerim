USE [SinavSistemiDB]
GO
/****** Object:  Table [dbo].[Akademisyen]    Script Date: 7.06.2024 09:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Akademisyen](
	[akademisyenID] [int] IDENTITY(1,1) NOT NULL,
	[adSoyad] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[sifre] [nvarchar](50) NULL,
	[ders] [nvarchar](50) NULL,
 CONSTRAINT [PK_Akademisyen] PRIMARY KEY CLUSTERED 
(
	[akademisyenID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bolum]    Script Date: 7.06.2024 09:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bolum](
	[bolumID] [int] IDENTITY(1,1) NOT NULL,
	[ad] [nvarchar](50) NULL,
 CONSTRAINT [PK_Bolum] PRIMARY KEY CLUSTERED 
(
	[bolumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ders]    Script Date: 7.06.2024 09:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ders](
	[dersID] [int] IDENTITY(1,1) NOT NULL,
	[ad] [nvarchar](50) NULL,
	[kod] [nvarchar](50) NULL,
	[ogrenciSayisi] [nvarchar](50) NULL,
	[sinif] [nvarchar](50) NULL,
 CONSTRAINT [PK_Ders] PRIMARY KEY CLUSTERED 
(
	[dersID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kayit]    Script Date: 7.06.2024 09:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kayit](
	[kayitID] [int] IDENTITY(1,1) NOT NULL,
	[programTurID] [int] NULL,
	[ogrSinifID] [int] NULL,
	[dersID] [int] NULL,
	[tarih] [date] NULL,
	[saat] [time](7) NULL,
	[sinifID] [int] NULL,
	[akademisyen1ID] [int] NULL,
	[akademisyen2ID] [int] NULL,
	[akademisyen3ID] [int] NULL,
	[sinavTurID] [int] NULL,
 CONSTRAINT [PK_Kayit] PRIMARY KEY CLUSTERED 
(
	[kayitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OgrenciSinif]    Script Date: 7.06.2024 09:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OgrenciSinif](
	[ogrSinifID] [int] IDENTITY(1,1) NOT NULL,
	[ad] [int] NULL,
 CONSTRAINT [PK_OgrenciSinif] PRIMARY KEY CLUSTERED 
(
	[ogrSinifID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ögretmen]    Script Date: 7.06.2024 09:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ögretmen](
	[o] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProgramTur]    Script Date: 7.06.2024 09:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgramTur](
	[programTurID] [int] IDENTITY(1,1) NOT NULL,
	[ad] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProgramTur] PRIMARY KEY CLUSTERED 
(
	[programTurID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SinavTur]    Script Date: 7.06.2024 09:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinavTur](
	[sinavTurID] [int] IDENTITY(1,1) NOT NULL,
	[ad] [nvarchar](50) NULL,
 CONSTRAINT [PK_SinavTur] PRIMARY KEY CLUSTERED 
(
	[sinavTurID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sinif]    Script Date: 7.06.2024 09:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sinif](
	[sinifID] [int] IDENTITY(1,1) NOT NULL,
	[ad] [nvarchar](50) NULL,
	[kapasite] [int] NULL,
 CONSTRAINT [PK_Sinif] PRIMARY KEY CLUSTERED 
(
	[sinifID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SinifKayit]    Script Date: 7.06.2024 09:41:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinifKayit](
	[sinifKayitID] [int] IDENTITY(1,1) NOT NULL,
	[kayitID] [int] NULL,
	[sinifID] [int] NULL,
	[gozetmenID] [int] NULL,
 CONSTRAINT [PK_SinifKayit] PRIMARY KEY CLUSTERED 
(
	[sinifKayitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Akademisyen] ON 

INSERT [dbo].[Akademisyen] ([akademisyenID], [adSoyad], [email], [sifre], [ders]) VALUES (2, N'Erdi Yalçın', N'erdi@gmail.com', N'1234', N'Veri Tabanı')
INSERT [dbo].[Akademisyen] ([akademisyenID], [adSoyad], [email], [sifre], [ders]) VALUES (3, N'Emrah Mercan', N'emrah@gmail.com', N'12345', N'Kariyer Planlama')
INSERT [dbo].[Akademisyen] ([akademisyenID], [adSoyad], [email], [sifre], [ders]) VALUES (6, N'Fatih İlkbahar', N'fatih@gmail.com', N'123', N'Görsel Programlama 3')
INSERT [dbo].[Akademisyen] ([akademisyenID], [adSoyad], [email], [sifre], [ders]) VALUES (9, N'Mehmet Bozuk', N'mehmet@gmail.com', N'0123', N'İngilizce(50)')
INSERT [dbo].[Akademisyen] ([akademisyenID], [adSoyad], [email], [sifre], [ders]) VALUES (12, N'Ali Said Kabakcı', N'alisaid@gmail.com', N'159', N'İngilizce(50)')
INSERT [dbo].[Akademisyen] ([akademisyenID], [adSoyad], [email], [sifre], [ders]) VALUES (13, N'Serdar Arpacı', N'serdar@email.com', N'246', N'Ağ Temelleri(45)')
INSERT [dbo].[Akademisyen] ([akademisyenID], [adSoyad], [email], [sifre], [ders]) VALUES (21, N'Osman Göktaş', N'osman@gmail.com', N'369', N'İngilizce')
INSERT [dbo].[Akademisyen] ([akademisyenID], [adSoyad], [email], [sifre], [ders]) VALUES (22, N'Ali Bolat', N'ali@gmail.com', N'123', N'Kariyer Planlama')
INSERT [dbo].[Akademisyen] ([akademisyenID], [adSoyad], [email], [sifre], [ders]) VALUES (26, N'Yok', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Akademisyen] OFF
GO
SET IDENTITY_INSERT [dbo].[Bolum] ON 

INSERT [dbo].[Bolum] ([bolumID], [ad]) VALUES (1, N'Bilgisayar Program')
SET IDENTITY_INSERT [dbo].[Bolum] OFF
GO
SET IDENTITY_INSERT [dbo].[Ders] ON 

INSERT [dbo].[Ders] ([dersID], [ad], [kod], [ogrenciSayisi], [sinif]) VALUES (1, N'Kariyer Planlama', N'KRP102', N'40', N'1')
INSERT [dbo].[Ders] ([dersID], [ad], [kod], [ogrenciSayisi], [sinif]) VALUES (2, N'İngilizce', N'YDB1113', N'45', N'1')
INSERT [dbo].[Ders] ([dersID], [ad], [kod], [ogrenciSayisi], [sinif]) VALUES (4, N'İnternet Programcılığı', N'ABL3019', N'50', N'2')
INSERT [dbo].[Ders] ([dersID], [ad], [kod], [ogrenciSayisi], [sinif]) VALUES (5, N'Ağ Temelleri', N'ABL2006', N'46', N'1')
INSERT [dbo].[Ders] ([dersID], [ad], [kod], [ogrenciSayisi], [sinif]) VALUES (6, N'Görsel Programlama', N'ABL4016', N'50', N'2')
INSERT [dbo].[Ders] ([dersID], [ad], [kod], [ogrenciSayisi], [sinif]) VALUES (7, N'Veri Tabanı', N'ABL4014', N'48', N'2')
INSERT [dbo].[Ders] ([dersID], [ad], [kod], [ogrenciSayisi], [sinif]) VALUES (9, N'İşletme Yönetimi', N'ABL4034', N'52', N'2')
INSERT [dbo].[Ders] ([dersID], [ad], [kod], [ogrenciSayisi], [sinif]) VALUES (13, N'Türk Dili', N'TDB1121', N'47', N'1')
INSERT [dbo].[Ders] ([dersID], [ad], [kod], [ogrenciSayisi], [sinif]) VALUES (21, N'Mikro Denetleyiciler', N'ABL-3015', N'48', N'2')
INSERT [dbo].[Ders] ([dersID], [ad], [kod], [ogrenciSayisi], [sinif]) VALUES (22, N'Ofis Yazılımları', N'ABL1007', N'50', N'1')
SET IDENTITY_INSERT [dbo].[Ders] OFF
GO
SET IDENTITY_INSERT [dbo].[Kayit] ON 

INSERT [dbo].[Kayit] ([kayitID], [programTurID], [ogrSinifID], [dersID], [tarih], [saat], [sinifID], [akademisyen1ID], [akademisyen2ID], [akademisyen3ID], [sinavTurID]) VALUES (5, 1, 1, 5, CAST(N'2024-05-21' AS Date), CAST(N'12:50:00' AS Time), 1, 3, NULL, NULL, 2)
INSERT [dbo].[Kayit] ([kayitID], [programTurID], [ogrSinifID], [dersID], [tarih], [saat], [sinifID], [akademisyen1ID], [akademisyen2ID], [akademisyen3ID], [sinavTurID]) VALUES (6, 1, 1, 4, CAST(N'2024-05-28' AS Date), CAST(N'14:50:00' AS Time), 1, 3, NULL, NULL, 1)
INSERT [dbo].[Kayit] ([kayitID], [programTurID], [ogrSinifID], [dersID], [tarih], [saat], [sinifID], [akademisyen1ID], [akademisyen2ID], [akademisyen3ID], [sinavTurID]) VALUES (8, 1, 2, 2, CAST(N'2024-05-17' AS Date), CAST(N'12:10:00' AS Time), 2, 3, NULL, NULL, 1)
INSERT [dbo].[Kayit] ([kayitID], [programTurID], [ogrSinifID], [dersID], [tarih], [saat], [sinifID], [akademisyen1ID], [akademisyen2ID], [akademisyen3ID], [sinavTurID]) VALUES (9, 1, 2, 6, CAST(N'2024-05-20' AS Date), CAST(N'10:00:00' AS Time), 2, 6, NULL, NULL, 1)
INSERT [dbo].[Kayit] ([kayitID], [programTurID], [ogrSinifID], [dersID], [tarih], [saat], [sinifID], [akademisyen1ID], [akademisyen2ID], [akademisyen3ID], [sinavTurID]) VALUES (10, 1, 1, 6, CAST(N'2024-05-20' AS Date), CAST(N'12:00:00' AS Time), 1, 6, NULL, NULL, 1)
INSERT [dbo].[Kayit] ([kayitID], [programTurID], [ogrSinifID], [dersID], [tarih], [saat], [sinifID], [akademisyen1ID], [akademisyen2ID], [akademisyen3ID], [sinavTurID]) VALUES (12, 1, 2, 6, CAST(N'2024-05-20' AS Date), CAST(N'10:00:00' AS Time), 2, 6, NULL, NULL, 1)
INSERT [dbo].[Kayit] ([kayitID], [programTurID], [ogrSinifID], [dersID], [tarih], [saat], [sinifID], [akademisyen1ID], [akademisyen2ID], [akademisyen3ID], [sinavTurID]) VALUES (13, 1, 2, 6, CAST(N'2024-05-21' AS Date), CAST(N'10:00:00' AS Time), 2, 6, NULL, NULL, 1)
INSERT [dbo].[Kayit] ([kayitID], [programTurID], [ogrSinifID], [dersID], [tarih], [saat], [sinifID], [akademisyen1ID], [akademisyen2ID], [akademisyen3ID], [sinavTurID]) VALUES (14, 1, 2, 1, CAST(N'2024-05-22' AS Date), CAST(N'14:00:00' AS Time), 2, 2, NULL, NULL, 1)
INSERT [dbo].[Kayit] ([kayitID], [programTurID], [ogrSinifID], [dersID], [tarih], [saat], [sinifID], [akademisyen1ID], [akademisyen2ID], [akademisyen3ID], [sinavTurID]) VALUES (15, 1, 2, 5, CAST(N'2024-05-29' AS Date), CAST(N'15:50:00' AS Time), 2, 6, NULL, NULL, 1)
INSERT [dbo].[Kayit] ([kayitID], [programTurID], [ogrSinifID], [dersID], [tarih], [saat], [sinifID], [akademisyen1ID], [akademisyen2ID], [akademisyen3ID], [sinavTurID]) VALUES (19, 1, 1, 2, CAST(N'2024-06-04' AS Date), CAST(N'12:00:00' AS Time), 1, 2, 6, 13, 1)
INSERT [dbo].[Kayit] ([kayitID], [programTurID], [ogrSinifID], [dersID], [tarih], [saat], [sinifID], [akademisyen1ID], [akademisyen2ID], [akademisyen3ID], [sinavTurID]) VALUES (26, 1, 2, 9, CAST(N'2024-06-13' AS Date), CAST(N'14:00:00' AS Time), 2, 12, 13, 26, 1)
INSERT [dbo].[Kayit] ([kayitID], [programTurID], [ogrSinifID], [dersID], [tarih], [saat], [sinifID], [akademisyen1ID], [akademisyen2ID], [akademisyen3ID], [sinavTurID]) VALUES (27, 1, 1, 22, CAST(N'2024-06-01' AS Date), CAST(N'11:00:00' AS Time), 1, 13, 2, 26, 1)
INSERT [dbo].[Kayit] ([kayitID], [programTurID], [ogrSinifID], [dersID], [tarih], [saat], [sinifID], [akademisyen1ID], [akademisyen2ID], [akademisyen3ID], [sinavTurID]) VALUES (30, 1, 1, 1, CAST(N'2024-06-05' AS Date), CAST(N'12:00:00' AS Time), 1, 6, 13, 26, 1)
INSERT [dbo].[Kayit] ([kayitID], [programTurID], [ogrSinifID], [dersID], [tarih], [saat], [sinifID], [akademisyen1ID], [akademisyen2ID], [akademisyen3ID], [sinavTurID]) VALUES (31, 1, 2, 4, CAST(N'2024-06-07' AS Date), CAST(N'15:00:00' AS Time), 2, 2, 6, 26, 2)
INSERT [dbo].[Kayit] ([kayitID], [programTurID], [ogrSinifID], [dersID], [tarih], [saat], [sinifID], [akademisyen1ID], [akademisyen2ID], [akademisyen3ID], [sinavTurID]) VALUES (32, 1, 2, 4, CAST(N'2024-06-08' AS Date), CAST(N'01:00:00' AS Time), 2, 3, 6, 26, 2)
INSERT [dbo].[Kayit] ([kayitID], [programTurID], [ogrSinifID], [dersID], [tarih], [saat], [sinifID], [akademisyen1ID], [akademisyen2ID], [akademisyen3ID], [sinavTurID]) VALUES (33, 1, 1, 5, CAST(N'2024-06-08' AS Date), CAST(N'11:00:00' AS Time), 1, 3, 13, 26, 1)
SET IDENTITY_INSERT [dbo].[Kayit] OFF
GO
SET IDENTITY_INSERT [dbo].[OgrenciSinif] ON 

INSERT [dbo].[OgrenciSinif] ([ogrSinifID], [ad]) VALUES (1, 1)
INSERT [dbo].[OgrenciSinif] ([ogrSinifID], [ad]) VALUES (2, 2)
SET IDENTITY_INSERT [dbo].[OgrenciSinif] OFF
GO
SET IDENTITY_INSERT [dbo].[ProgramTur] ON 

INSERT [dbo].[ProgramTur] ([programTurID], [ad]) VALUES (1, N'BİLGİSAYAR')
SET IDENTITY_INSERT [dbo].[ProgramTur] OFF
GO
SET IDENTITY_INSERT [dbo].[SinavTur] ON 

INSERT [dbo].[SinavTur] ([sinavTurID], [ad]) VALUES (1, N'Vize')
INSERT [dbo].[SinavTur] ([sinavTurID], [ad]) VALUES (2, N'Final')
SET IDENTITY_INSERT [dbo].[SinavTur] OFF
GO
SET IDENTITY_INSERT [dbo].[Sinif] ON 

INSERT [dbo].[Sinif] ([sinifID], [ad], [kapasite]) VALUES (1, N'303', 50)
INSERT [dbo].[Sinif] ([sinifID], [ad], [kapasite]) VALUES (2, N'305', 50)
SET IDENTITY_INSERT [dbo].[Sinif] OFF
GO
ALTER TABLE [dbo].[Kayit]  WITH CHECK ADD  CONSTRAINT [FK_Kayit_Akademisyen] FOREIGN KEY([akademisyen1ID])
REFERENCES [dbo].[Akademisyen] ([akademisyenID])
GO
ALTER TABLE [dbo].[Kayit] CHECK CONSTRAINT [FK_Kayit_Akademisyen]
GO
ALTER TABLE [dbo].[Kayit]  WITH CHECK ADD  CONSTRAINT [FK_Kayit_Akademisyen1] FOREIGN KEY([akademisyen2ID])
REFERENCES [dbo].[Akademisyen] ([akademisyenID])
GO
ALTER TABLE [dbo].[Kayit] CHECK CONSTRAINT [FK_Kayit_Akademisyen1]
GO
ALTER TABLE [dbo].[Kayit]  WITH CHECK ADD  CONSTRAINT [FK_Kayit_Akademisyen2] FOREIGN KEY([akademisyen3ID])
REFERENCES [dbo].[Akademisyen] ([akademisyenID])
GO
ALTER TABLE [dbo].[Kayit] CHECK CONSTRAINT [FK_Kayit_Akademisyen2]
GO
ALTER TABLE [dbo].[Kayit]  WITH CHECK ADD  CONSTRAINT [FK_Kayit_Ders] FOREIGN KEY([dersID])
REFERENCES [dbo].[Ders] ([dersID])
GO
ALTER TABLE [dbo].[Kayit] CHECK CONSTRAINT [FK_Kayit_Ders]
GO
ALTER TABLE [dbo].[Kayit]  WITH CHECK ADD  CONSTRAINT [FK_Kayit_OgrenciSinif1] FOREIGN KEY([ogrSinifID])
REFERENCES [dbo].[OgrenciSinif] ([ogrSinifID])
GO
ALTER TABLE [dbo].[Kayit] CHECK CONSTRAINT [FK_Kayit_OgrenciSinif1]
GO
ALTER TABLE [dbo].[Kayit]  WITH CHECK ADD  CONSTRAINT [FK_Kayit_ProgramTur] FOREIGN KEY([programTurID])
REFERENCES [dbo].[ProgramTur] ([programTurID])
GO
ALTER TABLE [dbo].[Kayit] CHECK CONSTRAINT [FK_Kayit_ProgramTur]
GO
ALTER TABLE [dbo].[Kayit]  WITH CHECK ADD  CONSTRAINT [FK_Kayit_SinavTur] FOREIGN KEY([sinavTurID])
REFERENCES [dbo].[SinavTur] ([sinavTurID])
GO
ALTER TABLE [dbo].[Kayit] CHECK CONSTRAINT [FK_Kayit_SinavTur]
GO
ALTER TABLE [dbo].[Kayit]  WITH CHECK ADD  CONSTRAINT [FK_Kayit_Sinif] FOREIGN KEY([sinifID])
REFERENCES [dbo].[Sinif] ([sinifID])
GO
ALTER TABLE [dbo].[Kayit] CHECK CONSTRAINT [FK_Kayit_Sinif]
GO
ALTER TABLE [dbo].[SinifKayit]  WITH CHECK ADD  CONSTRAINT [FK_SinifKayit_Akademisyen] FOREIGN KEY([gozetmenID])
REFERENCES [dbo].[Akademisyen] ([akademisyenID])
GO
ALTER TABLE [dbo].[SinifKayit] CHECK CONSTRAINT [FK_SinifKayit_Akademisyen]
GO
ALTER TABLE [dbo].[SinifKayit]  WITH CHECK ADD  CONSTRAINT [FK_SinifKayit_Kayit] FOREIGN KEY([kayitID])
REFERENCES [dbo].[Kayit] ([kayitID])
GO
ALTER TABLE [dbo].[SinifKayit] CHECK CONSTRAINT [FK_SinifKayit_Kayit]
GO
ALTER TABLE [dbo].[SinifKayit]  WITH CHECK ADD  CONSTRAINT [FK_SinifKayit_Sinif] FOREIGN KEY([sinifID])
REFERENCES [dbo].[Sinif] ([sinifID])
GO
ALTER TABLE [dbo].[SinifKayit] CHECK CONSTRAINT [FK_SinifKayit_Sinif]
GO

USE [master]
GO
/****** Object:  Database [OtelRezarvasyonDB]    Script Date: 25.05.2024 23:44:57 ******/
CREATE DATABASE [OtelRezarvasyonDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OtelRezarvasyonDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\OtelRezarvasyonDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OtelRezarvasyonDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\OtelRezarvasyonDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [OtelRezarvasyonDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OtelRezarvasyonDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OtelRezarvasyonDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET RECOVERY FULL 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET  MULTI_USER 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OtelRezarvasyonDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OtelRezarvasyonDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'OtelRezarvasyonDB', N'ON'
GO
ALTER DATABASE [OtelRezarvasyonDB] SET QUERY_STORE = OFF
GO
USE [OtelRezarvasyonDB]
GO
/****** Object:  Table [dbo].[TblDepartman]    Script Date: 25.05.2024 23:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblDepartman](
	[DepartmanID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmanAd] [nvarchar](50) NULL,
	[Telefon] [char](10) NULL,
	[Durum] [int] NOT NULL,
 CONSTRAINT [PK_TblDepartman] PRIMARY KEY CLUSTERED 
(
	[DepartmanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblDurum]    Script Date: 25.05.2024 23:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblDurum](
	[DurumID] [int] IDENTITY(1,1) NOT NULL,
	[DurumAd] [nvarchar](20) NULL,
 CONSTRAINT [PK_TblDurum] PRIMARY KEY CLUSTERED 
(
	[DurumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblGorev]    Script Date: 25.05.2024 23:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblGorev](
	[GorevID] [int] IDENTITY(1,1) NOT NULL,
	[GorevAd] [nvarchar](50) NULL,
	[Departman] [int] NULL,
	[Durum] [int] NOT NULL,
 CONSTRAINT [PK_TblGorev] PRIMARY KEY CLUSTERED 
(
	[GorevID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblHakkimda]    Script Date: 25.05.2024 23:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblHakkimda](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Hakkimda1] [nvarchar](1000) NULL,
	[Hakkimda2] [nvarchar](1000) NULL,
	[Hakkimda3] [nvarchar](1000) NULL,
	[Hakkimda4] [nvarchar](1000) NULL,
 CONSTRAINT [PK_TblHakkimda] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tblİletisim]    Script Date: 25.05.2024 23:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tblİletisim](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Aciklama] [nvarchar](1000) NULL,
	[Koordinat] [nvarchar](1000) NULL,
	[Telefon] [nvarchar](30) NULL,
	[Email] [nvarchar](50) NULL,
	[Adres] [nvarchar](250) NULL,
 CONSTRAINT [PK_Tblİletisim] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblMesaj]    Script Date: 25.05.2024 23:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblMesaj](
	[MesajID] [int] IDENTITY(1,1) NOT NULL,
	[Gonderen] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Konu] [nvarchar](100) NULL,
	[Mesaj] [nvarchar](1000) NULL,
 CONSTRAINT [PK_TblMesaj] PRIMARY KEY CLUSTERED 
(
	[MesajID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblMesaj2]    Script Date: 25.05.2024 23:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblMesaj2](
	[MesajID] [int] IDENTITY(1,1) NOT NULL,
	[Gonderen] [nvarchar](100) NULL,
	[Alici] [nvarchar](100) NULL,
	[Konu] [nvarchar](1000) NULL,
	[Mesaj] [nvarchar](max) NULL,
	[Tarih] [date] NULL,
 CONSTRAINT [PK_TblMesaj2] PRIMARY KEY CLUSTERED 
(
	[MesajID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblMisafir]    Script Date: 25.05.2024 23:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblMisafir](
	[MisafirID] [int] IDENTITY(1,1) NOT NULL,
	[AdSoyad] [nvarchar](50) NULL,
	[TC] [char](11) NULL,
	[Email] [nvarchar](50) NULL,
	[Sifre] [nvarchar](50) NULL,
	[Telefon] [nvarchar](20) NULL,
	[Adres] [nvarchar](200) NULL,
	[Aciklama] [nvarchar](250) NULL,
	[Ulke] [int] NULL,
	[Durum] [int] NULL,
 CONSTRAINT [PK_TblMisafir] PRIMARY KEY CLUSTERED 
(
	[MisafirID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblOda]    Script Date: 25.05.2024 23:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblOda](
	[OdaID] [int] IDENTITY(1,1) NOT NULL,
	[OdaNo] [char](3) NULL,
	[Kat] [varchar](2) NULL,
	[Kapasite] [char](1) NULL,
	[Aciklama] [nvarchar](200) NULL,
	[Telefon] [char](4) NULL,
	[Durum] [int] NOT NULL,
 CONSTRAINT [PK_TblOda] PRIMARY KEY CLUSTERED 
(
	[OdaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblPersonel]    Script Date: 25.05.2024 23:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblPersonel](
	[PersonelID] [int] IDENTITY(1,1) NOT NULL,
	[AdSoyad] [nvarchar](50) NULL,
	[TC] [char](11) NULL,
	[Adres] [nvarchar](250) NULL,
	[Telefon] [nvarchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[IseGirisTarih] [date] NULL,
	[IstenCikisTarih] [date] NULL,
	[Departman] [int] NULL,
	[Gorev] [int] NULL,
	[Aciklama] [nvarchar](250) NULL,
	[Durum] [int] NOT NULL,
 CONSTRAINT [PK_TblPersonel] PRIMARY KEY CLUSTERED 
(
	[PersonelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblRezervasyon]    Script Date: 25.05.2024 23:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblRezervasyon](
	[RezervasyonID] [int] IDENTITY(1,1) NOT NULL,
	[Misafir] [int] NULL,
	[GirisTarih] [date] NULL,
	[CikisTarih] [date] NULL,
	[Kisi] [char](1) NULL,
	[Oda] [int] NULL,
	[RezervasyonAdSoyad] [nvarchar](50) NULL,
	[Telefon] [nvarchar](20) NULL,
	[Aciklama] [nvarchar](500) NULL,
	[Durum] [int] NOT NULL,
 CONSTRAINT [PK_TblRezervasyon] PRIMARY KEY CLUSTERED 
(
	[RezervasyonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblUlke]    Script Date: 25.05.2024 23:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblUlke](
	[UlkeID] [int] IDENTITY(1,1) NOT NULL,
	[UlkeAd] [nvarchar](30) NULL,
 CONSTRAINT [PK_TblUlke] PRIMARY KEY CLUSTERED 
(
	[UlkeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblYeniKayit]    Script Date: 25.05.2024 23:44:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblYeniKayit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AdSoyad] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Telefon] [nvarchar](20) NULL,
	[Sifre] [nvarchar](50) NULL,
 CONSTRAINT [PK_TblYeniKayit] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblDepartman] ON 

INSERT [dbo].[TblDepartman] ([DepartmanID], [DepartmanAd], [Telefon], [Durum]) VALUES (1, N'Yönetici', N'3647      ', 1)
SET IDENTITY_INSERT [dbo].[TblDepartman] OFF
GO
SET IDENTITY_INSERT [dbo].[TblDurum] ON 

INSERT [dbo].[TblDurum] ([DurumID], [DurumAd]) VALUES (1, N'Aktif')
INSERT [dbo].[TblDurum] ([DurumID], [DurumAd]) VALUES (2, N'Pasif')
INSERT [dbo].[TblDurum] ([DurumID], [DurumAd]) VALUES (3, N'Kirli')
INSERT [dbo].[TblDurum] ([DurumID], [DurumAd]) VALUES (4, N'Temiz')
INSERT [dbo].[TblDurum] ([DurumID], [DurumAd]) VALUES (5, N'Arızalı Oda')
INSERT [dbo].[TblDurum] ([DurumID], [DurumAd]) VALUES (6, N'Ürün Stok Azaldı')
INSERT [dbo].[TblDurum] ([DurumID], [DurumAd]) VALUES (7, N'Ürün Stok Yeterli')
INSERT [dbo].[TblDurum] ([DurumID], [DurumAd]) VALUES (8, N'İzinde')
INSERT [dbo].[TblDurum] ([DurumID], [DurumAd]) VALUES (9, N'Raporlu')
INSERT [dbo].[TblDurum] ([DurumID], [DurumAd]) VALUES (10, N'Oda Dolu')
INSERT [dbo].[TblDurum] ([DurumID], [DurumAd]) VALUES (11, N'Rezervasyon İptal')
INSERT [dbo].[TblDurum] ([DurumID], [DurumAd]) VALUES (12, N'Çıkış Yapıldı')
INSERT [dbo].[TblDurum] ([DurumID], [DurumAd]) VALUES (13, N'Rezervasyon Yapıldı')
SET IDENTITY_INSERT [dbo].[TblDurum] OFF
GO
SET IDENTITY_INSERT [dbo].[TblGorev] ON 

INSERT [dbo].[TblGorev] ([GorevID], [GorevAd], [Departman], [Durum]) VALUES (1, N'Yönetici', 1, 1)
SET IDENTITY_INSERT [dbo].[TblGorev] OFF
GO
SET IDENTITY_INSERT [dbo].[TblHakkimda] ON 

INSERT [dbo].[TblHakkimda] ([ID], [Hakkimda1], [Hakkimda2], [Hakkimda3], [Hakkimda4]) VALUES (1, N'Otel ve truzim sektöründe 9. yılımızda sizlere hizmet vermenin mutluluğunu yaşıyoruz.', N'Otelcilik bizi için bir iş değil ,misafirlerimizin mutluluğu, çalışanlarımızın motivasyon kaynağıdır. İzmir,Antalya,Manisa ve İstanbul olmak üzere 4 farklı şehirdeki şubelerimizle sizlere hizmet vermeye devam ediyoruz. Önümüzdeki yaz Doğu anadolu bölgesinde kış truzimi için yeni bir şube olarak Kars''da 5.şubemizi açacağız. Yılın misafirlerimizi ağrlamaktan onur duyarız.  ', N'Hemen rezervasyonunuzu yapıp bu eğlenceli tatile başlayın.', N'İster eğlenmek, ister dinlenmek için yılın tüm yorgunluğunu atmak adına sizleri otelimize bekliyoruz. Haziran ayı rezervasyonlarında %25 indirim uygulanacaktır.')
SET IDENTITY_INSERT [dbo].[TblHakkimda] OFF
GO
SET IDENTITY_INSERT [dbo].[Tblİletisim] ON 

INSERT [dbo].[Tblİletisim] ([ID], [Aciklama], [Koordinat], [Telefon], [Email], [Adres]) VALUES (1, N' İzmir, Antalya, Manisa ve İstanbul illerindeki 4 farklı şubemizle yılın 365 gününde hem yaz
 hem de kış sezonlarında sizlere güler yüzlü personelimizle hizmet vermeye devam ediyoruz.
 Aklınıza takılan tüm sorular için bir telefon uzağınızdayız. Bizi 24 saat arayabilirsiniz.', N'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d6384.17865160219!2d30.634427790996224!3d36.86428065980212!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14c39171fa11b9d5%3A0xd92f0aa0f6e40106!2zQWx0xLFua3VtLCBBa2Rlbml6IEJsdi4gMTc2IEMsIDA3MDcwIEJhaHTEsWzEsSBLw7Z5w7wgS8O2ecO8L0tvbnlhYWx0xLEvQW50YWx5YQ!5e0!3m2!1str!2str!4v1715126164452!5m2!1str!2str', N'+(90)-(552)-8819-8819', N'otel@gmail.com', N'Altınkum, Akdeniz Blv. 176 C, 07070 Bahtılı Köyü Köyü/Konyaaltı/Antalya')
SET IDENTITY_INSERT [dbo].[Tblİletisim] OFF
GO
SET IDENTITY_INSERT [dbo].[TblMesaj] ON 

INSERT [dbo].[TblMesaj] ([MesajID], [Gonderen], [Email], [Konu], [Mesaj]) VALUES (1, N'Veli Yıldız', N'veli@gmail.com', N'Teşekkür', N'Otelinizden çok memnun kaldık.')
INSERT [dbo].[TblMesaj] ([MesajID], [Gonderen], [Email], [Konu], [Mesaj]) VALUES (2, N'İrem Ay', N'irem@gmail.com', N'Rica', N'Fiyatları Öğrenebilir miyim?')
INSERT [dbo].[TblMesaj] ([MesajID], [Gonderen], [Email], [Konu], [Mesaj]) VALUES (3, N'İrem Ay', N'irem@gmail.com', N'Rica', N'Fiyatları Öğrenebilir miyim?')
INSERT [dbo].[TblMesaj] ([MesajID], [Gonderen], [Email], [Konu], [Mesaj]) VALUES (4, N'Mahmut Odabaşı', N'odabasi@gmail.com', N'Memnuniyet', N'Her şeyden çok memnun kaldım teşekkürler.')
SET IDENTITY_INSERT [dbo].[TblMesaj] OFF
GO
SET IDENTITY_INSERT [dbo].[TblMesaj2] ON 

INSERT [dbo].[TblMesaj2] ([MesajID], [Gonderen], [Alici], [Konu], [Mesaj], [Tarih]) VALUES (1, N'turkan@gmail.com', N'fatma@gmail.com', N'teşekkür', N'Merhaba Fatma Hanım sizlere çok teşekkür ediyorum güzel yorumlarda bulunmuşsunuz,sağlıklı güzler dilerim.', CAST(N'2024-05-10' AS Date))
INSERT [dbo].[TblMesaj2] ([MesajID], [Gonderen], [Alici], [Konu], [Mesaj], [Tarih]) VALUES (2, N'fatma@gmail.com', N'turkan@gmail.com', N'rica', N'Çalışanlarınız çok ilgiliydi teşşekür ederiz', CAST(N'2024-05-10' AS Date))
INSERT [dbo].[TblMesaj2] ([MesajID], [Gonderen], [Alici], [Konu], [Mesaj], [Tarih]) VALUES (1008, N'fatma@gmail.com', N'turkan@gmail.com', N'Teşekkür', N'İlginiz için teşekkürler.', CAST(N'2024-05-08' AS Date))
INSERT [dbo].[TblMesaj2] ([MesajID], [Gonderen], [Alici], [Konu], [Mesaj], [Tarih]) VALUES (1012, N'sude@gmail.com', N'turkan@gmail.com', N'Memnuniyet', N'Oteliniz de kaldığım süre boyunca çok memnun kaldım her şer için teşekkürler.', CAST(N'2024-05-08' AS Date))
INSERT [dbo].[TblMesaj2] ([MesajID], [Gonderen], [Alici], [Konu], [Mesaj], [Tarih]) VALUES (1013, N'turkan@gmail.com', N'sude@gmail.com', N'Teşekkürler', N'Bizi tercih ettiğiniz için biz teşekkür ederiz.', CAST(N'2024-05-08' AS Date))
SET IDENTITY_INSERT [dbo].[TblMesaj2] OFF
GO
SET IDENTITY_INSERT [dbo].[TblMisafir] ON 

INSERT [dbo].[TblMisafir] ([MisafirID], [AdSoyad], [TC], [Email], [Sifre], [Telefon], [Adres], [Aciklama], [Ulke], [Durum]) VALUES (1, N'Fatma Güler', N'14783175324', N'fatma@gmail.com', N'123', N'05524871265', N'Ankara', N'İş Seyahati', 1, 1)
INSERT [dbo].[TblMisafir] ([MisafirID], [AdSoyad], [TC], [Email], [Sifre], [Telefon], [Adres], [Aciklama], [Ulke], [Durum]) VALUES (2, N'Sude Alaca', N'13258961478', N'sude@gmail.com', N'1234', N'05462684576', N'İzmir', N'Seminer', 1, 1)
INSERT [dbo].[TblMisafir] ([MisafirID], [AdSoyad], [TC], [Email], [Sifre], [Telefon], [Adres], [Aciklama], [Ulke], [Durum]) VALUES (3, N'Hasan Danacı', N'13579621456', N'hasan@gmail.com', N'1212', N'05562487562', N'İstanbul', N'Tatil', 1, 1)
INSERT [dbo].[TblMisafir] ([MisafirID], [AdSoyad], [TC], [Email], [Sifre], [Telefon], [Adres], [Aciklama], [Ulke], [Durum]) VALUES (4, N'Su Demir', N'58963214753', N'su@gmail.com', N'4747', N'05521232323', N'Balikesir', N'Gezi', 1, 1)
INSERT [dbo].[TblMisafir] ([MisafirID], [AdSoyad], [TC], [Email], [Sifre], [Telefon], [Adres], [Aciklama], [Ulke], [Durum]) VALUES (5, N'Ulvi Ateş', NULL, N'ulvi@gmail.com', N'3636', N'05524684747', NULL, NULL, NULL, NULL)
INSERT [dbo].[TblMisafir] ([MisafirID], [AdSoyad], [TC], [Email], [Sifre], [Telefon], [Adres], [Aciklama], [Ulke], [Durum]) VALUES (6, N'Elif Su', NULL, N'elif@gmail.com', N'125', N'0553218836', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TblMisafir] OFF
GO
SET IDENTITY_INSERT [dbo].[TblOda] ON 

INSERT [dbo].[TblOda] ([OdaID], [OdaNo], [Kat], [Kapasite], [Aciklama], [Telefon], [Durum]) VALUES (6, N'6  ', N'4', N'1', N'1 kisilik', N'40  ', 2)
INSERT [dbo].[TblOda] ([OdaID], [OdaNo], [Kat], [Kapasite], [Aciklama], [Telefon], [Durum]) VALUES (7, N'7  ', N'4', N'1', N'1 kisilik', N'41  ', 1)
INSERT [dbo].[TblOda] ([OdaID], [OdaNo], [Kat], [Kapasite], [Aciklama], [Telefon], [Durum]) VALUES (10, N'10 ', N'4', N'1', N'1 kisilik', N'42  ', 2)
INSERT [dbo].[TblOda] ([OdaID], [OdaNo], [Kat], [Kapasite], [Aciklama], [Telefon], [Durum]) VALUES (13, N'13 ', N'4', N'1', N'1 kisilik', N'43  ', 2)
INSERT [dbo].[TblOda] ([OdaID], [OdaNo], [Kat], [Kapasite], [Aciklama], [Telefon], [Durum]) VALUES (15, N'15 ', N'5', N'2', N'2 kisilik', N'44  ', 2)
INSERT [dbo].[TblOda] ([OdaID], [OdaNo], [Kat], [Kapasite], [Aciklama], [Telefon], [Durum]) VALUES (16, N'16 ', N'5', N'2', N'2 kisilik', N'45  ', 2)
INSERT [dbo].[TblOda] ([OdaID], [OdaNo], [Kat], [Kapasite], [Aciklama], [Telefon], [Durum]) VALUES (17, N'17 ', N'5', N'2', N'2 kisilik', N'46  ', 1)
INSERT [dbo].[TblOda] ([OdaID], [OdaNo], [Kat], [Kapasite], [Aciklama], [Telefon], [Durum]) VALUES (18, N'18 ', N'5', N'2', N'4 kisilik', N'44  ', 2)
SET IDENTITY_INSERT [dbo].[TblOda] OFF
GO
SET IDENTITY_INSERT [dbo].[TblPersonel] ON 

INSERT [dbo].[TblPersonel] ([PersonelID], [AdSoyad], [TC], [Adres], [Telefon], [Email], [IseGirisTarih], [IstenCikisTarih], [Departman], [Gorev], [Aciklama], [Durum]) VALUES (1, N'Türkan Ergünn', N'12345678910', N'İstanbul', N'05462876361', N'turkan@gmail.com', CAST(N'2015-02-12' AS Date), NULL, 1, 1, N'Tüm Yetkilere Sahip', 1)
SET IDENTITY_INSERT [dbo].[TblPersonel] OFF
GO
SET IDENTITY_INSERT [dbo].[TblRezervasyon] ON 

INSERT [dbo].[TblRezervasyon] ([RezervasyonID], [Misafir], [GirisTarih], [CikisTarih], [Kisi], [Oda], [RezervasyonAdSoyad], [Telefon], [Aciklama], [Durum]) VALUES (2, 1, CAST(N'2024-02-12' AS Date), CAST(N'2024-04-03' AS Date), N'1', 6, N'Fatma Güler', N'05524871265', N'Suit Oda', 1)
INSERT [dbo].[TblRezervasyon] ([RezervasyonID], [Misafir], [GirisTarih], [CikisTarih], [Kisi], [Oda], [RezervasyonAdSoyad], [Telefon], [Aciklama], [Durum]) VALUES (5, 1, CAST(N'2024-05-09' AS Date), CAST(N'2024-06-19' AS Date), N'1', 6, N'Fatma Güler', N'05524871265', N'Tek Kişilik', 13)
INSERT [dbo].[TblRezervasyon] ([RezervasyonID], [Misafir], [GirisTarih], [CikisTarih], [Kisi], [Oda], [RezervasyonAdSoyad], [Telefon], [Aciklama], [Durum]) VALUES (8, 2, CAST(N'2024-05-24' AS Date), CAST(N'2024-05-19' AS Date), N'1', 6, N'Sude Alaca', N'05462684576', N'Tek Kişilik', 13)
INSERT [dbo].[TblRezervasyon] ([RezervasyonID], [Misafir], [GirisTarih], [CikisTarih], [Kisi], [Oda], [RezervasyonAdSoyad], [Telefon], [Aciklama], [Durum]) VALUES (12, 1, CAST(N'2024-05-18' AS Date), CAST(N'2024-06-22' AS Date), N'1', 6, N'Sude Alaca', N'05462684576', N'Seminer', 13)
INSERT [dbo].[TblRezervasyon] ([RezervasyonID], [Misafir], [GirisTarih], [CikisTarih], [Kisi], [Oda], [RezervasyonAdSoyad], [Telefon], [Aciklama], [Durum]) VALUES (17, 3, CAST(N'2024-05-19' AS Date), CAST(N'2024-05-22' AS Date), N'1', 7, N'Hasan Danacı', N'05562487562', N'Tatil', 13)
INSERT [dbo].[TblRezervasyon] ([RezervasyonID], [Misafir], [GirisTarih], [CikisTarih], [Kisi], [Oda], [RezervasyonAdSoyad], [Telefon], [Aciklama], [Durum]) VALUES (18, 1, CAST(N'2024-05-25' AS Date), CAST(N'2024-06-02' AS Date), N'1', 13, N'Fatma Güler', N'05524871265', N'Tatil', 13)
INSERT [dbo].[TblRezervasyon] ([RezervasyonID], [Misafir], [GirisTarih], [CikisTarih], [Kisi], [Oda], [RezervasyonAdSoyad], [Telefon], [Aciklama], [Durum]) VALUES (19, 1, CAST(N'2024-05-18' AS Date), CAST(N'2024-05-25' AS Date), N'1', 6, N'Fatma Güler', N'05524871265', N'Genç Oda', 13)
INSERT [dbo].[TblRezervasyon] ([RezervasyonID], [Misafir], [GirisTarih], [CikisTarih], [Kisi], [Oda], [RezervasyonAdSoyad], [Telefon], [Aciklama], [Durum]) VALUES (20, 1, CAST(N'2024-05-17' AS Date), CAST(N'2024-05-25' AS Date), N'1', 18, N'Fatma Güler', N'05524871265', N'Tek Kişilik', 13)
INSERT [dbo].[TblRezervasyon] ([RezervasyonID], [Misafir], [GirisTarih], [CikisTarih], [Kisi], [Oda], [RezervasyonAdSoyad], [Telefon], [Aciklama], [Durum]) VALUES (35, 2, CAST(N'2024-05-12' AS Date), CAST(N'2024-05-17' AS Date), N'1', 6, N'Sude Alaca', N'05524871265', N'Gezme', 13)
INSERT [dbo].[TblRezervasyon] ([RezervasyonID], [Misafir], [GirisTarih], [CikisTarih], [Kisi], [Oda], [RezervasyonAdSoyad], [Telefon], [Aciklama], [Durum]) VALUES (44, 1, CAST(N'2024-05-19' AS Date), CAST(N'2024-06-01' AS Date), N'2', 15, N'Hasan Danacı', N'05524871265', N'İki Kişi', 13)
INSERT [dbo].[TblRezervasyon] ([RezervasyonID], [Misafir], [GirisTarih], [CikisTarih], [Kisi], [Oda], [RezervasyonAdSoyad], [Telefon], [Aciklama], [Durum]) VALUES (58, NULL, CAST(N'2024-06-13' AS Date), CAST(N'2024-06-22' AS Date), N'1', 10, N'Su Demir', N'05521232323', N'tatil', 13)
INSERT [dbo].[TblRezervasyon] ([RezervasyonID], [Misafir], [GirisTarih], [CikisTarih], [Kisi], [Oda], [RezervasyonAdSoyad], [Telefon], [Aciklama], [Durum]) VALUES (59, NULL, CAST(N'2024-05-26' AS Date), CAST(N'2024-06-06' AS Date), N'1', 15, N'Ulvi Ateş', N'05524684747', N'gezi', 13)
INSERT [dbo].[TblRezervasyon] ([RezervasyonID], [Misafir], [GirisTarih], [CikisTarih], [Kisi], [Oda], [RezervasyonAdSoyad], [Telefon], [Aciklama], [Durum]) VALUES (60, NULL, CAST(N'2024-06-08' AS Date), CAST(N'2024-06-15' AS Date), N'1', 18, N'Ulvi Ateş', N'05524684747', N'gezi', 13)
INSERT [dbo].[TblRezervasyon] ([RezervasyonID], [Misafir], [GirisTarih], [CikisTarih], [Kisi], [Oda], [RezervasyonAdSoyad], [Telefon], [Aciklama], [Durum]) VALUES (63, NULL, CAST(N'2024-05-16' AS Date), CAST(N'2024-05-19' AS Date), N'1', 13, N'Su Demir', N'05521232323', N'tatil', 13)
INSERT [dbo].[TblRezervasyon] ([RezervasyonID], [Misafir], [GirisTarih], [CikisTarih], [Kisi], [Oda], [RezervasyonAdSoyad], [Telefon], [Aciklama], [Durum]) VALUES (64, NULL, CAST(N'2024-05-20' AS Date), CAST(N'2024-05-26' AS Date), N'1', 6, N'Su Demir', N'05521232323', N'tatil', 13)
INSERT [dbo].[TblRezervasyon] ([RezervasyonID], [Misafir], [GirisTarih], [CikisTarih], [Kisi], [Oda], [RezervasyonAdSoyad], [Telefon], [Aciklama], [Durum]) VALUES (70, NULL, CAST(N'2024-06-12' AS Date), CAST(N'2024-06-21' AS Date), N'1', 10, N'Su Demir', N'05521232323', N'gezi', 13)
INSERT [dbo].[TblRezervasyon] ([RezervasyonID], [Misafir], [GirisTarih], [CikisTarih], [Kisi], [Oda], [RezervasyonAdSoyad], [Telefon], [Aciklama], [Durum]) VALUES (72, NULL, CAST(N'2024-05-15' AS Date), CAST(N'2024-05-18' AS Date), N'1', 6, N'Elif Su', N'05523218856', N'tatil', 13)
SET IDENTITY_INSERT [dbo].[TblRezervasyon] OFF
GO
SET IDENTITY_INSERT [dbo].[TblUlke] ON 

INSERT [dbo].[TblUlke] ([UlkeID], [UlkeAd]) VALUES (1, N'Türkiye')
SET IDENTITY_INSERT [dbo].[TblUlke] OFF
GO
SET IDENTITY_INSERT [dbo].[TblYeniKayit] ON 

INSERT [dbo].[TblYeniKayit] ([ID], [AdSoyad], [Email], [Telefon], [Sifre]) VALUES (1, N'Fatma Güler', N'fatma@gmail.com', N'05524871265', N'123')
INSERT [dbo].[TblYeniKayit] ([ID], [AdSoyad], [Email], [Telefon], [Sifre]) VALUES (2, N'Sude Alaca', N'sude@gmail.com', N'05462684576', N'1234')
INSERT [dbo].[TblYeniKayit] ([ID], [AdSoyad], [Email], [Telefon], [Sifre]) VALUES (3, N'Hasan Danacı', N'hasan@gmail.com', N'05562487562', N'1212')
INSERT [dbo].[TblYeniKayit] ([ID], [AdSoyad], [Email], [Telefon], [Sifre]) VALUES (4, N'Ahmet Arıkan', N'ahmet@gmail.com', N'05523218845', N'123')
INSERT [dbo].[TblYeniKayit] ([ID], [AdSoyad], [Email], [Telefon], [Sifre]) VALUES (5, N'Mert Kaya', N'mert@gmail.com', N'05423694571', N'369')
INSERT [dbo].[TblYeniKayit] ([ID], [AdSoyad], [Email], [Telefon], [Sifre]) VALUES (6, NULL, NULL, N'0536925814712', NULL)
INSERT [dbo].[TblYeniKayit] ([ID], [AdSoyad], [Email], [Telefon], [Sifre]) VALUES (7, N'Veli Develi', N'develi@gmail.com', N'05369851475', N'159')
SET IDENTITY_INSERT [dbo].[TblYeniKayit] OFF
GO
ALTER TABLE [dbo].[TblDepartman]  WITH CHECK ADD  CONSTRAINT [FK_TblDepartman_TblDurum] FOREIGN KEY([Durum])
REFERENCES [dbo].[TblDurum] ([DurumID])
GO
ALTER TABLE [dbo].[TblDepartman] CHECK CONSTRAINT [FK_TblDepartman_TblDurum]
GO
ALTER TABLE [dbo].[TblGorev]  WITH CHECK ADD  CONSTRAINT [FK_TblGorev_TblDepartman] FOREIGN KEY([Departman])
REFERENCES [dbo].[TblDepartman] ([DepartmanID])
GO
ALTER TABLE [dbo].[TblGorev] CHECK CONSTRAINT [FK_TblGorev_TblDepartman]
GO
ALTER TABLE [dbo].[TblGorev]  WITH CHECK ADD  CONSTRAINT [FK_TblGorev_TblDurum] FOREIGN KEY([Durum])
REFERENCES [dbo].[TblDurum] ([DurumID])
GO
ALTER TABLE [dbo].[TblGorev] CHECK CONSTRAINT [FK_TblGorev_TblDurum]
GO
ALTER TABLE [dbo].[TblMisafir]  WITH CHECK ADD  CONSTRAINT [FK_TblMisafir_TblDurum] FOREIGN KEY([Durum])
REFERENCES [dbo].[TblDurum] ([DurumID])
GO
ALTER TABLE [dbo].[TblMisafir] CHECK CONSTRAINT [FK_TblMisafir_TblDurum]
GO
ALTER TABLE [dbo].[TblOda]  WITH CHECK ADD  CONSTRAINT [FK_TblOda_TblDurum] FOREIGN KEY([Durum])
REFERENCES [dbo].[TblDurum] ([DurumID])
GO
ALTER TABLE [dbo].[TblOda] CHECK CONSTRAINT [FK_TblOda_TblDurum]
GO
ALTER TABLE [dbo].[TblPersonel]  WITH CHECK ADD  CONSTRAINT [FK_TblPersonel_TblDepartman] FOREIGN KEY([Departman])
REFERENCES [dbo].[TblDepartman] ([DepartmanID])
GO
ALTER TABLE [dbo].[TblPersonel] CHECK CONSTRAINT [FK_TblPersonel_TblDepartman]
GO
ALTER TABLE [dbo].[TblPersonel]  WITH CHECK ADD  CONSTRAINT [FK_TblPersonel_TblDurum] FOREIGN KEY([Durum])
REFERENCES [dbo].[TblDurum] ([DurumID])
GO
ALTER TABLE [dbo].[TblPersonel] CHECK CONSTRAINT [FK_TblPersonel_TblDurum]
GO
ALTER TABLE [dbo].[TblRezervasyon]  WITH CHECK ADD  CONSTRAINT [FK_TblRezervasyon_TblDurum] FOREIGN KEY([Durum])
REFERENCES [dbo].[TblDurum] ([DurumID])
GO
ALTER TABLE [dbo].[TblRezervasyon] CHECK CONSTRAINT [FK_TblRezervasyon_TblDurum]
GO
ALTER TABLE [dbo].[TblRezervasyon]  WITH CHECK ADD  CONSTRAINT [FK_TblRezervasyon_TblMisafir] FOREIGN KEY([Misafir])
REFERENCES [dbo].[TblMisafir] ([MisafirID])
GO
ALTER TABLE [dbo].[TblRezervasyon] CHECK CONSTRAINT [FK_TblRezervasyon_TblMisafir]
GO
ALTER TABLE [dbo].[TblRezervasyon]  WITH CHECK ADD  CONSTRAINT [FK_TblRezervasyon_TblOda] FOREIGN KEY([Oda])
REFERENCES [dbo].[TblOda] ([OdaID])
GO
ALTER TABLE [dbo].[TblRezervasyon] CHECK CONSTRAINT [FK_TblRezervasyon_TblOda]
GO
USE [master]
GO
ALTER DATABASE [OtelRezarvasyonDB] SET  READ_WRITE 
GO

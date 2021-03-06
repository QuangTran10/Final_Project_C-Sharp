USE [master]
GO
/****** Object:  Database [banhang]    Script Date: 11/21/2021 10:33:34 AM ******/
CREATE DATABASE [banhang]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'banhang', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\banhang.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'banhang_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\banhang_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [banhang] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [banhang].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [banhang] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [banhang] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [banhang] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [banhang] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [banhang] SET ARITHABORT OFF 
GO
ALTER DATABASE [banhang] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [banhang] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [banhang] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [banhang] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [banhang] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [banhang] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [banhang] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [banhang] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [banhang] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [banhang] SET  DISABLE_BROKER 
GO
ALTER DATABASE [banhang] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [banhang] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [banhang] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [banhang] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [banhang] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [banhang] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [banhang] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [banhang] SET RECOVERY FULL 
GO
ALTER DATABASE [banhang] SET  MULTI_USER 
GO
ALTER DATABASE [banhang] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [banhang] SET DB_CHAINING OFF 
GO
ALTER DATABASE [banhang] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [banhang] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [banhang] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'banhang', N'ON'
GO
USE [banhang]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 11/21/2021 10:33:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaHD] [int] NOT NULL,
	[MaSanPham] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[GiamGia] [float] NOT NULL CONSTRAINT [DF_ChiTietHoaDon_GiamGia]  DEFAULT ((0)),
	[DonGia] [int] NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC,
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 11/21/2021 10:33:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHD] [int] NOT NULL,
	[MaNV] [int] NULL,
	[MaKH] [int] NULL,
	[NgayLapHD] [datetime] NOT NULL,
	[NgayGiao] [datetime] NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 11/21/2021 10:33:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[TenKH] [nvarchar](255) NOT NULL,
	[GioiTinh] [nvarchar](20) NOT NULL,
	[DiaChiKH] [nvarchar](255) NOT NULL,
	[SDT] [nvarchar](12) NOT NULL,
	[ThanhPho] [int] NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 11/21/2021 10:33:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[MaLSP] [int] IDENTITY(1,1) NOT NULL,
	[TenLSP] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_LoaiSanPham] PRIMARY KEY CLUSTERED 
(
	[MaLSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 11/21/2021 10:33:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](255) NOT NULL,
	[NgayLV] [date] NOT NULL,
	[SoDienThoai] [nvarchar](12) NOT NULL,
	[GioiTinh] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](255) NOT NULL,
	[TaiKhoan] [nvarchar](50) NULL,
	[Password] [nvarchar](255) NULL,
	[Admin] [tinyint] NOT NULL CONSTRAINT [DF_NhanVien_Admin]  DEFAULT ((0)),
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 11/21/2021 10:33:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSanPham] [int] IDENTITY(1,1) NOT NULL,
	[TenSanPham] [nvarchar](255) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[Gia] [float] NULL,
	[LoaiSanPham] [int] NULL,
	[HinhAnh] [text] NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThanhPho]    Script Date: 11/21/2021 10:33:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThanhPho](
	[ThanhPho] [int] NOT NULL,
	[TenThanhPho] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ThanhPho] PRIMARY KEY CLUSTERED 
(
	[ThanhPho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSanPham], [SoLuong], [GiamGia], [DonGia]) VALUES (2412, 2, 1, 0, 250000)
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSanPham], [SoLuong], [GiamGia], [DonGia]) VALUES (2874, 1, 1, 0, 500000)
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSanPham], [SoLuong], [GiamGia], [DonGia]) VALUES (2874, 6, 1, 0, 500000)
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSanPham], [SoLuong], [GiamGia], [DonGia]) VALUES (2890, 1, 3, 0, 500000)
INSERT [dbo].[ChiTietHoaDon] ([MaHD], [MaSanPham], [SoLuong], [GiamGia], [DonGia]) VALUES (2920, 1, 2, 0, 500000)
INSERT [dbo].[HoaDon] ([MaHD], [MaNV], [MaKH], [NgayLapHD], [NgayGiao]) VALUES (2412, 1, 1, CAST(N'2021-11-17 00:00:00.000' AS DateTime), CAST(N'2021-11-20 00:00:00.000' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [MaNV], [MaKH], [NgayLapHD], [NgayGiao]) VALUES (2874, 1, 1, CAST(N'2021-11-17 00:00:00.000' AS DateTime), CAST(N'2021-11-20 00:00:00.000' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [MaNV], [MaKH], [NgayLapHD], [NgayGiao]) VALUES (2890, 5, 2, CAST(N'2021-11-17 00:00:00.000' AS DateTime), CAST(N'2021-11-20 00:00:00.000' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHD], [MaNV], [MaKH], [NgayLapHD], [NgayGiao]) VALUES (2920, 5, 1, CAST(N'2021-11-17 00:00:00.000' AS DateTime), CAST(N'2021-11-20 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [GioiTinh], [DiaChiKH], [SDT], [ThanhPho]) VALUES (1, N'Khách Vãn Lai', N'Nam', N'Sóc Trăng', N'0859083181', 2)
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [GioiTinh], [DiaChiKH], [SDT], [ThanhPho]) VALUES (2, N'Trần Thanh Quang', N'Nam', N'180 Triệu Nương, TP Sóc Trăng', N'0859083181', 3)
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
SET IDENTITY_INSERT [dbo].[LoaiSanPham] ON 

INSERT [dbo].[LoaiSanPham] ([MaLSP], [TenLSP]) VALUES (1, N'Hoa Hồng')
INSERT [dbo].[LoaiSanPham] ([MaLSP], [TenLSP]) VALUES (2, N'Hoa Cúc')
INSERT [dbo].[LoaiSanPham] ([MaLSP], [TenLSP]) VALUES (3, N'Hoa Cẩm Tú Cầu')
INSERT [dbo].[LoaiSanPham] ([MaLSP], [TenLSP]) VALUES (4, N'Hoa Lan')
INSERT [dbo].[LoaiSanPham] ([MaLSP], [TenLSP]) VALUES (5, N'Hoa Mai')
INSERT [dbo].[LoaiSanPham] ([MaLSP], [TenLSP]) VALUES (7, N'Hoa Đào ')
SET IDENTITY_INSERT [dbo].[LoaiSanPham] OFF
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([MaNV], [HoTen], [NgayLV], [SoDienThoai], [GioiTinh], [DiaChi], [TaiKhoan], [Password], [Admin]) VALUES (1, N'Trần Tuấn Anh', CAST(N'2019-11-11' AS Date), N'0918151004', N'Nam', N'Sóc Trăng', N'admin', N'123456', 1)
INSERT [dbo].[NhanVien] ([MaNV], [HoTen], [NgayLV], [SoDienThoai], [GioiTinh], [DiaChi], [TaiKhoan], [Password], [Admin]) VALUES (5, N'Nguyễn Văn Entony', CAST(N'2021-11-01' AS Date), N'0377117471', N'Nam', N'Mỏ Cày Bắc, Bến Tre', N'entony', N'123456', 0)
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [SoLuong], [Gia], [LoaiSanPham], [HinhAnh]) VALUES (1, N'Hoa hồng trắng Shizuku Rose', 13, 500000, 1, N'D:\QuanLyBanHang\QuanLyBanHang\Resources\cac-loai-hoa-hong-trang-Shizuku.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [SoLuong], [Gia], [LoaiSanPham], [HinhAnh]) VALUES (2, N'Hoa hồng cổ Sapa', 9, 250000, 1, N'D:\QuanLyBanHang\QuanLyBanHang\Resources\hoa-hong-co-sapa.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [SoLuong], [Gia], [LoaiSanPham], [HinhAnh]) VALUES (3, N'Hoa hồng tím Lavender Crystal', 10, 700000, 1, N'D:\QuanLyBanHang\QuanLyBanHang\Resources\cac-loai-hoa-hong-tim-Lavender Crystal.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [SoLuong], [Gia], [LoaiSanPham], [HinhAnh]) VALUES (5, N'Lan Vũ Nữ', 10, 200000, 4, N'D:\QuanLyBanHang\QuanLyBanHang\Resources\20921bc1dd28d68592002564902a4711.jfif')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [SoLuong], [Gia], [LoaiSanPham], [HinhAnh]) VALUES (6, N'Lan Hồ Điệp', 19, 500000, 4, N'D:\QuanLyBanHang\QuanLyBanHang\Resources\ky-thuat-cham-soc-lan-ho-diep-cay-tuoi-tot-ra-hoa-deu-deu-hd1-1591526921-966-width600height600.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [SoLuong], [Gia], [LoaiSanPham], [HinhAnh]) VALUES (7, N'Hoa Mai Vàng', 10, 2000000, 5, N'D:\QuanLyBanHang\QuanLyBanHang\Resources\cay-mai-vang-ngay-tet.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [SoLuong], [Gia], [LoaiSanPham], [HinhAnh]) VALUES (8, N'Mai Chùm gửi', 10, 5000000, 1, N'D:\QuanLyBanHang\QuanLyBanHang\Resources\mai-chum-gui.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [SoLuong], [Gia], [LoaiSanPham], [HinhAnh]) VALUES (9, N'Thạch thảo tím', 10, 30000, 2, N'D:\QuanLyBanHang\QuanLyBanHang\Resources\cúc-th?ch-th?o.png')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [SoLuong], [Gia], [LoaiSanPham], [HinhAnh]) VALUES (10, N'Cúc châu phi', 20, 30000, 2, N'D:\QuanLyBanHang\QuanLyBanHang\Resources\hat-giong-hoa-cuc-chau-phi-1.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [SoLuong], [Gia], [LoaiSanPham], [HinhAnh]) VALUES (11, N'Hoa ngàn sao', 20, 30000, 2, N'D:\QuanLyBanHang\QuanLyBanHang\Resources\cay-hoa-ngan-sao.jpg')
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [SoLuong], [Gia], [LoaiSanPham], [HinhAnh]) VALUES (12, N'Hoa hồng cổ Son Môi', 10, 500000, 1, N'D:\QuanLyBanHang\QuanLyBanHang\Resources\hoa-hong-co-son-moi.png')
SET IDENTITY_INSERT [dbo].[SanPham] OFF
INSERT [dbo].[ThanhPho] ([ThanhPho], [TenThanhPho]) VALUES (1, N'Thành Phố HCM')
INSERT [dbo].[ThanhPho] ([ThanhPho], [TenThanhPho]) VALUES (2, N'Cần Thơ')
INSERT [dbo].[ThanhPho] ([ThanhPho], [TenThanhPho]) VALUES (3, N'Sóc Trăng')
INSERT [dbo].[ThanhPho] ([ThanhPho], [TenThanhPho]) VALUES (4, N'Hà Nội')
INSERT [dbo].[ThanhPho] ([ThanhPho], [TenThanhPho]) VALUES (5, N'Đà Nẵng')
INSERT [dbo].[ThanhPho] ([ThanhPho], [TenThanhPho]) VALUES (6, N'Vĩnh Long')
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoaDon] ([MaHD])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_SanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_SanPham]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [FK_KhachHang_ThanhPho] FOREIGN KEY([ThanhPho])
REFERENCES [dbo].[ThanhPho] ([ThanhPho])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [FK_KhachHang_ThanhPho]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_LoaiSanPham] FOREIGN KEY([LoaiSanPham])
REFERENCES [dbo].[LoaiSanPham] ([MaLSP])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_LoaiSanPham]
GO
USE [master]
GO
ALTER DATABASE [banhang] SET  READ_WRITE 
GO

CREATE DATABASE QLKYTUCXA

USE QLKYTUCXA

CREATE TABLE SinhVien (
    MaSV VARCHAR(25) PRIMARY KEY,
    TenSV NVARCHAR(255),
    Email VARCHAR(255),
    SDT VARCHAR(20),
    GioiTinh NVARCHAR(10),
	NgaySinh DATETIME,
    MaPhong VARCHAR(25),
	LoaiPhong NVARCHAR(255),
	NgayVao DATETIME,
	NgayRa DATETIME,
	TienCoc DECIMAL(10, 2),
	DaDong DECIMAL(10, 2),
	DuyetDon NVARCHAR(25),
	XinRa NVARCHAR(25)
);

CREATE TABLE Phong (
    MaPhong VARCHAR(25) PRIMARY KEY,
	MaLoai VARCHAR(25),
    SoGiuong INT,
    GiaTien DECIMAL(10, 2)
);

CREATE TABLE DichVu (
    MaDV VARCHAR(25) PRIMARY KEY,
    TenDV NVARCHAR(255),
    GiaTien DECIMAL(10, 2),
);	

CREATE TABLE DangKyDichVu (
	Id VARCHAR(25) PRIMARY KEY,
	MaDV VARCHAR(25),
	MaSV VARCHAR (25)
)

CREATE TABLE LoaiPhong (
    MaLoai VARCHAR(25) PRIMARY KEY,
    TenLoai NVARCHAR(255),
);

CREATE TABLE TaiKhoan (
    TenTaiKhoan VARCHAR(255) PRIMARY KEY,
    MatKhau VARCHAR(255),
    Email VARCHAR(255),
);

CREATE TABLE Admin (
    TenDangNhap VARCHAR(50) PRIMARY KEY,
    MatKhau VARCHAR(255)
);

CREATE TABLE HoaDon (
    MaHD VARCHAR(25) PRIMARY KEY,
    TienDien DECIMAL(10, 2),
    TienNuoc DECIMAL(10, 2),
    TienPhong DECIMAL(10, 2),
    TienDV DECIMAL(10, 2),
    MaSV VARCHAR(25),
	NgayXuatHoaDon DATETIME
);

CREATE TABLE DonXinTham (
	MaDon VARCHAR(25) PRIMARY KEY,
	TenNguoiThan NVARCHAR(255),
	MaSV VARCHAR(25),
	QuanHe NVARCHAR(50),
	NgayXin DATETIME,
	ThoiGian DATETIME,
	DuyetDon NVARCHAR(25)
);

--Insert thông tin SinhVien
INSERT INTO SinhVien (MaSV, TenSV, Email, SDT, GioiTinh, NgaySinh, MaPhong, LoaiPhong, NgayVao, TienCoc, DaDong)
VALUES
    ('2274801', N'Nguyễn Văn Huuy', 'huy@gmail.com', '0123456789', 'Nam', '2001-02-12', 'P001', N'VIP' ,'2018-12-09 10:30:00', 0, 0),
    ('2274802', N'Trần Gia Bảo', 'bao@gmail.com', '0123456781', 'Nam', '2001-02-14', 'P002', N'Thường', '2018-12-09 10:30:00', 0, 0),
    ('2274803', N'Phan Minh Phúc', 'phuc@gmail.com', '0123456782', 'Nam', '2001-02-15', 'P003', N'Cao Cấp' ,'2018-12-09 10:30:00', 0, 0 )

INSERT INTO Phong (MaPhong, SoGiuong, GiaTien,MaLoai)
VALUES 
	('P001', 2, 3000000, 01),
	('P002', 4, 1000000, 02),
	('P003', 3, 2000000, 03)

INSERT INTO DichVu (MaDV, TenDV, GiaTien)
VALUES
    (1, N'Giặt sấy', 100000),
    (2, N'Dọn phòng', 75000),
	(3, N'Lavie Gym', 300000)

INSERT INTO LoaiPhong (MaLoai, TenLoai)
VALUES
    (01, N'Loại A'),
    (02, N'Loại C'),
    (03, N'Loại B')
	

--Tạo khóa ngoại bảng SinhVien
ALTER TABLE SinhVien
ADD CONSTRAINT FK_SinhVien_Phong_IdPhong
FOREIGN KEY (MaPhong)
REFERENCES Phong(MaPhong);

--Tạo khóa ngoại bảng Phong
ALTER TABLE Phong
ADD CONSTRAINT FK_Phong_LoaiPhong_MaLoai
FOREIGN KEY (MaLoai)
REFERENCES LoaiPhong(MaLoai);

--Tạo khóa ngoại cho bảng hóa đơn
ALTER TABLE HoaDon
ADD CONSTRAINT FK_HoaDon_SinhVien_MaSV
FOREIGN KEY (MaSV)
REFERENCES SinhVien(MaSV);

-- Tạo khóa ngoại cho bảng người thân
ALTER TABLE DonXinTham
ADD CONSTRAINT FK_XinTham_SinhVien_MaSV
FOREIGN KEY (MaSV)
REFERENCES SinhVien(MaSV);

--Tạo khóa ngoại cho bảng Đăng ký dịch vụ
ALTER TABLE DangKyDichVu
ADD CONSTRAINT FK_DangKyDichVu_SinhVien_MaSV
FOREIGN KEY (MaSV)
REFERENCES SinhVien(MaSV)

ALTER TABLE DangKyDichVu
ADD CONSTRAINT FK_DangKyDichVu_DichVu_MaDV
FOREIGN KEY (MaDV)
REFERENCES DichVu(MaDV)


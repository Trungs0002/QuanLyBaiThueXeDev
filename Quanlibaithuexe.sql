DROP DATABASE QuanLyBaiThueXe;

CREATE DATABASE QuanLyBaiThueXe;

USE QuanLyBaiThueXe;

-- Tao bang

CREATE TABLE LoaiXe (
    MaLoaiXe INT PRIMARY KEY,
    TenLoai NVARCHAR(100) NOT NULL,
    HangSanXuat NVARCHAR(100) NOT NULL,
    NamSanXuat INT NOT NULL,
    MoTa NVARCHAR(255)
);

CREATE TABLE Xe (
    BienSoXe NVARCHAR(15) PRIMARY KEY,
    MaLoaiXe INT FOREIGN KEY REFERENCES LoaiXe(MaLoaiXe),
    MauSon NVARCHAR(50),
    TinhTrang NVARCHAR(50),
    MoTa NVARCHAR(255)
);

ALTER TABLE Xe
ADD GiaThueXe INT;

CREATE TABLE KhachHang (
    MaKhachHang INT PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(10),
    DienThoai NVARCHAR(15),
    DiaChi NVARCHAR(255),
    SoChungMinh NVARCHAR(20),
    SoHoChieu NVARCHAR(20),
    SoTaiKhoan NVARCHAR(20),
    NgayDangKy DATETIME DEFAULT GETDATE(),
    DaThueXe BIT DEFAULT 0
);

CREATE TABLE PhieuThue (
    SoPhieuThue INT PRIMARY KEY,
    NgayThue DATETIME DEFAULT GETDATE(),
    MaKhachHang INT FOREIGN KEY REFERENCES KhachHang(MaKhachHang),
    SoChungMinh NVARCHAR(20),
    BienSoXe NVARCHAR(15) FOREIGN KEY REFERENCES Xe(BienSoXe),
    MaLoaiXe INT FOREIGN KEY REFERENCES LoaiXe(MaLoaiXe),
    HangSanXuat NVARCHAR(100),
    NamSanXuat INT,
    TinhTrang NVARCHAR(50),
    SoLuong INT,
    SoNgayMuon INT,
    DonGia FLOAT
);

CREATE TABLE PhieuNopPhat (
    SoPhieuPhat INT PRIMARY KEY,
    NgayPhat DATETIME DEFAULT GETDATE(),
    MaKhachHang INT FOREIGN KEY REFERENCES KhachHang(MaKhachHang),
    HoTenKhachHang NVARCHAR(100),
    SoChungMinh NVARCHAR(20),
    LyDoNopPhat NVARCHAR(255),
    SoTienNopPhat FLOAT,
    TongSoTien FLOAT
);

ALTER TABLE PhieuNopPhat
ADD NgayThueXe DATETIME, 
    NgayTraXe DATETIME;

CREATE TABLE NhanVien (
    MaNhanVien INT PRIMARY KEY,
    TenNhanVien NVARCHAR(100) NOT NULL,
    DienThoai NVARCHAR(15),
    MoTa NVARCHAR(255)
);

CREATE TABLE DoanhThu (
    MaDoanhThu INT PRIMARY KEY,
    Thang INT NOT NULL,
    Nam INT NOT NULL,
    TongDoanhThu FLOAT,
    SoXeKhongSuDung INT,
    LoaiXeDuocThue NVARCHAR(100)
);

CREATE TABLE LichSuThue (
    Id INT PRIMARY KEY IDENTITY(1,1), 
    MaKhachHang INT NOT NULL, 
    BienSoXe NVARCHAR(15) NOT NULL, 
    SoNgayMuon INT NOT NULL, 
    DonGia INT NOT NULL, 
    TongTien INT NOT NULL, 
    NgayThue DATETIME NOT NULL DEFAULT GETDATE(), 
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang) 
);

ALTER TABLE PhieuThue
ADD TrangThai NVARCHAR(50) DEFAULT N'Đã giao xe';

ALTER TABLE PhieuThue
ADD MaNhanVien INT FOREIGN KEY REFERENCES NhanVien(MaNhanVien);

-- insert
INSERT INTO LoaiXe (MaLoaiXe, TenLoai, HangSanXuat, NamSanXuat, MoTa) VALUES
(1, N'Sedan', N'Toyota', 2020, N'Xe sedan 4 chỗ ngồi'),
(2, N'SUV', N'Honda', 2021, N'Xe SUV rộng rãi'),
(3, N'Hatchback', N'Ford', 2019, N'Xe hatchback nhỏ gọn'),
(4, N'Pickup', N'Nissan', 2022, N'Xe bán tải mạnh mẽ'),
(5, N'Coupe', N'BMW', 2020, N'Xe coupe thể thao'),
(6, N'Mini Van', N'Mercedes', 2021, N'Xe van nhỏ gọn cho gia đình'),
(7, N'Convertible', N'Audi', 2022, N'Xe mui trần thể thao'),
(8, N'SUV cỡ lớn', N'Chevrolet', 2020, N'Xe SUV cỡ lớn cho gia đình'),
(9, N'Roadster', N'Porsche', 2021, N'Xe thể thao 2 chỗ ngồi'),
(10, N'Crossover', N'Kia', 2021, N'Xe crossover đa dụng');

INSERT INTO Xe (BienSoXe, MaLoaiXe, MauSon, TinhTrang, MoTa, GiaThueXe) VALUES
('29A-12345', 1, N'Đen', N'Còn sử dụng', N'Xe sedan Toyota màu đen', 600000),
('29A-12346', 1, N'Bạc', N'Còn sử dụng', N'Xe sedan Toyota màu bạc', 620000);
INSERT INTO Xe (BienSoXe, MaLoaiXe, MauSon, TinhTrang, MoTa, GiaThueXe) VALUES
('29B-67890', 2, N'Trắng', N'Còn sử dụng', N'Xe SUV Honda màu trắng', 650000),
('29B-67891', 2, N'Đen', N'Còn sử dụng', N'Xe SUV Honda màu đen', 670000),
('29B-67892', 2, N'Xanh', N'Còn sử dụng', N'Xe SUV Honda màu xanh', 660000);
INSERT INTO Xe (BienSoXe, MaLoaiXe, MauSon, TinhTrang, MoTa, GiaThueXe) VALUES
('29C-54321', 3, N'Đỏ', N'Hỏng hóc', N'Xe hatchback Ford màu đỏ', 800000),
('29C-54322', 3, N'Vàng', N'Còn sử dụng', N'Xe hatchback Ford màu vàng', 790000);
INSERT INTO Xe (BienSoXe, MaLoaiXe, MauSon, TinhTrang, MoTa, GiaThueXe) VALUES
('29D-98765', 4, N'Xanh', N'Còn sử dụng', N'Xe bán tải Nissan màu xanh', 300000),
('29D-98766', 4, N'Đen', N'Còn sử dụng', N'Xe bán tải Nissan màu đen', 310000),
('29D-98767', 4, N'Bạc', N'Còn sử dụng', N'Xe bán tải Nissan màu bạc', 305000),
('29D-98768', 4, N'Đỏ', N'Còn sử dụng', N'Xe bán tải Nissan màu đỏ', 320000);
INSERT INTO Xe (BienSoXe, MaLoaiXe, MauSon, TinhTrang, MoTa, GiaThueXe) VALUES
('29E-13579', 5, N'Bạc', N'Còn sử dụng', N'Xe coupe BMW màu bạc', 900000),
('29E-13580', 5, N'Đỏ', N'Còn sử dụng', N'Xe coupe BMW màu đỏ', 910000);
INSERT INTO Xe (BienSoXe, MaLoaiXe, MauSon, TinhTrang, MoTa, GiaThueXe) VALUES
('29F-24680', 6, N'Vàng', N'Còn sử dụng', N'Xe van Mercedes màu vàng', 700000),
('29F-24681', 6, N'Trắng', N'Còn sử dụng', N'Xe van Mercedes màu trắng', 710000),
('29F-24682', 6, N'Xanh', N'Còn sử dụng', N'Xe van Mercedes màu xanh', 720000);
INSERT INTO Xe (BienSoXe, MaLoaiXe, MauSon, TinhTrang, MoTa, GiaThueXe) VALUES
('29G-13579', 7, N'Đen', N'Còn sử dụng', N'Xe mui trần Audi màu đen', 850000),
('29G-13580', 7, N'Đỏ', N'Còn sử dụng', N'Xe mui trần Audi màu đỏ', 860000);
INSERT INTO Xe (BienSoXe, MaLoaiXe, MauSon, TinhTrang, MoTa, GiaThueXe) VALUES
('29H-98765', 8, N'Trắng', N'Còn sử dụng', N'Xe SUV c ỡ lớn Chevrolet màu trắng', 950000),
('29H-98766', 8, N'Xanh', N'Còn sử dụng', N'Xe SUV cỡ lớn Chevrolet màu xanh', 960000),
('29H-98767', 8, N'Đen', N'Còn sử dụng', N'Xe SUV cỡ lớn Chevrolet màu đen', 970000);
INSERT INTO Xe (BienSoXe, MaLoaiXe, MauSon, TinhTrang, MoTa, GiaThueXe) VALUES
('29I-54321', 9, N'Đỏ', N'Còn sử dụng', N'Xe roadster Mazda màu đỏ', 800000),
('29I-54322', 9, N'Vàng', N'Còn sử dụng', N'Xe roadster Mazda màu vàng', 810000);
INSERT INTO Xe (BienSoXe, MaLoaiXe, MauSon, TinhTrang, MoTa, GiaThueXe) VALUES
('29J-13579', 10, N'Đen', N'Còn sử dụng', N'Xe crossover Kia màu đen', 750000),
('29J-13580', 10, N'Bạc', N'Còn sử dụng', N'Xe crossover Kia màu bạc', 760000),
('29J-13581', 10, N'Xanh', N'Còn sử dụng', N'Xe crossover Kia màu xanh', 755000);

INSERT INTO KhachHang (MaKhachHang, HoTen, GioiTinh, DienThoai, DiaChi, SoChungMinh) VALUES
(1, N'Nguyễn Văn A', N'Nam', N'0123456789', N'Hà Nội', N'123456789'),
(2, N'Trần Thị B', N'Nữ', N'0987654321', N'Đà Nẵng', N'987654321'),
(3, N'Lê Văn C', N'Nam', N'0112233445', N'TP.HCM', N'456789123'),
(4, N'Phạm Thị D', N'Nữ', N'0223344556', N'Hải Phòng', N'321654987'),
(5, N'Nguyễn Văn E', N'Nam', N'0334455667', N'Cần Thơ', N'654321789'),
(6, N'Nguyễn Thị K', N'Nữ', N'0445566778', N'Vĩnh Long', N'987654321'),
(7, N'Trần Văn M', N'Nam', N'0556677889', N'Nam Định', N'123456789'),
(8, N'Lê Thị N', N'Nữ', N'0667788990', N'Hải Dương', N'987654321'),
(9, N'Phạm Văn O', N'Nam', N'0778899001', N'Thái Bình', N'456789123'),
(10, N'Nguyễn Văn P', N'Nam', N'0889900112', N'Quảng Ninh', N'321654987');

INSERT INTO NhanVien (MaNhanVien, TenNhanVien, DienThoai, MoTa) VALUES
(1, N'Nguyễn Văn F', N'0123456789', N'Quản lý bãi xe'),
(2, N'Trần Thị G', N'0987654321', N'Nhân viên lễ tân'),
(3, N'Lê Văn H', N'0112233445', N'Nhân viên bảo trì'),
(4, N'Phạm Thị I', N'0223344556', N'Nhân viên cho thuê xe'),
(5, N'Nguyễn Văn J', N'0334455667', N'Nhân viên kế toán'),
(6, N'Nguyễn Thị L', N'0445566778', N'Nhân viên bảo trì xe'),
(7, N'Trần Văn M', N'0556677889', N'Nhân viên cho thuê xe'),
(8, N'Lê Thị N', N'0667788990', N'Nhân viên lễ tân'),
(9, N'Phạm Văn O', N'0778899001', N'Quản lý bãi xe'),
(10, N'Nguyễn Văn P', N'0889900112', N'Nhân viên kế toán');
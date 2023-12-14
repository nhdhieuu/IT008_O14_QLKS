﻿CREATE DATABASE QLKS

USE QLKS

CREATE TABLE QUANLI
(
	MAQL CHAR(5) PRIMARY KEY,
	TENQUANLI NVARCHAR(50),
	USERNAME VARCHAR(20),
	PASS VARCHAR(20),
	CCCD CHAR(12),
	SDT CHAR(10),
	NGAYSINH DATETIME,
	GIOITINH VARCHAR(3),
	AVATAR  VARBINARY(MAX)
)

CREATE TABLE KHACHHANG
(
	MAKH CHAR(5) PRIMARY KEY,
	TENKH NVARCHAR(50),
	USERNAME VARCHAR(20),
	PASS VARCHAR(20),
	CCCD CHAR(12),
	SDT CHAR(10),
	NGAYSINH DATETIME,
	GIOITINH VARCHAR(3),
	AVATAR  VARBINARY(MAX)
)

	
CREATE TABLE PHONG
(
	MAPHONG CHAR(5) PRIMARY KEY,
	TENPHONG VARCHAR(20),
	LOAIPHONG SMALLINT, --VIP, THUONG...
	SOGIUONG SMALLINT, --4,6,8...
	TRANGTHAI VARCHAR(10),
)

CREATE TABLE THUEPHONG
(
	MATHUEPHONG CHAR(5) PRIMARY KEY,
	MAKH CHAR(5) NULL,
	MAPHONG CHAR(5),
	NGAYBD DATE,
	NGAYKT DATE,
)
ALTER TABLE THUEPHONG 
ADD CONSTRAINT FK_THUEPHONG_KHACHHANG FOREIGN KEY (MAKH) REFERENCES KHACHHANG(MAKH)

ALTER TABLE THUEPHONG 
ADD CONSTRAINT FK_THUEPHONG_PHONG FOREIGN KEY (MAPHONG) REFERENCES PHONG(MAPHONG)


CREATE TABLE DICHVU (
	MADV CHAR(5) PRIMARY KEY,
	TENDV NVARCHAR(100),
	DONGIA MONEY,
	SOLUONG SMALLINT --SỐ LƯỢNG DỊCH VỤ ĐÓ CÒN LẠI
);

CREATE TABLE CHITIETDV 
(
	MATHUEPHONG CHAR(5),
    MADV CHAR(5), 
    SOLUONG INT, -- SỐ LƯỢNG PHÒNG ĐÓ ĐẶT
    THANHTIEN MONEY,
    PRIMARY KEY (MATHUEPHONG, MADV),
);
ALTER TABLE CHITIETDV
ADD CONSTRAINT FK_CTDICHVU_THUEPHONG FOREIGN KEY (MATHUEPHONG) REFERENCES THUEPHONG(MATHUEPHONG)

ALTER TABLE CHITIETDV
ADD CONSTRAINT FK_CTDICHVU_DICHVU FOREIGN KEY (MADV) REFERENCES DICHVU(MADV)

CREATE TABLE NHANVIEN
(
	MANV CHAR(5) PRIMARY KEY,
	TENNV VARCHAR(50),
	CCCD CHAR(12),
	SDT CHAR(10),
	NGAYSINH DATETIME,
	GIOITINH VARCHAR(3),
	BOPHAN VARCHAR(20), --LỄ TÂN, PHỤC VỤ PHÒNG, ẨM THỰC,...
)

CREATE TABLE HOADON (
	SOHD INT PRIMARY KEY,
	NGAYLAP DATETIME,
	TONGTIEN MONEY,
);

CREATE TABLE CTHD (
	SOHD INT,
	MAPHONG CHAR(5),
	MANV CHAR(5),
	THANHTIEN MONEY,
	PRIMARY KEY(SOHD, MAPHONG),
  
);
ALTER TABLE CTHD
ADD CONSTRAINT FK_CTHD_HOADON FOREIGN KEY (SOHD) REFERENCES HOADON (SOHD)
    
ALTER TABLE CTHD 
ADD CONSTRAINT FK_CTHD_NHANVIEN FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV)
    
ALTER TABLE CTHD 
ADD CONSTRAINT FK_CTHD_THUEPHONG FOREIGN KEY (MAPHONG) REFERENCES THUEPHONG(MATHUEPHONG)  


INSERT INTO KHACHHANG (MAKH,TENKH,USERNAME,PASS,CCCD,SDT,NGAYSINH,GIOITINH,AVATAR)
VALUES
('KH001','Nguyen Duy Hung','hung0101','hung123456','084204011380','0345664024','2004-09-07','Nam',null),
('KH002','Le Huy Hoang','hoang0202','hoang123456','084204011235','0978601661','2004-08-07','Nam',null),
('KH003','Nguyen Huynh Duy Hieu','hieu0303','hieu123456','084204011377','0345635874','2004-12-11','Nam',null),
('KH004','Tran Hong Quyen','quyen0404','quyen123456','084204023587','0343556224','2004-05-02','Nam',null),
('KH005','Mai Hoang Hung','hung0505','hung123456','084204016654','0223658977','2004-09-10','Nam',null),
('KH006','Cao Van Hoang','hoang0606','hoang123456','084204554778','0387762536','2004-04-07','Nam',null),
('KH007','Nguyen Thuy Loan','loan0707','loan123456','084204033574','0387798742','1989-12-13','Nu',null),
('KH008','Phan Thi My Tam','tam0808','tam123456','084222544876','0268477963','1981-01-16','Nu',null),
('KH009','Nguyen Thanh Tung','tung0909','tung123456','084201256487','0456887966','1994-07-05','Nam',null),
('KH010','Ho Ngoc Ha','ha1010','ha123456','084204011378','0345664036','1984-11-25','Nu',null),
('KH011','Hoang Thuy Linh','linh1111','linh123456','084204011376','0345664025','1988-08-11','Nu',null);

INSERT INTO NHANVIEN (MANV,TENNV,CCCD,SDT,NGAYSINH,GIOITINH,BOPHAN)
VALUES 
('NV001', 'Bui Trong Hoang Huy','084204011377','0566879644','2004-02-12','Nam','Le Tan'),
('NV002', 'Do Nguyen Hoang Huy','084202254377','0145879624','2004-07-12','Nam','Le Tan'),
('NV003', 'Pham Khai Hung','084204011375','0345668792','2002-05-05','Nam','Le Tan'),
('NV004', 'Phan Tran Tien Hung','084204022456','0566335674','2004-04-15','Nam','Phuc Vu'),
('NV005', 'Bui Thai Hoang','084204022457','0266871247','2001-03-07','Nam','Phuc Vu'),
('NV006', 'Ngo Duy Hung','084202235687','0562229644','2004-07-17','Nam','Phuc Vu'),
('NV007', 'Doan Quang Huy','084225871378','0566226544','2004-01-11','Nam','Phuc Vu'),
('NV008', 'To Hoang Huy','084204022499','0225579646','2003-02-12','Nam','Ve Sinh'),
('NV009', 'Nguyen Thi Lan','084203331377','0776879622','1990-02-11','Nu','Ve Sinh'),
('NV010', 'Le Thi Hoa','084226879377','0563339644','1995-04-12','Nu','Ve Sinh'),
('NV011', 'Pham Hoang Duy','084204012268','0566872255','2004-08-23','Nam','CSKH'),
('NV012', 'Nguyen Thi Hoa','084204011371','0266879642','2000-09-11','Nu','CSKH');

ALTER TABLE PHONG 
ALTER COLUMN LOAIPHONG varchar(10)
ALTER TABLE PHONG 
ADD BONTAM CHAR(6)
ALTER TABLE PHONG 
ADD STYLE VARCHAR(20)
ALTER TABLE PHONG 
ADD INTERNET VARCHAR(20)
ALTER TABLE PHONG 
ADD HOBOI VARCHAR(6)
ALTER TABLE PHONG
ADD GIATHEOGIO INT
ALTER TABLE PHONG
ADD GIATHEONGAY INT

INSERT INTO PHONG (MAPHONG,TENPHONG,LOAIPHONG,SOGIUONG,TRANGTHAI,BONTAM,HOBOI,INTERNET,STYLE,GIATHEOGIO,GIATHEONGAY)
VALUES
('MP101','P101','Standard','1','Trong','Khong','Khong','Thap','Style','150000','750000'),
('MP102','P102','Standard','1','Trong','Khong','Khong','Thap','Style','150000','750000'),
('MP103','P103','Superior','2','Da Dat','Co','Khong','Trung Binh','Style','200000','900000'),
('MP104','P104','Deluxe','1','Trong','Co','Khong','Cao','Style','300000','1350000'),
('MP105','P105','Deluxe','2','Da Dat','Co','Khong','Cao','Style','300000','1350000'),
('MP106','P106','Suite','2','Da Dat','Co','Co','Cao','Style','500000','2500000'),
('MP201','P201','Standard','1','Da Dat','Khong','Khong','Thap','Style','150000','750000'),
('MP202','P202','Standard','1','Trong','Khong','Khong','Thap','Style','150000','750000'),
('MP203','P203','Superior','2','Khoa','Co','Khong','Trung Binh','Style','200000','900000'),
('MP204','P204','Deluxe','1','Da Dat','Co','Khong','Cao','Style','300000','1350000'),
('MP205','P205','Deluxe','2','Trong','Co','Khong','Cao','Style','300000','1350000'),
('MP206','P206','Suite','2','Trong','Co','Co','Cao','Style','500000','2500000'),
('MP301','P301','Standard','1','Da Dat','Khong','Khong','Thap','Style','150000','750000'),
('MP302','P302','Standard','1','Trong','Khong','Khong','Thap','Style','150000','750000'),
('MP303','P303','Superior','1','Da Dat','Co','Khong','Trung Binh','Style','200000','900000'),
('MP304','P304','Deluxe','1','Trong','Co','Khong','Cao','Style','300000','1350000'),
('MP305','P305','Deluxe','2','Khoa','Co','Khong','Cao','Style','300000','1350000'),
('MP306','P306','Suite','1','Da Dat','Co','Co','Cao','Style','500000','2500000');

ALTER TABLE THUEPHONG
ADD KQUATHUE VARCHAR(11)

INSERT INTO THUEPHONG (MATHUEPHONG,MAKH,MAPHONG,NGAYBD,NGAYKT,KQUATHUE)
VALUES
('TP01', 'KH001','MP103','2023-12-01','2023-12-05','Thanh Cong'),
('TP02', 'KH002','MP105','2023-12-03','2023-12-05','Thanh Cong'),
('TP03', 'KH003','MP106','2023-12-01','2023-12-04','Thanh Cong'),
('TP04', 'KH004','MP201','2023-12-02','2023-12-02','Thanh Cong'),--- đang lấy thuê 4 tiếng 
('TP05', 'KH005','MP204','2023-12-06','2023-12-08','Thanh Cong'),
('TP06', 'KH006','MP301','2023-12-05','2023-12-06','Thanh Cong'),
('TP07', 'KH009','MP303','2023-12-01','2023-12-02','Thanh Cong'),
('TP08', 'KH011','MP306','2023-12-04','2023-12-05','Thanh Cong');


INSERT INTO DICHVU (MADV,TENDV,DONGIA,SOLUONG)
VALUES
('DV01','Coca-cola','30000','500'),
('DV02','Pepsi','30000','500'),
('DV03','Fante','30000','500'),
('DV04','7Up','30000','500'),
('DV05','Nuoc suoi','20000','800'),
('DV06','Bia Huda','30000','500'),
('DV07','Bia Ha Noi','30000','500'),
('DV08','Bia Sai Gon','30000','500'),
('DV09','Ruou vang do Merlot','3000000','80'),
('DV10','Ruou vang trang Chardonnay','3000000','80'),
('DV11','Ruou vang hong Rosé','2500000','80'),
('DV12','Banh mi bate','30000','200'),
('DV13','Buger','500000','200'),
('DV14','Spagehetti','200000','150'),
('DV15','Tom hum','1500000','80'),
('DV16','Sushi','300000','80'),
('DV17','Salad hoa qua','150000','200'),
('DV18','Beef steak','1000000','120'),
('DV19','Chocolate Fondant','300000','200'),
('DV20','Pudding','100000','200'),
('DV21','Pho bo','100000','300'),
('DV22','Don phong','500000','500'),
('DV23','Spa','4000000','50'),




INSERT INTO CHITIETDV(MATHUEPHONG,MADV,SOLUONG,THANHTIEN)
VALUES
('TP01','DV05','2','40000'),
('TP01','DV12','1','30000'),
('TP02','DV01','1','30000'),
('TP02','DV14','1','200000'),
('TP03','DV09','1','3000000'),
('TP03','DV20','2','200000'),
('TP03','DV18','2','2000000'),
('TP04','DV06','3','90000'),
('TP05','DV21','2','200000'),
('TP05','DV17','2','300000'),
('TP05','DV20','2','200000'),
('TP06','DV13','1','50000'),
('TP07','DV03','2','60000'),
('TP07','DV21','2','200000'),
('TP08','DV10','1','3000000'),
('TP08','DV15','1','1500000'),
('TP08','DV22','1','500000'),
('TP08','DV23','1','4000000')

INSERT INTO HOADON(SOHD,NGAYLAP,TONGTIEN)
VALUES
('HD001','2023-12-05','3670000'),
('HD002','2023-12-05','2930000'),
('HD003','2023-12-04','12700000'),
('HD004','2023-12-02','690000'),
('HD005','2023-12-08','3200000'),
('HD006','2023-12-06','800000'),
('HD007','2023-12-02','1160000'),
('HD008','2023-12-05','11500000')

INSERT INTO CTHD (SOHD,MAPHONG,MANV,THANHTIEN)
VALUES
('HD001','MP103','NV001','367000'),
('HD002','MP105','NV001','2930000'),
('HD003','MP106','NV002','12700000'),
('HD004','MP201','NV002','690000'),
('HD005','MP204','NV003','3200000'),
('HD006','MP301','NV003','800000'),
('HD007','MP303','NV002','1160000'),
('HD008','MP306','NV001','11500000')

INSERT INTO QUANLI(MAQL,TENQUANLI,USERNAME,PASS,CCCD,SDT,NGAYSINH,GIOITINH,AVATAR)
VALUES
('QL001','Nguyen Van Dung','dung0309','dung123456','042204001234','0835523073','2004-03-09','Nam',null),
('QL002','Duong Viet Hoang','hoang3010','hoang123456','042204005678','0854815516','2004-10-30','Nam',null)
<<<<<<< HEAD
create database QLKsss
use QLKsss
=======

create database QLKSS
use QLKSS
>>>>>>> SuaChuaLoiLam2
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
	AVATAR  VARBINARY(MAX),
	CLASS VARCHAR(10),
	ClassID INT
)

	
CREATE TABLE PHONG
(
	MAPHONG CHAR(5) PRIMARY KEY,
	TENPHONG VARCHAR(20),
	LOAIPHONG SMALLINT, --VIP, THUONG...
	SOGIUONG SMALLINT, --4,6,8...
	TRANGTHAI VARCHAR(10),
)
<<<<<<< HEAD


=======
alter table PHONG
add NGUOI INT
alter table PHONG
add CLEANING varchar(10)
alter table PHONG
add MAINTAIN varchar(10)
alter table PHONG
add EQUIP varchar(10)
>>>>>>> SuaChuaLoiLam2



CREATE TABLE THUEPHONG
(
	MATHUEPHONG CHAR(5) PRIMARY KEY,
	MAKH CHAR(5) NULL,
	MAPHONG CHAR(5),
	NGAYBD DATETIME,
	NGAYKT DATETIME,
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
  
);
ALTER TABLE CHITIETDV
ADD CONSTRAINT FK_CTDICHVU_THUEPHONG FOREIGN KEY (MATHUEPHONG) REFERENCES THUEPHONG(MATHUEPHONG)

ALTER TABLE CHITIETDV
ADD CONSTRAINT FK_CTDICHVU_DICHVU FOREIGN KEY (MADV) REFERENCES DICHVU(MADV)
create table DVCOSAN
(
LOAIPHONG varchar(10),
MADV char(5),
SOLUONG INT
)

alter table DVCOSAN
 ADD CONSTRAINT FK_DVCOSAN_DICHVU FOREIGN KEY (MADV) REFERENCES DICHVU(MADV)  
CREATE TABLE PROBLEM
(
MAPR CHAR(5) PRIMARY KEY,
PRNAME NVARCHAR(50),
PRICE MONEY
)
CREATE TABLE CHITIETPR
(
	MATHUEPHONG CHAR(5),
    MAPR CHAR(5), 
    SOLUONG INT, -- SỐ LƯỢNG PHÒNG ĐÓ ĐẶT
    THANHTIEN MONEY,
   
);
alter table CHITIETPR
add  NGAYPR datetime

ALTER TABLE CHITIETPR
ADD CONSTRAINT FK_CTPR_THUEPHONG FOREIGN KEY (MATHUEPHONG) REFERENCES THUEPHONG(MATHUEPHONG)
ALTER TABLE CHITIETPR
ADD CONSTRAINT FK_CTPR_PROBLEM FOREIGN KEY (MAPR) REFERENCES PROBLEM(MAPR)

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
	SOHD CHAR(5) PRIMARY KEY,
	NGAYLAP DATETIME,
	TONGTIEN MONEY,
	MANV CHAR(5),
	MAKH CHAR(5)
);



ALTER TABLE HOADON
ADD CONSTRAINT FK_HOADON_KHACHHANG FOREIGN KEY (MAKH) REFERENCES KHACHHANG(MAKH);

CREATE TABLE CTHD (
	SOHD CHAR(5),
	MAPHONG CHAR(5),
	
	
	PRIMARY KEY(SOHD, MAPHONG),
  
);
ALTER TABLE CTHD
ADD CONSTRAINT FK_CTHD_HOADON FOREIGN KEY (SOHD) REFERENCES HOADON (SOHD)
    
ALTER TABLE HOADON
ADD CONSTRAINT FK_HOADON_NHANVIEN FOREIGN KEY (MANV) REFERENCES NHANVIEN(MANV)
    
ALTER TABLE CTHD 
ADD CONSTRAINT FK_CTHD_THUEPHONG FOREIGN KEY (MAPHONG) REFERENCES THUEPHONG(MATHUEPHONG)  

Create table QLGIA
(
LPHONG varchar(3),
THEO varchar(4),
TUAN varchar(6),
GIA money
)
alter table CHITIETDV
add  NGAYDV datetime

INSERT INTO QLGIA (LPHONG,THEO,TUAN,GIA)
VALUES
('STD','hour','in',150000),
('SUP','hour','in',250000),
('DLX','hour','in',350000),
('SUT','hour','in',450000),
('STD','day','in',450000),
('SUP','day','in',650000),
('DLX','day','in',850000),
('SUT','day','in',1050000),
('STD','hour','T7',200000),
('SUP','hour','T7',300000),
('DLX','hour','T7',400000),
('SUT','hour','T7',500000),
('STD','day','T7',500000),
('SUP','day','T7',70000),
('DLX','day','T7',900000),
('SUT','day','T7',1100000),
('STD','hour','CN',250000),
('SUP','hour','CN',350000),
('DLX','hour','CN',450000),
('SUT','hour','CN',550000),
('STD','day','CN',550000),
('SUP','day','CN',750000),
('DLX','day','CN',950000),
('SUT','day','CN',1150000)



INSERT INTO KHACHHANG (MAKH,TENKH,USERNAME,PASS,CCCD,SDT,NGAYSINH,GIOITINH,AVATAR,CLASS)
VALUES
('KH001','Nguyen Duy Hung','hung0101','hung123456','084204011380','0345664024','2004-09-07','Nam',null,'Silver'),
('KH002','Le Huy Hoang','hoang0202','hoang123456','084204011235','0978601661','2004-08-07','Nam',null,'Gold'),
('KH003','Nguyen Huynh Duy Hieu','hieu0303','hieu123456','084204011377','0345635874','2004-12-11','Nam',null,'Platinum'),
('KH004','Tran Hong Quyen','quyen0404','quyen123456','084204023587','0343556224','2004-05-02','Nam',null,'Diamond'),
('KH005','Mai Hoang Hung','hung0505','hung123456','084204016654','0223658977','2004-09-10','Nam',null,'Platinum'),
('KH006','Cao Van Hoang','hoang0606','hoang123456','084204554778','0387762536','2004-04-07','Nam',null,'Silver'),
('KH007','Nguyen Thuy Loan','loan0707','loan123456','084204033574','0387798742','1989-12-13','Nu',null,'Gold'),
('KH008','Phan Thi My Tam','tam0808','tam123456','084222544876','0268477963','1981-01-16','Nu',null,'Diamond'),
('KH009','Nguyen Thanh Tung','tung0909','tung123456','084201256487','0456887966','1994-07-05','Nam',null,'Gold'),
('KH010','Ho Ngoc Ha','ha1010','ha123456','084204011378','0345664036','1984-11-25','Nu',null,'Platinum'),
('KH011','Hoang Thuy Linh','linh1111','linh123456','084204011376','0345664025','1988-08-11','Nu',null,'Gold')


--update classID
UPDATE KHACHHANG
SET classID = 
    CASE 
        WHEN  CLASS LIKE 'Diamond' THEN 4
        WHEN CLASS LIKE 'Platinum' THEN 3
        WHEN CLASS LIKE 'Gold' THEN 2
        WHEN CLASS LIKE 'Silver' THEN 1
    END;



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
('NV012', 'Nguyen Thi Hoa','084204011371','0266879642','2000-09-11','Nu','CSKH')

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
ADD GIATHEOGIO money
ALTER TABLE PHONG
ADD GIATHEONGAY money
alter table PHONG
add NGUOI INT
alter table PHONG
add CLEANING varchar(10)
alter table PHONG
add MAINTAIN varchar(10)
alter table PHONG
add EQUIP varchar(10)

<<<<<<< HEAD
INSERT INTO PHONG (MAPHONG,TENPHONG,LOAIPHONG,SOGIUONG,TRANGTHAI,BONTAM,HOBOI,INTERNET,STYLE,GIATHEOGIO,GIATHEONGAY,CLEANING, MAINTAIN, EQUIP,NGUOI)
VALUES
('MP101','P101','Standard','1','Empty','Khong','Khong','Thap','Style','150000','750000','Daily','Monthly','Minibar',1),
('MP102','P102','Standard','1','Booking','Khong','Khong','Thap','Style','150000','750000','Daily','Monthly','Minibar',2),
('MP103','P103','Superior','2','Rented','Co','Khong','Trung Binh','Style','200000','900000','Daily','Monthly','Minibar',4),
('MP104','P104','Deluxe','1','Empty','Co','Khong','Cao','Style','300000','1350000','Daily','Monthly','Fridge',2),
('MP105','P105','Deluxe','2','Rented','Co','Khong','Cao','Style','300000','1350000','Daily','Monthly','Fridge',4),
('MP106','P106','Suite','2','Booking','Co','Co','Cao','Style','500000','2500000','Daily','Monthly','Fridge',2),
('MP201','P201','Standard','1','Rented','Khong','Khong','Thap','Style','150000','750000','Daily','Monthly','Minibar',1),
('MP202','P202','Standard','1','Empty','Khong','Khong','Thap','Style','150000','750000','Daily','Monthly','Minibar',2),
('MP203','P203','Superior','2','Unavailabl','Co','Khong','Trung Binh','Style','200000','900000','Monthly','Monthly','Minibar',4),
('MP204','P204','Deluxe','1','Rented','Co','Khong','Cao','Style','300000','1350000','Daily','Monthly','Fridge',2),
('MP205','P205','Deluxe','2','Empty','Co','Khong','Cao','Style','300000','1350000','Daily','Monthly','Fridge',4),
('MP206','P206','Suite','2','Booking','Co','Co','Cao','Style','500000','2500000','Daily','Monthly','Fridge',2),
('MP301','P301','Standard','1','Rented','Khong','Khong','Thap','Style','150000','750000','Daily','Monthly','Minibar',1),
('MP302','P302','Standard','1','Empty','Khong','Khong','Thap','Style','150000','750000','Daily','Monthly','Minibar',2),
('MP303','P303','Superior','1','Rented','Co','Khong','Trung Binh','Style','200000','900000','Daily','Monthly','Minibar',2),
('MP304','P304','Deluxe','1','Empty','Co','Khong','Cao','Style','300000','1350000','Daily','Monthly','Fridge',2),
('MP305','P305','Deluxe','2','Unavailabl','Co','Khong','Cao','Style','300000','1350000','Monthly','Monthly','Fridge',4),
('MP306','P306','Suite','1','Rented','Co','Co','Cao','Style','500000','2500000','Daily','Monthly','Fridge',2)

=======
INSERT INTO PHONG (MAPHONG,TENPHONG,LOAIPHONG,SOGIUONG,TRANGTHAI,BONTAM,HOBOI,INTERNET,STYLE,GIATHEOGIO,GIATHEONGAY,CLEANING, MAINTAIN, EQUIP)
VALUES
('MP101','P101','Standard','1','Empty','Khong','Khong','Thap','Style','150000','750000','Daily','Monthly','Minibar'),
('MP102','P102','Standard','1','Booking','Khong','Khong','Thap','Style','150000','750000','Daily','Monthly','Minibar'),
('MP103','P103','Superior','2','Rented','Co','Khong','Trung Binh','Style','200000','900000','Daily','Monthly','Minibar'),
('MP104','P104','Deluxe','1','Empty','Co','Khong','Cao','Style','300000','1350000','Daily','Monthly','Fridge'),
('MP105','P105','Deluxe','2','Rented','Co','Khong','Cao','Style','300000','1350000','Daily','Monthly','Fridge'),
('MP106','P106','Suite','2','Booking','Co','Co','Cao','Style','500000','2500000','Daily','Monthly','Fridge'),
('MP201','P201','Standard','1','Rented','Khong','Khong','Thap','Style','150000','750000','Daily','Monthly','Minibar'),
('MP202','P202','Standard','1','Empty','Khong','Khong','Thap','Style','150000','750000','Daily','Monthly','Minibar'),
('MP203','P203','Superior','2','Unavailabl','Co','Khong','Trung Binh','Style','200000','900000','Monthly','Monthly','Minibar'),
('MP204','P204','Deluxe','1','Rented','Co','Khong','Cao','Style','300000','1350000','Daily','Monthly','Fridge'),
('MP205','P205','Deluxe','2','Empty','Co','Khong','Cao','Style','300000','1350000','Daily','Monthly','Fridge'),
('MP206','P206','Suite','2','Booking','Co','Co','Cao','Style','500000','2500000','Daily','Monthly','Fridge'),
('MP301','P301','Standard','1','Rented','Khong','Khong','Thap','Style','150000','750000','Daily','Monthly','Minibar'),
('MP302','P302','Standard','1','Empty','Khong','Khong','Thap','Style','150000','750000','Daily','Monthly','Minibar'),
('MP303','P303','Superior','1','Rented','Co','Khong','Trung Binh','Style','200000','900000','Daily','Monthly','Minibar'),
('MP304','P304','Deluxe','1','Empty','Co','Khong','Cao','Style','300000','1350000','Daily','Monthly','Fridge'),
('MP305','P305','Deluxe','2','Unavailabl','Co','Khong','Cao','Style','300000','1350000','Monthly','Monthly','Fridge'),
('MP306','P306','Suite','1','Rented','Co','Co','Cao','Style','500000','2500000','Daily','Monthly','Fridge')
>>>>>>> SuaChuaLoiLam2

ALTER TABLE THUEPHONG
ADD KQUATHUE VARCHAR(11)

INSERT INTO THUEPHONG (MATHUEPHONG,MAKH,MAPHONG,NGAYBD,NGAYKT,KQUATHUE)
VALUES
('TP01', 'KH001','MP103','2023-12-01','2023-12-05','Thanh Cong'),
('TP02', 'KH001','MP105','2023-12-03','2023-12-05','Thanh Cong'),
('TP03', 'KH003','MP106','2023-12-01','2023-12-04','That Bai'),
('TP04', 'KH004','MP201','2023-12-02','2023-12-02','Dang Thue'),--- đang lấy thuê 4 tiếng 
('TP05', 'KH005','MP204','2023-12-06','2023-12-08','Thanh Cong'),
('TP06', 'KH006','MP301','2023-12-05','2023-12-06','Dang Thue'),
('TP07', 'KH009','MP303','2023-12-01','2023-12-02','Thanh Cong'),
('TP08', 'KH011','MP306','2023-12-04','2023-12-05','Thanh Cong'),
('TP09', 'KH007','MP102','2023-12-04','2023-12-05','That Bai'),
('TP10', 'KH008','MP206','2023-12-04','2023-12-05','That Bai')

INSERT INTO DICHVU (MADV,TENDV,DONGIA,SOLUONG)
VALUES
('DV01','Coca-cola','30000','500'),
('DV02','Pepsi','30000','500'),
('DV03','Fanta','30000','500'),
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
('DV14','Spaghetti','200000','150'),
('DV15','Tom hum','1500000','80'),
('DV16','Sushi','300000','80'),
('DV17','Salad hoa qua','150000','200'),
('DV18','Beef steak','1000000','120'),
('DV19','Chocolate Fondant','300000','200'),
('DV20','Pudding','100000','200'),
('DV21','Pho bo','100000','300'),
('DV22','Don phong','500000','500'),
('DV23','Spa','4000000','50')




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

INSERT INTO HOADON(SOHD,NGAYLAP,TONGTIEN,MANV,MAKH)
VALUES
('HD001','2023-12-05','3670000','NV001','KH001'),
('HD002','2023-12-05','2930000','NV002','KH002'),
('HD003','2023-12-04','12700000','NV003','KH003'),
('HD004','2023-12-02','690000','NV004','KH004'),
('HD005','2023-12-08','3200000','NV005','KH005'),
('HD006','2023-12-06','800000','NV006','KH006'),
('HD007','2023-12-02','1160000','NV007','KH007'),
('HD008','2023-12-05','11500000','NV008','KH008')

INSERT INTO CTHD (SOHD,MAPHONG)
VALUES
('HD001','TP01'),
('HD001','TP02'),
('HD002','TP03'),
('HD003','TP04'),
('HD004','TP04'),
('HD005','TP05'),
('HD006','TP06'),
('HD007','TP07'),
('HD008','TP08')

INSERT INTO QUANLI(MAQL,TENQUANLI,USERNAME,PASS,CCCD,SDT,NGAYSINH,GIOITINH,AVATAR)
VALUES
('QL001','Nguyen Van Dung','dung0309','dung123456','042204001234','0835523073','2004-03-09','Nam',null),
('QL002','Duong Viet Hoang','hoang3010','hoang123456','042204005678','0854815516','2004-10-30','Nam',null)


INSERT INTO PROBLEM (MAPR,PRNAME,PRICE)
VALUES
('PR01','Internet','0'),
('PR02','Repair','0'),
('PR03','Clean','0'),
('PR04','Breakfast','300000')


ALTER TABLE khachhang
ALTER COLUMN Pass VARCHAR(255)

ALTER TABLE quanli
ALTER COLUMN Pass VARCHAR(255)

update quanli
set pass = '43243611735235013911816185200155796117123311074889994985113018611613614522819926'
where maql = 'QL001'

update quanli
set pass = '529521139114180781902101416869619424625414423510211130216982323325147881192713208'
where maql = 'QL002'


update khachhang
set pass = '12818522514123911131112171221606522233631401197510519722858919488233551562101758150'
where makh = 'kh001'

update khachhang
set pass = '2421641751393268941728388222208101187234827613072156837157241251213391111406098'
where makh = 'kh002'

update khachhang
set pass = '5046958281792217012712211104145770491081824722814914154312082132122484910314039'
where makh = 'kh003'

update khachhang
set pass = '694441718921015713515917821810010560104172972001351601911398890752201371241553184'
where makh = 'kh004'

update khachhang
set pass = '1281692031752301058741192122391631151181051949520867185112226842541476210231235994175'
where makh = 'kh005'

update khachhang
set pass = '2559596144155163412271711822141862031551602522261752311831581831433667198246227733823567'
where makh = 'kh006'

update khachhang
set pass = '218159144246795791198123969015721549194581231161879216207121061972194463422215'
where makh = 'kh007'

update khachhang
set pass = '20020021826161336423719725410315216615157241243194628813922021317923011010924311521616358'
where makh = 'kh008'

update khachhang
set pass = '2191512351692505689173224451185233291711914423198102247112651861422884601822710399'
where makh = 'kh009'

update khachhang
set pass = '6151361814913712079625639135411795416913716597219166372129751271466623813720411'
where makh = 'kh010'

update khachhang
set pass = '86255219136249199822129243313619869143100181991687019613535315713513510887222135193'
where makh = 'kh011'

update khachhang
set pass = '208144613841322415915420142179180134547713411812113121446512722347710918010323797'
where makh = 'kh012'

UPDATE CHITIETDV 
SET NGAYDV='12/23/2023' 

UPDATE CHITIETPR
SET NGAYPR='12/23/2023' 

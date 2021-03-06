CREATE DATABASE NguyenThanhDuyDB

USE NguyenThanhDuyDB

GO

CREATE TABLE Category(
	ID int IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	Description nvarchar(50) NULL,
	PRIMARY KEY (ID)
) 

INSERT INTO Category (Name,Description) 
VALUES (N'Văn Học',N'Thể loại giới thiệu về nền văn học'),
	   (N'Toán Học',N'Thể loại giới thiệu về nền Toán Học'),
	   (N'Địa Lý',N'Thể loại giới thiệu về nền Địa Lý'),
	   (N'Khoa Học',N'Thể loại giới thiệu về nền Khoa Học'),
	   (N'Tiếng Anh',N'Thể loại giới thiệu về nền Tiếng Anh'),
	   (N'Lịch sử',N'Thể loại giới thiệu về nền Lịch sử'),
	   (N'Giáo dục',N'Thể loại giới thiệu về nền Giáo dục'),
	   (N'Du Lịch',N'Thể loại giới thiệu về nền Du Lịch'),
	   (N'Kĩ năng',N'Thể loại giới thiệu về nền Kĩ năng')
GO
CREATE TABLE Product(
	ID int IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	UnitCost decimal(18, 0) NOT NULL,
	Quantity int NOT NULL,
	Image text NOT NULL,
	Description nvarchar(250) NULL,
	Status [int] NOT NULL,
	IDCategory int,
	PRIMARY KEY (ID),
	FOREIGN KEY (IDCategory) REFERENCES Category(ID)
)

GO
INSERT INTO Product (Name,UnitCost,Quantity,Image,Description,Status,IDCategory) 
VALUES (N'TRẮC NGHIỆM CHUYÊN ĐỀ GIẢI TÍCH',250000,11,'sp17.jpg',N'câu chuyện về thể giới...',1,2),
	   (N'Phân Tích Tư Duy Giải Câu Điểm 8 9 10',100000,10,'sp16.jpg',N'Cuốn sách nói về những thiên văn...',1,2),
	   (N'TIẾT LỘ BÍ QUYẾT 3 BƯỚC ĐẠT ĐIỂM ',200000,10,'sp16.jpg',N'Bí quyết giúp các bạn học tốt...',1,2),
	   (N'Người Đua Diều',20000,15,'sp14.jpg',N'câu chuyện về tình cảm...',1,1),
	   (N'Colorful – Mori Eto',30000,12,'sp13.jpg',N'câu chuyện về nước ngoài...',1,1),
	   (N'Bắt Trẻ Đồng Xanh',200000,2,'sp12.jpg',N'câu chuyện về nông thôn...',1,1),
	   (N'Nếu Chỉ Còn Một Ngày Để Sống',200000,2,'udsp12.jpg',N'câu chuyện lý tưởng sống...',1,1)


GO
CREATE TABLE UserAccount(
	ID int IDENTITY(1,1) NOT NULL,
	UserName varchar(50) NOT NULL,
	Password varchar(50) NOT NULL,
	Status int NOT NULL,
	PRIMARY KEY (ID)
)

INSERT INTO UserAccount (UserName,Password,Status) 
VALUES ('Admin','admin',1),
	   ('duynt','duynt11',1),
	   ('duynn','duynn',1),
	   ('accc','acc',0),
	   ('ntnn','12345',1),
	   ('bacs','asd',1)
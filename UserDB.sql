CREATE DATABASE Register
GO

USE Register

CREATE TABLE UserInfo
(
	ID INT PRIMARY KEY IDENTITY(1,1),
	FullName NVARCHAR(50),
	PassWd NVARCHAR(100)
)
GO

Insert into UserInfo (FullName, PassWd) values ('tao', 'tao123');
SELECT * FROM UserInfo;
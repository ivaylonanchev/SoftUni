--01.Create database
CREATE DATABASE Minions
--02.Add Table
CREATE TABLE Minions
(
	Id INT PRIMARY KEY,
	Name VARCHAR(50),
	Age INT
)
CREATE TABLE Towns
(
	Id INT PRIMARY KEY,
	Age VARCHAR(50)
)
--03.
ALTER TABLE Minions
ADD TownId INT

ALTER TABLE Minions 
ADD FOREIGN KEY (TownId) REFERENCES Towns(Id)

--04.
INSERT INTO Towns
VALUES(1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna')

INSERT INTO Minions
VALUES(1,'Kevin', 22,1),
(2,'Bob', 15,3),
(3,'Steward', NULL,2)
--05.

TRUNCATE TABLE Minions	
--06.
DROP Table Minions
DROP TABLE Towns

--07.

CREATE TABLE People
(
	Id INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	Gender CHAR(1) NOT NULL,
		CHECK(Gender in('m', 'f')),
	[Birthdate] DATETIME2 NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People(Id, [Name],Gender, [Birthdate])
VALUES (1,'St', 'm', '10-09-2000'),
(2,'St', 'm', '10-09-2000'),
(3,'St', 'm', '10-09-2000'),
(4,'St', 'm', '10-09-2000'),
(5,'St', 'm', '10-09-2000')

--0.8

CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME2,
	IsDeleted BIT,
)
INSERT INTO Users(Username,[Password])
			VALUES('Bobina', 'bobina1'),
				('Bobina', 'bobina1'),
				('Bobina', 'bobina1'),
				('Bobina', 'bobina1'),
				('Bobina', 'bobina1')
--0.9
--Delete PK
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC076682AA6B
--Set new PK
ALTER TABLE Users
ADD CONSTRAINT PK_UsersTable PRIMARY KEY(Id, Username)
--0.10
ALTER TABLE Users
ADD CONSTRAINT CHK_PasswordIsAtLeast5Characters
	CHECK(LEN(Password) >=5)
--11
ALTER TABLE Users
ADD CONSTRAINT DF_LoginTime
DEFAULT '01.01.2024' FOR LastLoginTime
--12
ALTER TABLE Users 
DROP CONSTRAINT PK_UsersTable

ALTER TABLE Users
ADD CONSTRAINT PK_UsersTable PRIMARY KEY(Id)

--13
CREATE DATABASE Movies

CREATE TABLE Directors
(
	Id INT PRIMARY KEY NOT NULL,
	DirectorName VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX),
)
CREATE TABLE Genres
(
	Id INT PRIMARY KEY NOT NULL,
	GenreName VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX),
)
CREATE TABLE Categories
(
	Id INT PRIMARY KEY NOT NULL,
	CategoryName VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX),
)
CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(30),
	DirectorId INT NOT NULL,
	CopyrightYear DATETIME2,
	Lenght INT,
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating INT,
	Notes VARCHAR(MAX),
)
INSERT INTO Directors
	Values(1,'Ivanov','PUGB'),
	(2,'Stoyanov','PUaaaaGB'),
	(3,'Peshov','aa'),
	(4,'Toshev','ccc'),
	(5,'Georgiev','gsffs')

INSERT INTO Genres
	Values(1,'Roman','aa'),
	(2,'Action','ss'),
	(3,'Horror','dd'),
	(4,'Adventure','ww'),
	(5,'Biography','ee')

INSERT INTO Categories
	Values(1,'123','aa'),
	(2,'333','ss'),
	(3,'444','dd'),
	(4,'555','ww'),
	(5,'666','ee')

ALTER TABLE Movies
ADD FOREIGN KEY (DirectorId) REFERENCES Directors(Id) 

ALTER TABLE Movies
ADD FOREIGN KEY (GenreId) REFERENCES Genres(Id) 

ALTER TABLE Movies
ADD FOREIGN KEY (CategoryId) REFERENCES Categories(Id) 

INSERT INTO Movies(DirectorId,GenreId,CategoryId)
	VALUES(1,1,5),
	(2,5,5),
	(5,3,2),
	(4,1,5),
	(4,2,4)

--14
CREATE DATABASE CarRental

drop database CarRental

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(30) NOT NULL,
	DailyRate VARCHAR(30),
	WeeklyRate VARCHAR(30),
	MonthlyRate VARCHAR(30),
	WeekendRate VARCHAR(30)
)
INSERT INTO Categories(CategoryName)
	VALUES('Kategoriq1'),
	('Kategoriq2'),
	('Kategoriq3')

CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber INT NOT NULL,
	Manufacturer VARCHAR(30),
	Model VARCHAR(30) NOT NULL,
	CarYear DATETIME2,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Doors INT,
	Picture VARBINARY,
	Condition VARCHAR(30),
	Available BIT
)
INSERT INTO Cars(PlateNumber, Model, CategoryId)
	VALUES(1123,'Kategoriq1', 1),
	(321,'Kategoriq2', 2),
	(222,'Kategoriq3', 3)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Title VARCHAR(MAX),
	Notes VARCHAR(MAX)
)
INSERT INTO Employees(FirstName, LastName)
	VALUES('IVan', 'Stoyanov'),
	('Stoyan', 'Ivanov'),
	('Ivaylo', 'Gochev')
CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber INT,
	FullName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(100),
	City VARCHAR(50),
	ZIPCode INT,
	Notes VARCHAR(MAX)
)
INSERT INTO Customers(FullName)
	VALUES('IVan'),
	('Stoyan'),
	('Ivaylo')
CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeedId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
	TankLevel INT,
	KilometrageStart INT,
	KilometrageEnd INT,
	TotalKilometrage INT,
	StartDate DATETIME2,
	EndDate DATETIME2,
	TotalDays INT,
	RateApplied INT, 
	TaxRate INT,
	OrderStatus VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX)
)
INSERT INTO RentalOrders(EmployeedId, CustomerId, CarId, OrderStatus)
	VALUES(1,2,3, 'Good'),
	(3,2,1, 'Fine'),
	(3,1,2 , 'Exc')


--16. SoftUni Database

CREATE DATABASE SoftUni

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
)
CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	AddressText VARCHAR(MAX),
	TownId INT FOREIGN KEY REFERENCES Towns(Id)
)
CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
)
CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30),
	MiddleName VARCHAR(30),
	LastName VARCHAR(30),
	JobTitle VARCHAR(30),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
	HireDate DATETIME2,
	Salary INT NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

--19
SELECT * FROM Towns ORDER BY [Name]
SELECT * FROM Departments ORDER BY [Name]
SELECT * FROM Employees ORDER BY Salary DESC
--21
SELECT [Name] FROM Towns ORDER BY [Name]
SELECT [Name] FROM Departments ORDER BY [Name]
SELECT [FirstName], 
	[LastName], 
	[JobTitle], 
	[Salary]  
FROM Employees ORDER BY Salary DESC

--22
UPDATE Employees
SET Salary += Salary * 0.1

SELECT Salary FROM Employees


INSERT INTO Employees(Salary)
	VALUES(1231)

UPDATE Employees
SET Salary = 2
WHERE Id = 1
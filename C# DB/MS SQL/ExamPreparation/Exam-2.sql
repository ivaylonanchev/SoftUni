CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)
CREATE TABLE Contacts
(
	Id INT PRIMARY KEY IDENTITY,
	Email NVARCHAR(100),
	PhoneNumber NVARCHAR(20),
	PostAddress NVARCHAR(200),
	Website NVARCHAR(50)
)
CREATE TABLE Libraries
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	ContactId INT FOREIGN KEY REFERENCES Contacts(Id) NOT NULL
)
CREATE TABLE Authors
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	ContactId INT FOREIGN KEY REFERENCES Contacts(Id) NOT NULL	
)
CREATE TABLE Books
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(100) NOT NULL,
	YearPublished INT NOT NULL,
	ISBN NVARCHAR(13) NOT NULL UNIQUE,
	AuthorId INT FOREIGN KEY REFERENCES Authors(Id) NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL
)
CREATE TABLE LibrariesBooks
(
	LibraryId INT NOT NULL,
	BookId INT NOT NULL,

	CONSTRAINT PK_LibrariesBooks PRIMARY KEY (LibraryId, BookId),

	CONSTRAINT FK_LibrariesBooks_LibraryId FOREIGN KEY (LibraryId) REFERENCES Libraries(Id),
	CONSTRAINT FK_LibrariesBooks_BookId FOREIGN KEY (BookId) REFERENCES Books(Id)
)	

--2

INSERT INTO Contacts(Email, PhoneNumber, PostAddress,	Website)
		VALUES (null, null, null, null),
				(null, null, null, null),
				('stephen.king@example.com', '+4445556666', '15 Fiction Ave, Bangor, ME', 'www.stephenking.com'),
				('suzanne.collins@example.com', '+7778889999', '10 Mockingbird Ln, NY, NY', 'www.suzannecollins.com')

INSERT INTO Authors([Name], ContactId)
		VALUES('George Orwell',	21),
		('Aldous Huxley',	22),
		('Stephen King',	23),
		('Suzanne Collins',	24)

INSERT INTO Books(Title,YearPublished, ISBN, AuthorId, GenreId)
		VALUES('1984',	1949,	'9780451524935',	16,	2),
		('Animal Farm',	1945,	'9780451526342',		16,	2),
		('Brave New World',	1932,	'9780060850524',	17,	2),
		('The Doors of Perception',	1954,	'9780060850531',	17	,2),
		('The Shining',	1977,	'9780307743657'	,18	,9),
		('It',	1986,	'9781501142970'	,18,	9),
		('The Hunger Games'	,2008,	'9780439023481',	19,	7),
		('Catching Fire',	2009,	'9780439023498',	19,	7),
		('Mockingjay',	2010	,'9780439023511',	19	,7)

INSERT INTO LibrariesBooks(LibraryId, BookId)
		VALUES(1,36),
			(1,37),
			(2,38),
			(2,39),
			(3,40),
			(3,41),
			(4,42),
			(4,43),
			(5,44)

--3
UPDATE c
SET c.Website = LOWER(TRIM('www.' + REPLACE(a.[Name], ' ', '') + '.com'))
FROM Contacts as c
JOIN Authors as a ON a.ContactId = c.Id
WHERE c.Website IS NULL

--4
DECLARE @ToDelete_Books TABLE(Id INT)
INSERT INTO @ToDelete_Books
SELECT Id
FROM Authors
WHERE [Name]  LIKE 'Alex Michaelides' 

DECLARE @ToDelete_Lbr TABLE(Id INT)
INSERT INTO @ToDelete_Lbr
SELECT b.Id
FROM Books as B
JOIN @ToDelete_Books as t ON t.Id = b.AuthorId

DELETE FROM LibrariesBooks
WHERE BookId IN(SELECT Id FROM @ToDelete_Lbr)

DELETE FROM Books
WHERE Id IN (SELECT Id FROM @ToDelete_Books)

DELETE FROM Authors
WHERE Id IN (SELECT Id FROM @ToDelete_Books)

--5

SELECT
	Title as [Book Title],
	ISBN,
	YearPublished as [YearReleased]
FROM Books
ORDER BY YearPublished DESC,
		Title

--6

SELECT
	b.Id
	,b.Title
	,b.ISBN
	,g.[Name]
FROM Books AS b
JOIN Genres AS g ON g.Id = b.GenreId
WHERE g.[Name] IN ('Biography', 'Historical Fiction' )
ORDER BY g.[Name],
		b.Title 

--7

SELECT
	l.[Name] AS Lybrary
	,Email
	FROM Libraries AS l
	JOIN Contacts AS c ON c.Id= l.ContactId
	WHERE l.Id NOT IN 
	(
    SELECT LibraryId
    FROM LibrariesBooks lb
    JOIN Books b ON BookId = b.Id
    JOIN Genres g ON GenreId = g.Id
    WHERE Name = 'Mystery'
	)
ORDER BY Name;


--8
SELECT TOP 3
		Title,
		YearPublished as [Year],
		g.[Name] AS Gnre
FROM Books as b
JOIN Genres as g on g.Id = b.GenreId
WHERE (YearPublished >2000 AND Title LIKE '%a%' )
	OR
	(YearPublished < 1950 AND g.[Name] LIKE '%Fantasy%')
ORDER BY b.[Title] ASC, YearPublished DESC
	
	--9

	SELECT
			a.[Name]
			,c.Email
			,c.PostAddress
	FROM Authors AS a
	JOIN Contacts AS c ON c.Id = a.ContactId
	WHERE c.PostAddress LIKE '%UK'
	ORDER BY a.[Name]


	--10

	SELECT
	a.[Name] AS Author
	,b.Title
	,l.[Name] AS [Library]
	,c.PostAddress AS LibraryAddress
	FROM Books AS b
	JOIN Genres AS g On g.Id = b.GenreId	
	JOIN Authors AS a ON a.Id = b.AuthorId
	JOIN LibrariesBooks AS lb ON lb.BookId = b.Id
	JOIN Libraries AS l ON l.Id = lb.LibraryId
	JOIN Contacts AS c ON c.Id = l.ContactId
	WHERE c.PostAddress LIKE '%Denver%' AND g.[Name] IN('Fiction', 'Memoirs')
	ORDER BY b.Title

	--11

	CREATE FUNCTION udf_AuthorsWithBooks(@name VARCHAR(50)) 
	RETURNS INT
	AS
	BEGIN
				
		RETURN
		(SELECT
			COUNT(b.[Title])
		FROM Authors as a
		JOIN Books AS b On b.AuthorId = a.Id
		WHERE a.[Name] LIKE @name
		)
	END
	SELECT dbo.udf_AuthorsWithBooks('J.K. Rowling')

	--12
		
	CREATE PROC usp_SearchByGenre(@genreName VARCHAR(30))
	AS 
	BEGIN
		SELECT
		b.Title
		,b.YearPublished
		,b.ISBN
		,a.[Name]
		,g.[Name]
		FROM Books AS b
		JOIN Genres AS g ON g.Id = b.GenreId
		JOIN Authors AS a ON a.Id = b.AuthorId
		WHERE g.[Name] LIKE @genreName
		ORDER BY b.Title
	END

	EXEC usp_SearchByGenre 'Fantasy'
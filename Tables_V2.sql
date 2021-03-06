--DELETE GP.Movies
--DELETE GP.Rating
--DELETE GP.Genre
--DELETE GP.Region
--DELETE GP.Director
--DELETE GP.Actor
--DELETE GP.Financial
--DELETE GP.AdditionalInfo

DROP SCHEMA IF EXISTS GP;
GO

CREATE SCHEMA GP;
GO

DROP TABLE IF EXISTS GP.Movies
DROP TABLE IF EXISTS GP.Rating
DROP TABLE IF EXISTS GP.Genre
DROP TABLE IF EXISTS GP.Region
DROP TABLE IF EXISTS GP.Director
DROP TABLE IF EXISTS GP.Actor
DROP TABLE IF EXISTS GP.Financial
DROP TABLE IF EXISTS GP.AdditionalInfo

CREATE TABLE GP.Movies
(
   MovieID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
   Title NVARCHAR(MAX) NOT NULL,
   Year INT NOT NULL,
   Runtime INT NOT NULL,
   ContentRating NVARCHAR(10) NOT NULL,
   DateCreated DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
   DateUpdated DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
);
GO

CREATE TABLE GP.Rating
(
	RatingID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	IMDBscore FLOAT NOT NULL,
	VotesCount INT NOT NULL,
	MovieID INT NOT NULL FOREIGN KEY
		REFERENCES GP.Movies(MovieID),
	DateCreated DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
	DateUpdated DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())
);
GO

CREATE TABLE GP.Director
(
	MovieID INT NOT NULL FOREIGN KEY
		REFERENCES GP.Movies(MovieID),
	DirectorID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,		
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	DateCreated DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
	DateUpdated DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())
);
GO

CREATE TABLE GP.Actor
(
	MovieID INT NOT NULL FOREIGN KEY
		REFERENCES GP.Movies(MovieID),
	ActorID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,		
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	DateCreated DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
	DateUpdated DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())
);
GO

CREATE TABLE GP.Genre
(
	MovieID INT NOT NULL FOREIGN KEY
		REFERENCES GP.Movies(MovieID),
	GenreID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	Genre NVARCHAR(15) NOT NULL,
	DateCreated DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
	DateUpdated DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())
);
GO

CREATE TABLE GP.Financial
(
	FinancialID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	MovieID INT NOT NULL FOREIGN KEY
		REFERENCES GP.Movies(MovieID),
	Budget BIGINT NOT NULL,
	Gross BIGINT NOT NULL,
	DateCreated DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
	DateUpdated DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())
);
GO

CREATE TABLE GP.Region
(
	RegionID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	MovieID INT NOT NULL FOREIGN KEY
		REFERENCES GP.Movies(MovieID),
	Country NVARCHAR(25) NOT NULL,
	Language NVARCHAR(25) NOT NULL,
	DateCreated DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
	DateUpdated DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())
);
GO

CREATE TABLE GP.AdditionalInfo
(
	InfoID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	MovieID INT NOT NULL FOREIGN KEY
		REFERENCES GP.Movies(MovieID),
	MovieLink NVARCHAR(150) NOT NULL,
	AspectRatio NVARCHAR(10) NOT NULL,
	Color NVARCHAR (100) NOT NULL,
	DateCreated DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
	DateUpdated DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())

	--UNIQUE
	--(
	--	MovieLink ASC
	--)
);
GO


--CREATE SCHEMA GP;
--drop table GP.Movie
--drop table GP.Rating
--drop table GP.Genre
--drop table GP.[Language]
--drop table GP.Director

CREATE TABLE GP.Movie
(
   MovieID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
   IMDBID INT NOT NULL,
   Title NVARCHAR(25) NOT NULL,
   Adult BIT NOT NULL,
   TagLine NVARCHAR(200) NOT NULL,
   Overview NVARCHAR(500) NOT NULL,
   ReleaseDate DATETIME2(0) NOT NULL,
   Runtime INT NOT NULL,
   GenreID INT NOT NULL,
   DirectorID INT NOT NULL,
   Budget INT NOT NULL,
   AverageVote INT NOT NULL,
   OriginalLanguage NVARCHAR(2) NOT NULL,
   --DateUpdated DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),

   UNIQUE
   (
      Title ASC,
	   IMDBID ASC,
	  GenreID ASC,
	  DirectorID ASC
   )
);
GO

CREATE TABLE GP.Rating
(
	--NEEDS PRIMARY KEY
	AverageVote INT NOT NULL,
	MovieID INT NOT NULL FOREIGN KEY
		REFERENCES GP.Movie(MovieID),
	--DateUpdated DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())
);
GO

CREATE TABLE GP.Director
(
	MovieID INT NOT NULL FOREIGN KEY
		REFERENCES GP.Movie(MovieID),
	DirectorID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,		
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	BirthDate DATETIME2(0) NOT NULL,
	--DateUpdated DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())
);
GO

CREATE TABLE GP.Genre
(
	MovieID INT NOT NULL FOREIGN KEY
		REFERENCES GP.Movie(MovieID),
	GenreID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	Genre NVARCHAR(15) NOT NULL,
	--DateUpdated DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())
	UNIQUE (GenreID ASC)
);
GO

CREATE TABLE GP.[Language]
(
	--NEEDS PRIMARY KEY
	MovieID INT NOT NULL FOREIGN KEY
		REFERENCES GP.Movie(MovieID),
	OriginalLanguage NVARCHAR(2) NOT NULL
	--DateUpdated DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())
);
GO

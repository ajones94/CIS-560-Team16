--DROP SCHEMA IF EXISTS GP;
--CREATE SCHEMA GP;
--DROP TABLE IF EXISTS GP.Movies
--DROP TABLE IF EXISTS GP.Links
--DROP TABLE IF EXISTS GP.Tags
--DROP TABLE IF EXISTS GP.Ratings

CREATE TABLE GP.Movies
(
   MovieID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
   Title NVARCHAR(50) NOT NULL UNIQUE,
   Genre NVARCHAR(200) NOT NULL,
   UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())
);
GO

CREATE TABLE GP.Links
(
   IMDBID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
   MovieID INT NOT NULL FOREIGN KEY
		REFERENCES GP.Movies(MovieID),
   TMDBID INT NOT NULL UNIQUE
);
GO

CREATE TABLE GP.Tags
(
   UserID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
   MovieID INT NOT NULL FOREIGN KEY
		REFERENCES GP.Movies(MovieID),
   Tag NVARCHAR(50) NOT NULL,
   [TimeStamp] DATETIME2(0) NOT NULL

);
GO

CREATE TABLE GP.Ratings
(
   UserID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
   MovieID INT NOT NULL FOREIGN KEY
		REFERENCES GP.Movies(MovieID),
   Rating INT NOT NULL, 
   [TimeStamp] DATETIME2(0) NOT NULL
);
GO

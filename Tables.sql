CREATE SCHEMA TeamProject;
DROP TABLE IF EXISTS TeamProject.Movies 
DROP TABLE IF EXISTS TeamProject.Directors 
DROP TABLE IF EXISTS TeamProject.Genres 
DROP TABLE IF EXISTS TeamProject.Ratings

CREATE TABLE TeamProject.Movies 
(
		MovieID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
		Title NVARCHAR(200) NOT NULL,
		DirectorID INT NOT NULL,
		GenreID INT NOT NULL,
		AverageRating INT NOT NULL,
		LanguageID INT NOT NULL,
		Overview NVARCHAR(1000) NOT NULL, 
		ReleaseDate DATETIME2(0) NOT NULL,
		UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),

		UNIQUE
		 (
			Title ASC,
			DirectorID ASC,
			GenreID ASC, 
			AverageRating ASC,
			LanguageID ASC
		 )
);
GO

/*
CREATE TABLE TeamProject.Directors 
(
		MovieID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
		DirectorID INT NOT NULL FOREIGN KEY
			REFERENCES TeamProject.Movies(DirectorID),
		LastName NVARCHAR(20) NOT NULL,
		FirstName NVARCHAR(20) NOT NULL,
		DateOfBirth DATETIME2(0) NOT NULL,
		UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())
);
GO
*/

CREATE TABLE TeamProject.Linguistic
(
		MovieID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
		LanguageID INT NOT NULL FOREIGN KEY
			REFERENCES TeamProject.Movies(LanguageID),
		[Language] NVARCHAR(20) NOT NULL,
		UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())
);
GO

CREATE TABLE TeamProject.Genres 
(
		MovieID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
		GenreID INT NOT NULL FOREIGN KEY
			REFERENCES TeamProject.Movies(GenreID),
		[Name] NVARCHAR(20) NOT NULL,
		UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())	
);
GO

CREATE TABLE TeamProject.Ratings
(
		MovieID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
		AverageRating INT NOT NULL FOREIGN KEY
			REFERENCES TeamProject.Movies(AverageRating),
		[Name] NVARCHAR(20) NOT NULL,
		Age NVARCHAR(20) NOT NULL,
		UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())

		 UNIQUE
		 (
			[Name] ASC,
			Age ASC
		 )
);
GO
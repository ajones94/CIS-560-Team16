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
		Overview NVARCHAR(1000) NOT NULL, 
		ReleaseDate DATETIME2(0) NOT NULL,

		UNIQUE
		 (
			Title ASC,
			DirectorID ASC,
			GenreID ASC, 
			AverageRating ASC
		 )
);
GO

CREATE TABLE TeamProject.Directors 
(
		--NEED PRIMARY KEY
		DirectorID INT NOT NULL FOREIGN KEY
			REFERENCES MOVIES(DirectorID),
		LastName NVARCHAR(20) NOT NULL,
		FirstName NVARCHAR(20) NOT NULL,
		DateOfBirth DATETIME2(0) NOT NULL
);
GO

CREATE TABLE TeamProject.Genres 
(
		--NEED PRIMARY KEY
		GenreID INT NOT NULL FOREIGN KEY
			REFERENCES MOVIES(GenreID),
		[Name] NVARCHAR(20) NOT NULL,	
);
GO

CREATE TABLE TeamProject.Ratings
(
		--NEED PRIMARY KEY
		AverageRating INT NOT NULL FOREIGN KEY
			REFERENCES MOVIES(AverageRating),
		[Name] NVARCHAR(20) NOT NULL,
		Age NVARCHAR(20) NOT NULL,

		 UNIQUE
		 (
			[Name] ASC,
			Age ASC
		 )
);
GO
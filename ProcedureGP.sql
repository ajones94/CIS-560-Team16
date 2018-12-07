
-----------------------------------------------------INSERT-----------------------------------------------------------------

/**************************************
 * Procedure for inserting a new Movie
 **************************************/

DROP PROCEDURE IF EXISTS GP.InsertMovie 
GO

CREATE PROCEDURE GP.InsertMovie
   @Title NVARCHAR(50),
   @Year INT,
   @RunTime INT,
   @ContentRating NVARCHAR(10)
AS

INSERT GP.Movies(Title, Year, RunTime, ContentRating)
VALUES(@Title, @Year, @RunTime, @ContentRating);

GO

/**************************************
 * Procedure for inserting a new Rating
 **************************************/

DROP PROCEDURE IF EXISTS GP.InsertRating 
GO

CREATE PROCEDURE GP.InsertRating
	@IMDBscore INT,
	@VotesCount INT
AS

INSERT GP.Rating(IMDBscore, VotesCount)
VALUES(@IMDBscore, @VotesCount);
GO

/**************************************
 * Procedure for inserting a new Director
 **************************************/

DROP PROCEDURE IF EXISTS GP.InsertDirector 
GO

CREATE PROCEDURE GP.InsertDirector
	@FirstName NVARCHAR(20),
	@LastName NVARCHAR(20)
AS

INSERT GP.Director(FirstName, LastName)
VALUES(@FirstName, @LastName);
GO


/**************************************
 * Procedure for inserting a new Actor
 **************************************/

DROP PROCEDURE IF EXISTS GP.InsertActor
GO

CREATE PROCEDURE GP.InsertActor
	@FirstName NVARCHAR(20),
	@LastName NVARCHAR(20)
AS

INSERT GP.Actor(FirstName, LastName)
VALUES(@FirstName, @LastName);
GO

/**************************************
 * Procedure for inserting a new Genre
 **************************************/

DROP PROCEDURE IF EXISTS GP.InsertGenre
GO

CREATE PROCEDURE GP.InsertGenre
	@Genre NVARCHAR(15)
AS

INSERT GP.Genre(Genre)
VALUES(@Genre);
GO

/**************************************
 * Procedure for inserting a new Financial
 **************************************/

DROP PROCEDURE IF EXISTS GP.InsertFinancial
GO

CREATE PROCEDURE GP.InsertFinancial
	@Budget INT,
	@Gross INT
AS

INSERT GP.Financial(Budget, Gross)
VALUES(@Budget, @Gross);
GO

/**************************************
 * Procedure for inserting a new Region
 **************************************/

DROP PROCEDURE IF EXISTS GP.InsertRegion
GO

CREATE PROCEDURE GP.InsertRegion
	@Country NVARCHAR(25),
	@Language NVARCHAR(25)
AS

INSERT GP.Region(Country, Language)
VALUES(@country, @Language);
GO

/**************************************
 * Procedure for inserting a new Additional Info
 **************************************/

DROP PROCEDURE IF EXISTS GP.InsertAdditionalInfo
GO

CREATE PROCEDURE GP.InsertAdditionalInfo
	@MovieLink NVARCHAR(100),
	@AspectRatio NVARCHAR(10),
	@Color NVARCHAR(10)
AS

INSERT GP.AdditionalInfo(MovieLink, AspectRatio, Color)
VALUES(@MovieLink, @AspectRatio, @Color);
GO

-----------------------------------------------------UPDATE-----------------------------------------------------------------

/**************************************
 * Procedure for updating a Movie
 **************************************/

DROP PROCEDURE IF EXISTS GP.UpdateMovie 
GO

CREATE PROCEDURE GP.UpdateMovie
   @MovieID INT,
   @Title NVARCHAR(50),
   @Year INT,
   @RunTime INT,
   @ContentRating NVARCHAR(10),
   @UpdatedOn DATETIMEOFFSET OUTPUT
AS

UPDATE GP.Movies
SET
  Title = CASE WHEN @Title IS NULL OR @Title = '' THEN Title ELSE @Title END,
  Year = CASE WHEN @Year IS NULL OR @Year = '' THEN Year ELSE @Year END,
  RunTime = CASE WHEN @RunTime IS NULL OR @RunTime = '' THEN RunTime ELSE @RunTime END,
  ContentRating = CASE WHEN @ContentRating IS NULL OR @ContentRating = '' THEN ContentRating ELSE @ContentRating END,
  UpdatedOn = SYSDATETIMEOFFSET()
WHERE MovieID = @MovieID;
GO

/**************************************
 * Procedure for updating a Rating
 **************************************/

DROP PROCEDURE IF EXISTS GP.UpdateRating 
GO

CREATE PROCEDURE GP.UpdateRating
	@RatingID INT,
	@IMDBscore INT,
	@VotesCount INT,
	@UpdatedOn DATETIMEOFFSET OUTPUT
AS

UPDATE GP.Rating
SET
  IMDBscore = CASE WHEN @IMDBscore IS NULL OR @IMDBscore = '' THEN IMDBscore ELSE @IMDBscore END,
  VotesCount = CASE WHEN @VotesCount IS NULL OR @VotesCount = '' THEN VotesCount ELSE @VotesCount END,
  UpdatedOn = SYSDATETIMEOFFSET()
WHERE RatingID = @RatingID;
GO

/**************************************
 * Procedure for updating a Director
 **************************************/

DROP PROCEDURE IF EXISTS GP.UpdateDirector
GO

CREATE PROCEDURE GP.UpdateDirector
	@DirectorID INT,
	@FirstName NVARCHAR(20),
	@LastName NVARCHAR(20),
    @UpdatedOn DATETIMEOFFSET OUTPUT
AS

UPDATE GP.Director
SET
  FirstName = CASE WHEN @FirstName IS NULL OR @FirstName = '' THEN FirstName ELSE @FirstName END,
  LastName = CASE WHEN @LastName IS NULL OR @LastName = '' THEN LastName ELSE @LastName END,
  UpdatedOn = SYSDATETIMEOFFSET()
WHERE DirectorID = @DirectorID;
GO

/**************************************
 * Procedure for updating an Actor
 **************************************/

DROP PROCEDURE IF EXISTS GP.UpdateActor
GO

CREATE PROCEDURE GP.UpdateActor
	@ActorID INT,
	@FirstName NVARCHAR(20),
	@LastName NVARCHAR(20),
    @UpdatedOn DATETIMEOFFSET OUTPUT
AS

UPDATE GP.Actor
SET
  FirstName = CASE WHEN @FirstName IS NULL OR @FirstName = '' THEN FirstName ELSE @FirstName END,
  LastName = CASE WHEN @LastName IS NULL OR @LastName = '' THEN LastName ELSE @LastName END,
  UpdatedOn = SYSDATETIMEOFFSET()
WHERE ActorID = @ActorID;
GO

/**************************************
 * Procedure for updating a Genre
 **************************************/

DROP PROCEDURE IF EXISTS GP.UpdateGenre 
GO

CREATE PROCEDURE GP.UpdateGenre
	@GenreID INT,
	@Genre NVARCHAR(15),
    @UpdatedOn DATETIMEOFFSET OUTPUT
AS

UPDATE GP.Genre
SET
  Genre = CASE WHEN @Genre IS NULL OR @Genre = '' THEN Genre ELSE @Genre END,
  UpdatedOn = SYSDATETIMEOFFSET()
WHERE GenreID = @GenreID;
GO

/**************************************
 * Procedure for updating a Financial
 **************************************/

DROP PROCEDURE IF EXISTS GP.UpdateFinancial
GO

CREATE PROCEDURE GP.UpdateFinancial
	@FinancialID INT,
	@Budget INT,
	@Gross INT,
    @UpdatedOn DATETIMEOFFSET OUTPUT
AS

UPDATE GP.Financial
SET
  Budget = CASE WHEN @Budget IS NULL OR @Budget = '' THEN Budget ELSE @Budget END,
  Gross = CASE WHEN @Gross IS NULL OR @Gross = '' THEN Gross ELSE @Gross END,
  UpdatedOn = SYSDATETIMEOFFSET()
WHERE FinancialID = @FinancialID;
GO

/**************************************
 * Procedure for updating a Region
 **************************************/

DROP PROCEDURE IF EXISTS GP.UpdateRegion
GO

CREATE PROCEDURE GP.UpdateRegion
	@RegionID INT,
	@Country NVARCHAR(25),
	@Language NVARCHAR(25),
    @UpdatedOn DATETIMEOFFSET OUTPUT
AS

UPDATE GP.Region
SET
  Country = CASE WHEN @Country IS NULL OR @Country = '' THEN Country ELSE @Country END,
  Language = CASE WHEN @Language IS NULL OR @Language = '' THEN Language ELSE @Language END,
  UpdatedOn = SYSDATETIMEOFFSET()
WHERE RegionID = @RegionID;
GO

/**************************************
 * Procedure for updating a Additional Info
 **************************************/

DROP PROCEDURE IF EXISTS GP.UpdateInfo
GO

CREATE PROCEDURE GP.UpdateInfo
	@InfoID INT,
	@MovieLink NVARCHAR(100),
	@AspectRatio NVARCHAR(10),
	@Color NVARCHAR(10),
    @UpdatedOn DATETIMEOFFSET OUTPUT
AS

UPDATE GP.AdditionalInfo
SET
  MovieLink = CASE WHEN @MovieLink IS NULL OR @MovieLink = '' THEN MovieLink ELSE @MovieLink END,
  AspectRatio = CASE WHEN @AspectRatio IS NULL OR @AspectRatio = '' THEN AspectRatio ELSE @AspectRatio END,
  Color = CASE WHEN @Color IS NULL OR @Color = '' THEN Color ELSE @Color END,
  UpdatedOn = SYSDATETIMEOFFSET()
WHERE InfoID = @InfoID;
GO

-----------------------------------------------------DELETE-----------------------------------------------------------------

/**************************************
 * Procedure for deleting a Movie entry
 **************************************/

CREATE PROCEDURE GP.DeleteMovie
	@MovieTitle NVARCHAR(50),
	@MovieID INT
AS
BEGIN
	DELETE FROM GP.Movies WHERE Title = @MovieTitle OR MovieID = @MovieID
END

/**************************************
 * Procedure for deleting an Actor entry
 **************************************/
go
CREATE PROCEDURE GP.DeleteActor
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@ActorID INT
AS
BEGIN
	DELETE FROM GP.Actor WHERE ActorID = @ActorID OR FirstName = @FirstName OR LastName = @LastName
END


/**************************************
 * Procedure for deleting a Director entry
 **************************************/
GO
CREATE PROCEDURE GP.DeleteDirector
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@DirectorID INT
AS
BEGIN
	DELETE FROM Gp.Director WHERE FirstName = @FirstName OR LastName = @LastName OR DirectorID = @DirectorID
END

/**************************************
 * Procedure for deleting a Rating entry
 **************************************/
GO
CREATE PROCEDURE GP.DeleteRating
	@RatingID INT,
	@IMDBRating INT,
	@MovieID INT
AS
BEGIN
	DELETE FROM GP.Rating WHERE RatingID = @RatingID OR IMDBscore = @IMDBRating OR MovieID = @MovieID
END

/**************************************
 * Procedure for deleting a Genre entry
 **************************************/
GO
CREATE PROCEDURE GP.DeleteGenre
	@GenreID INT,
	@Genre NVARCHAR(15)
AS
BEGIN
	DELETE FROM GP.Genre WHERE GenreID = @GenreID OR Genre = @Genre
END

/**************************************
 * Procedure for deleting a Financial entry
 **************************************/
GO
CREATE PROCEDURE GP.DeleteFinances
	@FinancialID INT,
	@Budget INT,
	@Gross INT
AS
BEGIN
	DELETE FROM Gp.Financial WHERE FinancialID = @FinancialID OR Budget = @Budget OR Gross = @Gross
END

/**************************************
 * Procedure for deleting an Additional Info entry
 **************************************/
GO
CREATE PROCEDURE GP.DeleteAditionalInfo
	@InfoID INT
AS
BEGIN
	DELETE FROM GP.AdditionalInfo WHERE InfoID = @InfoID
END


-----------------------------------------------------SEARCH-----------------------------------------------------------------

/**************************************
 * Movie Title Search Procedure
 **************************************/

EXEC GP.TitleSearch
	@Title = 'Die Hard'
	GO

DROP PROCEDURE IF EXISTS GP.TitleSearch
GO

CREATE PROCEDURE GP.TitleSearch
   @Title NVARCHAR(50)
AS

SELECT *
FROM GP.Movies M
WHERE M.Title = @Title;
GO

/**************************************
 * Actor Name Search Procedure
 **************************************/

DROP PROCEDURE IF EXISTS GP.ActorSearch
GO

CREATE PROCEDURE GP.ActorSearch
    @Name NVARCHAR(20)
AS

SELECT *
FROM GP.Actor A
WHERE A.FirstName = @Name OR A.LastName = @Name;
GO

/**************************************
 * Director Name Search Procedure
 **************************************/

DROP PROCEDURE IF EXISTS GP.DirectorSearch
GO

CREATE PROCEDURE GP.DirectorSearch
    @Name NVARCHAR(20)
AS

SELECT *
FROM GP.Director D
WHERE D.FirstName = @Name OR D.LastName = @Name;
GO

/**************************************
 * Rating Range Search Procedure
 **************************************/

EXEC GP.RatingRangeSearch
	@MinRating = 5,
	@MaxRating = 8
	GO

DROP PROCEDURE IF EXISTS GP.RatingRangeSearch
GO

CREATE PROCEDURE GP.RatingRangeSearch
   @MinRating INT,
   @MaxRating INT
AS

SELECT DISTINCT M.Title, R.IMDBscore, F.Gross, F.Budget, REG.Country, REG.Language 
FROM GP.Rating R
	  INNER JOIN GP.Movies M ON M.MovieID = R.MovieID
	  INNER JOIN GP.Actor A ON A.MovieID = R.MovieID
	  INNER JOIN GP.Director D ON D.MovieID = R.MovieID
	  INNER JOIN GP.Genre G ON G.MovieID = R.MovieID
	  INNER JOIN GP.Region REG ON REG.MovieID = R.MovieID
	  INNER JOIN GP.Financial F ON F.MovieID = R.MovieID
	  INNER JOIN GP.AdditionalInfo I ON I.MovieID = R.MovieID
WHERE R.IMDBscore BETWEEN @MinRating AND @MaxRating
ORDER BY R.IMDBscore DESC;
GO

-----------------------------------------------------STATS-----------------------------------------------------------------
/**************************************
 * Procedure to find Actor Count
 **************************************/
CREATE PROCEDURE GP.ActorCount
	@ActorFirstName NVARCHAR(100),
	@ActorLastName NVARCHAR(100)
AS
BEGIN
	SELECT COUNT(DISTINCT M.MovieID) AS MovieCount 
	FROM GP.Movies M
		INNER JOIN GP.Actor A ON A.MovieID = M.MovieID
	WHERE A.FirstName = @ActorFirstName AND A.LastName = @ActorLastName
END


GO

/**************************************
 * Procedure to find Director Count
 **************************************/
CREATE PROCEDURE GP.DirectorCount
	@DirectorFirstName NVARCHAR(100),
	@DirectorLastName NVARCHAR(100)
AS
BEGIN
	SELECT COUNT(DISTINCT M.MovieID) AS MovieCount
	FROM GP.Movies M
		INNER JOIN Gp.Director D ON D.MovieID = M.MovieID
	WHERE D.FirstName = @DirectorFirstName AND D.LastName = @DirectorLastName

END


GO
/**************************************
 * Procedure to Calculate Genre Gross
 **************************************/
 DROP PROCEDURE IF EXISTS GP.GenreGross
 GO

CREATE PROCEDURE GP.GenreGross
	@GenreName NVARCHAR(50)
AS
BEGIN
	SELECT FORMAT(SUM(F.Gross), '##,##0') AS GenreGross, FORMAT(SUM(F.Budget), '##,##0') as GenreBudget, SUM(F.Gross-F.Budget) AS GenreProfit
	FROM GP.Financial F
		INNER JOIN GP.Genre G ON G.MovieID = F.MovieID
	WHERE G.Genre = @GenreName
END

-----------------------------------------------------FINANCIAL-----------------------------------------------------------------

/**************************************
 * Procedure to find Movie Gross
 **************************************/

EXEC GP.MovieGross
	@Title = 'Die Hard'
	GO


DROP PROCEDURE IF EXISTS GP.MovieGross
GO

CREATE PROCEDURE GP.MovieGross
	@Title NVARCHAR(50)
AS
BEGIN
SELECT M.Title, F.Gross
FROM GP.Movies M
	INNER JOIN GP.Financial F ON F.MovieID = M.MovieID
	WHERE M.Title = @Title
GROUP BY F.Gross, M.Title
ORDER BY F.Gross DESC
END
GO

/**************************************
 * Procedure to find Movie Budget
 **************************************/

EXEC GP.MovieBudget
	@Title = 'Die Hard'
	GO


DROP PROCEDURE IF EXISTS GP.MovieBudget
GO

CREATE PROCEDURE GP.MovieBudget
	@Title NVARCHAR(50)
AS
BEGIN
SELECT M.Title, FORMAT(F.Budget, '##,##0')
FROM GP.Movies M
	INNER JOIN GP.Financial F ON F.MovieID = M.MovieID
	WHERE M.Title = @Title
GROUP BY F.Budget, M.Title
ORDER BY F.Budget DESC
END
GO

/**************************************
 * Procedure to find 100 highest grossing movies
 **************************************/

EXEC GP.TopMovieGross_100
GO

DROP PROCEDURE IF EXISTS GP.TopMovieGross_100
GO

CREATE PROCEDURE GP.TopMovieGross_100
AS
BEGIN
SELECT TOP 100 F.Gross, M.Title
FROM GP.Financial F
	INNER JOIN GP.Movies M ON F.MovieID = M.MovieID
GROUP BY F.Gross, M.Title
ORDER BY F.Gross DESC
END
GO

/**************************************
 * Procedure to find 100 most profitable movies
 **************************************/

EXEC GP.TopMovieProfit_100
GO

DROP PROCEDURE IF EXISTS GP.TopMovieProfit_100
GO

CREATE PROCEDURE GP.TopMovieProfit_100
AS

SELECT TOP 100 -SUM(F.Gross - F.Budget) AS Profit, M.Title
FROM GP.Financial F
	INNER JOIN GP.Movies M ON M.MovieID = F.MovieID
GROUP BY M.Title
ORDER BY Profit ASC
GO

DROP PROCEDURE IF EXISTS GP.MovieSearch
GO

CREATE PROCEDURE GP.MovieSearch
	@MovieTitle nvarchar(MAX) = null,
	@Genre nvarchar(50) = null,
	@Country nvarchar(100) = null,
	@Language nvarchar(100) = null,
	@DirectorFirstName nvarchar(100) = null,
	@DirectorLastName nvarchar(100) = null
 	as 
	SELECT g.Title, g.Year, g.Runtime, g.ContentRating, d.FirstName, d.LastName, rE.Language, rE.Country, aI.AspectRatio, aI.Color, f.Budget, f.Gross, r.IMDBscore, r.VotesCount
	FROM GP.Genre M
	INNER JOIN GP.Movies g on g.MovieID = M.MovieID
	INNER JOIN GP.Director d on d.MovieID = M.MovieID
	INNER JOIN GP.Region rE on rE.MovieID = M.MovieID
	INNER JOIN GP.AdditionalInfo aI on aI.MovieID = M.MovieID
	INNER JOIN GP.Financial f on f.MovieID = M.MovieID
	INNER JOIN GP.Rating r on r.MovieID = M.MovieID
		
		/*INNER JOIN GP.Actor A ON a.MovieID = M.MovieID*/
	WHERE
	(g.Title = @MovieTitle OR @MovieTitle IS NULL)
		AND (M.Genre = @Genre OR @Genre IS NULL)
		AND (rE.Country = @Country OR @Country IS NULL)
		AND (rE.Language = @Language OR @Language IS NULL)
		AND (d.FirstName = @DirectorFirstName OR @DirectorFirstName IS NULL)
		AND (d.LastName = @DirectorLastname OR @DirectorLastName IS NULL)
GO



DROP PROCEDURE IF EXISTS GP.DirectorSearch
	GO
	CREATE PROCEDURE GP.DirectorSearch
	@MovieTitle nvarchar(MAX) = null,
	@Genre nvarchar(50) = null,
	@Country nvarchar(100) = null,
	@Language nvarchar(100) = null,
	@DirectorFirstName nvarchar(100) = null,
	@DirectorLastName nvarchar(100) = null
	AS
	Select d.FirstName, d.LastName, m.Title
	FROM GP.Movies m
	INNER JOIN GP.Genre g on g.MovieID = m.MovieID
	INNER JOIN GP.Region rE on rE.MovieID = m.MovieID
	INNER JOIN GP.AdditionalInfo aI on aI.MovieID = m.MovieID
	INNER JOIN GP.Financial f on f.MovieID = m.MovieID
	INNER JOIN GP.Rating r on r.MovieID = m.MovieID
	INNER JOIN GP.Director d on d.MovieID = m.MovieID
	WHERE
	(m.Title = @MovieTitle OR @MovieTitle IS NULL)
		AND (rE.Country = @Country OR @Country IS NULL)
		AND (rE.Language = @Language OR @Language IS NULL)
		AND (d.FirstName = @DirectorFirstName OR @DirectorFirstName IS NULL)
		AND (d.LastName = @DirectorLastname OR @DirectorLastName IS NULL)
		AND (g.Genre = @Genre OR @Genre IS NULL)

DROP PROCEDURE IF EXISTS GP.FinancialSearch
GO

CREATE PROCEDURE GP.FinancialSearch
	@MovieTitle nvarchar(MAX) = null,
	@Genre nvarchar(50) = null,
	@Country nvarchar(100) = null,
	@Language nvarchar(100) = null,
	@DirectorFirstName nvarchar(100) = null,
	@DirectorLastName nvarchar(100) = null
	AS
	Select d.FirstName, d.LastName, m.Title
	FROM GP.Financial f
	INNER JOIN GP.Genre g on g.MovieID = f.MovieID
	INNER JOIN GP.Movies m on m.MovieID = f.MovieID
	INNER JOIN GP.Region rE on rE.MovieID = M.MovieID
	INNER JOIN GP.AdditionalInfo aI on aI.MovieID = M.MovieID
	INNER JOIN GP.Director d on d.MovieID = M.MovieID
	INNER JOIN GP.Rating r on r.MovieID = M.MovieID
	WHERE
	(m.Title = @MovieTitle OR @MovieTitle IS NULL)
		AND (g.Genre = @Genre OR @Genre IS NULL)
		AND (rE.Country = @Country OR @Country IS NULL)
		AND (rE.Language = @Language OR @Language IS NULL)
		AND (d.FirstName = @DirectorFirstName OR @DirectorFirstName IS NULL)
		AND (d.LastName = @DirectorLastname OR @DirectorLastName IS NULL)






 /*/**************************************************
 * Specific Search Procedure using Title, Tag, Genre
 ***************************************************/

 --Only works with all variables filled, incorrect joins, too tired to fix now

DROP PROCEDURE IF EXISTS GP.SpecificSearch 
GO

CREATE PROCEDURE GP.SpecificSearch

   @Title NVARCHAR(50),
   @Tag NVARCHAR(25),
   @Genre NVARCHAR(200)

AS
BEGIN

    IF (@Title IS NOT NULL AND @Tag IS NULL AND @Genre IS NULL)
        -- Search by title only
        SELECT *
        FROM GP.Movies M
      INNER JOIN GP.Tags T ON T.MovieID = M.MovieID
      INNER JOIN GP.Links L ON L.MovieID = M.MovieID
      INNER JOIN GP.Ratings R ON R.MovieID = M.MovieID
        WHERE
            M.Tile = @Title

    ELSE IF (@Title IS NULL AND @Tag IS NOT NULL AND @Genre IS NULL)
        -- Search by tag only
        SELECT *
        FROM GP.Movies M
      INNER JOIN GP.Tags T ON T.MovieID = M.MovieID
      INNER JOIN GP.Links L ON L.MovieID = M.MovieID
      INNER JOIN GP.Ratings R ON R.MovieID = M.MovieID
        WHERE
            Tag = @Tag

    ELSE IF (@Title IS NULL AND @Tag IS NULL AND @Genre IS NOT NULL)
        -- Search by genre only
        SELECT *
        FROM GP.Movies M
      INNER JOIN GP.Tags T ON T.MovieID = M.MovieID
      INNER JOIN GP.Links L ON L.MovieID = M.MovieID
      INNER JOIN GP.Ratings R ON R.MovieID = M.MovieID
        WHERE
            Genres = @Genre

    ELSE IF (@Title IS NOT NULL AND @Tag IS NOT NULL AND @Genre IS NULL)
        -- Search by title and tag
        SELECT *
        FROM GP.Movies M
      INNER JOIN GP.Tags T ON T.MovieID = M.MovieID
      INNER JOIN GP.Links L ON L.MovieID = M.MovieID
      INNER JOIN GP.Ratings R ON R.MovieID = M.MovieID
        WHERE
            Tile = @Title
            AND Tag = @Tag

    ELSE
        -- Search by any other combination
        SELECT *
        FROM GP.Movies M
      INNER JOIN GP.Tags T ON T.MovieID = M.MovieID
      INNER JOIN GP.Links L ON L.MovieID = M.MovieID
      INNER JOIN GP.Ratings R ON R.MovieID = M.MovieID
        WHERE
                (@Title IS NULL OR (Tile = @Title))
            AND (@Tag IS NULL OR (Tag  = @Tag))
            AND (@Genre IS NULL OR (Genres = @Genre))
END
GO

/*******************************************
 * General Search Procedure using any string
 * https://www.mssqltips.com/sqlservertip/1522/searching-and-finding-a-string-value-in-all-columns-in-a-sql-server-table/
 *******************************************/

--Untested

DROP PROCEDURE IF EXISTS GP.GeneralSearch 
GO

CREATE PROCEDURE GP.GeneralSearch 
 
  @SearchParameter VARCHAR(100), 
  @Schema sysname, @Table sysname 
AS

BEGIN TRY
   DECLARE @SQLCommand varchar(max) = 'SELECT * FROM [' + @Schema + '].[' + @Table + '] WHERE ' 
     
   SELECT @SQLCommand = @SQLCommand + '[' + COLUMN_NAME + '] LIKE ''' + @SearchParameter + ''' OR '
   FROM INFORMATION_SCHEMA.COLUMNS 
   WHERE TABLE_SCHEMA = @Schema
   AND TABLE_NAME = @Table 
   AND DATA_TYPE IN ('char','nchar','ntext','nvarchar','text','varchar')

   SET @sqlCommand = left(@sqlCommand,len(@sqlCommand)-3)
   EXEC (@SQLCommand)
   PRINT @SQLCommand
END TRY

BEGIN CATCH 
   PRINT 'There was an error. Check to make sure object exists.'
   PRINT error_message()
END CATCH 
GO*/

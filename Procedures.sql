
EXEC dbo.InsertMovie
	@MovieID = 809453,
	@Title = 'testTitle',
	@Genre = 'testGenre',
	@IMDBID = 70890,
	@TMDBID =70894,
	@UserID = 235549,
	@Rating = 0,
	@TimeStamp = 'stamp',
	@Tag = 'testTag';
	
EXEC dbo.UpdateMovie
	@MovieID = 809455,
	@Title = 'testTitle1',
	@Genre = 'testGenre1',
	@IMDBID = 70892,
	@TMDBID =70892,
	@UserID = 235542,
	@Rating = 1,
	@TimeStamp = 'stamp1',
	@Tag = 'testTag1';
	
EXEC dbo.DeleteMovie @MovieID = 809455; 

EXEC dbo.TagSearch @Tag = 'testTag';

EXEC dbo.RatingRangeSearch
	@MinRating =2,
	@MaxRating = 3;

EXEC dbo.SpecificSearch
	@Title ='testTitle',
	@Tag = 'testTag',
	@Genre = 'testGenre';

/**************************************
 * Procedure for inserting a new movie
 **************************************/

 --Tested, working

DROP PROCEDURE IF EXISTS dbo.InsertMovie 
GO

CREATE PROCEDURE dbo.InsertMovie
   @MovieID INT,
   @Title NVARCHAR(50),
   @Genre NVARCHAR(200),
   @IMDBID INT,
   @TMDBID INT,
   @UserID INT,
   @Rating INT,
   @TimeStamp NVARCHAR(50),
   @Tag NVARCHAR(25)--,
   --@UpdatedOn DATETIMEOFFSET OUTPUT
AS

INSERT dbo.Movies(MovieID, Tile, Genres)
VALUES(@MovieID, @Title, @Genre);

/*SET @UpdatedOn =
   (
      SELECT M.UpdatedOn
      FROM dbo.Movies M
      WHERE M.MovieID = @MovieID
   );*/

INSERT dbo.Links(MovieID, IMDBID, TMDBID)
VALUES(@MovieID, @IMDBID, @TMDBID);

INSERT dbo.Ratings(MovieID, UserID, Rating, [TimeStamp])
VALUES(@MovieID, @UserID, @Rating, @TimeStamp);

INSERT dbo.Tags(MovieID, UserID, [TimeStamp], Tag)
VALUES(@MovieID, @UserID, @TimeStamp, @Tag);
GO

/**************************************
 * Procedure for updating a movie entry
 **************************************/

 --Updates all entries in database ¯\_(ツ)_/¯

DROP PROCEDURE IF EXISTS dbo.UpdateMovie 
GO

CREATE PROCEDURE dbo.UpdateMovie
   @MovieID INT,
   @Title NVARCHAR(50),
   @Genre NVARCHAR(200),
   @IMDBID INT,
   @TMDBID INT,
   @UserID INT,
   @Rating INT,
   @TimeStamp NVARCHAR(50),
   @Tag NVARCHAR(25)--,
   --@UpdatedOn DATETIMEOFFSET OUTPUT
AS

UPDATE dbo.Movies
SET
	MovieID = CASE WHEN @MovieID IS NOT NULL THEN @MovieID ELSE MovieID END,
	Tile = CASE WHEN @Title IS NOT NULL THEN @Title ELSE Tile END,
	Genres = CASE WHEN @Genre IS NOT NULL THEN @Genre ELSE Genres END;--,
	--UpdatedOn = SYSDATETIMEOFFSET();

UPDATE dbo.Links
SET
	MovieID = CASE WHEN @MovieID IS NOT NULL THEN @MovieID ELSE MovieID END,
	IMDBID = CASE WHEN @IMDBID IS NOT NULL THEN @IMDBID ELSE IMDBID END,
	TMDBID = CASE WHEN @TMDBID IS NOT NULL THEN @TMDBID ELSE TMDBID END;
	
UPDATE dbo.Ratings
SET
	MovieID = CASE WHEN @MovieID IS NOT NULL THEN @MovieID ELSE MovieID END,
	UserID = CASE WHEN @UserID IS NOT NULL THEN @UserID ELSE UserID END,
	Rating = CASE WHEN @Rating IS NOT NULL THEN @Rating ELSE Rating END,
	TimeStamp = CASE WHEN @TimeStamp IS NOT NULL THEN @TimeStamp ELSE TimeStamp END;

UPDATE dbo.Tags
SET
	MovieID = CASE WHEN @MovieID IS NOT NULL THEN @MovieID ELSE MovieID END,
	UserID = CASE WHEN @UserID IS NOT NULL THEN @UserID ELSE UserID END,
	Tag = CASE WHEN @Tag IS NOT NULL THEN @Tag ELSE Tag END,
	TimeStamp = CASE WHEN @TimeStamp IS NOT NULL THEN @TimeStamp ELSE TimeStamp END;
GO

/**************************************
 * Procedure for deleting a movie entry
 **************************************/

 --Deletes all entries in database ¯\_(ツ)_/¯

DROP PROCEDURE IF EXISTS dbo.DeleteMovie 
GO

CREATE PROCEDURE dbo.DeleteMovie
   @MovieID INT
AS

DELETE FROM dbo.Movies
WHERE MovieID = @MovieID;

DELETE FROM dbo.Links
WHERE MovieID = @MovieID;

DELETE FROM dbo.Ratings
WHERE MovieID = @MovieID;

DELETE FROM dbo.Tags
WHERE MovieID = @MovieID;
GO

/**************************************
 * Tag Only Search Procedure
 **************************************/

--Tested, working

DROP PROCEDURE IF EXISTS dbo.TagSearch
GO

CREATE PROCEDURE dbo.TagSearch
   @Tag NVARCHAR(500)
AS

SELECT *
FROM dbo.Tags T
WHERE T.Tag = @Tag;
GO

/**************************************
 * Rating Range Search Procedure
 **************************************/

--Untested

DROP PROCEDURE IF EXISTS dbo.RatingRangeSearch
GO

CREATE PROCEDURE dbo.RatingRangeSearch
   @MinRating INT,
   @MaxRating INT
AS

SELECT *
FROM dbo.Ratings R
	INNER JOIN dbo.Tags T ON T.MovieID = R.MovieID
	INNER JOIN dbo.Links L ON L.MovieID = R.MovieID
	INNER JOIN dbo.Movies M ON M.MovieID = R.MovieID
WHERE R.Rating BETWEEN @MinRating AND @MaxRating;
GO

 /**************************************************
 * Specific Search Procedure using Title, Tag, Genre
 ***************************************************/

 --Only works with all variables filled, incorrect joins, too tired to fix now

DROP PROCEDURE IF EXISTS dbo.SpecificSearch 
GO

CREATE PROCEDURE dbo.SpecificSearch

   @Title NVARCHAR(50),
   @Tag NVARCHAR(25),
   @Genre NVARCHAR(200)

AS
BEGIN

    IF (@Title IS NOT NULL AND @Tag IS NULL AND @Genre IS NULL)
        -- Search by title only
        SELECT *
        FROM dbo.Movies M
			INNER JOIN dbo.Tags T ON T.MovieID = M.MovieID
			INNER JOIN dbo.Links L ON L.MovieID = M.MovieID
			INNER JOIN dbo.Ratings R ON R.MovieID = M.MovieID
        WHERE
            M.Tile = @Title

    ELSE IF (@Title IS NULL AND @Tag IS NOT NULL AND @Genre IS NULL)
        -- Search by tag only
        SELECT *
        FROM dbo.Movies M
			INNER JOIN dbo.Tags T ON T.MovieID = M.MovieID
			INNER JOIN dbo.Links L ON L.MovieID = M.MovieID
			INNER JOIN dbo.Ratings R ON R.MovieID = M.MovieID
        WHERE
            Tag = @Tag

    ELSE IF (@Title IS NULL AND @Tag IS NULL AND @Genre IS NOT NULL)
        -- Search by genre only
        SELECT *
        FROM dbo.Movies M
			INNER JOIN dbo.Tags T ON T.MovieID = M.MovieID
			INNER JOIN dbo.Links L ON L.MovieID = M.MovieID
			INNER JOIN dbo.Ratings R ON R.MovieID = M.MovieID
        WHERE
            Genres = @Genre

    ELSE IF (@Title IS NOT NULL AND @Tag IS NOT NULL AND @Genre IS NULL)
        -- Search by title and tag
        SELECT *
        FROM dbo.Movies M
			INNER JOIN dbo.Tags T ON T.MovieID = M.MovieID
			INNER JOIN dbo.Links L ON L.MovieID = M.MovieID
			INNER JOIN dbo.Ratings R ON R.MovieID = M.MovieID
        WHERE
            Tile = @Title
            AND Tag = @Tag

    ELSE
        -- Search by any other combination
        SELECT *
        FROM dbo.Movies M
			INNER JOIN dbo.Tags T ON T.MovieID = M.MovieID
			INNER JOIN dbo.Links L ON L.MovieID = M.MovieID
			INNER JOIN dbo.Ratings R ON R.MovieID = M.MovieID
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

DROP PROCEDURE IF EXISTS dbo.GeneralSearch 
GO

CREATE PROCEDURE dbo.GeneralSearch 
 
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
GO

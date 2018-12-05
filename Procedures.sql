/**************************************
 * Procedure for inserting a new movie
 **************************************/

CREATE PROCEDURE dbo.InsertMovie
   @MovieID INT,
   @Title NVARCHAR(50),
   @Genre NVARCHAR(200),
   @IMDBID INT,
   @TMDBID INT,
   @UserID INT,
   @Rating INT,
   @TimeStamp DATETIMEOFFSET,
   @Tag NVARCHAR(25),
   @UpdatedOn DATETIMEOFFSET OUTPUT
AS

INSERT dbo.Movies(MovieID, Title, Genre, UpdatedOn)
VALUES(@MovieID, @Title, @Genre, @UpdatedOn);

SET @UpdatedOn =
   (
      SELECT M.UpdatedOn
      FROM dbo.Movies M
      WHERE M.MovieID = @MovieID
   );

INSERT dbo.Links(MovieID, IMDBID, TMDBID)
VALUES(@MovieID, @IMDBID, @TMDBID);

INSERT dbo.Ratings(MovieID, UserID, Rating, TimeStamp)
VALUES(@MovieID, @UserID, @Rating, @TimeStamp);

INSERT dbo.Tags(MovieID, UserID, TimeStamp, Tag)
VALUES(@MovieID, @UserID, @TimeStamp, @Tag);
GO

/**************************************
 * Procedure for updating a movie entry
 **************************************/

CREATE PROCEDURE dbo.UpdateMovie
   @MovieID INT,
   @Title NVARCHAR(50),
   @Genre NVARCHAR(200),
   @IMDBID INT,
   @TMDBID INT,
   @UserID INT,
   @Rating INT,
   @TimeStamp DATETIMEOFFSET,
   @Tag NVARCHAR(25),
   @UpdatedOn DATETIMEOFFSET OUTPUT
AS

UPDATE dbo.Movies
SET
	MovieID = CASE WHEN @MovieID IS NOT NULL THEN @MovieID ELSE MovieID END,
	Title = CASE WHEN @Title IS NOT NULL THEN @Title ELSE Title END,
	Genre = CASE WHEN @Genre IS NOT NULL THEN @Genre ELSE Genre END,
	UpdatedOn = SYSDATETIMEOFFSET();

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

CREATE PROCEDURE dbo.TagSearch
   @Tag NVARCHAR(25)
AS

SELECT *
FROM dbo.Tags T
WHERE T.Tag = @Tag;
GO

 /**************************************************
 * Specific Search Procedure using Title, Tag, Genre
 ***************************************************/

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
            M.Title = @Title

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
            Genre = @Genre

    ELSE IF (@Title IS NOT NULL AND @Tag IS NOT NULL AND @Genre IS NULL)
        -- Search by title and tag
        SELECT *
        FROM dbo.Movies M
			INNER JOIN dbo.Tags T ON T.MovieID = M.MovieID
			INNER JOIN dbo.Links L ON L.MovieID = M.MovieID
			INNER JOIN dbo.Ratings R ON R.MovieID = M.MovieID
        WHERE
            Title = @Title
            AND Tag = @Tag

    ELSE
        -- Search by any other combination
        SELECT *
        FROM dbo.Movies M
			INNER JOIN dbo.Tags T ON T.MovieID = M.MovieID
			INNER JOIN dbo.Links L ON L.MovieID = M.MovieID
			INNER JOIN dbo.Ratings R ON R.MovieID = M.MovieID
        WHERE
                (@Title IS NULL OR (Title = @Title))
            AND (@Tag IS NULL OR (Tag  = @Tag))
            AND (@Genre IS NULL OR (Genre = @Genre))
END
GO

/*******************************************
 * General Search Procedure using any string
 * https://www.mssqltips.com/sqlservertip/1522/searching-and-finding-a-string-value-in-all-columns-in-a-sql-server-table/
 *******************************************/

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

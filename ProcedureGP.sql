/**************************************
 * Procedure for inserting a new movie
 **************************************/

CREATE PROCEDURE GP.InsertMovie
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

INSERT GP.Movies(MovieID, Title, Genre, UpdatedOn)
VALUES(@MovieID, @Title, @Genre, @UpdatedOn);

SET @UpdatedOn =
   (
      SELECT M.UpdatedOn
      FROM GP.Movies M
      WHERE M.MovieID = @MovieID
   );

INSERT GP.Links(MovieID, IMDBID, TMDBID)
VALUES(@MovieID, @IMDBID, @TMDBID);

INSERT GP.Ratings(MovieID, UserID, Rating, TimeStamp)
VALUES(@MovieID, @UserID, @Rating, @TimeStamp);

INSERT GP.Tags(MovieID, UserID, TimeStamp, Tag)
VALUES(@MovieID, @UserID, @TimeStamp, @Tag);
GO

/**************************************
 * Procedure for updating a movie entry
 **************************************/

CREATE PROCEDURE GP.UpdateMovie
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

UPDATE GP.Movies
SET
	MovieID = CASE WHEN @MovieID IS NOT NULL THEN @MovieID ELSE MovieID END,
	Title = CASE WHEN @Title IS NOT NULL THEN @Title ELSE Title END,
	Genre = CASE WHEN @Genre IS NOT NULL THEN @Genre ELSE Genre END,
	UpdatedOn = SYSDATETIMEOFFSET();

UPDATE GP.Links
SET
	MovieID = CASE WHEN @MovieID IS NOT NULL THEN @MovieID ELSE MovieID END,
	IMDBID = CASE WHEN @IMDBID IS NOT NULL THEN @IMDBID ELSE IMDBID END,
	TMDBID = CASE WHEN @TMDBID IS NOT NULL THEN @TMDBID ELSE TMDBID END;
	
UPDATE GP.Ratings
SET
	MovieID = CASE WHEN @MovieID IS NOT NULL THEN @MovieID ELSE MovieID END,
	UserID = CASE WHEN @UserID IS NOT NULL THEN @UserID ELSE UserID END,
	Rating = CASE WHEN @Rating IS NOT NULL THEN @Rating ELSE Rating END,
	TimeStamp = CASE WHEN @TimeStamp IS NOT NULL THEN @TimeStamp ELSE TimeStamp END;

UPDATE GP.Tags
SET
	MovieID = CASE WHEN @MovieID IS NOT NULL THEN @MovieID ELSE MovieID END,
	UserID = CASE WHEN @UserID IS NOT NULL THEN @UserID ELSE UserID END,
	Tag = CASE WHEN @Tag IS NOT NULL THEN @Tag ELSE Tag END,
	TimeStamp = CASE WHEN @TimeStamp IS NOT NULL THEN @TimeStamp ELSE TimeStamp END;
GO

/**************************************
 * Procedure for deleting a movie entry
 **************************************/

CREATE PROCEDURE GP.DeleteMovie
   @MovieID INT
AS

DELETE FROM GP.Movies
WHERE MovieID = @MovieID;

DELETE FROM GP.Links
WHERE MovieID = @MovieID;

DELETE FROM GP.Ratings
WHERE MovieID = @MovieID;

DELETE FROM GP.Tags
WHERE MovieID = @MovieID;
GO

/**************************************
 * Tag Only Search Procedure
 **************************************/

CREATE PROCEDURE GP.TagSearch
   @Tag NVARCHAR(25)
AS

SELECT *
FROM GP.Tags T
WHERE T.Tag = @Tag;
GO

 /**************************************************
 * Specific Search Procedure using Title, Tag, Genre
 ***************************************************/

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
            M.Title = @Title

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
            Genre = @Genre

    ELSE IF (@Title IS NOT NULL AND @Tag IS NOT NULL AND @Genre IS NULL)
        -- Search by title and tag
        SELECT *
        FROM GP.Movies M
			INNER JOIN GP.Tags T ON T.MovieID = M.MovieID
			INNER JOIN GP.Links L ON L.MovieID = M.MovieID
			INNER JOIN GP.Ratings R ON R.MovieID = M.MovieID
        WHERE
            Title = @Title
            AND Tag = @Tag

    ELSE
        -- Search by any other combination
        SELECT *
        FROM GP.Movies M
			INNER JOIN GP.Tags T ON T.MovieID = M.MovieID
			INNER JOIN GP.Links L ON L.MovieID = M.MovieID
			INNER JOIN GP.Ratings R ON R.MovieID = M.MovieID
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

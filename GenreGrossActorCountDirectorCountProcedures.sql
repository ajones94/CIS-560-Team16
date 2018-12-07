--DROP PROCEDURE IF EXISTS GP.GenreGross
--DROP PROCEDURE IF EXISTS GP.ActorCount
--DROP PROCEDURE IF EXISTS GP.DirectorCount


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
CREATE PROCEDURE GP.GenreGross
	@GenreName NVARCHAR(50)
AS
BEGIN
	SELECT FORMAT(SUM(F.Gross), '##,##0') AS GenreGross
	FROM GP.Financial F
		INNER JOIN GP.Genre G ON G.MovieID = F.MovieID
	WHERE G.Genre = @GenreName
END



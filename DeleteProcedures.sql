CREATE PROCEDURE GP.DeleteMovie
	@MovieTitle NVARCHAR(50),
	@MovieID INT
AS
BEGIN
	DELETE FROM GP.Movies WHERE Title = @MovieTile OR MovieID = @MovieID
END

go
CREATE PROCEDURE GP.DeleteActor
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@ActorID INT
AS
BEGIN
	DELETE FROM GP.Actor WHERE ActorID = @ActorID OR FirstName = @FirstName OR LastName = @LastName
END


GO
CREATE PROCEDURE GP.DeleteDirector
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@DirectorID INT
AS
BEGIN
	DELETE FROM Gp.Director WHERE FirstName = @FirstName OR LastName = @LastName OR DirectorID = @DirectorID
END


GO
CREATE PROCEDURE GP.DeleteRating
	@RatingID INT,
	@IMDBRating INT,
	@MovieID INT
AS
BEGIN
	DELETE FROM GP.Rating WHERE RatingID = @RatingID OR IMDBRating = @IMDBRating OR MovieID = @MovieID
END

GO
CREATE PROCEDURE GP.DeleteGenre
	@GenreID INT,
	@Genre NVARCHAR(15)
AS
BEGIN
	DELETE FROM GP.Genre WHERE GenreID = @GenreID OR Genre = @Genre
END

GO
CREATE PROCEDURE GP.DeleteFinances
	@FinancialID INT,
	@Budget INT,
	@Gross INT
AS
BEGIN
	DELETE FROM Gp.Financial WHERE FinancialID = @FinancialID OR Budget = @Budget OR Gross = @Gross
END

GO
CREATE PROCEDURE GP.DeleteAditionalInfo
	@InfoID INT
AS
BEGIN
	DELETE FROM Gp.AditionalInfo WHERE InfoID = @InfoID
END
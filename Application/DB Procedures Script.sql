--Group project procedures rough file
--Group 19

--Create User procedure
CREATE OR ALTER PROCEDURE Proj.AddUser
	--Input parameters
	@FirstName NVARCHAR(128),
	@LastName NVARCHAR(128),
	@Email NVARCHAR(128),
	@HashedPassword NVARCHAR(64),
	@PermissionLevel NVARCHAR(32),

	--Output parameters
	@UserID INT OUTPUT
AS
	INSERT Proj."User"(UserCategoryID,FirstName,LastName,Email,HashedPassword)
	SELECT UC.UserCategoryID,@FirstName, @LastName, @Email, @HashedPassword
	FROM Proj.UserCategory UC
	WHERE UC.PermissionLevel=@PermissionLevel;
			
	SET @UserID = SCOPE_IDENTITY();
GO

--Create Genre procedure
CREATE OR ALTER PROCEDURE Book.AddGenre
	--Input parameters
	@Descriptor NVARCHAR(64),

	--Output parameters
	@GenreID INT OUTPUT
AS
	INSERT Book.Genre(Descriptor)
	VALUES(@Descriptor);

	SET @GenreID=SCOPE_IDENTITY();
GO

--Create Publisher procedure
CREATE OR ALTER PROCEDURE Book.AddPublisher
	--Input parameters
	@PublisherName NVARCHAR(128),

	--Output parameters
	@PublisherID INT OUTPUT
AS
	INSERT Book.Publisher("Name")
	VALUES(@PublisherName);

	SET @PublisherID=SCOPE_IDENTITY();
GO

CREATE OR ALTER PROCEDURE Book.AddBookGenre
	--Input parameters
	@GenreID INT,
	@BookInfoID INT
AS
	INSERT Book.BookGenre(GenreID,BookInfoID)
	VALUES(@GenreID,@BookInfoID);
GO

CREATE OR ALTER PROCEDURE Book.CheckOutBook
	--Input parameters
	@BookID INT,
	@Email NVARCHAR(128),

	--Output parameters
	@CheckOutID INT OUTPUT,
	@DueDate DATETIMEOFFSET OUTPUT
AS
	DECLARE @CheckValid BIT = 
	(
		SELECT B.Removed
		FROM Book.Book B
		WHERE B.BookID=@BookID
	);

	IF @CheckValid IS NULL OR @CheckValid=1
	BEGIN
		DECLARE @Message NVARCHAR(256) = N'Invalid BookID!';
		THROW 50000, @Message, 1;
	END;

	DECLARE @Check INT = 
	(
		SELECT CO.CheckOutID
		FROM Book.CheckOut CO
		WHERE CO.BookID=@BookID AND CO.ReturnDate IS NULL
	);

	IF @Check IS NOT NULL
	BEGIN
		SET @Message = N'Book already checked out!';
		THROW 50000, @Message, 1;
	END;

	DECLARE @UserID INT;
	EXEC Proj.GetIDFromEmail @Email, @UserID OUTPUT;

	SET @DueDate = DATEADD(WEEK,2,SYSDATETIMEOFFSET());

	INSERT Book.CheckOut(BookID,UserID,CheckOutDate,DueDate)
	VALUES(@BookID, @UserID, SYSDATETIMEOFFSET(),@DueDate);

	SET @CheckOutID = SCOPE_IDENTITY();
GO

CREATE OR ALTER PROCEDURE Book.RenewBook
	--Input parameters
	@BookID INT,
	@Email NVARCHAR(128),

	--Output parameters
	@CheckOutID INT OUTPUT,
	@NewDueDate DATETIMEOFFSET OUTPUT
AS

	DECLARE @UserID INT;
	EXEC Proj.GetIDFromEmail @Email, @UserID OUTPUT;

	SET @NewDueDate = DATEADD(WEEK,1,SYSDATETIMEOFFSET());

	SET @CheckOutID = 
	(	SELECT CO.CheckOutID
		FROM Book.CheckOut CO
		WHERE BookID=@BookID AND UserID=@UserID AND ReturnDate IS NULL
	);

	IF @CheckOutID IS NULL
	BEGIN
		DECLARE @Message NVARCHAR(256) = N'Book not checked out!';
		THROW 50000, @Message, 1;
	END;

	UPDATE Book.CheckOut
		SET DueDate=@NewDueDate
	WHERE CheckOutID=@CheckOutID;

GO

CREATE OR ALTER PROCEDURE Book.CheckInBook
	--Input parameters
	@BookID INT,

	--Output parameters
	@CheckOutID INT OUTPUT
AS
	SET @CheckOutID = 
	(	SELECT CO.CheckOutID
		FROM Book.CheckOut CO
		WHERE BookID=@BookID AND /*UserID=@UserID AND*/ ReturnDate IS NULL
	);

	IF @CheckOutID IS NULL
	BEGIN
		DECLARE @Message NVARCHAR(256) = N'Book not checked out!';
		THROW 50000, @Message, 1;
	END;

	UPDATE Book.CheckOut
		SET ReturnDate=SYSDATETIMEOFFSET()
	WHERE CheckOutID=@CheckOutID;
GO

CREATE OR ALTER PROCEDURE Book.AddAuthor
	--Input parameters
	@FirstName NVARCHAR(128),
	@LastName NVARCHAR(128),

	--Output parameters
	@AuthorID INT OUTPUT
AS
	INSERT Book.Author(FirstName,LastName)
	VALUES(@FirstName,@LastName);
	
	SET @AuthorID = SCOPE_IDENTITY();
GO

CREATE OR ALTER PROCEDURE Proj.LoginUser
	--input parameters
	@Email NVARCHAR(128),
	@HashedPassword NVARCHAR(64),

	--output parameters
	@FirstNAME NVARCHAR(128) OUTPUT,
	@PermissionLevel NVARCHAR(32) OUTPUT
AS
	DECLARE @UserID INT;

	SET @UserID = 
	COALESCE((
		SELECT U.UserID
		FROM Proj."User" U
		WHERE U.Email=@Email AND U.HashedPassword=@HashedPassword
	),-1);

	IF @UserID = -1
	BEGIN
		DECLARE @Message NVARCHAR(256) = N'Invalid login attempt!';
		THROW 50000, @Message, 1;
	END;

	SET @FirstNAME = 
	(
		SELECT U.FirstName
		FROM Proj."User" U
		WHERE U.UserID=@UserID
	);

	SET @PermissionLevel = 
	(
		SELECT UC.PermissionLevel
		FROM Proj."User" U
			INNER JOIN Proj.UserCategory UC ON UC.UserCategoryID=U.UserCategoryID
		WHERE U.UserID=@UserID
	);
GO

CREATE OR ALTER PROCEDURE Book.AddBookWithInfoID
	--input parameters
	@BookInfoID INT,
	@QualityDescription NVARCHAR(32),

	--output parameter
	@BookID INT OUTPUT
AS
	DECLARE @QualityID INT;

	SET @QualityID = 
	(
		SELECT BQ.QualityID
		FROM Book.BookQuality BQ
		WHERE BQ."Description"=@QualityDescription
	);

	INSERT Book.Book(BookInfoID,QualityID)
	VALUES(@BookInfoID,@QualityID);
	
	SET @BookID = SCOPE_IDENTITY();
GO

CREATE OR ALTER PROCEDURE Book.AddBookInfo
	--input params
	@Title NVARCHAR(128),
	@AuthorFirstName NVARCHAR(128),
	@AuthorLastName NVARCHAR(128),
	@PublisherName NVARCHAR(128),
	@GenreDescriptor NVARCHAR(64),
	@ISBN NVARCHAR(32),
	@CopyrightYear SMALLINT,
	
	--output params
	@BookInfoID INT OUTPUT
AS
	DECLARE @PublisherID INT,
			@AuthorID INT,
			@GenreID INT;

	SET @PublisherID =
	(
		SELECT P.PublisherID
		FROM Book.Publisher P
		WHERE P."Name"=@PublisherName
	);

	IF @PublisherID IS NULL
	BEGIN
		EXEC Book.AddPublisher @PublisherName, @PublisherID OUTPUT;
	END;

	SET @AuthorID = 
	(
		SELECT A.AuthorID
		FROM Book.Author A
		WHERE A.FirstName=@AuthorFirstName AND A.LastName=@AuthorLastName
	);

	IF @AuthorID IS NULL
	BEGIN
		EXEC Book.AddAuthor @AuthorFirstName, @AuthorLastName, @AuthorID OUTPUT;
	END;

	INSERT Book.BookInfo(Title,AuthorID,PublisherID,ISBN,CopyrightYear)
	VALUES (@Title,@AuthorID,@PublisherID,@ISBN, @CopyrightYear);

	SET @BookInfoID=SCOPE_IDENTITY();

	SET @GenreID = 
	(
		SELECT G.GenreID
		FROM Book.Genre G
		WHERE G.Descriptor=@GenreDescriptor
	);

	IF @GenreID IS NULL
	BEGIN
		EXEC Book.AddGenre @GenreDescriptor, @GenreID OUTPUT;
	END;

	EXEC Book.AddBookGenre @GenreID, @BookInfoID;
GO

CREATE OR ALTER PROCEDURE Book.AddBookWithoutInfoID
	--input params
	@Title NVARCHAR(128),
	@AuthorFirstName NVARCHAR(128),
	@AuthorLastName NVARCHAR(128),
	@PublisherName NVARCHAR(128),
	@GenreDescriptor NVARCHAR(64),
	@ISBN NVARCHAR(32),
	@CopyrightYear SMALLINT,
	
	--output params
	@BookID INT OUTPUT
AS
	DECLARE @BookInfoID INT;

	SET @BookInfoID = 
	(
		SELECT BI.BookInfoID
		FROM Book.BookInfo BI
		WHERE BI.ISBN=@ISBN
	);

	IF @BookInfoID IS NULL
	BEGIN
		EXEC Book.AddBookInfo @Title,@AuthorFirstName,@AuthorLastName,@PublisherName,@GenreDescriptor,@ISBN,@CopyrightYear, @BookInfoID OUTPUT;
	END;

	EXEC Book.AddBookWithInfoID @BookInfoID, N'New', @BookID OUTPUT;
GO

CREATE OR ALTER PROCEDURE Book.SearchWithAll
	@Title NVARCHAR(128),
	@FirstName NVARCHAR(128),
	@LastName NVARCHAR(128),
	@ISBN NVARCHAR(32),
	@GenreDescriptor  NVARCHAR(64)
AS
	SELECT B.BookID, BI.Title, A.FirstName AS AuthorFirstName, A.LastName AS AuthorLastName, BI.ISBN, BI.Copyrightyear, P."Name" AS PublisherName, G.Descriptor AS Genre, 
			COALESCE((
						SELECT CO.BookID
						FROM Book.CheckOut CO
						WHERE CO.BookID=B.BookID AND ReturnDate IS NULL
					),0) AS CheckedOut--returns non-zero value if book checked out, 
		FROM Book.Book B
			INNER JOIN Book.BookInfo BI ON B.BookInfoID=BI.BookInfoID
			INNER JOIN Book.Author A ON A.AuthorID=BI.AuthorID
			INNER JOIN Book.Publisher P ON P.PublisherID=BI.PublisherID
			INNER JOIN Book.BookGenre BG ON BG.BookInfoID=BI.BookInfoID
			INNER JOIN Book.Genre G ON G.GenreID=BG.GenreID
		WHERE (BI.Title=@Title OR BI.Title LIKE @Title) AND (A.LastName LIKE @LastName OR A.LastName=@LastName) AND(BI.ISBN LIKE @ISBN OR BI.ISBN=@ISBN) AND (G.Descriptor=@GenreDescriptor OR G.Descriptor LIKE @GenreDescriptor) AND (B.Removed = 0)
		ORDER BY BI.Title;
GO

CREATE OR ALTER PROCEDURE Book.SearchForTitle
	@Title NVARCHAR(128)
AS
	SELECT B.BookID, BI.Title, A.FirstName AS AuthorFirstName, A.LastName AS AuthorLastName, P."Name" AS PublisherName, G.Descriptor AS Genre, BI.ISBN, BI.Copyrightyear,
			COALESCE((
						SELECT CO.BookID
						FROM Book.CheckOut CO
						WHERE CO.BookID=B.BookID AND ReturnDate IS NULL
					),0) AS CheckedOut--returns non-zero value if book checked out, 
		FROM Book.Book B
			INNER JOIN Book.BookInfo BI ON B.BookInfoID=BI.BookInfoID
			INNER JOIN Book.Author A ON A.AuthorID=BI.AuthorID
			INNER JOIN Book.Publisher P ON P.PublisherID=BI.PublisherID
			INNER JOIN Book.BookGenre BG ON BG.BookInfoID=BI.BookInfoID
			INNER JOIN Book.Genre G ON G.GenreID=BG.GenreID
		WHERE (BI.Title=@Title OR BI.Title LIKE @Title) AND (B.Removed = 0)
		ORDER BY BI.Title;
GO


CREATE OR ALTER PROCEDURE Book.SearchForAuthor
	@FirstName NVARCHAR(128),
	@LastName NVARCHAR(128)
AS
	SELECT B.BookID, BI.Title, A.FirstName AS AuthorFirstName, A.LastName AS AuthorLastName, P."Name" AS PublisherName, G.Descriptor AS Genre, BI.ISBN, BI.Copyrightyear,
			COALESCE((
						SELECT CO.BookID
						FROM Book.CheckOut CO
						WHERE CO.BookID=B.BookID AND ReturnDate IS NULL
					),0) AS CheckedOut--returns non-zero value if book checked out, 
		FROM Book.Book B
			INNER JOIN Book.BookInfo BI ON B.BookInfoID=BI.BookInfoID
			INNER JOIN Book.Author A ON A.AuthorID=BI.AuthorID
			INNER JOIN Book.Publisher P ON P.PublisherID=BI.PublisherID
			INNER JOIN Book.BookGenre BG ON BG.BookInfoID=BI.BookInfoID
			INNER JOIN Book.Genre G ON G.GenreID=BG.GenreID
		WHERE (A.LastName LIKE @LastName OR A.LastName=@LastName) AND (B.Removed = 0)
		ORDER BY BI.Title;
GO

CREATE OR ALTER PROCEDURE Book.SearchForISBN
	@ISBN NVARCHAR(32)
AS
	SELECT B.BookID, BI.Title, A.FirstName AS AuthorFirstName, A.LastName AS AuthorLastName, P."Name" AS PublisherName, G.Descriptor AS Genre, BI.ISBN, BI.Copyrightyear,
			COALESCE((
						SELECT CO.BookID
						FROM Book.CheckOut CO
						WHERE CO.BookID=B.BookID AND ReturnDate IS NULL
					),0) AS CheckedOut--returns non-zero value if book checked out, 
		FROM Book.Book B
			INNER JOIN Book.BookInfo BI ON B.BookInfoID=BI.BookInfoID
			INNER JOIN Book.Author A ON A.AuthorID=BI.AuthorID
			INNER JOIN Book.Publisher P ON P.PublisherID=BI.PublisherID
			INNER JOIN Book.BookGenre BG ON BG.BookInfoID=BI.BookInfoID
			INNER JOIN Book.Genre G ON G.GenreID=BG.GenreID
		WHERE (BI.ISBN LIKE @ISBN OR BI.ISBN=@ISBN) AND (B.Removed = 0)
		ORDER BY BI.Title;
GO

CREATE OR ALTER PROCEDURE Book.SearchByGenre
	@GenreDescriptor  NVARCHAR(64)
AS
	SELECT B.BookID, BI.Title, A.FirstName AS AuthorFirstName, A.LastName AS AuthorLastName, P."Name" AS PublisherName, G.Descriptor AS Genre, BI.ISBN, BI.Copyrightyear,
			COALESCE((
						SELECT CO.BookID
						FROM Book.CheckOut CO
						WHERE CO.BookID=B.BookID AND ReturnDate IS NULL
					),0) AS CheckedOut --returns non-zero value if book checked out, 
		FROM Book.Book B
			INNER JOIN Book.BookInfo BI ON B.BookInfoID=BI.BookInfoID
			INNER JOIN Book.Author A ON A.AuthorID=BI.AuthorID
			INNER JOIN Book.Publisher P ON P.PublisherID=BI.PublisherID
			INNER JOIN Book.BookGenre BG ON BG.BookInfoID=BI.BookInfoID
			INNER JOIN Book.Genre G ON G.GenreID=BG.GenreID
		WHERE (G.Descriptor=@GenreDescriptor OR G.Descriptor LIKE @GenreDescriptor) AND (B.Removed = 0)
		ORDER BY BI.Title;
GO

CREATE OR ALTER PROCEDURE Book.RemoveBookWithID
	--input params
	@BookID INT
AS
	DECLARE @Check INT;

	SET @Check=(
			SELECT B.BookID
			FROM Book.Book B
			WHERE B.BookID=@BookID		
		);
	IF @Check IS NULL
	BEGIN
		DECLARE @Message NVARCHAR(256) = N'BookID not in Database!';
		THROW 50000, @Message, 1;
	END;

	UPDATE Book.Book
	SET Removed=1
	WHERE BookID=@BookID;
GO

CREATE OR ALTER PROCEDURE Book.UpdateBookQuality
	--Input parameters
	@BookID INT,
	@NewDescriptor NVARCHAR(32)

AS
	DECLARE @Check INT;

	SET @Check=(
			SELECT B.BookID
			FROM Book.Book B
			WHERE B.BookID=@BookID		
		);

	IF @Check IS NULL
	BEGIN
		DECLARE @Message NVARCHAR(256) = N'Invalid BookID!';
		THROW 50000, @Message, 1;
	END;
	
	DECLARE @QualityID INT;

	SET @QualityID = (
			SELECT BQ.QualityID
			FROM Book.BookQuality BQ
			WHERE BQ."Description"=@NewDescriptor
		);
	IF @QualityID IS NULL
	BEGIN
		SET @Message = N'Invalid Quality Description!';
		THROW 50000, @Message, 1;
	END;

	UPDATE Book.Book
		SET QualityID=@QualityID
	WHERE BookID=@BookID;
GO

CREATE OR ALTER PROCEDURE Book.GetBookInfoIDForBook
	@BookID INT,

	@BookInfoID INT OUTPUT
AS
	SET @BookInfoID = 
	(
		SELECT B.BookInfoID
		FROM Book.Book B
		WHERE B.BookID=@BookID
	);

	IF @BookInfoID IS NULL
	BEGIN
		DECLARE @Message NVARCHAR(256) = N'Invalid BookID!';
		THROW 50000, @Message, 1;
	END;
GO

CREATE OR ALTER PROCEDURE Book.GetAllBookInfoForBook
	@BookID INT
AS
	DECLARE @BookInfoID INT = 
	(
		SELECT B.BookInfoID
		FROM Book.Book B
		WHERE B.BookID=@BookID
	);

	IF @BookInfoID IS NULL
	BEGIN
		DECLARE @Message NVARCHAR(256) = N'Invalid BookID!';
		THROW 50000, @Message, 1;
	END;

	SELECT BI.BookInfoID, BI.Title, A.FirstName AS AuthorFirstName, A.LastName AS AuthorLastName, BI.ISBN, BI.CopyrightYear, P."Name" AS PublisherName,  G.Descriptor AS Genre
	FROM Book.BookInfo BI
			INNER JOIN Book.Author A ON A.AuthorID=BI.AuthorID
			INNER JOIN Book.Publisher P ON P.PublisherID=BI.PublisherID
			INNER JOIN Book.BookGenre BG ON BG.BookInfoID=BI.BookInfoID
			INNER JOIN Book.Genre G ON G.GenreID=BG.GenreID
	WHERE BI.BookInfoID=@BookInfoID
GO

CREATE OR ALTER PROCEDURE Proj.ChangePassword
	@Email NVARCHAR(128),
	@NewHashedPassword NVARCHAR(64)
AS
	DECLARE @UserID INT;
	EXEC Proj.GetIDFromEmail @Email, @UserID OUTPUT;

	UPDATE Proj."User"
	SET HashedPassword=@NewHashedPassword
	WHERE UserID=@UserID
GO

CREATE OR ALTER PROCEDURE Book.GetUserCheckedOutBooks
	@Email NVARCHAR(128)
AS
	DECLARE @UserID INT;
	EXEC Proj.GetIDFromEmail @Email, @UserID OUTPUT;
	
	SELECT CO.BookID,BI.Title, A.FirstName AS AuthorFirstName, A.LastName AS AuthorLastName, BI.ISBN, BI.CopyrightYear, CO.CheckOutDate,CO.DueDate
	FROM Book.CheckOut CO
		INNER JOIN Book.Book B ON CO.BookID=B.BookID
		INNER JOIN Book.BookInfo BI ON B.BookInfoID=BI.BookInfoID
		INNER JOIN Book.Author A ON A.AuthorID=BI.AuthorID
	WHERE CO.UserID=@UserID AND CO.ReturnDate IS NULL
	ORDER BY CO.CheckOutDate ASC
GO

CREATE OR ALTER PROCEDURE Book.GetUserCheckedOutHistory
	@Email NVARCHAR(128)
AS
	DECLARE @UserID INT;
	EXEC Proj.GetIDFromEmail @Email, @UserID OUTPUT;
	
	SELECT CO.BookID,BI.Title, A.FirstName AS AuthorFirstName, A.LastName AS AuthorLastName, BI.ISBN, BI.CopyrightYear, CO.CheckOutDate,CO.DueDate, CO.ReturnDate AS DateReturned
	FROM Book.CheckOut CO
		INNER JOIN Book.Book B ON CO.BookID=B.BookID
		INNER JOIN Book.BookInfo BI ON B.BookInfoID=BI.BookInfoID
		INNER JOIN Book.Author A ON A.AuthorID=BI.AuthorID
	WHERE CO.UserID=@UserID
	ORDER BY CO.CheckOutDate ASC
GO

CREATE OR ALTER PROCEDURE Book.GetUserOverdueBooks
	@Email NVARCHAR(128)
AS
	DECLARE @UserID INT;
	EXEC Proj.GetIDFromEmail @Email, @UserID OUTPUT;
	
	SELECT CO.BookID,BI.Title, A.FirstName AS AuthorFirstName, A.LastName AS AuthorLastName, BI.ISBN, BI.CopyrightYear, CO.CheckOutDate,CO.DueDate
	FROM Book.CheckOut CO
		INNER JOIN Book.Book B ON CO.BookID=B.BookID
		INNER JOIN Book.BookInfo BI ON B.BookInfoID=BI.BookInfoID
		INNER JOIN Book.Author A ON A.AuthorID=BI.AuthorID
	WHERE CO.UserID=@UserID AND CO.ReturnDate IS NULL AND CO.DueDate<SYSDATETIMEOFFSET()
	ORDER BY CO.CheckOutDate ASC
GO

CREATE OR ALTER PROCEDURE Proj.GetIDFromEmail
	@Email NVARCHAR(128),
	@UserID INT OUTPUT
AS
	SET @UserID = 
	(
		SELECT U.UserID
		FROM Proj."User" U
		WHERE U.Email=@Email
	);

	IF @UserID IS NULL
	BEGIN
		DECLARE @Message NVARCHAR(256)= N'Invalid Email!';
		THROW 50000, @Message, 1;
	END;
GO

--TO DO:
--Add query for get bookinfo using bookid
--places where userid is passed in should be replaced with email
--Change password request using just email and new password
--trigger for any changes?
--add procedure to return all books checked out to a certain user, given their email.
--add removed col for book, probably just a bit
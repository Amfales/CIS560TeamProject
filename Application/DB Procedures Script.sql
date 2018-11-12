--Group project procedures rough file
--Group 19

--Create User procedure
CREATE OR ALTER PROCEDURE Proj.AddUser
	--Input parameters
	@FirstName NVARCHAR(128),
	@LastName NVARCHAR(128),
	@Email NVARCHAR(128),
	@HashedPassword NVARCHAR(128),
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
	INSERT Book.Publisher(PublisherName)
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
	--Inpute parameters
	@BookID INT,
	@UserID INT,

	--Output parameters
	@CheckOutID INT OUTPUT,
	@DueDate DATETIMEOFFSET OUTPUT
AS
	DECLARE @Check INT;

	SET @Check = 
	(
		SELECT CO.CheckOutID
		FROM Book.CheckOut CO
		WHERE CO.BookID=@BookID AND CO.ReturnDate IS NULL
	);

	IF @Check IS NOT NULL
	BEGIN
		DECLARE @Message NVARCHAR(256) = N'Book already checked out!';
		THROW 50000, @Message, 1;
	END;

	SET @DueDate = DATEADD(WEEK,2,SYSDATETIMEOFFSET());

	INSERT Book.CheckOut(BookID,UserID,CheckOutDate,DueDate)
	VALUES(@BookID, @UserID, SYSDATETIMEOFFSET(),@DueDate);

	SET @CheckOutID = SCOPE_IDENTITY();
GO

CREATE OR ALTER PROCEDURE Book.RenewBook
	--Inpute parameters
	@BookID INT,
	@UserID INT,

	--Output parameters
	@CheckOutID INT OUTPUT,
	@NewDueDate DATETIMEOFFSET OUTPUT
AS
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
	--Inpute parameters
	@BookID INT,
	@UserID INT,

	--Output parameters
	@CheckOutID INT OUTPUT
AS
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
	@HashedPassword NVARCHAR(128),

	--output parameters
	@UserID INT OUTPUT,
	@FirstNAME NVARCHAR(128) OUTPUT,
	@PermissionLevel NVARCHAR(32) OUTPUT
AS
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
		WHERE P.PublisherName=@PublisherName
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

CREATE OR ALTER PROCEDURE Book.SearchForTitle
	@Title NVARCHAR(128)
AS
	SELECT B.BookID, BI.Title, A.FirstName, A.LastName, P.PublisherName, G.Descriptor, BI.ISBN, BI.Copyrightyear,
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
		WHERE BI.Title=@Title OR BI.Title LIKE @Title
		ORDER BY BI.Title;
GO


CREATE OR ALTER PROCEDURE Book.SearchForAuthor
	@FirstName NVARCHAR(128),
	@LastName NVARCHAR(128)
AS
	SELECT B.BookID, BI.Title, A.FirstName, A.LastName, P.PublisherName, G.Descriptor, BI.ISBN, BI.Copyrightyear,
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
		WHERE A.LastName LIKE @LastName OR A.LastName=@LastName
		ORDER BY BI.Title;
GO

CREATE OR ALTER PROCEDURE Book.SearchForISBN
	@ISBN NVARCHAR(32)
AS
	SELECT B.BookID, BI.Title, A.FirstName, A.LastName, P.PublisherName, G.Descriptor, BI.ISBN, BI.Copyrightyear,
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
		WHERE BI.ISBN LIKE @ISBN OR BI.ISBN=@ISBN 
		ORDER BY BI.Title;
GO

CREATE OR ALTER PROCEDURE Book.SearchByGenre
	@GenreDescriptor  NVARCHAR(64)
AS
	SELECT B.BookID, BI.Title, A.FirstName, A.LastName, P.PublisherName, G.Descriptor, BI.ISBN, BI.Copyrightyear,
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
		WHERE G.Descriptor=@GenreDescriptor OR G.Descriptor LIKE @GenreDescriptor
		ORDER BY BI.Title;
GO
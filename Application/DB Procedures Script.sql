--Group project procedures rough file
--Group 19

--Create User procedure
--This procedure is used to add new users as either patrons or admins.
--It accepts all the necessary information for making a new user, including which permission they should have.
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
--Adds a new genre descriptor.
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
--Adds a new publisher name.
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

--Creates a row to tie a BookInfo to a Genre
CREATE OR ALTER PROCEDURE Book.AddBookGenre
	--Input parameters
	@GenreID INT,
	@BookInfoID INT
AS
	INSERT Book.BookGenre(GenreID,BookInfoID)
	VALUES(@GenreID,@BookInfoID);
GO

--Adds a row in the CheckOut table corresponding to the book and user given.
--It will throw an error if the BookID or Email is invalid, or the book is already checked out.
CREATE OR ALTER PROCEDURE Book.CheckOutBook
	--Input parameters
	@BookID INT,
	@Email NVARCHAR(128),

	--Output parameters
	@CheckOutID INT OUTPUT,
	@DueDate DATETIME2 OUTPUT
AS
	--First need to check if book corresponding to that ID is a valid ID or has already been removed.
	DECLARE @CheckValid BIT = 
	(
		SELECT B.Removed
		FROM Book.Book B
		WHERE B.BookID=@BookID
	);

	--Validate value and throw error if wrong.
	IF @CheckValid IS NULL OR @CheckValid=1
	BEGIN
		DECLARE @Message NVARCHAR(256) = N'Invalid BookID!';
		THROW 50000, @Message, 1;
	END;

	--Check if book is already checked out.
	DECLARE @Check INT = 
	(
		SELECT CO.CheckOutID
		FROM Book.CheckOut CO
		WHERE CO.BookID=@BookID AND CO.ReturnDate IS NULL
	);

	--Throw error if book already checked out.
	IF @Check IS NOT NULL
	BEGIN
		SET @Message = N'Book already checked out!';
		THROW 50001, @Message, 1;
	END;

	--Get UserID corresponding to the email.
	DECLARE @UserID INT;
	EXEC Proj.GetIDFromEmail @Email, @UserID OUTPUT;

	SET @DueDate = DATEADD(WEEK,2,SYSDATETIME());

	INSERT Book.CheckOut(BookID,UserID,CheckOutDate,DueDate)
	VALUES(@BookID, @UserID, SYSDATETIME(),@DueDate);

	SET @CheckOutID = SCOPE_IDENTITY();
GO

--Updates the due date of a Checked Out book. 
--Throws errors if book not checked out or email is invalid.
CREATE OR ALTER PROCEDURE Book.RenewBook
	--Input parameters
	@BookID INT,
	@Email NVARCHAR(128),

	--Output parameters
	@CheckOutID INT OUTPUT,
	@NewDueDate DATETIME2 OUTPUT
AS
	--Get UserID corresponding to the Email.
	DECLARE @UserID INT;
	EXEC Proj.GetIDFromEmail @Email, @UserID OUTPUT;

	--Get CheckOutID
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

	DECLARE @OldDate DATETIME2 = (
		SELECT CO.DueDate
		FROM Book.CheckOut CO
		WHERE CO.CheckOutID = @CheckOutID
	);

	--Get date one week from original due date.
	SET @NewDueDate = DATEADD(WEEK,1,@OldDate);

	UPDATE Book.CheckOut
		SET DueDate=@NewDueDate
	WHERE CheckOutID=@CheckOutID;

GO

--Updates the returned date of a row in CheckOut, which marks the book as returned.
--Afterwards, the row is treated as in the past, and will only be returned when looking up a book or user's checkout history.
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
		SET ReturnDate=SYSDATETIME()
	WHERE CheckOutID=@CheckOutID;
GO

--Adds an author to the Author table.
--Returns the identifier that was created for it.
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

--"Login" Procedure, used to check if password matches given email.
--Throws an error with code 50000 if login information is not valid.
--If it is valid, returns the first name of the user and the text of their permission level.
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

--Adds a new Book to Book table with the given BookInfoID. Quality defaults to new.
--Returns the new BookID
CREATE OR ALTER PROCEDURE Book.AddBookWithInfoID
	--input parameters
	@BookInfoID INT,
	@QualityDescription NVARCHAR(32)=N'New',

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

--Adds a new BookInfo with all of the info passed in.
--Additionally, calls other procedures to add any values not previously in the various tables along the way.

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

--Adds a new Book without a given BookInfoID.
--It first tries to find if the BookInfo is already in the table.
-- if not, it adds the BookInfo by calling the procedure to do so.
-- if it is already in the table, it just calls the procedure to add with the BookInfoID.
--Returns new BookID
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

--Searches the table for all books that are found to exactly match or be like the given inputs.
--Filters upon all given values, but defaults to returning every book.
--Uses a form of pagination, dependent on what the caller gives it. Defaults to first page and 25 results per page.
CREATE OR ALTER PROCEDURE Book.SearchBookWithAll
	@Title NVARCHAR(128)=N'%',
	@FirstName NVARCHAR(128)=N'%',
	@LastName NVARCHAR(128)=N'%',
	@ISBN NVARCHAR(32)=N'%',
	@GenreDescriptor  NVARCHAR(64)=N'%',
	@SearchPage INT = 1,
	@RowsPerPage INT = 25
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
		ORDER BY BI.Title
		OFFSET ((@SearchPage-1)*@RowsPerPage) ROWS FETCH NEXT @RowsPerPage ROWS ONLY;
GO

--Searches the table for all BookInfos that are found to exactly match or be like the given inputs.
--Filters upon all given values, but defaults to returning every book.
--Uses a form of pagination, dependent on what the caller gives it. Defaults to first page and 25 results per page.
CREATE OR ALTER PROCEDURE Book.SearchBookInfoWithAll
	@Title NVARCHAR(128)=N'%',
	@FirstName NVARCHAR(128)=N'%',
	@LastName NVARCHAR(128)=N'%',
	@ISBN NVARCHAR(32)=N'%',
	@GenreDescriptor  NVARCHAR(64)=N'%',
	@SearchPage INT = 1,
	@RowsPerPage INT = 25
AS
	SELECT BI.Title, A.FirstName AS AuthorFirstName, A.LastName AS AuthorLastName, BI.ISBN, BI.Copyrightyear, P."Name" AS PublisherName, G.Descriptor AS Genre
			
		FROM Book.Book B
			INNER JOIN Book.BookInfo BI ON B.BookInfoID=BI.BookInfoID
			INNER JOIN Book.Author A ON A.AuthorID=BI.AuthorID
			INNER JOIN Book.Publisher P ON P.PublisherID=BI.PublisherID
			INNER JOIN Book.BookGenre BG ON BG.BookInfoID=BI.BookInfoID
			INNER JOIN Book.Genre G ON G.GenreID=BG.GenreID
		WHERE (BI.Title=@Title OR BI.Title LIKE @Title) AND (A.LastName LIKE @LastName OR A.LastName=@LastName) AND(BI.ISBN LIKE @ISBN OR BI.ISBN=@ISBN) AND (G.Descriptor=@GenreDescriptor OR G.Descriptor LIKE @GenreDescriptor) AND (B.Removed = 0)
		GROUP BY BI.Title, A.FirstName, A.LastName, BI.ISBN, BI.CopyrightYear, P."Name", G.Descriptor
		ORDER BY BI.Title
		OFFSET ((@SearchPage-1)*@RowsPerPage) ROWS FETCH NEXT @RowsPerPage ROWS ONLY;
GO

--Gets all BookIDs that haven't been removed corresponding to the given BookInfoID
CREATE OR ALTER PROCEDURE Book.GetAllBookIDOfBookInfo
	@BookInfoID INT
AS
	SELECT B.BookID, 
				COALESCE((
					SELECT CO.BookID
					FROM Book.CheckOut CO
					WHERE CO.BookID=B.BookID AND ReturnDate IS NULL
				),0) AS CheckedOut--returns non-zero value if book checked out, 
	FROM Book.Book B
	WHERE B.BookInfoID=@BookInfoID AND B.Removed=0
	ORDER BY CheckedOut ASC
GO

--Search procedure for finding all books that match exactly or are like a given title.
CREATE OR ALTER PROCEDURE Book.SearchForTitle
	@Title NVARCHAR(128),
	@SearchPage INT = 1,
	@RowsPerPage INT = 25
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
		ORDER BY BI.Title
		OFFSET ((@SearchPage-1)*@RowsPerPage) ROWS FETCH NEXT @RowsPerPage ROWS ONLY;
GO

--Search procedure for finding all books that match exactly or are like a given last name of an author.
CREATE OR ALTER PROCEDURE Book.SearchForAuthor
	@FirstName NVARCHAR(128),
	@LastName NVARCHAR(128),
	@SearchPage INT = 1,
	@RowsPerPage INT = 25
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
		ORDER BY BI.Title
		OFFSET ((@SearchPage-1)*@RowsPerPage) ROWS FETCH NEXT @RowsPerPage ROWS ONLY;
GO

--Search procedure for finding all books that match exactly or are like a given ISBN.
CREATE OR ALTER PROCEDURE Book.SearchForISBN
	@ISBN NVARCHAR(32),
	@SearchPage INT = 1,
	@RowsPerPage INT = 25
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
		ORDER BY BI.Title
		OFFSET ((@SearchPage-1)*@RowsPerPage) ROWS FETCH NEXT @RowsPerPage ROWS ONLY;
GO

--Search procedure for finding all books that match exactly or are like a given genre.
CREATE OR ALTER PROCEDURE Book.SearchByGenre
	@GenreDescriptor  NVARCHAR(64),
	@SearchPage INT = 1,
	@RowsPerPage INT = 25
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
		ORDER BY BI.Title
		OFFSET ((@SearchPage-1)*@RowsPerPage) ROWS FETCH NEXT @RowsPerPage ROWS ONLY;
GO

--Marks the removed flag on the given BookID as a 1, which means it has been removed.
--First verifies that the BookID is in the table.
--No return value, will return exception if there is a problem.
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

--Updates the quality of the given Book to the specified value.
--If either the BookID or GenreDescriptor is not in the table, an error is thrown.
--No return value, if no error thrown than success can be assumed.
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

--Given a BookID, get the corresponding BookInfoID
--Throws error for invalid BookID
--Returns BookInfoID if all is good.
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

--Given a BookID, get all the corresponding BookInfo
--Throws error for invalid BookID
--Is a select statement if all is good.
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

--Takes an email and new password. Old password not needed, as the assumption is that
--only admins are able to initiate the change in password.
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

--Get all books checked out by a user currently
--Throws an error if email is invalid.
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

--Get all books checked out by a user at any point in time
--Throws an error if email is invalid.
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


--Get all books that a specific user has overdue
--Throws an error if email is invalid.
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
	WHERE CO.UserID=@UserID AND CO.ReturnDate IS NULL AND CO.DueDate<SYSDATETIME()
	ORDER BY CO.CheckOutDate ASC
GO

--Gets the corresponding ID for a user with a given email.
--Throws error if email is not valid.
--Otherwise returns UserID
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

--Get all books that are overdue
--Returns all relevant book info, as well as UserID and Email
CREATE OR ALTER PROCEDURE Book.GetAllOverdueBooks

AS
	
	SELECT CO.UserID, U.Email, CO.BookID, BI.Title, A.FirstName AS AuthorFirstName, A.LastName AS AuthorLastName, BI.ISBN, BI.CopyrightYear, CO.CheckOutDate,CO.DueDate
	FROM Book.CheckOut CO
		INNER JOIN Proj."User" U ON U.UserID=CO.UserID
		INNER JOIN Book.Book B ON CO.BookID=B.BookID
		INNER JOIN Book.BookInfo BI ON B.BookInfoID=BI.BookInfoID
		INNER JOIN Book.Author A ON A.AuthorID=BI.AuthorID
	WHERE CO.ReturnDate IS NULL AND CO.DueDate<SYSDATETIME()
	ORDER BY CO.UserID ASC
GO

--Gets all books with no filter, simply ordered on how often they've been checked out.
--Also uses a form of pagination. Either given by caller or assumed first page with 25 books per page.
CREATE OR ALTER PROCEDURE Book.GetBooksByPopularity
	@SearchPage INT = 1,
	@RowsPerPage INT = 25
AS
	SELECT B.BookID, BI.Title, A.FirstName AS AuthorFirstName, A.LastName AS AuthorLastName, BI.ISBN, BI.Copyrightyear, P."Name" AS PublisherName, G.Descriptor AS Genre, 
			COALESCE((
						SELECT CO.BookID
						FROM Book.CheckOut CO
						WHERE CO.BookID=B.BookID AND ReturnDate IS NULL
					),0) AS CheckedOut--returns non-zero value if book checked out, 
		FROM (Book.Book B
			INNER JOIN Book.BookInfo BI ON B.BookInfoID=BI.BookInfoID
			INNER JOIN Book.Author A ON A.AuthorID=BI.AuthorID
			INNER JOIN Book.Publisher P ON P.PublisherID=BI.PublisherID
			INNER JOIN Book.BookGenre BG ON BG.BookInfoID=BI.BookInfoID
			INNER JOIN Book.Genre G ON G.GenreID=BG.GenreID)
			LEFT JOIN (
				SELECT CO.BookID, COUNT(DISTINCT CO.CheckOutID) AS Popularity
				FROM Book.CheckOut CO
				GROUP BY CO.BookID
			) DT ON DT.BookID = B.BookID
		ORDER BY DT.Popularity DESC, BI.Title
		OFFSET ((@SearchPage-1)*@RowsPerPage) ROWS FETCH NEXT @RowsPerPage ROWS ONLY;
GO

--Report type query
--This procedure gets all users paired with the number of times they've checked a book out.
--It also gives them a ranking based on how many times they've checked something out.
CREATE OR ALTER PROCEDURE Proj.AllUsersNumTimesCheckedOut

AS
	SELECT U.UserID, U.Email, 
		   (
				SELECT COUNT(CO.CheckOutID)
				FROM Book.CheckOut CO
				WHERE CO.UserID=U.UserID
		   ) AS NumberBooksCheckedOut,
		   RANK() OVER(ORDER BY (
								SELECT COUNT(CO.CheckOutID)
								FROM Book.CheckOut CO
								WHERE CO.UserID=U.UserID) DESC
			) AS CheckOutRanking
	FROM Proj."User" U
	ORDER BY CheckOutRanking
GO

--Gets all books with no filter, simply ordered on how often they've been checked out.
--Also uses a form of pagination. Either given by caller or assumed first page with 25 books per page.
CREATE OR ALTER PROCEDURE Book.GetAllBookInfosWithCheckOutCount

AS
	SELECT BI.Title, A.FirstName AS AuthorFirstName, A.LastName AS AuthorLastName, BI.ISBN,
			COALESCE((
				SELECT COUNT(CO.CheckOutID)
				FROM Book.CheckOut CO
				INNER JOIN Book.Book BB ON CO.BookID=BB.BookID
				WHERE BB.BookInfoID=BI.BookInfoID
			),0) AS NumTimesCheckedOut,
			RANK() OVER(ORDER BY (
									SELECT COUNT(CO.CheckOutID)
									FROM Book.CheckOut CO
									INNER JOIN Book.Book BB ON CO.BookID=BB.BookID
									WHERE BB.BookInfoID=BI.BookInfoID
									) DESC
			) AS Ranking
			
		FROM (Book.BookInfo BI
			INNER JOIN Book.Author A ON A.AuthorID=BI.AuthorID
			INNER JOIN Book.Publisher P ON P.PublisherID=BI.PublisherID
			INNER JOIN Book.BookGenre BG ON BG.BookInfoID=BI.BookInfoID
			INNER JOIN Book.Genre G ON G.GenreID=BG.GenreID)
			
		ORDER BY NumTimesCheckedOut DESC, Title ASC
GO

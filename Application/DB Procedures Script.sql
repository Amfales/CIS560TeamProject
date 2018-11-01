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
			
	SET @UserID = IDENT_CURRENT('Proj.User');
GO

--Create Admin user procedure
CREATE OR ALTER PROCEDURE Proj.AddAdmin
	--Input parameters
	@FirstName NVARCHAR(128),
	@LastName NVARCHAR(128),
	@Email NVARCHAR(128),
	@HashedPassword NVARCHAR(128),

	--Output parameters
	@UserID INT OUTPUT
AS
	EXEC Proj.AddUser @FirstName,@LastName,@Email,@HashedPassword, N'Admin',@UserID OUTPUT;
	
GO

--Create Patron user procedure
CREATE OR ALTER PROCEDURE Proj.AddAdmin
	--Input parameters
	@FirstName NVARCHAR(128),
	@LastName NVARCHAR(128),
	@Email NVARCHAR(128),
	@HashedPassword NVARCHAR(128),

	--Output parameters
	@UserID INT OUTPUT
AS
	EXEC Proj.AddUser @FirstName,@LastName,@Email,@HashedPassword, N'Patron',@UserID OUTPUT;
	
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

	SET @GenreID=IDENT_CURRENT('Book.Genre');
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

	SET @PublisherID=IDENT_CURRENT('Book.Publisher');
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
	SET @DueDate = DATEADD(WEEK,2,SYSDATETIMEOFFSET());

	INSERT Book.CheckOut(BookID,UserID,CheckOutDate,DueDate)
	VALUES(@BookID, @UserID, SYSDATETIMEOFFSET(),@DueDate);

	SET @CheckOutID = IDENT_CURRENT('Book.CheckOut');
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

	UPDATE Book.CheckOut
		SET DueDate=@NewDueDate
	WHERE BookID=@BookID AND UserID=@UserID AND ReturnDate=NULL;

	SET @CheckOutID = 
	(	SELECT CO.CheckOutID
		FROM Book.CheckOut CO
		WHERE BookID=@BookID AND UserID=@UserID AND ReturnDate=NULL
	);
GO
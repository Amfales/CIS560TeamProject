--TRUNCATE TABLE Proj."User";

--TEST FOR AddUser PROCEDURE
--DELETE Proj."User";
SELECT * FROM Proj."User";

DECLARE @NewUser INT;

EXEC Proj.AddUser N'Grant', N'Willford', N'gwillford@ksu.edu', N'apoij', N'Admin', @NewUser OUTPUT;

SELECT * FROM Proj."User";
SELECT @NewUser AS NewUserID;

EXEC Proj.AddUser N'Grant', N'Willford', N'gwillford.edu', N'apoij', N'Admin', @NewUser OUTPUT;
SELECT * FROM Proj."User";
SELECT @NewUser AS NewUserID;


--TEST FOR AddGenre Procedure
--DELETE Book.Genre;
SELECT * FROM Book.Genre;

DECLARE @NewGenreID INT;

EXEC Book.AddGenre N'Test', @NewGenreID OUTPUT;

SELECT * FROM Book.Genre;
SELECT @NewGenreID AS NewGenreID;

EXEC Book.AddGenre N'Test', @NewGenreID OUTPUT;
SELECT * FROM Book.Genre;

--Test Book.AddAuthor
SELECT * FROM Book.Author;

DECLARE @AuthorID INT;

EXEC Book.AddAuthor N'Friedrich', N'Dürrenmatt', @AuthorID OUTPUT;

SELECT * FROM Book.Author;
SELECT @AuthorID AS NewAuthorID;

--Test Proj.LoginUser
SELECT * FROM Proj."User";

DECLARE @UserID INT,
		@FirstNAME NVARCHAR(128),
		@PermissionLevel NVARCHAR(32);

EXEC Proj.LoginUser N'gwillford@ksu.edu', N'apoij',@UserID OUTPUT,@FirstNAME OUTPUT,@PermissionLevel OUTPUT;

SELECT @UserID AS ReturnedID, @FirstNAME AS ReturnedFName, @PermissionLevel AS ReturnedPermissionLevel;

EXEC Proj.LoginUser N'gwilsdrd@ksu.edu', N'apoij',@UserID OUTPUT,@FirstNAME OUTPUT,@PermissionLevel OUTPUT;

SELECT @UserID AS ReturnedID, @FirstNAME AS ReturnedFName, @PermissionLevel AS ReturnedPermissionLevel;


EXEC Proj.LoginUser N'gwillford@ksu.edu', N'apadfoij',@UserID OUTPUT,@FirstNAME OUTPUT,@PermissionLevel OUTPUT;

SELECT @UserID AS ReturnedID, @FirstNAME AS ReturnedFName, @PermissionLevel AS ReturnedPermissionLevel;
GO

--Test for Book.AddBookWithoutInfoID
SELECT * FROM Book.BookInfo;
SELECT * FROM Book.Book;
SELECT * FROM Book.BookGenre;
SELECT * FROM Book.Genre;
SELECT * FROM Book.Author;
SELECT * FROM Book.Publisher;

DECLARE @BookID INT;

EXEC Book.AddBookWithoutInfoID N'Test book 3: even testiest', N'First', N'Last', N'Buttz Book Co.', N'Fantasy',N'ISBN-3',2012, @BookID OUTPUT;

SELECT @BookID;
GO

--Test for Book.Checkout
SELECT * FROM Book.CheckOut;
SELECT * FROM Proj."User";
SELECT * FROM Book.Book;

DECLARE @CheckoutID INT,
		@BookID INT = 1,
		@UserID INT = 1,
		@DueDate DATETIMEOFFSET;

EXEC Book.CheckOutBook @BookID, @UserID, @CheckoutID OUTPUT, @DueDate OUTPUT;

SELECT @CheckoutID AS NewCheckOutID, @DueDate AS DueDate;
GO

--Test Book.CheckInBook
SELECT * FROM Book.CheckOut;

DECLARE @BookID INT = 1,
		@UserID INT = 1,
		@CheckOutID INT;

EXEC Book.CheckInBook @BookID, @UserID, @CheckOutID OUTPUT;

SELECT @CheckOutID;

SELECT * FROM Book.Book B INNER JOIN Book.BookInfo BI ON BI.BookInfoID=B.BookInfoID

--Test Book.SearchForTitle
EXEC Book.SearchForTitle N'Test book 3: even testiest';
EXEC Book.SearchForTitle N'Test b%';
EXEC Book.SearchForTitle N'buttz';

--Test Book.SearchForAuthor
EXEC Book.SearchForAuthor N't', N'Last';
EXEC Book.SearchForAuthor N't', N'La%';
EXEC Book.SearchForAuthor N't', N'Tootz';

--Test Book.SearchForISBN
EXEC Book.SearchForISBN N'ISBN-3';
EXEC Book.SearchForISBN N'ISBN-3%';
EXEC Book.SearchForISBN N'ISBN-%';
EXEC Book.SearchForISBN N'ISBN-2';
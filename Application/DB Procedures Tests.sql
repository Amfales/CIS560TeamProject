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

DECLARE @FirstNAME NVARCHAR(128),
		@PermissionLevel NVARCHAR(32);

EXEC Proj.LoginUser N'gwillford@ksu.edu', N'apoij',@FirstNAME OUTPUT,@PermissionLevel OUTPUT;

SELECT  @FirstNAME AS ReturnedFName, @PermissionLevel AS ReturnedPermissionLevel;

EXEC Proj.LoginUser N'gwilsdrd@ksu.edu', N'apoij',@FirstNAME OUTPUT,@PermissionLevel OUTPUT;

SELECT @FirstNAME AS ReturnedFName, @PermissionLevel AS ReturnedPermissionLevel;


EXEC Proj.LoginUser N'gwillford@ksu.edu', N'apadfoij',@FirstNAME OUTPUT,@PermissionLevel OUTPUT;

SELECT @FirstNAME AS ReturnedFName, @PermissionLevel AS ReturnedPermissionLevel;
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
		@DueDate DATETIMEOFFSET;

EXEC Book.CheckOutBook 4, N'gwillford@ksu.edu', @CheckoutID OUTPUT, @DueDate OUTPUT;

SELECT @CheckoutID AS NewCheckOutID, @DueDate AS DueDate;
GO

--Test Book.CheckInBook
SELECT * FROM Book.CheckOut;

DECLARE @CheckOutID INT;

EXEC Book.CheckInBook 3,  @CheckOutID OUTPUT;

SELECT @CheckOutID;

SELECT * FROM Book.Book B INNER JOIN Book.BookInfo BI ON BI.BookInfoID=B.BookInfoID

--Test Book.SearchForTitle
EXEC Book.SearchForTitle N'Test book 3: even testiest';
EXEC Book.SearchForTitle N'Test b%';
EXEC Book.SearchForTitle N'wrong';

--Test Book.SearchForAuthor
EXEC Book.SearchForAuthor N't', N'Last';
EXEC Book.SearchForAuthor N't', N'La%';
EXEC Book.SearchForAuthor N't', N'wrong';

--Test Book.SearchForISBN
EXEC Book.SearchForISBN N'ISBN-3';
EXEC Book.SearchForISBN N'ISBN-3%';
EXEC Book.SearchForISBN N'ISBN-%';
EXEC Book.SearchForISBN N'ISBN-2';

--Test Book.SearchByGenre
EXEC Book.SearchByGenre N'Fantasy';
EXEC Book.SearchByGenre N'Fan%';
EXEC Book.SearchByGenre N'wrong';


--Test Book.DeleteBookWithID
SELECT * From Book.BookInfo
SELECT * FROM Book.Book

--Test Book.UpdateBookQuality
SELECT * FROM Book.Book

EXEC Book.UpdateBookQuality 1, N'Used';
SELECT * FROM Book.Book INNER JOIN Book.BookQuality BQ ON BQ.QualityID=BOok.QualityID
EXEC Book.UpdateBookQuality 2, N'Used';
SELECT * FROM Book.Book
EXEC Book.UpdateBookQuality 2, N'Ud';
SELECT * FROM Book.Book
EXEC Book.UpdateBookQuality 4, N'New';
SELECT * FROM Book.Book INNER JOIN Book.BookQuality BQ ON BQ.QualityID=BOok.QualityID


--test Book.SearchWithAll
EXEC Book.SearchWithAll N'Test book 3: even testiest', N't', N'La%', N'ISBN-3',N'Fantasy';
EXEC Book.SearchWithAll N'Test book 3: even testiest', N'%', N'%', N'ISBN-3',N'%';
EXEC Book.SearchWithAll N'Test book 3: even testiest', N'%', N'Rob', N'ISBN-3',N'%';
EXEC Book.SearchWithAll N'%', N'%', N'La%', N'%',N'Fantasy';


--test Book.GetBookInfoIDForBook
DECLARE @BookInfoID INT;
EXEC Book.GetBookInfoIDForBook 2, @BookInfoID OUTPUT;
SELECT @BookInfoID AS BookInfoID;
EXEC Book.GetBookInfoIDForBook -1, @BookInfoID OUTPUT;
SELECT @BookInfoID AS BookInfoID;

--test Book.GetAllBookInfoForBook
EXEC Book.GetAllBookInfoForBook 3;
EXEC Book.GetAllBookInfoForBook -1;

--test Proj.ChangePassword
SELECT * FROM Proj."User";
EXEC Proj.ChangePassword N'gwillford@ksu.edu', N'new pass';
SELECT * FROM Proj."User";
EXEC Proj.ChangePassword N'gwillford@ksu.edu', N'newest pass';
EXEC Proj.ChangePassword N'gwillfrd@ksu.edu', N'newest pass';

--test Book.RemoveBookWithID
SELECT * FROM Book.Book;
EXEC Book.RemoveBookWithID 1;
SELECT * FROM Book.Book;
EXEC Book.SearchWithAll N'Test book 3: even testiest', N't', N'La%', N'ISBN-3',N'Fantasy';
EXEC Book.SearchForTitle N'Test book 3: even testiest';
EXEC Book.SearchForAuthor N't', N'Last';
EXEC Book.SearchForISBN N'ISBN-3';
EXEC Book.SearchByGenre N'Fantasy';
EXEC Book.RemoveBookWithID 2;

--test Book.GetUserCheckedOutBooks
EXEC Book.GetUserCheckedOutBooks N'gwillford@ksu.edu';

--test Book.GetUserCheckedOutHistory
EXEC Book.GetUserCheckedOutHistory N'gwillford@ksu.edu';

EXEC Book.GetUserOverdueBooks N'gwillford@ksu.edu';
INSERT Book.CheckOut(BookID, UserID, CheckOutDate, DueDate)
VALUES(5,1,SYSDATETIMEOFFSET(), '2017-11-29 12:25:28.2037170 -06:00');

SELECT * FROM Book.CheckOut
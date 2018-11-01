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
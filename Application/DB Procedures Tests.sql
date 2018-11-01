--TRUNCATE TABLE Proj."User";

--DELETE Proj."User";

SELECT * FROM Proj."User";

DECLARE @NewUser INT;

EXEC Proj.AddUser N'Grant', N'Willford', N'gwillford.edu', N'apoij', N'Admin', @NewUser OUTPUT;

SELECT * FROM Proj."User";
SELECT @NewUser AS NewUserID;

--DELETE Book.Genre;

SELECT * FROM Book.Genre;

DECLARE @NewGenreID INT;

EXEC Book.AddGenre N'Test', @NewGenreID OUTPUT;

SELECT * FROM Book.Genre;
SELECT @NewGenreID AS NewGenreID;
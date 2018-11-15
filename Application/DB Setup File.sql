-- Project Database Setup Script
DROP TABLE IF EXISTS Book.BookGenre, Book.Genre, Book.CheckOut, Book.Book, Proj."User"
GO
DROP TABLE IF EXISTS Book.BookInfo, Book.Publisher, Book.BookQuality,Proj.UserCategory
GO
DROP TABLE IF EXISTS Book.Author
GO

--DROP SCHEMA IF EXISTS Proj;
--GO

--DROP SCHEMA IF EXISTS Book;
--GO

--CREATE SCHEMA Proj;
--GO

--CREATE SCHEMA Book;
--GO

CREATE TABLE Book.Publisher
(
	PublisherID INT PRIMARY KEY IDENTITY(1,1),
	"Name" NVARCHAR(128) NOT NULL ,
	
	CONSTRAINT UK_Book_Publisher_PublisherName UNIQUE("Name")
);

CREATE TABLE Book.Author
(
	AuthorID INT PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(128) NOT NULL,
	LastName NVARCHAR(128) NOT NULL,

	CONSTRAINT UK_Book_Author_FirstName_LastName UNIQUE(FirstName,LastName)
);


CREATE TABLE Book.BookInfo
(
	BookInfoID INT PRIMARY KEY IDENTITY(1,1),
	AuthorID INT NOT NULL,
	Title NVARCHAR(128) NOT NULL,
	PublisherID INT NOT NULL,
	ISBN NVARCHAR(32) NOT NULL,
	CopyrightYear SMALLINT NOT NULL,

	CONSTRAINT FK_Book_BookInfo_PublisherID FOREIGN KEY(PublisherID)
		REFERENCES Book.Publisher(PublisherID),
	CONSTRAINT FK_Book_BookInfo_AuthorID FOREIGN KEY(AuthorID)
		REFERENCES Book.Author(AuthorID),
	CONSTRAINT UK_Book_BookInfo_ISBN UNIQUE(ISBN)
);

CREATE TABLE Book.Genre
(
	GenreID INT PRIMARY KEY IDENTITY(1,1),
	Descriptor NVARCHAR(64) NOT NULL,

	CONSTRAINT UK_Book_Genre_Descriptor UNIQUE(Descriptor)
);

CREATE TABLE Book.BookGenre
(
	GenreID INT NOT NULL,
	BookInfoID INT NOT NULL,

	PRIMARY KEY(GenreID, BookInfoID),

	CONSTRAINT FK_Book_BookGenre_GenreID FOREIGN KEY(GenreID)
		REFERENCES Book.Genre(GenreID),

	CONSTRAINT FK_Book_BookGenre_BookInfoID FOREIGN KEY(BookInfoID)
		REFERENCES  Book.BookInfo(BookInfoID)
);

CREATE TABLE Book.BookQuality
(
	QualityID INT PRIMARY KEY IDENTITY(1,1),
	"Description" NVARCHAR(32) NOT NULL,
	
	CONSTRAINT UK_Book_BookQuality_Description UNIQUE("Description")
);

CREATE TABLE Book.Book
(
	BookID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	BookInfoID INT NOT NULL,
	QualityID INT NOT NULL,
	Removed BIT NOT NULL DEFAULT(0),

	CONSTRAINT FK_Book_Book_BookInfoID FOREIGN KEY(BookInfoID)
		REFERENCES Book.BookInfo(BookInfoID),

	CONSTRAINT FK_Book_Book_QualityID FOREIGN KEY(QualityID)
		REFERENCES  Book.BookQuality(QualityID)
);

CREATE TABLE Proj.UserCategory
(
	UserCategoryID INT PRIMARY KEY IDENTITY(1,1),
	PermissionLevel NVARCHAR(32) NOT NULL
);

CREATE TABLE Proj."User"
(
	UserID INT PRIMARY KEY IDENTITY(1,1),
	UserCategoryID INT NOT NULL,
	FirstName NVARCHAR(128) NOT NULL,
	LastName NVARCHAR(128) NOT NULL,
	Email NVARCHAR(128) NOT NULL,
	HashedPassword NVARCHAR(64) NOT NULL,


	CONSTRAINT FK_Proj_User_UserCategoryID FOREIGN KEY(UserCategoryID)
		REFERENCES Proj.UserCategory(UserCategoryID),

	CONSTRAINT UK_Proj_User_Email UNIQUE(Email)
);

CREATE TABLE Book.CheckOut
(
	CheckOutID INT PRIMARY KEY IDENTITY(1,1),
	BookID INT NOT NULL,
	UserID INT NOT NULL,
	CheckOutDate DATETIMEOFFSET NOT NULL,
	DueDate DATETIMEOFFSET NOT NULL,
	ReturnDate DATETIMEOFFSET DEFAULT(NULL),

	CONSTRAINT FK_Book_CheckOut_BookID FOREIGN KEY(BookID)
		REFERENCES Book.Book(BookID),
	CONSTRAINT FK_Book_CheckOut_UserID FOREIGN KEY(UserID)
		REFERENCES Proj."User"(UserID)
);
GO



INSERT Proj.UserCategory(PermissionLevel)
Values (N'Admin'),(N'Patron');

INSERT Book.BookQuality("Description")
VALUES (N'New'),(N'Used');
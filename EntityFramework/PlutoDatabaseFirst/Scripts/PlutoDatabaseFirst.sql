SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

/**************************/
/*     Table: Authors     */
/**************************/

CREATE TABLE [dbo].[Authors]
(
	[AuthorID]		[int] IDENTITY(1,1) NOT NULL,
	[Name]			[varchar](255) NOT NULL,

	CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
	(
		[AuthorID] ASC
	) 
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
ON [PRIMARY]
GO

/**************************/
/*     Table: Courses     */
/**************************/

CREATE TABLE [dbo].[Courses]
(
	[CourseID]		[int] IDENTITY(1,1) NOT NULL,
	[AuthorID]		[int] NOT NULL,
	[Title]			[varchar](255) NOT NULL,
	[Description]	[varchar](8000) NOT NULL,
	[Price]			[smallint] NOT NULL,
	[LevelString]	[varchar](50) NOT NULL,
	[Level]			[tinyint] NOT NULL,

	CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
	(
		[CourseID] ASC
	)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
ON [PRIMARY]
GO

/**************************/
/* Table: Course Sections */
/**************************/

CREATE TABLE [dbo].[CourseSections]
(
	[SectionID]		[int] IDENTITY(1,1) NOT NULL,
	[CourseID]		[int] NOT NULL,
	[Title]			[varchar](255) NOT NULL,

	CONSTRAINT [PK_Sections] PRIMARY KEY CLUSTERED 
	(
		[SectionID] ASC
	)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
ON [PRIMARY]
GO

/**************************/
/*   Table: Course Tags   */
/**************************/

CREATE TABLE [dbo].[CourseTags]
(
	[CourseID]		[int] NOT NULL,
	[TagID]			[int] NOT NULL,

	CONSTRAINT [PK_CourseTags] PRIMARY KEY CLUSTERED 
	(
		[CourseID] ASC,
		[TagID] ASC
	)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
ON [PRIMARY]
GO

/**************************/
/*      Table: Posts      */
/**************************/

CREATE TABLE [dbo].[Posts]
(
	[PostID]		[int] NOT NULL,
	[DatePublished] [smalldatetime] NOT NULL,
	[Title]			[varchar](255) NOT NULL,
	[Body]			[varchar](8000) NOT NULL,

	CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
	(
		[PostID] ASC
	)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
ON [PRIMARY]
GO

/**************************/
/*      Table: Tags       */
/**************************/

CREATE TABLE [dbo].[Tags]
(
	[TagID]			[int] IDENTITY(1,1) NOT NULL,
	[Name]			[varchar](50) NOT NULL,

	CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
	(
		[TagID] ASC
	)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
ON [PRIMARY]
GO

/**************************/
/*      Table: User       */
/**************************/

CREATE TABLE [dbo].[tblUser]
(
	[UserID]		[int] NOT NULL,
	[Username]		[varchar](50) NOT NULL,
	[Password]		[int] NOT NULL,

	CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
	(
		[UserID] ASC
	)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
ON [PRIMARY]
GO

/**************************/
/*       References       */
/**************************/

ALTER TABLE [dbo].[Courses] ADD CONSTRAINT [FK_Courses_Authors] FOREIGN KEY([AuthorID]) REFERENCES [dbo].[Authors] ([AuthorID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Authors]
GO

ALTER TABLE [dbo].[CourseSections]  ADD CONSTRAINT [FK_CourseSections_Courses] FOREIGN KEY([CourseID]) REFERENCES [dbo].[Courses] ([CourseID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CourseSections] CHECK CONSTRAINT [FK_CourseSections_Courses]
GO

ALTER TABLE [dbo].[CourseTags] ADD CONSTRAINT [FK_CourseTags_Courses] FOREIGN KEY([CourseID]) REFERENCES [dbo].[Courses] ([CourseID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CourseTags] CHECK CONSTRAINT [FK_CourseTags_Courses]
GO

ALTER TABLE [dbo].[CourseTags] ADD CONSTRAINT [FK_CourseTags_Tags] FOREIGN KEY([TagID]) REFERENCES [dbo].[Tags] ([TagID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CourseTags] CHECK CONSTRAINT [FK_CourseTags_Tags]
GO


/******************************/
/* Function: GetAuthorCourses */
/******************************/

CREATE FUNCTION [dbo].[funcGetAuthorCourses]
(
	@AuthorID int
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT * FROM Courses WHERE AuthorID = @AuthorID 
)
GO

/******************************/
/* Procedure: DeleteCourse    */
/******************************/

CREATE PROC [dbo].[DeleteCourse] 
(
	@CourseID int
)
AS
BEGIN

	DELETE FROM Courses	WHERE CourseID = @CourseID

END
GO

/******************************/
/* Procedure: GetCourses      */
/******************************/

CREATE PROC [dbo].[GetCourses] 
AS
BEGIN

	SELECT * FROM Courses

END
GO

/******************************/
/* Procedure: InsertCourse    */
/******************************/

CREATE PROC [dbo].[InsertCourse]
(
	@AuthorID int,
	@Title varchar(255),
	@Description varchar(8000),
	@Price smallint,
	@LevelString varchar(50),
	@Level tinyint
)
AS
BEGIN

	INSERT INTO [dbo].[Courses]
	(
		[AuthorID],
		[Title],
		[Description],
		[Price],
		[LevelString],
		[Level]
	)
	VALUES
	(
		@AuthorID,
		@Title,
		@Description,
		@Price,
		@LevelString,
		@Level
	)
END
GO

/******************************/
/* Procedure: UpdateCourse    */
/******************************/

CREATE PROC [dbo].[UpdateCourse]
(
	@CourseID int,
	@Title varchar(255),
	@Description varchar(8000),
	@LevelString varchar(50),
	@Level tinyint
)
AS
BEGIN
	UPDATE Courses
	SET 
		Title = @Title,
		Description = @Description,
		LevelString = @LevelString,
		Level = @Level
	WHERE
		CourseID = @CourseID
END
GO

/******************************/
/*          Populate          */
/******************************/

INSERT INTO Authors (Name)
VALUES ('Mosh Hamedani')
GO

INSERT INTO Authors (Name)
VALUES ('John Smith')
GO

INSERT INTO Courses (AuthorID, Title, Description, Price, Level, LevelString)
VALUES (1, 'C# Advanced', 'C# Advanced Description', 69, 3, 'Advanced')
GO

INSERT INTO Courses (AuthorID, Title, Description, Price, Level, LevelString)
VALUES (1, 'C# Intermediate', 'C# Intermediate Description', 49, 2, 'Intermediate')
GO

INSERT INTO Courses (AuthorID, Title, Description, Price, Level, LevelString)
VALUES (1, 'Clean Code', 'Clean Code Description', 99, 2, 'Intermediate')
GO
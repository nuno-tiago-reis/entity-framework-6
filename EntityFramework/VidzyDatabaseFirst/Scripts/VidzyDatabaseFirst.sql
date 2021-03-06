SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

/**************************/
/*     Table: Genres      */
/**************************/

CREATE TABLE [dbo].[Genres]
(
	[ID]			[tinyint] NOT NULL,
	[Name]			[varchar](255) NOT NULL,

	CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
ON [PRIMARY]
GO

/**************************/
/*   Table: VideoGenres   */
/**************************/

CREATE TABLE [dbo].[VideoGenres]
(
	[VideoID]		[int] NOT NULL,
	[GenreID]		[tinyint] NOT NULL,

	CONSTRAINT [PK_VideoGenres] PRIMARY KEY CLUSTERED 
	(
		[VideoID] ASC,
		[GenreID] ASC
	)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
ON [PRIMARY]
GO

/**************************/
/*      Table: Videos     */
/**************************/

CREATE TABLE [dbo].[Videos]
(
	[ID]			[int] IDENTITY(1,1) NOT NULL,
	[Name]			[varchar](255) NOT NULL,
	[ReleaseDate]	[datetime] NOT NULL,

	CONSTRAINT [PK_Videos] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
ON [PRIMARY]
GO

/**************************/
/*       References       */
/**************************/

ALTER TABLE [dbo].[VideoGenres]  WITH CHECK ADD  CONSTRAINT [FK_VideoGenres_Genres] FOREIGN KEY([GenreID]) REFERENCES [dbo].[Genres] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VideoGenres] CHECK CONSTRAINT [FK_VideoGenres_Genres]
GO

ALTER TABLE [dbo].[VideoGenres]  WITH CHECK ADD  CONSTRAINT [FK_VideoGenres_Videos] FOREIGN KEY([VideoID]) REFERENCES [dbo].[Videos] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VideoGenres] CHECK CONSTRAINT [FK_VideoGenres_Videos]
GO

/******************************/
/* Procedure: AddVideo        */
/******************************/

CREATE PROCEDURE [dbo].[spAddVideo]
(
	@Name varchar(255),
	@ReleaseDate datetime,
	@Genre varchar(255)
)
AS

	DECLARE @GenreID tinyint
	SET @GenreID = (SELECT ID FROM Genres WHERE Name = @Genre)

	INSERT INTO Videos (Name, ReleaseDate)
	VALUES (@Name, @ReleaseDate)

	DECLARE @VideoID int
	SET @VideoID = SCOPE_IDENTITY()

	INSERT INTO VideoGenres (VideoID, GenreID)
	VALUES (@VideoID, @GenreID)

GO

/******************************/
/*          Populate          */
/******************************/

INSERT INTO Genres
	(ID, Name)
VALUES 
	(1, 'Comedy'), 
	(2, 'Action'), 
	(3, 'Horror'), 
	(4, 'Thriller'), 
	(5, 'Family'), 
	(6, 'Romance'), 
	(7, 'Fantasy'),
	(8, 'Adventure')
GO
namespace PlutoDataAnnotations.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class PopulateCourses : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			this.Sql("INSERT INTO Courses(Title, Description, Level, FullPrice, AuthorID, CategoryID) VALUES('Entity Framework in Depth: The Complete Guide', 'Entity Framework is an Object / Relational Mapper (O/RM) that helps you read and write data from and to a database. In this course, Mosh, teaches you the core concepts of Entity Framework through a series of clear, concise and hands-on lectures.', 1, 100, 1, 1)");
			this.Sql("INSERT INTO Courses(Title, Description, Level, FullPrice, AuthorID, CategoryID) VALUES('The Complete ASP.NET MVC 5 Course', 'ASP.NET MVC is a server - side web framework for building dynamic, data-driven web applications.Since its first release in 2009, it has gained a lot of popularity amongst developers using Microsoft technologies. If you want to get employed as a web developer at a company that utilizes Microsoft technologies, you need to master ASP.NET MVC.', 2, 120, 1, 1)");
			this.Sql("INSERT INTO Courses(Title, Description, Level, FullPrice, AuthorID, CategoryID) VALUES('C# Advanced Topics: Prepare for Technical Interviews', 'In C# Advanced Topics, the third part in Mosh''s best-selling C# series, he walks you through the advanced features of C# that are frequently used in building real-world applications.', 3, 150, 1, 3)");
			this.Sql("INSERT INTO Courses(Title, Description, Level, FullPrice, AuthorID, CategoryID) VALUES('RPG Core Combat Creator: Learn Intermediate Unity C#', 'Build a Role Playing Game (RPG) in Unity. Improve your C sharp, code architecture, game & level design. Full game scale.', 3, 200, 2, 2)");

		}

		/// <inheritdoc />
		public override void Down()
		{
			this.Sql("DELETE FROM Courses WHERE Title = 'Entity Framework in Depth: The Complete Guide'");
			this.Sql("DELETE FROM Courses WHERE Title = 'The Complete ASP.NET MVC 5 Course'");
			this.Sql("DELETE FROM Courses WHERE Title = 'C# Advanced Topics: Prepare for Technical Interviews'");
			this.Sql("DELETE FROM Courses WHERE Title = 'RPG Core Combat Creator: Learn Intermediate Unity C#'");
		}
	}
}
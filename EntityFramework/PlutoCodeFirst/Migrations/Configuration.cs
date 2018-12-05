using System.Collections.Generic;
using System.Data.Entity.Migrations;

using JetBrains.Annotations;

using PlutoCodeFirst.Model;

namespace PlutoCodeFirst.Migrations
{
	[UsedImplicitly]
	internal sealed class Configuration : DbMigrationsConfiguration<PlutoContext>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Configuration"/> class.
		/// </summary>
		public Configuration()
		{
			this.AutomaticMigrationsEnabled = false;
		}

		/// <inheritdoc />
		protected override void Seed(PlutoContext context)
		{
			context.Authors.AddOrUpdate(author => author.Name, new Author
			{
				Name = "Mosh Hamedani",
				Courses = new List<Course>
				{
					new Course
					{
						Name = "Entity Framework in Depth: The Complete Guide",
						Description = "Entity Framework is an Object / Relational Mapper (O/RM) that helps you read and write data from and to a database. In this course, Mosh, teaches you the core concepts of Entity Framework through a series of clear, concise and hands-on lectures.",
						Level = CourseLevel.Beginner,
						FullPrice = 100
					},
					new Course
					{
						Name = "The Complete ASP.NET MVC 5 Course",
						Description = "ASP.NET MVC is a server - side web framework for building dynamic, data-driven web applications.Since its first release in 2009, it has gained a lot of popularity amongst developers using Microsoft technologies. If you want to get employed as a web developer at a company that utilizes Microsoft technologies, you need to master ASP.NET MVC.",
						Level = CourseLevel.Intermediate,
						FullPrice = 120
					},
					new Course
					{
						Name = "C# Advanced Topics: Prepare for Technical Interviews",
						Description = "In C# Advanced Topics, the third part in Mosh's best-selling C# series, he walks you through the advanced features of C# that are frequently used in building real-world applications.",
						Level = CourseLevel.Advanced,
						FullPrice = 150
					},
				}
			});

			context.Authors.AddOrUpdate(author => author.Name, new Author
			{
				Name = "Ben Tristem",
				Courses = new List<Course>
				{
					new Course
					{
						Name = "RPG Core Combat Creator: Learn Intermediate Unity C#",
						Description = "Build a Role Playing Game (RPG) in Unity. Improve your C sharp, code architecture, game & level design. Full game scale.",
						Level = CourseLevel.Advanced,
						FullPrice = 200
					}
				}
			});
		}
	}
}

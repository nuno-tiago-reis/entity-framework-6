using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;

using JetBrains.Annotations;

using PlutoDataAnnotations.Model;

namespace PlutoDataAnnotations.Migrations
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
			#region Add Tags
			var tags = new Dictionary<string, Tag>
			{
				{ "c#",          new Tag { ID = 1, Name = "c#" }},
				{ "angular",     new Tag { ID = 2, Name = "angular" }},
				{ "javascript",  new Tag { ID = 3, Name = "javascript" }},
				{ "node",        new Tag { ID = 4, Name = "node" }},
				{ "oop",         new Tag { ID = 5, Name = "oop" }},
				{ "linq",        new Tag { ID = 6, Name = "linq" }},
			};

			foreach (var tag in tags.Values)
				context.Tags.AddOrUpdate(t => t.ID, tag);
			#endregion

			#region Add Authors
			var authors = new List<Author>
			{
				new Author
				{
					ID = 1,
					Name = "Mosh Hamedani"
				},
				new Author
				{
					ID = 2,
					Name = "Anthony Alicea"
				},
				new Author
				{
					ID = 3,
					Name = "Eric Wise"
				},
				new Author
				{
					ID = 4,
					Name = "Tom Owsiak"
				},
				new Author
				{
					ID = 5,
					Name = "John Smith"
				}
			};

			foreach (var author in authors)
				context.Authors.AddOrUpdate(a => a.ID, author);
			#endregion

			#region Add Courses
			var courses = new List<Course>
			{
				new Course
				{
					ID = 1,
					Name = "C# Basics",
					AuthorID = 1,
					FullPrice = 49,
					Description = "Description for C# Basics",
					Level = CourseLevel.Beginner,
					Tags = new Collection<Tag>
					{
						tags["c#"]
					}
				},
				new Course
				{
					ID = 2,
					Name = "C# Intermediate",
					AuthorID = 1,
					FullPrice = 49,
					Description = "Description for C# Intermediate",
					Level = CourseLevel.Intermediate,
					Tags = new Collection<Tag>
					{
						tags["c#"],
						tags["oop"]
					}
				},
				new Course
				{
					ID = 3,
					Name = "C# Advanced",
					AuthorID = 1,
					FullPrice = 69,
					Description = "Description for C# Advanced",
					Level = CourseLevel.Advanced,
					Tags = new Collection<Tag>
					{
						tags["c#"]
					}
				},
				new Course
				{
					ID = 4,
					Name = "Javascript: Understanding the Weird Parts",
					AuthorID = 2,
					FullPrice = 149,
					Description = "Description for Javascript",
					Level = CourseLevel.Intermediate,
					Tags = new Collection<Tag>
					{
						tags["javascript"]
					}
				},
				new Course
				{
					ID = 5,
					Name = "Learn and Understand AngularJS",
					AuthorID = 2,
					FullPrice = 99,
					Description = "Description for AngularJS",
					Level = CourseLevel.Intermediate,
					Tags = new Collection<Tag>
					{
						tags["angular"]
					}
				},
				new Course
				{
					ID = 6,
					Name = "Learn and Understand NodeJS",
					AuthorID = 2,
					FullPrice = 149,
					Description = "Description for NodeJS",
					Level = CourseLevel.Intermediate,
					Tags = new Collection<Tag>
					{
						tags["node"]
					}
				},
				new Course
				{
					ID = 7,
					Name = "Programming for Complete Beginners",
					AuthorID = 3,
					FullPrice = 45,
					Description = "Description for Programming for Beginners",
					Level = CourseLevel.Beginner,
					Tags = new Collection<Tag>
					{
						tags["c#"]
					}
				},
				new Course
				{
					ID = 8,
					Name = "A 16 Hour C# Course with Visual Studio 2013",
					AuthorID = 4,
					FullPrice = 150,
					Description = "Description 16 Hour Course",
					Level = CourseLevel.Beginner,
					Tags = new Collection<Tag>
					{
						tags["c#"]
					}
				},
				new Course
				{
					ID = 9,
					Name = "Learn JavaScript Through Visual Studio 2013",
					AuthorID = 4,
					FullPrice = 20,
					Description = "Description Learn Javascript",
					Level = CourseLevel.Beginner,
					Tags = new Collection<Tag>
					{
						tags["javascript"]
					}
				}
			};

			foreach (var course in courses)
				context.Courses.AddOrUpdate(c => c.ID, course);
			#endregion
		}
	}
}
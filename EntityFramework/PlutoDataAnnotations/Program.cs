using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

using PlutoDataAnnotations.Model;

namespace PlutoDataAnnotations
{
	[SuppressMessage("ReSharper", "RedundantAnonymousTypePropertyName")]
	public sealed class Program
	{
		public static void Main(string[] args)
		{
			using (var context = new PlutoContext())
			{
				// LINQ syntax
				Console.WriteLine(@"LINQ Syntax");
				Console.WriteLine();

				QueryUsingLinqSyntax(context);

				// Extension syntax
				Console.WriteLine(@"Extension Syntax");
				Console.WriteLine();

				QueryUsingExtensionSyntax(context);
			}
		}

		/// <summary>
		/// Queries using linq syntax.
		/// </summary>
		/// <param name="context">The context.</param>
		private static void QueryUsingLinqSyntax(PlutoContext context)
		{
			#region [Filter by CourseID]
			Console.WriteLine(@"#Filter by CourseID");
			Console.WriteLine();

			var filterByCourseID =
				from course in context.Courses
				where course.ID > 3
				orderby course.ID descending
				select course;

			foreach (var row in filterByCourseID)
				Console.WriteLine($@" {row.ID}: {row.Name} ({row.Author.Name})");
			Console.WriteLine();
			#endregion

			#region [Filter by CourseName]
			Console.WriteLine(@"#Filter by CourseName");
			Console.WriteLine();

			var filterByCourseName =
				from course in context.Courses
				where course.Name.Contains("c#")
				orderby course.Name
				select course;

			foreach (var row in filterByCourseName)
				Console.WriteLine($@" {row.ID}: {row.Name} ({row.Author.Name})");
			Console.WriteLine();
			#endregion

			#region [Filter by CourseLevel]
			Console.WriteLine(@"#Filter by CourseLevel");
			Console.WriteLine();

			var filterByCourseLevel =
				from course in context.Courses
				where course.Level == CourseLevel.Beginner
				orderby course.Author.Name, course.FullPrice
				select course;

			foreach (var row in filterByCourseLevel)
				Console.WriteLine($@" {row.ID}: {row.Name} ({row.FullPrice} - {row.Author.Name})");
			Console.WriteLine();
			#endregion

			#region [Anonymous Objects]
			Console.WriteLine(@"#Anonymous Objects");
			Console.WriteLine();

			var anonymousObjects =
				from course in context.Courses
				where course.ID > 3
				orderby course.ID descending
				select new
				{
					CourseID = course.ID,
					CourseName = course.Name,
					AuthorName = course.Author.Name
				};

			foreach (var row in anonymousObjects)
				Console.WriteLine($@" {row.CourseID}: {row.CourseName} ({row.AuthorName})");
			Console.WriteLine();
			#endregion

			#region [Group by Level]
			Console.WriteLine(@"#Group by Level");
			Console.WriteLine();

			var groupCoursesByLevel =
				from course in context.Courses
				group course by course.Level into courseGroup
				select courseGroup;

			foreach (var row in groupCoursesByLevel)
			{
				Console.WriteLine($@" {row.Key} ({row.Count()})");
				foreach (var course in row)
					Console.WriteLine($@"  {course.ID}: {course.Name} ({course.Author.Name})");
				Console.WriteLine();
			}
			#endregion

			#region [Group Join]
			Console.WriteLine(@"#Group Join");
			Console.WriteLine();

			var groupJoinAuthorsWithCourses =
				from author in context.Authors
				join course in context.Courses on author.ID equals course.AuthorID into authorGroup
				select new
				{
					AuthorID = author.ID,
					AuthorName = author.Name,
					Courses = authorGroup
				};

			foreach (var row in groupJoinAuthorsWithCourses)
				Console.WriteLine($@" {row.AuthorID}: {row.AuthorName} ({row.Courses.Count()})");
			Console.WriteLine();
			#endregion

			#region [Cross Join]
			Console.WriteLine(@"#Cross Join");
			Console.WriteLine();

			var crossJoinAuthorsWithCourses =
				from author in context.Authors
				from course in context.Courses
				select new
				{
					AuthorID = author.ID,
					AuthorName = author.Name,
					CourseID = course.ID,
					CourseName = course.Name
				};

			foreach (var row in crossJoinAuthorsWithCourses)
				Console.WriteLine($@" {row.AuthorID}: {row.AuthorName} /{row.CourseID} : {row.CourseName})");
			Console.WriteLine();
			#endregion

			#region [Join]
			Console.WriteLine(@"#Join");
			Console.WriteLine();

			var joinCoursesWithAuthors =
				from course in context.Courses
				join author in context.Authors on course.AuthorID equals author.ID
				select new
				{
					CourseID = course.ID,
					CourseName = course.Name,
					AuthorID = author.ID,
					AuthorName = author.Name
				};

			foreach (var row in joinCoursesWithAuthors)
				Console.WriteLine($@" {row.CourseID}: {row.CourseName} ({row.AuthorName})");
			Console.WriteLine();
			#endregion
		}

		/// <summary>
		/// Queries using extension syntax.
		/// </summary>
		/// <param name="context">The context.</param>
		private static void QueryUsingExtensionSyntax(PlutoContext context)
		{
			#region [Filter by CourseID]
			Console.WriteLine(@"#Filter by CourseID");
			Console.WriteLine();

			var filterByCourseID = context.Courses
				.Where(course => course.ID > 3)
				.OrderByDescending(course => course.ID);

			foreach (var row in filterByCourseID)
				Console.WriteLine($@" {row.ID}: {row.Name} ({row.Author.Name})");
			Console.WriteLine();
			#endregion

			#region [Filter by CourseName]
			Console.WriteLine(@"#Filter by CourseName");
			Console.WriteLine();

			var filterCoursesByName = context.Courses
				.Where(course => course.Name.Contains("c#"))
				.OrderBy(course => course.Name);

			foreach (var row in filterCoursesByName)
				Console.WriteLine($@" {row.ID}: {row.Name} ({row.Author.Name})");
			Console.WriteLine();
			#endregion

			#region [Filter by CourseLevel]
			Console.WriteLine(@"#Filter by CourseLevel");
			Console.WriteLine();

			var filterCoursesByLevel = context.Courses
				.Where(course => course.Level == CourseLevel.Beginner)
				.OrderBy(course => course.Author.Name)
				.ThenBy(course => course.FullPrice);

			foreach (var row in filterCoursesByLevel)
				Console.WriteLine($@" {row.ID}: {row.Name} ({row.FullPrice} - {row.Author.Name})");
			Console.WriteLine();
			#endregion

			#region [Anonymous Objects]
			Console.WriteLine(@"#Anonymous Objects");
			Console.WriteLine();

			var anonymousObjects = context.Courses.Select(course => new
			{
				CourseID = course.ID,
				CourseName = course.Name,
				CourseTags = course.Tags.ToList()
			});

			foreach (var row in anonymousObjects)
			{
				Console.Write($@" {row.CourseID}: {row.CourseName} ({row.CourseTags.Count}:");
				for (int i = 0; i < row.CourseTags.Count; i++)
				{
					var tag = row.CourseTags[i];

					Console.Write(i != row.CourseTags.Count - 1 ? $@"{tag.Name}, " : $@"{tag.Name}");
				}
				Console.WriteLine(@")");
			}

			Console.WriteLine();
			#endregion

			#region [Group by Level]
			Console.WriteLine(@"#Group by Level");
			Console.WriteLine();

			var groupCoursesByLevel = context.Courses
				.GroupBy(course => course.Level);

			foreach (var row in groupCoursesByLevel)
			{
				Console.WriteLine($@" {row.Key} ({row.Count()})");
				foreach (var course in row)
					Console.WriteLine($@"  {course.ID}: {course.Name} ({course.Author.Name})");
				Console.WriteLine();
			}
			#endregion

			#region [Group Join]
			Console.WriteLine(@"#Group Join");
			Console.WriteLine();

			var groupJoinAuthorsWithCourses = context.Authors.GroupJoin
			(
				context.Courses,
				author => author.ID,
				course => course.AuthorID,
				(author, courses) => new
				{
					AuthorID = author.ID,
					AuthorName = author.Name,
					Courses = courses
				}
			);

			foreach (var row in groupJoinAuthorsWithCourses)
				Console.WriteLine($@" {row.AuthorID}: {row.AuthorName} ({row.Courses.Count()})");
			Console.WriteLine();
			#endregion

			#region [Cross Join]
			Console.WriteLine(@"#Cross Join");
			Console.WriteLine();

			var crossJoinAuthorsWithCourses = context.Authors.SelectMany
			(
				author => context.Courses,
				(author, course) => new
				{
					CourseID = course.ID,
					CourseName = course.Name,
					AuthorID = author.ID,
					AuthorName = author.Name
				}
			);

			foreach (var row in crossJoinAuthorsWithCourses)
				Console.WriteLine($@" {row.AuthorID}: {row.AuthorName} /{row.CourseID} : {row.CourseName})");
			Console.WriteLine();
			#endregion

			#region [Join]
			Console.WriteLine(@"#Join");
			Console.WriteLine();

			var joinCoursesWithAuthors = context.Courses.Join
			(
				context.Authors,
				course => course.AuthorID,
				author => author.ID,
				(course, author) => new
				{
					CourseID = course.ID,
					CourseName = course.Name,
					AuthorID = author.ID,
					AuthorName = author.Name
				}
			);

			foreach (var course in joinCoursesWithAuthors)
				Console.WriteLine($@" {course.CourseID}: {course.CourseName} ({course.AuthorName})");
			Console.WriteLine();
			#endregion

			#region [Partitions]
			Console.WriteLine(@"#Partition by CourseID");
			Console.WriteLine();

			var partitionByCourseID = context.Courses
				.OrderByDescending(course => course.ID)
				.Skip(3).Take(3);

			foreach (var row in partitionByCourseID)
				Console.WriteLine($@" {row.ID}: {row.Name} ({row.Author.Name})");
			Console.WriteLine();
			#endregion

			#region [Element Operators]
			Console.WriteLine(@"#Element Operators");
			Console.WriteLine();

			var firstCourse = context.Courses
				.OrderBy(course => course.Level)
				.FirstOrDefault(course => course.FullPrice > 100);

			Console.WriteLine($@" {firstCourse?.ID}: {firstCourse?.Name} ({firstCourse?.Author.Name})");
			Console.WriteLine();

			var lastCourse = context.Courses
				.OrderByDescending(course => course.Level)
				.FirstOrDefault(course => course.FullPrice > 100);

			Console.WriteLine($@" {lastCourse?.ID}: {lastCourse?.Name} ({lastCourse?.Author.Name})");
			Console.WriteLine();

			bool allAbove100Dollars = context.Courses.All(course => course.FullPrice > 100);
			bool anyBelow50Dollars = context.Courses.Any(course => course.FullPrice < 50);

			Console.WriteLine($@"All above 100? {allAbove100Dollars}");
			Console.WriteLine($@"Any below 50? {anyBelow50Dollars}");
			Console.WriteLine();

			float leastExpensiveCoursePrice = context.Courses.Min(course => course.FullPrice);
			float mostExpensiveCoursePrice = context.Courses.Max(course => course.FullPrice);
			float averageCoursePrice = context.Courses.Average(course => course.FullPrice);

			Console.WriteLine($@"Least expensive price: {leastExpensiveCoursePrice}");
			Console.WriteLine($@"Most expensive price: {mostExpensiveCoursePrice}");
			Console.WriteLine($@"Average price: {averageCoursePrice}");
			Console.WriteLine();
			#endregion
		}
	}
}
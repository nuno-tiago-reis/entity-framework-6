using System;
using PlutoDatabaseFirst.Model;

namespace PlutoDatabaseFirst
{
	public sealed class Program
	{
		public static void Main(string[] args)
		{
			var context = new PlutoDbContext();

			var courses = context.GetCourses();
			foreach (var course in courses)
			{
				Console.WriteLine(course.Title);
			}

			var authorCourses = context.GetAuthorCourses(0);
			foreach (var course in authorCourses)
			{
				Console.WriteLine(course.Title);
			}

		}
	}
}
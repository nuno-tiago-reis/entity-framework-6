using System.Collections.Generic;

using PlutoCodeFirst.Model;

namespace PlutoCodeFirst.Core.Repositories
{
	public interface ICourseRepository : IRepository<Course>
	{
		/// <summary>
		/// Gets the top selling courses.
		/// </summary>
		/// <param name="count">The count.</param>
		IEnumerable<Course> GetTopSellingCourses(int count);

		/// <summary>
		/// Gets the courses with authors.
		/// </summary>
		/// <param name="pageIndex">Index of the page.</param>
		/// <param name="pageSize">Size of the page.</param>
		IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize);
	}
}
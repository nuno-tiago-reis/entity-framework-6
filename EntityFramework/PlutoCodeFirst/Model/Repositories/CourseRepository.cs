using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PlutoCodeFirst.Core.Repositories;

namespace PlutoCodeFirst.Model.Repositories
{
	public sealed class CourseRepository : Repository<Course, PlutoContext>, ICourseRepository
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CourseRepository"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public CourseRepository(PlutoContext context) : base(context)
		{
			// Nothing to do here.
		}

		/// <inheritdoc />
		public IEnumerable<Course> GetTopSellingCourses(int count)
		{
			return this.Context.Courses.OrderByDescending(c => c.FullPrice).Take(count).ToList();
		}

		/// <inheritdoc />
		public IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize = 10)
		{
			return this.Context.Courses
				.Include(c => c.Author)
				.OrderBy(c => c.Name)
				.Skip((pageIndex - 1) * pageSize)
				.Take(pageSize)
				.ToList();
		}
	}
}
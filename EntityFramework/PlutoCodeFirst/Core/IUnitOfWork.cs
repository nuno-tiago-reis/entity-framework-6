using System;

using PlutoCodeFirst.Core.Repositories;

namespace PlutoCodeFirst.Core
{
	public interface IUnitOfWork : IDisposable
	{
		/// <summary>
		/// Gets the courses.
		/// </summary>
		ICourseRepository Courses { get; }

		/// <summary>
		/// Gets the authors.
		/// </summary>
		IAuthorRepository Authors { get; }

		/// <summary>
		/// Completes this unity of work.
		/// </summary>
		int Complete();
	}
}
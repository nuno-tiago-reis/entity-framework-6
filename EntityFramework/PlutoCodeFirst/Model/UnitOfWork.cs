using PlutoCodeFirst.Core;
using PlutoCodeFirst.Core.Repositories;
using PlutoCodeFirst.Model.Repositories;

namespace PlutoCodeFirst.Model
{
	public sealed class UnitOfWork : IUnitOfWork
	{
		/// <summary>
		/// The context.
		/// </summary>
		private readonly PlutoContext context;

		/// <inheritdoc />
		public ICourseRepository Courses { get; private set; }

		/// <inheritdoc />
		public IAuthorRepository Authors { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="UnitOfWork"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public UnitOfWork(PlutoContext context)
		{
			this.context = context;
			this.Courses = new CourseRepository(this.context);
			this.Authors = new AuthorRepository(this.context);
		}


		/// <inheritdoc />
		public int Complete()
		{
			return this.context.SaveChanges();
		}

		/// <inheritdoc />
		public void Dispose()
		{
			this.context.Dispose();
		}
	}
}
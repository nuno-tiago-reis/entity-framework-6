using System.Data.Entity;
using System.Linq;

using PlutoCodeFirst.Core.Repositories;

namespace PlutoCodeFirst.Model.Repositories
{
	public sealed class AuthorRepository : Repository<Author, PlutoContext>, IAuthorRepository
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AuthorRepository"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public AuthorRepository(PlutoContext context) : base(context)
		{
			// Nothing to do here.
		}

		/// <inheritdoc />
		public Author GetAuthorWithCourses(int id)
		{
			return this.Context.Authors.Include(a => a.Courses).SingleOrDefault(a => a.ID == id);
		}
	}
}
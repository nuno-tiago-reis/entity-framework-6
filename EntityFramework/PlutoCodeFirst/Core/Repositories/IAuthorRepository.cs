using PlutoCodeFirst.Model;

namespace PlutoCodeFirst.Core.Repositories
{
	public interface IAuthorRepository : IRepository<Author>
	{
		/// <summary>
		/// Gets an author with courses.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		Author GetAuthorWithCourses(int id);
	}
}
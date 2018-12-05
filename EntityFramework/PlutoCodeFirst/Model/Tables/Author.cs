using System.Collections.Generic;

namespace PlutoCodeFirst.Model
{
	public sealed class Author
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		public int ID { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the courses.
		/// </summary>
		public IList<Course> Courses { get; set; }
	}
}
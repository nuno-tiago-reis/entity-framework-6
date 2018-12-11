using System.Collections.Generic;

namespace PlutoCodeFirst.Model
{
	public class Tag
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
		public virtual IList<Course> Courses { get; set; }
	}
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlutoCodeFirst.Model
{
	public sealed class Tag
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		[Required]
		public int ID { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		[Required]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the courses.
		/// </summary>
		public IList<Course> Courses { get; set; }
	}
}
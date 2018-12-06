using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlutoDataAnnotations.Model
{
	[Table("Authors")]
	public class Author
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		[Key]
		[Required]
		public int ID { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		[Index]
		[Required]
		[MaxLength(255)]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the courses.
		/// </summary>
		public virtual IList<Course> Courses { get; set; }
	}
}
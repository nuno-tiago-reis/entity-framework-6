using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidzyDataAnnotations.Model
{
	[Table("Genres")]
	public class Genre
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
		/// Gets or sets the videos.
		/// </summary>
		public virtual IList<Video> Videos { get; set; }
	}
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidzyDataAnnotations.Model
{
	[Table("Videos")]
	public sealed class Video
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
		/// Gets or sets the genre id.
		/// </summary>
		[Required]
		public int GenreID { get; set; }

		/// <summary>
		/// Gets or sets the genre.
		/// </summary>
		public Genre Genre { get; set; }

		/// <summary>
		/// Gets or sets the tags.
		/// </summary>
		public IList<Tag> Tags { get; set; }

		/// <summary>
		/// Gets or sets the release date.
		/// </summary>
		[Required]
		public DateTime ReleaseDate { get; set; }

		/// <summary>
		/// Gets or sets the classification.
		/// </summary>
		[Required]
		public Classification Classification { get; set; }
	}

	public enum Classification : byte
	{
		Bronze = 0,
		Silver = 1,
		Gold = 2
	}
}
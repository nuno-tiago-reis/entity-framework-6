using System;
using System.Collections.Generic;

namespace VidzyCodeFirst.Model
{
	public sealed class Video
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
		/// Gets or sets the genre id.
		/// </summary>
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
		public DateTime ReleaseDate { get; set; }

		/// <summary>
		/// Gets or sets the classification.
		/// </summary>
		public Classification Classification { get; set; }
	}

	public enum Classification : byte
	{
		Bronze = 0,
		Silver = 1,
		Gold = 2
	}
}
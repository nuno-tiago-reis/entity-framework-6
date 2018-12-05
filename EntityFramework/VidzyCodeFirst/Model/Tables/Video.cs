using System;

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
		/// Gets or sets the genre.
		/// </summary>
		public Genre Genre { get; set; }

		/// <summary>
		/// Gets or sets the release date.
		/// </summary>
		public DateTime ReleaseDate { get; set; }
	}
}
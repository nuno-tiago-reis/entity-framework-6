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
		/// Gets or sets the release date.
		/// </summary>
		public DateTime ReleaseDate { get; set; }

		/// <summary>
		/// Gets or sets the genres.
		/// </summary>
		public IList<Genre> Genres { get; set; }
	}
}
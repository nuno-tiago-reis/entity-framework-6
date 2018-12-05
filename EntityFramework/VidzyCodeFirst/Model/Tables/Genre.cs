using System.Collections.Generic;

namespace VidzyCodeFirst.Model
{
	public sealed class Genre
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
		/// Gets or sets the videos.
		/// </summary>
		public IList<Video> Videos { get; set; }
	}
}
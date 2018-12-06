using System.Data.Entity.Migrations;

using JetBrains.Annotations;

using VidzyCodeFirst.Model;

namespace VidzyCodeFirst.Migrations
{
	[UsedImplicitly]
	internal sealed class Configuration : DbMigrationsConfiguration<VidzyContext>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Configuration"/> class.
		/// </summary>
		public Configuration()
		{
			this.AutomaticMigrationsEnabled = false;
		}

		/// <inheritdoc />
		protected override void Seed(VidzyContext context)
		{
			context.Genres.AddOrUpdate
			(
				genre => genre.Name,
			
				new Genre
				{
					Name = "Action",
				},
				new Genre
				{
					Name = "Comedy",
				},
				new Genre
				{
					Name = "Family",
				},
				new Genre
				{
					Name = "Horror",
				},
				new Genre
				{
					Name = "Romance",
				},
				new Genre
				{
					Name = "Fantasy",
				},
				new Genre
				{
					Name = "Thriller",
				}
			);
		}
	}
}
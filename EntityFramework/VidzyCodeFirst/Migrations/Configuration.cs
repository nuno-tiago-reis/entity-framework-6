using System;
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
					ID = 1,
					Name = "Action",
				},
				new Genre
				{
					ID = 2,
					Name = "Comedy",
				},
				new Genre
				{
					ID = 3,
					Name = "Drama",
				},
				new Genre
				{
					ID = 4,
					Name = "Family",
				},
				new Genre
				{
					ID = 5,
					Name = "Fantasy",
				},
				new Genre
				{
					ID = 6,
					Name = "Horror",
				},
				new Genre
				{
					ID = 7,
					Name = "Romance",
				},
				new Genre
				{
					ID = 8,
					Name = "Thriller",
				}
			);

			context.Videos.AddOrUpdate(video => video.ID, new Video
			{
				ID = 1,
				Name = "The Godfather",
				ReleaseDate = new DateTime(1972, 3, 24),
				Classification = Classification.Platinum,
				GenreID = 3
			});

			context.Videos.AddOrUpdate(video => video.ID, new Video
			{
				ID = 2,
				Name = "The Shawshank Redemption",
				ReleaseDate = new DateTime(1994, 9, 14),
				Classification = Classification.Gold,
				GenreID = 3
			});

			context.Videos.AddOrUpdate(video => video.ID, new Video
			{
				ID = 3,
				Name = "Schindler's List",
				ReleaseDate = new DateTime(1994, 2, 4),
				Classification = Classification.Gold,
				GenreID = 3
			});

			context.Videos.AddOrUpdate(video => video.ID, new Video
			{
				ID = 4,
				Name = "The Hangover",
				ReleaseDate = new DateTime(2009, 6, 11),
				Classification = Classification.Gold,
				GenreID = 2
			});

			context.Videos.AddOrUpdate(video => video.ID, new Video
			{
				ID = 5,
				Name = "Anchorman",
				ReleaseDate = new DateTime(2004, 4, 11),
				Classification = Classification.Silver,
				GenreID = 2
			});

			context.Videos.AddOrUpdate(video => video.ID, new Video
			{
				ID = 6,
				Name = "Die Hard",
				ReleaseDate = new DateTime(1988, 6, 13),
				Classification = Classification.Gold,
				GenreID = 1
			});

			context.Videos.AddOrUpdate(video => video.ID, new Video
			{
				ID = 7,
				Name = "The Dark Knight",
				ReleaseDate = new DateTime(2008, 1, 5),
				Classification = Classification.Gold,
				GenreID = 1
			});

			context.Videos.AddOrUpdate(video => video.ID, new Video
			{
				ID = 8,
				Name = "Terminator 2: Judgment Day",
				ReleaseDate = new DateTime(1991, 5, 15),
				Classification = Classification.Platinum,
				GenreID = 1
			});
		}
	}
}
using System;
using System.Linq;

using VidzyDataAnnotations.Model;

namespace VidzyDataAnnotations
{
	public sealed class Program
	{
		public static void Main(string[] args)
		{
			var context = new VidzyContext();

			#region Action Videos by Name
			Console.WriteLine(@"#Action Videos");

			var actionVideos = context.Videos
				.Where(video => video.Genre.Name == "Action")
				.OrderBy(video => video.Name);

			foreach (var row in actionVideos)
			{
				Console.WriteLine($@" {row.Name}");
			}
			Console.WriteLine();
			#endregion

			#region Gold Drama Videos by Release Date
			Console.WriteLine(@"#Gold Drama Videos");

			var dramaVideos = context.Videos
				.Where(video => video.Genre.Name == "Drama" && video.Classification == Classification.Gold)
				.OrderBy(video => video.ReleaseDate);

			foreach (var row in dramaVideos)
			{
				Console.WriteLine($@" {row.Name}");
			}
			Console.WriteLine();
			#endregion

			#region Videos with Genre
			Console.WriteLine(@"#Videos with Genre");

			var videosWithGenre = context.Videos.Join
			(
				context.Genres,
				video => video.GenreID,
				genre => genre.ID,
				(video, genre) => new
				{
					VideoName = video.Name,
					VideoGenre = genre.Name
				}
			);

			foreach (var row in videosWithGenre)
			{
				Console.WriteLine($@" {row.VideoGenre} ({row.VideoGenre})");
			}
			Console.WriteLine();
			#endregion

			#region Videos by Classification
			Console.WriteLine(@"#Videos with Genre");

			var videosByClassification = context.Videos
				.GroupBy(video => video.Classification)
				.Select(classificationGroup => new
				{
					Classification = classificationGroup.Key,
					Videos = classificationGroup.OrderBy(video => video.Name)
				});

			foreach (var row in videosByClassification)
			{
				Console.WriteLine($@" {row.Classification} ({row.Videos.Count()})");
				foreach (var video in row.Videos)
					Console.WriteLine($@"  {video.ID}: {video.Name} ({video.Genre.Name})");
				Console.WriteLine();
			}
			Console.WriteLine();
			#endregion

			#region Classifications with Video Count
			Console.WriteLine(@"#Classifications with Video Count");

			var classificationsWithVideoCount = context.Videos
				.GroupBy(video => video.Classification)
				.Select(classification => new
				{
					Classification = classification.Key,
					Count = classification.Count()
				})
				.OrderByDescending(classification => classification.Count);

			foreach (var row in classificationsWithVideoCount)
			{
				Console.WriteLine($@" {row.Classification} ({row.Count})");
			}
			Console.WriteLine();
			#endregion

			#region Genres with Video Count
			Console.WriteLine(@"#Genres with Video Count");

			var genresWithVideoCount = context.Genres
				.GroupJoin
				(
					context.Videos,
					genre => genre.ID,
					video => video.GenreID,
					(genre, videos) => new
					{
						Genre = genre.Name,
						Count = videos.Count()
					}
				)
				.OrderByDescending(genre => genre.Count);

			foreach (var row in genresWithVideoCount)
			{
				Console.WriteLine($@" {row.Genre} ({row.Count})");
			}
			Console.WriteLine();
			#endregion
		}
	}
}
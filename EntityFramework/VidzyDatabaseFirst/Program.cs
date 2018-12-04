using System;
using System.Collections.Generic;

using VidzyDatabaseFirst.Model;

namespace VidzyDatabaseFirst
{
	public sealed class Program
	{
		public static void Main(string[] args)
		{
			var context = new VidzyDbContext();

			var videos = new List<Video>
			{
				new Video
				{
					Name = "Harry Potter and the Philosophers Stone",
					ReleaseDate = DateTime.Today.AddYears(-18)
				},
				new Video
				{
					Name = "Harry Potter and the Chamber of Secrets",
					ReleaseDate = DateTime.Today.AddYears(-16)
				},
				new Video
				{
					Name = "Harry Potter and the Prisoner of Azkaban",
					ReleaseDate = DateTime.Today.AddYears(-14)
				},
				new Video
				{
					Name = "Harry Potter and the Goblet of Fire",
					ReleaseDate = DateTime.Today.AddYears(-12)
				},
				new Video
				{
					Name = "Harry Potter and the Order of the Phoenix",
					ReleaseDate = DateTime.Today.AddYears(-10)
				},
				new Video
				{
					Name = "Harry Potter and the Half Blood Prince",
					ReleaseDate = DateTime.Today.AddYears(-8)
				},
				new Video
				{
					Name = "Harry Potter and the Deathly Hallows: Part 1",
					ReleaseDate = DateTime.Today.AddYears(-6)
				},
				new Video
				{
					Name = "Harry Potter and the Deathly Hallows: Part 2",
					ReleaseDate = DateTime.Today.AddYears(-4)
				}

			};

			foreach (var video in videos)
			{
				context.AddVideo(video.Name, video.ReleaseDate, "Fantasy");
			}

			foreach (var video in context.Videos)
			{
				Console.WriteLine($"{video.Name}: {video.ReleaseDate}");
			}
		}
	}
}
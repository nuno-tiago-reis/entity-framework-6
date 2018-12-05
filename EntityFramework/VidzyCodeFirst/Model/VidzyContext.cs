using System.Data.Entity;

namespace VidzyCodeFirst.Model
{
	public sealed class VidzyContext : DbContext
	{
		/// <summary>
		/// Gets or sets the videos.
		/// </summary>
		public DbSet<Video> Videos { get; set; }

		/// <summary>
		/// Gets or sets the genres.
		/// </summary>
		public DbSet<Genre> Genres { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="VidzyContext"/> class.
		/// </summary>
		public VidzyContext() : base("name=DefaultConnection")
		{
			// Nothing to do here.
		}

		/// <inheritdoc />
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Conventions.Add(new IndexNamingConvention());
			modelBuilder.Conventions.Add(new ForeignKeyNamingConvention());
		}
	}
}
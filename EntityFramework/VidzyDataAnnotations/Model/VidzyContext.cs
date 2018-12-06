using System.Data.Entity;

namespace VidzyDataAnnotations.Model
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
		/// Gets or sets the tags.
		/// </summary>
		public DbSet<Tag> Tags { get; set; }

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

			// Modify the index and foreign key conventions
			modelBuilder.Conventions.Add(new IndexNamingConvention());
			modelBuilder.Conventions.Add(new ForeignKeyNamingConvention());
		}
	}
}
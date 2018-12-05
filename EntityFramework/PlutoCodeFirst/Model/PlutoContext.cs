using System.Data.Entity;

namespace PlutoCodeFirst.Model
{
	public sealed class PlutoContext : DbContext
	{
		/// <summary>
		/// Gets or sets the courses.
		/// </summary>
		public DbSet<Course> Courses { get; set; }

		/// <summary>
		/// Gets or sets the tags.
		/// </summary>
		public DbSet<Tag> Tags { get; set; }

		/// <summary>
		/// Gets or sets the authors.
		/// </summary>
		public DbSet<Author> Authors { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="PlutoContext"/> class.
		/// </summary>
		public PlutoContext() : base("name=DefaultConnection")
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

			// Modify the configurations
			modelBuilder.Configurations.Add(new AuthorConfiguration());
			modelBuilder.Configurations.Add(new CourseConfiguration());
			modelBuilder.Configurations.Add(new TagConfiguration());
		}
	}
}
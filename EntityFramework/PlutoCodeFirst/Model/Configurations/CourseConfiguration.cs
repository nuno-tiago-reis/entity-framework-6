using System.Data.Entity.ModelConfiguration;

namespace PlutoCodeFirst.Model
{
	public sealed class CourseConfiguration : EntityTypeConfiguration<Course>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CourseConfiguration"/> class.
		/// </summary>
		public CourseConfiguration()
		{
			this.ToTable("Courses");

			// Keys and indices
			this.HasKey(course => course.ID);
			this.HasIndex(course => course.Name);

			// Columns
			this.Property(course => course.Name)
				.IsRequired()
				.HasMaxLength(255);

			this.Property(course => course.Description)
				.IsRequired()
				.HasMaxLength(1000);

			this.Property(course => course.Level)
				.IsRequired();

			this.Property(course => course.FullPrice)
				.IsRequired();

			// Relationships
			this.HasRequired(course => course.Author)
				.WithMany(author => author.Courses)
				.HasForeignKey(course => course.AuthorID)
				.WillCascadeOnDelete();

			this.HasMany(course => course.Tags)
				.WithMany(tag => tag.Courses)
				.Map(map =>
				{
					map.ToTable("CourseTags");
					map.MapLeftKey("CourseID");
					map.MapRightKey("TagID");
				});
		}
	}
}
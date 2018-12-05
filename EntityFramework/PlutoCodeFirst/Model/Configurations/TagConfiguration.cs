using System.Data.Entity.ModelConfiguration;

namespace PlutoCodeFirst.Model
{
	public sealed class TagConfiguration : EntityTypeConfiguration<Tag>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TagConfiguration"/> class.
		/// </summary>
		public TagConfiguration()
		{
			this.ToTable("Tags");

			// Keys and indices
			this.HasKey(course => course.ID);
			this.HasIndex(course => course.Name);

			// Columns
			this.Property(course => course.Name)
				.IsRequired()
				.HasMaxLength(255);

			// Relationships
			this.HasMany(tag => tag.Courses)
				.WithMany(course => course.Tags)
				.Map(map =>
				{
					map.ToTable("CourseTags");
					map.MapLeftKey("TagID");
					map.MapRightKey("CourseID");
				});
		}
	}
}
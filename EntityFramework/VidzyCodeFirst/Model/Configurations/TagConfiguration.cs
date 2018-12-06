using System.Data.Entity.ModelConfiguration;

namespace VidzyCodeFirst.Model
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
			this.HasMany(tag => tag.Videos)
				.WithMany(video => video.Tags)
				.Map(map =>
				{
					map.ToTable("VideoTags");
					map.MapLeftKey("TagID");
					map.MapRightKey("VideoID");
				});
		}
	}
}
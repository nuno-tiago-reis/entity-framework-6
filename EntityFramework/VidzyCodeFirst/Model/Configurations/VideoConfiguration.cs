using System.Data.Entity.ModelConfiguration;

namespace VidzyCodeFirst.Model
{
	public sealed class VideoConfiguration : EntityTypeConfiguration<Video>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="VideoConfiguration"/> class.
		/// </summary>
		public VideoConfiguration()
		{
			this.ToTable("Videos");

			// Keys and indices
			this.HasKey(course => course.ID);
			this.HasIndex(course => course.Name);

			// Columns
			this.Property(course => course.Name)
				.IsRequired()
				.HasMaxLength(255);

			this.Property(course => course.ReleaseDate)
				.IsRequired();

			this.Property(course => course.Classification)
				.IsRequired();

			// Relationships
			this.HasRequired(video => video.Genre)
				.WithMany(genre => genre.Videos)
				.HasForeignKey(video => video.GenreID)
				.WillCascadeOnDelete();

			this.HasMany(video => video.Tags)
				.WithMany(tag => tag.Videos)
				.Map(map =>
				{
					map.ToTable("VideoTags");
					map.MapLeftKey("VideoID");
					map.MapRightKey("TagID");
				});
		}
	}
}
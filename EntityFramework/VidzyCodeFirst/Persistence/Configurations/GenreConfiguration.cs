using System.Data.Entity.ModelConfiguration;

namespace VidzyCodeFirst.Model
{
	public sealed class GenreConfiguration : EntityTypeConfiguration<Genre>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GenreConfiguration"/> class.
		/// </summary>
		public GenreConfiguration()
		{
			this.ToTable("Genres");

			// Keys and indices
			this.HasKey(author => author.ID);
			this.HasIndex(author => author.Name);

			// Columns
			this.Property(author => author.Name)
				.IsRequired()
				.HasMaxLength(255);

			// Relationships
			this.HasMany(tag => tag.Videos);
		}
	}
}
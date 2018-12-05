using System.Data.Entity.ModelConfiguration;

namespace PlutoCodeFirst.Model
{
	public sealed class AuthorConfiguration : EntityTypeConfiguration<Author>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AuthorConfiguration"/> class.
		/// </summary>
		public AuthorConfiguration()
		{
			this.ToTable("Authors");

			// Keys and indices
			this.HasKey(author => author.ID);
			this.HasIndex(author => author.Name);

			// Columns
			this.Property(author => author.Name)
				.IsRequired()
				.HasMaxLength(255);

			// Relationships
			this.HasMany(author => author.Courses);
		}
	}
}
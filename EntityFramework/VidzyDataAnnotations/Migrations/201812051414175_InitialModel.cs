namespace VidzyDataAnnotations.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class InitialModel : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			this.CreateTable
			(
				"dbo.Genres",
				c => new
				{
					ID = c.Int(nullable: false, identity: true),
					Name = c.String(),
				}
			)
			.PrimaryKey(t => t.ID);

			this.CreateTable
			(
				"dbo.Videos",
				c => new
				{
					ID = c.Int(nullable: false, identity: true),
					Name = c.String(),
					ReleaseDate = c.DateTime(nullable: false),
				}
			)
			.PrimaryKey(t => t.ID);

			this.CreateTable
			(
				"dbo.VideoGenres",
				c => new
				{
					VideoID = c.Int(nullable: false),
					GenreID = c.Int(nullable: false),
				}
			)
			.PrimaryKey(t => new { t.VideoID, t.GenreID })
			.ForeignKey("dbo.Videos", t => t.VideoID, cascadeDelete: true)
			.ForeignKey("dbo.Genres", t => t.GenreID, cascadeDelete: true)
			.Index(t => t.VideoID)
			.Index(t => t.GenreID);
		}

		/// <inheritdoc />
		public override void Down()
		{
			this.DropForeignKey("dbo.VideoGenres", "GenreID", "dbo.Genres");
			this.DropForeignKey("dbo.VideoGenres", "VideoID", "dbo.Videos");
			this.DropIndex("dbo.VideoGenres", new[] { "GenreID" });
			this.DropIndex("dbo.VideoGenres", new[] { "VideoID" });
			this.DropTable("dbo.VideoGenres");
			this.DropTable("dbo.Videos");
			this.DropTable("dbo.Genres");
		}
	}
}
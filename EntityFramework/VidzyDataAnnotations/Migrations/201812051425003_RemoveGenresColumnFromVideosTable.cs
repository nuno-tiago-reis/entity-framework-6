namespace VidzyDataAnnotations.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class RemoveGenresColumnFromVideosTable : DbMigration
	{
		public override void Up()
		{
			this.DropForeignKey("dbo.VideoGenres", "VideoID", "dbo.Videos");
			this.DropForeignKey("dbo.VideoGenres", "GenreID", "dbo.Genres");
			this.DropIndex("dbo.VideoGenres", new[] { "VideoID" });
			this.DropIndex("dbo.VideoGenres", new[] { "GenreID" });
			this.DropTable("dbo.VideoGenres");
		}

		public override void Down()
		{
			this.CreateTable
			(
				"dbo.VideoGenres",
				c => new
				{
					VideoID = c.Int(nullable: false),
					GenreID = c.Int(nullable: false),
				}
			)
			.PrimaryKey(t => new { t.VideoID, t.GenreID });

			this.CreateIndex("dbo.VideoGenres", "GenreID");
			this.CreateIndex("dbo.VideoGenres", "VideoID");
			this.AddForeignKey("dbo.VideoGenres", "GenreID", "dbo.Genres", "ID", cascadeDelete: true);
			this.AddForeignKey("dbo.VideoGenres", "VideoID", "dbo.Videos", "ID", cascadeDelete: true);
		}
	}
}
namespace VidzyCodeFirst.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class UpdateVideosToGenresRelationship : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			this.DropForeignKey("dbo.Videos", "GenreID", "dbo.Genres");
			this.DropIndex("dbo.Videos", new[] { "GenreID" });
			this.AlterColumn("dbo.Videos", "GenreID", c => c.Int(nullable: false));
			this.CreateIndex("dbo.Videos", "GenreID");
			this.AddForeignKey("dbo.Videos", "GenreID", "dbo.Genres", "ID", cascadeDelete: true);
		}

		/// <inheritdoc />
		public override void Down()
		{
			this.DropForeignKey("dbo.Videos", "GenreID", "dbo.Genres");
			this.DropIndex("dbo.Videos", new[] { "GenreID" });
			this.AlterColumn("dbo.Videos", "GenreID", c => c.Int());
			this.CreateIndex("dbo.Videos", "GenreID");
			this.AddForeignKey("dbo.Videos", "GenreID", "dbo.Genres", "ID");
		}
	}
}
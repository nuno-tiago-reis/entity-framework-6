namespace VidzyCodeFirst.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class AddGenreColumnToVideosTable : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			this.AddColumn("dbo.Videos", "GenreID", c => c.Int());
			this.CreateIndex("dbo.Videos", "GenreID");
			this.AddForeignKey("dbo.Videos", "GenreID", "dbo.Genres", "ID");
		}

		/// <inheritdoc />
		public override void Down()
		{
			this.DropForeignKey("dbo.Videos", "GenreID", "dbo.Genres");
			this.DropIndex("dbo.Videos", new[] { "GenreID" });
			this.DropColumn("dbo.Videos", "GenreID");
		}
	}
}
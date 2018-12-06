namespace VidzyCodeFirst.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class AddVideosToTagsRelationship : DbMigration
	{
		public override void Up()
		{
			this.CreateTable
			(
				"dbo.VideoTags",
				c => new
				{
					TagID = c.Int(nullable: false),
					VideoID = c.Int(nullable: false),
				}
			)
			.PrimaryKey(t => new { t.TagID, t.VideoID })
			.ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
			.ForeignKey("dbo.Videos", t => t.VideoID, cascadeDelete: true)
			.Index(t => t.TagID)
			.Index(t => t.VideoID);

		}

		public override void Down()
		{
			this.DropForeignKey("dbo.VideoTags", "VideoID", "dbo.Videos");
			this.DropForeignKey("dbo.VideoTags", "TagID", "dbo.Tags");
			this.DropIndex("dbo.VideoTags", new[] { "VideoID" });
			this.DropIndex("dbo.VideoTags", new[] { "TagID" });
			this.DropTable("dbo.VideoTags");
		}
	}
}
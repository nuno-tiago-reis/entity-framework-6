namespace VidzyDataAnnotations.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class RenameVideoTagsTable : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			// Not possible to rename this table without using fluent api
			this.RenameTable(name: "dbo.VideoTags", newName: "TagVideos");
		}

		/// <inheritdoc />
		public override void Down()
		{
			// Not possible to rename this table without using fluent api
			this.RenameTable(name: "dbo.TagVideos", newName: "VideoTags");
		}
	}
}
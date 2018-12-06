namespace VidzyDataAnnotations.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class AddClassificationColumnToVideosTable : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			this.AddColumn("dbo.Videos", "Classification", c => c.Int(nullable: false));
		}

		/// <inheritdoc />
		public override void Down()
		{
			this.DropColumn("dbo.Videos", "Classification");
		}
	}
}

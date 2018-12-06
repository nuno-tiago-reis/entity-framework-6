namespace VidzyDataAnnotations.Migrations
{
	using System.Data.Entity.Migrations;
	
	public partial class UpdateNullableColumnsInVideosTable : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			this.AlterColumn("dbo.Videos", "Name", c => c.String(nullable: false, maxLength: 255));
			this.CreateIndex("dbo.Videos", "Name");
		}

		/// <inheritdoc />
		public override void Down()
		{
			this.DropIndex("dbo.Videos", new[] { "Name" });
			this.AlterColumn("dbo.Videos", "Name", c => c.String());
		}
	}
}
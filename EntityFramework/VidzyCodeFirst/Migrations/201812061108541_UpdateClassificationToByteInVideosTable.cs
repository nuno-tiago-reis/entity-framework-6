namespace VidzyCodeFirst.Migrations
{
	using System.Data.Entity.Migrations;
	
	public partial class UpdateClassificationToByteInVideosTable : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			this.AlterColumn("dbo.Videos", "Classification", c => c.Byte(nullable: false));
		}

		/// <inheritdoc />
		public override void Down()
		{
			this.AlterColumn("dbo.Videos", "Classification", c => c.Int(nullable: false));
		}
	}
}
namespace VidzyCodeFirst.Migrations
{
	using System.Data.Entity.Migrations;
	
	public partial class UpdateNullableColumnsInGenresTable : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			this.AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
			this.CreateIndex("dbo.Genres", "Name");
		}

		/// <inheritdoc />
		public override void Down()
		{
			this.DropIndex("dbo.Genres", new[] { "Name" });
			this.AlterColumn("dbo.Genres", "Name", c => c.String());
		}
	}
}
namespace PlutoDataAnnotations.Migrations
{
	using System.Data.Entity.Migrations;
	
	public partial class UpdateNameColumnLengthAndIndexInTagsTable : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			this.AlterColumn("dbo.Tags", "Name", c => c.String(nullable: false, maxLength: 255));
			this.CreateIndex("dbo.Tags", "Name");
		}

		/// <inheritdoc />
		public override void Down()
		{
			this.DropIndex("dbo.Tags", new[] { "Name" });
			this.AlterColumn("dbo.Tags", "Name", c => c.String(nullable: false));
		}
	}
}
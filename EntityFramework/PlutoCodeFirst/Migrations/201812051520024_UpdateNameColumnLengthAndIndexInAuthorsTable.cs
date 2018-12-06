namespace PlutoCodeFirst.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class UpdateNameColumnLengthAndIndexInAuthorsTable : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			this.AlterColumn("dbo.Authors", "Name", c => c.String(nullable: false, maxLength: 255));
			this.CreateIndex("dbo.Authors", "Name");
		}

		/// <inheritdoc />
		public override void Down()
		{
			this.DropIndex("dbo.Authors", new[] { "Name" });
			this.AlterColumn("dbo.Authors", "Name", c => c.String(nullable: false));
		}
	}
}

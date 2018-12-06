namespace PlutoCodeFirst.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class UpdateNullableColumnsInTagsTable : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			this.AlterColumn("dbo.Tags", "Name", c => c.String(nullable: false));
		}

		/// <inheritdoc />
		public override void Down()
		{
			this.AlterColumn("dbo.Tags", "Name", c => c.String());
		}
	}
}
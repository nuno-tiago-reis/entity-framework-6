namespace PlutoDataAnnotations.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class UpdateNullableColumnsInAuthorsTable : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			this.AlterColumn("dbo.Authors", "Name", c => c.String(nullable: false));
		}

		/// <inheritdoc />
		public override void Down()
		{
			this.AlterColumn("dbo.Authors", "Name", c => c.String());
		}
	}
}
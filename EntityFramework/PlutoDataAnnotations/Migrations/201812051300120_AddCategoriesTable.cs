namespace PlutoDataAnnotations.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class AddCategoriesTable : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			this.CreateTable
			(
				"dbo.Categories",
				c => new
				{
					ID = c.Int(nullable: false, identity: true),
					Name = c.String(),
				}
			)
			.PrimaryKey(t => t.ID);

			this.Sql("INSERT INTO Categories (Name) VALUES ('Web Development')");
			this.Sql("INSERT INTO Categories (Name) VALUES ('Game Development')");
			this.Sql("INSERT INTO Categories (Name) VALUES ('Programming Languages')");
		}

		/// <inheritdoc />
		public override void Down()
		{
			this.DropTable("dbo.Categories");
		}
	}
}
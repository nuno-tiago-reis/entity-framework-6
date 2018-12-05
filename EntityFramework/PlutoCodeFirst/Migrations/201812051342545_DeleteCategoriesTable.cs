namespace PlutoCodeFirst.Migrations
{
	using System.Data.Entity.Migrations;
	
	public partial class DeleteCategoriesTable : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			this.CreateTable
			(
				"dbo._CategoriesBackup",
				c => new
				{
					ID = c.Int(nullable: false, identity: true),
					Name = c.String(),
				}
			)
			.PrimaryKey(t => t.ID);

			this.Sql("INSERT INTO _CategoriesBackup (Name) SELECT Name FROM Categories");

			this.DropTable("dbo.Categories");
		}

		/// <inheritdoc />
		public override void Down()
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

			this.Sql("INSERT INTO Categories (Name) SELECT Name FROM _CategoriesBackup");

			this.DropTable("dbo._CategoriesBackup");
		}
	}
}
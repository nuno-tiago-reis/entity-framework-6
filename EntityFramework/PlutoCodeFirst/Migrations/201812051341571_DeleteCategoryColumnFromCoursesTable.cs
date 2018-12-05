namespace PlutoCodeFirst.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class DeleteCategoryColumnFromCoursesTable : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			this.DropForeignKey("dbo.Courses", "CategoryID", "dbo.Categories");
			this.DropIndex("dbo.Courses", new[] { "CategoryID" });
			this.DropColumn("dbo.Courses", "CategoryID");
		}

		/// <inheritdoc />
		public override void Down()
		{
			this.AddColumn("dbo.Courses", "CategoryID", c => c.Int());
			this.CreateIndex("dbo.Courses", "CategoryID");
			this.AddForeignKey("dbo.Courses", "CategoryID", "dbo.Categories", "ID");
		}
	}
}

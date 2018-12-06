namespace PlutoDataAnnotations.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class AddCategoryColumnToCoursesTable : DbMigration
	{
		public override void Up()
		{
			this.AddColumn("dbo.Courses", "CategoryID", c => c.Int());
			this.CreateIndex("dbo.Courses", "CategoryID");
			this.AddForeignKey("dbo.Courses", "CategoryID", "dbo.Categories", "ID");

			this.Sql("UPDATE Courses SET CategoryID = 1");
		}

		public override void Down()
		{
			this.DropForeignKey("dbo.Courses", "CategoryID", "dbo.Categories");
			this.DropIndex("dbo.Courses", new[] { "CategoryID" });
			this.DropColumn("dbo.Courses", "CategoryID");
		}
	}
}
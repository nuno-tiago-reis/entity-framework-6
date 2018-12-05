namespace PlutoCodeFirst.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class UpdatedNullableColumnsInCoursesTable : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			this.DropForeignKey("dbo.Courses", "AuthorID", "dbo.Authors");
			this.DropIndex("dbo.Courses", new[] { "AuthorID" });
			this.AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false));
			this.AlterColumn("dbo.Courses", "Description", c => c.String(nullable: false));
			this.AlterColumn("dbo.Courses", "AuthorID", c => c.Int(nullable: false));
			this.CreateIndex("dbo.Courses", "AuthorID");
			this.AddForeignKey("dbo.Courses", "AuthorID", "dbo.Authors", "ID", cascadeDelete: true);
		}

		/// <inheritdoc />
		public override void Down()
		{
			this.DropForeignKey("dbo.Courses", "AuthorID", "dbo.Authors");
			this.DropIndex("dbo.Courses", new[] { "AuthorID" });
			this.AlterColumn("dbo.Courses", "AuthorID", c => c.Int());
			this.AlterColumn("dbo.Courses", "Description", c => c.String());
			this.AlterColumn("dbo.Courses", "Name", c => c.String());
			this.CreateIndex("dbo.Courses", "AuthorID");
			this.AddForeignKey("dbo.Courses", "AuthorID", "dbo.Authors", "ID");
		}
	}
}
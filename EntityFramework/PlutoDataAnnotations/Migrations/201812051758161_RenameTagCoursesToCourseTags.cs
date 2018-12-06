namespace PlutoDataAnnotations.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class RenameTagCoursesToCourseTags : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			this.RenameTable(name: "dbo.TagCourses", newName: "CourseTags");
			this.DropPrimaryKey("dbo.CourseTags");
			this.AlterColumn("dbo.Courses", "Description", c => c.String(nullable: false, maxLength: 1000));
			this.AddPrimaryKey("dbo.CourseTags", new[] { "CourseID", "TagID" });
		}

		/// <inheritdoc />
		public override void Down()
		{
			this.DropPrimaryKey("dbo.CourseTags");
			this.AlterColumn("dbo.Courses", "Description", c => c.String(nullable: false, maxLength: 511));
			this.AddPrimaryKey("dbo.CourseTags", new[] { "TagID", "CourseID" });
			this.RenameTable(name: "dbo.CourseTags", newName: "TagCourses");
		}
	}
}

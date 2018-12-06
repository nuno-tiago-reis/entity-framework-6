namespace PlutoDataAnnotations.Migrations
{
	using System.Data.Entity.Migrations;
	
	public partial class RenameCourseTagsToTagCourses : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			this.RenameTable(name: "dbo.CourseTags", newName: "TagCourses");
		}

		/// <inheritdoc />
		public override void Down()
		{
			this.RenameTable(name: "dbo.TagCourses", newName: "CourseTags");
		}
	}
}
namespace PlutoCodeFirst.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class RenameTitleToNameInCoursesTable : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			this.RenameColumn("dbo.Courses", "Title", "Name");
		}

		/// <inheritdoc />
		public override void Down()
		{
			this.RenameColumn("dbo.Courses", "Name", "Title");
		}
	}
}
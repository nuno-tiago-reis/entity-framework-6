namespace PlutoDataAnnotations.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class AddDatePublishedColumnToCoursesTable : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			this.AddColumn("dbo.Courses", "DatePublished", c => c.DateTime());
		}

		/// <inheritdoc />
		public override void Down()
		{
			this.DropColumn("dbo.Courses", "DatePublished");
		}
	}
}

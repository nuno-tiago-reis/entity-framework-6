namespace PlutoDataAnnotations.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class DeleteDatePublishedColumnFromCoursesTable : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			this.DropColumn("dbo.Courses", "DatePublished");
		}

		/// <inheritdoc />
		public override void Down()
		{
			this.AddColumn("dbo.Courses", "DatePublished", c => c.DateTime());
		}
	}
}
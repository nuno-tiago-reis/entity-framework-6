namespace PlutoCodeFirst.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class UpdateDescriptionColumnLengthInCoursesTable : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			this.AlterColumn("dbo.Courses", "Description", c => c.String(nullable: false, maxLength: 511));
		}

		/// <inheritdoc />
		public override void Down()
		{
			this.AlterColumn("dbo.Courses", "Description", c => c.String(nullable: false));
		}
	}
}
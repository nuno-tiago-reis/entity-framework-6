namespace PlutoDataAnnotations.Migrations
{
	using System.Data.Entity.Migrations;
	
	public partial class UpdateNameColumnLengthAndIndexInCoursesTable : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			this.AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 255));
			this.CreateIndex("dbo.Courses", "Name");
		}

		/// <inheritdoc />
		public override void Down()
		{
			this.DropIndex("dbo.Courses", new[] { "Name" });
			this.AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false));
		}
	}
}
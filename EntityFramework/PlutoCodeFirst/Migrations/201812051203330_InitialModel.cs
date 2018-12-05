namespace PlutoCodeFirst.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class InitialModel : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			this.CreateTable
			(
				"dbo.Authors",
				c => new
				{
					ID = c.Int(nullable: false, identity: true),
					Name = c.String(),
				}
			)
			.PrimaryKey(t => t.ID);

			this.CreateTable
			(
				"dbo.Courses",
				c => new
				{
					ID = c.Int(nullable: false, identity: true),
					Title = c.String(),
					Description = c.String(),
					Level = c.Int(nullable: false),
					FullPrice = c.Single(nullable: false),
					AuthorID = c.Int(),
				}
			)
			.PrimaryKey(t => t.ID)
			.ForeignKey("dbo.Authors", t => t.AuthorID)
			.Index(t => t.AuthorID);

			this.CreateTable
			(
				"dbo.Tags",
				c => new
				{
					ID = c.Int(nullable: false, identity: true),
					Name = c.String(),
				}
			)
			.PrimaryKey(t => t.ID);

			this.CreateTable
			(
				"dbo.TagCourses",
				c => new
				{
					TagID = c.Int(nullable: false),
					CourseID = c.Int(nullable: false),
				}
			)
			.PrimaryKey(t => new { t.TagID, t.CourseID })
			.ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
			.ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
			.Index(t => t.TagID)
			.Index(t => t.CourseID);
		}

		/// <inheritdoc />
		public override void Down()
		{
			this.DropForeignKey("dbo.TagCourses", "CourseID", "dbo.Courses");
			this.DropForeignKey("dbo.TagCourses", "TagID", "dbo.Tags");
			this.DropForeignKey("dbo.Courses", "AuthorID", "dbo.Authors");
			this.DropIndex("dbo.TagCourses", new[] { "CourseID" });
			this.DropIndex("dbo.TagCourses", new[] { "TagID" });
			this.DropIndex("dbo.Courses", new[] { "AuthorID" });
			this.DropTable("dbo.TagCourses");
			this.DropTable("dbo.Tags");
			this.DropTable("dbo.Courses");
			this.DropTable("dbo.Authors");
		}
	}
}

namespace VidzyCodeFirst.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class AddTagsTable : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			this.CreateTable
			(
				"dbo.Tags",
				c => new
				{
					ID = c.Int(nullable: false, identity: true),
					Name = c.String(),
					VideoID = c.Int(),
				}
			)
			.PrimaryKey(t => t.ID);
		}

		/// <inheritdoc />
		public override void Down()
		{
			this.DropTable("dbo.Tags");
		}
	}
}
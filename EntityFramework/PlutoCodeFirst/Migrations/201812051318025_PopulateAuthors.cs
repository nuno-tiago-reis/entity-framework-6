namespace PlutoCodeFirst.Migrations
{
	using System.Data.Entity.Migrations;
	
	public partial class PopulateAuthors : DbMigration
	{
		/// <inheritdoc />
		public override void Up()
		{
			this.Sql("INSERT INTO Authors(Name) VALUES('Mosh Hamedani')");
			this.Sql("INSERT INTO Authors(Name) VALUES('Ben Tristem')");
		}

		/// <inheritdoc />
		public override void Down()
		{
			this.Sql("DELETE FROM Authors WHERE Name = 'Mosh Hamedani'");
			this.Sql("DELETE FROM Authors WHERE Name = 'Ben Tristem'");
		}
	}
}

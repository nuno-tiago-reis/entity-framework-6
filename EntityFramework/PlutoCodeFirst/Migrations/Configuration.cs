using System.Data.Entity.Migrations;

using JetBrains.Annotations;

using PlutoCodeFirst.Model;

namespace PlutoCodeFirst.Migrations
{
	[UsedImplicitly]
	internal sealed class Configuration : DbMigrationsConfiguration<PlutoContext>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Configuration"/> class.
		/// </summary>
		public Configuration()
		{
			this.AutomaticMigrationsEnabled = true;
		}

		/// <inheritdoc />
		protected override void Seed(PlutoContext context)
		{
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data.
		}
	}
}

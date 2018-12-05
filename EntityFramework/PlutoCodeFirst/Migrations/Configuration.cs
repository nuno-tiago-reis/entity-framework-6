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
			this.AutomaticMigrationsEnabled = false;
		}

		/// <inheritdoc />
		protected override void Seed(PlutoContext context)
		{
			// Nothing to do here.
		}
	}
}

using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace VidzyCodeFirst.Model
{
	public sealed class ForeignKeyNamingConvention : IStoreModelConvention<AssociationType>
	{
		/// <inheritdoc />
		public void Apply(AssociationType association, DbModel model)
		{
			if (!association.IsForeignKey)
				return;

			var constraint = association.Constraint;

			if (DoPropertiesHaveDefaultNames(constraint.FromProperties, constraint.ToProperties))
			{
				NormalizeForeignKeyProperties(constraint.FromProperties);
			}
			if (DoPropertiesHaveDefaultNames(constraint.ToProperties, constraint.FromProperties))
			{
				NormalizeForeignKeyProperties(constraint.ToProperties);
			}
		}

		/// <summary>
		/// Does the properties have default names.
		/// </summary>
		/// 
		/// <param name="properties">The properties.</param>
		/// <param name="otherEndProperties">The other end properties.</param>
		private static bool DoPropertiesHaveDefaultNames(IReadOnlyCollection<EdmProperty> properties, IReadOnlyList<EdmProperty> otherEndProperties)
		{
			if (properties.Count != otherEndProperties.Count)
			{
				return false;
			}

			return !properties.Where((property, i) => !property.Name.EndsWith("_" + otherEndProperties[i].Name)).Any();
		}

		/// <summary>
		/// Normalizes the foreign key properties.
		/// </summary>
		/// 
		/// <param name="properties">The properties.</param>
		private static void NormalizeForeignKeyProperties(IEnumerable<EdmProperty> properties)
		{
			foreach (var property in properties)
			{
				string defaultPropertyName = property.Name;

				int underscoreIndex = defaultPropertyName.IndexOf('_');
				if (underscoreIndex <= 0)
				{
					continue;
				}

				string navigationPropertyName = defaultPropertyName.Substring(0, underscoreIndex);
				string targetKey = defaultPropertyName.Substring(underscoreIndex + 1);

				string newPropertyName;
				if (targetKey.StartsWith(navigationPropertyName))
				{
					newPropertyName = targetKey;
				}
				else
				{
					newPropertyName = navigationPropertyName + targetKey;
				}

				property.Name = newPropertyName;
			}
		}
	}
}
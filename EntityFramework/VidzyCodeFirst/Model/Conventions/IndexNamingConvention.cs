using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace VidzyCodeFirst.Model
{
	public sealed class IndexNamingConvention : IStoreModelConvention<EntityType>
	{
		/// <inheritdoc />
		public void Apply(EntityType item, DbModel model)
		{
			var indexInfos = new List<IndexInfo>();

			foreach (var property in item.Properties)
			{
				foreach (var metadataProperty in property.MetadataProperties)
				{
					if (!(metadataProperty.Value is IndexAnnotation annotation))
						continue;

					foreach (var index in annotation.Indexes)
					{
						var info = index.Name != null ? indexInfos.FirstOrDefault(e => e.Name == index.Name) : null;
						if (info == null)
						{
							info = new IndexInfo { Name = index.Name };
							indexInfos.Add(info);
						}
						else
						{
							var other = info.Entries[0].Index;
							if (index.IsUnique != other.IsUnique || index.IsClustered != other.IsClustered)
								throw new Exception("Invalid index configuration.");
						}

						info.Entries.Add(new IndexEntry { Column = property, Annotation = metadataProperty, Index = index });
					}
				}
			}

			if (indexInfos.Count == 0)
				return;

			foreach (var indexInfo in indexInfos)
			{
				var columns = indexInfo.Entries.OrderBy(e => e.Index.Order).Select(e => e.Column.Name).ToList();

				if (indexInfo.Name != null && indexInfo.Name != IndexOperation.BuildDefaultName(columns))
					continue;

				bool unique = indexInfo.Entries[0].Index.IsUnique;

				string name = $"{(unique ? "UX" : "IX")}_{string.Join("_", columns.Select(column => column.Replace("_", string.Empty)))}";

				if (name.Length > 128) name = name.Substring(0, 128);
				if (indexInfo.Name == name)
					continue;

				foreach (var entry in indexInfo.Entries)
				{
					var index = new IndexAttribute(name);
					if (entry.Index.Order >= 0)
						index.Order = entry.Index.Order;
					if (entry.Index.IsUniqueConfigured)
						index.IsUnique = entry.Index.IsUnique;
					if (entry.Index.IsClusteredConfigured)
						index.IsClustered = entry.Index.IsClustered;

					entry.Index = index;
					entry.Modified = true;
				}
			}

			foreach (var indexInfo in indexInfos.SelectMany(ii => ii.Entries).GroupBy(e => e.Annotation))
			{
				if (indexInfo.Any(e => e.Modified))
					indexInfo.Key.Value = new IndexAnnotation(indexInfo.Select(e => e.Index));
			}
		}

		private sealed class IndexInfo
		{
			public string Name;
			public readonly List<IndexEntry> Entries = new List<IndexEntry>();
		}

		private sealed class IndexEntry
		{
			public EdmProperty Column;
			public MetadataProperty Annotation;
			public IndexAttribute Index;
			public bool Modified;
		}
	}
}
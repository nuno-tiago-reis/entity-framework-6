﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlutoDataAnnotations.Model
{
	[Table("Courses")]
	public sealed class Course
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		[Key]
		[Required]
		public int ID { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		[Index]
		[Required]
		[MaxLength(255)]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		[Required]
		[MaxLength(1000)]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the full price.
		/// </summary>
		[Required]
		public float FullPrice { get; set; }

		/// <summary>
		/// Gets or sets the level.
		/// </summary>
		[Required]
		public CourseLevel Level { get; set; }

		/// <summary>
		/// Gets or sets the author.
		/// </summary>
		[Required]
		public int AuthorID { get; set; }

		/// <summary>
		/// Gets or sets the author.
		/// </summary>
		public Author Author { get; set; }

		/// <summary>
		/// Gets or sets the tags.
		/// </summary>
		public IList<Tag> Tags { get; set; }
	}

	public enum CourseLevel
	{
		Beginner = 1,
		Intermediate = 2,
		Advanced = 3
	}
}
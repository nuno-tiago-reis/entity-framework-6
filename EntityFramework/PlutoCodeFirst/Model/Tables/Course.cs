﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlutoCodeFirst.Model
{
	public enum CourseLevel
	{
		Beginner = 1,
		Intermediate = 2,
		Advanced = 3
	}

	public sealed class Course
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		public int ID { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the full price.
		/// </summary>
		public float FullPrice { get; set; }

		/// <summary>
		/// Gets or sets the level.
		/// </summary>
		public CourseLevel Level { get; set; }

		/// <summary>
		/// Gets or sets the author.
		/// </summary>
		public Author Author { get; set; }

		/// <summary>
		/// Gets or sets the tags.
		/// </summary>
		public IList<Tag> Tags { get; set; }
	}

}
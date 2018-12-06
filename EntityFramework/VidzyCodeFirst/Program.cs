using System;
using System.Linq;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;

using VidzyCodeFirst.Model;

namespace VidzyCodeFirst
{
	public sealed class Program
	{
		public static void Main(string[] args)
		{
			var context = new VidzyContext();
		}
	}
}
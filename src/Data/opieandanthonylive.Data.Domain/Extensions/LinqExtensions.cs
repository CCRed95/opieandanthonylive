using System;
using System.Collections.Generic;

namespace opieandanthonylive.Extensions
{
	public static class LinqExtensions
	{
		public static HashSet<T> ToHashSet<T>(
			this IEnumerable<T> source,
			IEqualityComparer<T> comparer = null)
		{
			return new HashSet<T>(source, comparer);
		}
	}
}

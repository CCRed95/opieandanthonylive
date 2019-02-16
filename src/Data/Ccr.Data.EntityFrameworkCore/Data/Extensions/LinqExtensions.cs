using System.Collections.Generic;
using System.Linq;

namespace Ccr.Data.Extensions
{
	public static class LinqExtensions
	{
		public static IEnumerable<IEnumerable<TValue>> Chunk<TValue>(
			this IEnumerable<TValue> @this,
			int chunkSize)
		{
			var pos = 0;
			while (@this.Skip(pos).Any())
			{
				yield return @this.Skip(pos).Take(chunkSize);
				pos += chunkSize;
			}
		}
	}
}

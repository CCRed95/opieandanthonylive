﻿using System;

// ReSharper disable BuiltInTypeReferenceStyle
namespace Ccr.Dnc.Core.Numerics.Ranges
{
	public class SingleRange
		: NonIntegralRangeBase<float>
	{
		public SingleRange(
			Single minimum,
			Single maximum) : base(
				minimum,
				maximum)
		{
		}

		public static implicit operator SingleRange(
			Tuple<Single, Single> value)
		{
			return new SingleRange(
				value.Item1,
				value.Item2);
		}
		public static implicit operator SingleRange(
			(Single, Single) value)
		{
			return new SingleRange(
				value.Item1,
				value.Item2);
		}
	}
}
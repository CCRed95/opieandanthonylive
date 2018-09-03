﻿using System;

// ReSharper disable BuiltInTypeReferenceStyle
namespace Ccr.Dnc.Core.Numerics.Ranges
{
	public class DoubleRange
		: NonIntegralRangeBase<double>
	{
		public DoubleRange(
			Double minimum,
			Double maximum) : base(
				minimum,
				maximum)
		{
		}

    public static implicit operator DoubleRange(
      Tuple<Double, Double> value)
    {
      return new DoubleRange(
        value.Item1,
        value.Item2);
    }
    public static implicit operator DoubleRange(
      (Double, Double) value)
    {
      return new DoubleRange(
        value.Item1,
        value.Item2);
    }
  }
}
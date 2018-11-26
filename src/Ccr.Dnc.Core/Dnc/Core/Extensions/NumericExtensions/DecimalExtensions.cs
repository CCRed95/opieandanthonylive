﻿using System;
using System.Collections;
using Ccr.Dnc.Core.Numerics;
using Ccr.Dnc.Core.Numerics.Ranges;
using JetBrains.Annotations;

// ReSharper disable BuiltInTypeReferenceStyle
namespace Ccr.Dnc.Core.Extensions.NumericExtensions
{
	public static class DecimalExtensions
	{
		/// <summary>
		///		Extension method that uses the non-generic <see cref="IComparer"/> interface to compare the 
		///		<see cref="Decimal"/> subject with the provided <paramref name="value"/> parameter, and returns 
		///		the largest numeric <see cref="Decimal"/> value of the two.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="Decimal"/> to perform the comparison upon.
		/// </param>
		/// <param name="value">
		///		The value of type <see cref="Decimal"/> in which to perform the comparison against the extension 
		///		method's subject, the <paramref name="this"/> parameter.
		/// </param>
		/// <returns>
		///		Compares the extension method's <see cref="Decimal"/> subject and the <paramref name="value"/> 
		///		parameter, and returns the largest numeric <see cref="Decimal"/> value of the two. 
		/// </returns>
		public static Decimal Smallest(
			this Decimal @this,
			Decimal value)
		{
			return @this < value
				? value
				: @this;
		}

		/// <summary>
		///		Extension method that uses the non-generic <see cref="IComparer"/> interface to compare the 
		///		<see cref="Decimal"/> subject with the provided <paramref name="value"/> parameter, and returns 
		///		the largest numeric <see cref="Decimal"/> value of the two.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="Decimal"/> to perform the comparison upon.
		/// </param>
		/// <param name="value">
		///		The value of type <see cref="Decimal"/> in which to perform the comparison against the extension 
		///		method's subject, the <paramref name="this"/> parameter.
		/// </param>
		/// <returns>
		///		Compares the extension method's <see cref="Decimal"/> subject and the <paramref name="value"/> 
		///		parameter, and returns the largest numeric <see cref="Decimal"/> value of the two. 
		/// </returns>
		public static Decimal Largest(
			this Decimal @this,
			Decimal value)
		{
			return @this > value
				? value
				: @this;
		}

		/// <summary>
		///		Extension method that performs a transformation on the <see cref="Decimal"/> subject using
		///		linear mapping to re-map from the provided initial range <paramref name="startRange"/> 
		///		to the target range <paramref name="endRange"/>.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="Decimal"/> to perform the linear map range re-mapping upon.
		/// </param>
		/// <param name="startRange">
		///		An instance of the type <see cref="DecimalRange"/>, describing a range of numeric values in 
		///		which the linear re-mapping uses as the initial range of the subject.
		/// </param>
		/// <param name="endRange">
		///		An instance of the type <see cref="DecimalRange"/>, describing a range of numeric values in
		///		which the linear re-mapping uses as the target range of the return value.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///		Thrown when either the <paramref name="startRange"/> or the <paramref name="endRange"/> 
		///		parameters are equal to <see langword="null"/>.
		///	</exception>
		/// <returns>
		///		A <see cref="Decimal"/> value that has been linearly mapped to the <paramref name="startRange"/>
		///		parameter and re-mapped to the <paramref name="endRange"/> parameter.
		/// </returns>
		public static Decimal LinearMap(
			this Decimal @this,
			[NotNull] DecimalRange startRange,
			[NotNull] DecimalRange endRange)
		{
			startRange.IsNotNull(nameof(startRange));
			endRange.IsNotNull(nameof(endRange));

			return (
					(@this - startRange.Minimum) *
					(endRange.Maximum - endRange.Minimum) /
					(startRange.Maximum - startRange.Minimum) +
					endRange.Minimum)
				.To<Decimal>();
		}

		/// <summary>
		///		Extension method that allows for <see cref="NonIntegralRangeBase{TIntegralType}.IsWithin"/> 
		///		to be called on a <see cref="Decimal"/> subject with the range and exclusivity passed as a 
		///		parameter, rather than on the <see cref="NonIntegralRangeBase{TIntegralType}"/> object 
		///		with a <see cref="Decimal"/> parameter.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="Decimal"/> value in which to check against the <paramref name="range"/>
		///		parameter to determine whether it is within the range, taking into account the exclusivity.
		/// </param>
		/// <param name="range">
		///		An instance of the type <see cref="DecimalRange"/>, describing a range of numeric values in 
		///		which the <paramref name="this"/> subject is to be compared against.
		/// </param>
		/// <param name="exclusivity">
		///		A value indicating whether to perform the upper and lower bounds comparisons including
		///		the range's Minimum and Maximum bounds, or to exclude them. This parameter is optional,
		///		and the default value is <see cref="EndpointExclusivity.Inclusive"/>.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///		Thrown when the specified <paramref name="range"/> is <see langword="null"/>.
		///	</exception>
		/// <returns>
		///		A <see cref="bool"/> value indicating whether or not the <paramref name="this"/> subject
		///		is within the provided <paramref cref="range"/> parameter, taking into account the 
		///		<see cref="EndpointExclusivity"/> mode via the <paramref name="exclusivity"/> parameter.
		/// </returns>
		public static bool IsWithin(
			this Decimal @this,
			[NotNull] DecimalRange range,
			EndpointExclusivity exclusivity = EndpointExclusivity.Inclusive)
		{
			range.IsNotNull(nameof(range));

			return range
				.IsWithin(
					@this,
					exclusivity);
		}

		/// <summary>
		///		Extension method that allows for <see cref="T:Ccr.Core.Numerics.NonIntegralRangeBase{TIntegralType}.IsNotWithin"/> 
		///		to be called on a <see cref="Decimal"/> subject with the range and exclusivity passed as a
		///		parameter, rather than on the <see cref="NonIntegralRangeBase{TIntegralType}"/> object 
		///		with a <see cref="Decimal"/> parameter.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="Decimal"/> value in which to check against the <paramref name="range"/>
		///		parameter to determine whether it is within the range, taking into account the exclusivity.
		/// </param>
		/// <param name="range">
		///		An instance of the type <see cref="DecimalRange"/>, describing a range of numeric values in 
		///		which the <paramref name="this"/> subject is to be compared against.
		/// </param>
		/// <param name="exclusivity">
		///		A value indicating whether to perform the upper and lower bounds comparisons including
		///		the range's Minimum and Maximum bounds, or to exclude them. This parameter is optional,
		///		and the default value is <see cref="EndpointExclusivity.Inclusive"/>.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///		Thrown when the specified <paramref name="range"/> is <see langword="null"/>.
		///	</exception>
		/// <returns>
		///		A <see cref="Decimal"/> value indicating whether or not the <paramref name="this"/> subject
		///		is within the provided <paramref cref="range"/> parameter, taking into account the 
		///		<see cref="EndpointExclusivity"/> mode via the <paramref name="exclusivity"/> parameter.
		///		This comparison is the logical inverse of the <see cref="IsNotWithin"/> extension method.
		/// </returns>
		public static bool IsNotWithin(
			this Decimal @this,
			[NotNull] DecimalRange range,
			EndpointExclusivity exclusivity = EndpointExclusivity.Inclusive)
		{
			range.IsNotNull(nameof(range));

			return range
				.IsNotWithin(
					@this,
					exclusivity);
		}

		/// <summary>
		///		Extension method that allows for <see cref="NonIntegralRangeBase{TIntegralType}.Constrain"/> 
		///		to be called on a <see cref="Decimal"/> subject with the range and exclusivity passed as a
		///		parameter, rather than on the <see cref="NonIntegralRangeBase{TIntegralType}"/> object 
		///		with a <see cref="Decimal"/> parameter.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="Decimal"/> value in which to check against the <paramref name="range"/>
		///		parameter to constrain a value within a range with an implicit inclusive comparison mode.
		/// </param>
		/// <param name="range">
		///		An instance of the type <see cref="DecimalRange"/>, describing a range of numeric values in 
		///		which the <paramref name="this"/> subject is to be compared against.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///		Thrown when the specified <paramref name="range"/> is <see langword="null"/>.
		///	</exception>
		/// <returns>
		///		A <see cref="Decimal"/> value that is the <paramref name="this"/> subject value adjusted to
		///		force the range of possible values to be within the provided <paramref cref="range"/> 
		///		parameter, using <see cref="EndpointExclusivity.Inclusive"/> as the comparison mode.
		/// </returns>
		public static Decimal Constrain(
			this Decimal @this,
			[NotNull] DecimalRange range)
		{
			range.IsNotNull(nameof(range));

			return range
				.Constrain(
					@this);
		}
		
	}
}

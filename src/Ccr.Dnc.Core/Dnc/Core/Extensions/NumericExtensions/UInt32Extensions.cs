﻿using System;
using System.Collections;
using Ccr.Dnc.Core.Numerics;
using Ccr.Dnc.Core.Numerics.Ranges;
using JetBrains.Annotations;

// ReSharper disable BuiltInTypeReferenceStyle
namespace Ccr.Dnc.Core.Extensions.NumericExtensions
{
	public static class UInt32Extensions
	{
		/// <summary>
		///		Extension method that uses the non-generic <see cref="IComparer"/> interface to compare the 
		///		<see cref="UInt32"/> subject with the provided <paramref name="value"/> parameter, and returns 
		///		the largest numeric <see cref="UInt32"/> value of the two.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="UInt32"/> to perform the comparison upon.
		/// </param>
		/// <param name="value">
		///		The value of type <see cref="UInt32"/> in which to perform the comparison against the extension 
		///		method's subject, the <paramref name="this"/> parameter.
		/// </param>
		/// <returns>
		///		Compares the extention method's <see cref="UInt32"/> subject and the <paramref name="value"/> 
		///		parameter, and returns the largest numeric <see cref="UInt32"/> value of the two. 
		/// </returns>
		public static UInt32 Smallest(
			this UInt32 @this,
			UInt32 value)
		{
			return @this < value
				? value
				: @this;
		}

		/// <summary>
		///		Extension method that uses the non-generic <see cref="IComparer"/> interface to compare the 
		///		<see cref="UInt32"/> subject with the provided <paramref name="value"/> parameter, and returns 
		///		the largest numeric <see cref="UInt32"/> value of the two.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="UInt32"/> to perform the comparison upon.
		/// </param>
		/// <param name="value">
		///		The value of type <see cref="UInt32"/> in which to perform the comparison against the extension 
		///		method's subject, the <paramref name="this"/> parameter.
		/// </param>
		/// <returns>
		///		Compares the extention method's <see cref="UInt32"/> subject and the <paramref name="value"/> 
		///		parameter, and returns the largest numeric <see cref="UInt32"/> value of the two. 
		/// </returns>
		public static UInt32 Largest(
			this UInt32 @this,
			UInt32 value)
		{
			return @this > value
				? value
				: @this;
		}

		/// <summary>
		///		Extension method that performs a transformation on the <see cref="UInt32"/> subject using
		///		linear mapping to re-map from the provided initial range <paramref name="startRange"/> 
		///		to the target range <paramref name="endRange"/>.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="UInt32"/> to perform the linear map range re-mapping upon.
		/// </param>
		/// <param name="startRange">
		///		An instance of the type <see cref="UInt32Range"/>, describing a range of numeric values in 
		///		which the linear re-mapping uses as the inital range of the subject.
		/// </param>
		/// <param name="endRange">
		///		An instance of the type <see cref="UInt32Range"/>, describing a range of numeric values in
		///		which the linear re-mapping uses as the target range of the return value.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///		Thrown when either the <paramref name="startRange"/> or the <paramref name="endRange"/> 
		///		parameters are equal to <see langword="null"/>.
		///	</exception>
		/// <returns>
		///		A <see cref="UInt32"/> value that has been linearly mapped to the <paramref name="startRange"/>
		///		parameter and re-mapped to the <paramref name="endRange"/> parameter.
		/// </returns>
		public static UInt32 LinearMap(
			this UInt32 @this,
			[NotNull] UInt32Range startRange,
			[NotNull] UInt32Range endRange)
		{
			startRange.IsNotNull(nameof(startRange));
			endRange.IsNotNull(nameof(endRange));

			return (
					(@this - startRange.Minimum) *
					(endRange.Maximum - endRange.Minimum) /
					(startRange.Maximum - startRange.Minimum) +
					endRange.Minimum)
				.To<UInt32>();
		}

		/// <summary>
		///		Extension method that allows for <see cref="IntegralRangeBase{TIntegralType}.IsWithin"/> 
		///		to be called on a <see cref="UInt32"/> subject with the range and exclusivity passed as a 
		///		parameter, rather than on the <see cref="IntegralRangeBase{TIntegralType}"/> object 
		///		with a <see cref="UInt32"/> parameter.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="UInt32"/> value in which to check against the <paramref name="range"/>
		///		parameter to determine whether it is within the range, taking into account the exclusivity.
		/// </param>
		/// <param name="range">
		///		An instance of the type <see cref="UInt32Range"/>, describing a range of numeric values in 
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
			this UInt32 @this,
			[NotNull] UInt32Range range,
			EndpointExclusivity exclusivity = EndpointExclusivity.Inclusive)
		{
			range.IsNotNull(nameof(range));

			return range
				.IsWithin(
					@this,
					exclusivity);
		}

		/// <summary>
		///		Extension method that allows for <see cref="IntegralRangeBase{TIntegralType}.IsNotWithin"/> 
		///		to be called on a <see cref="UInt32"/> subject with the range and exclusivity passed as a
		///		parameter, rather than on the <see cref="IntegralRangeBase{TIntegralType}"/> object 
		///		with a <see cref="UInt32"/> parameter.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="UInt32"/> value in which to check against the <paramref name="range"/>
		///		parameter to determine whether it is within the range, taking into account the exclusivity.
		/// </param>
		/// <param name="range">
		///		An instance of the type <see cref="UInt32Range"/>, describing a range of numeric values in 
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
		///		A <see cref="UInt32"/> value indicating whether or not the <paramref name="this"/> subject
		///		is within the provided <paramref cref="range"/> parameter, taking into account the 
		///		<see cref="EndpointExclusivity"/> mode via the <paramref name="exclusivity"/> parameter.
		///		This comparison is the logical inverse of the <see cref="IsNotWithin"/> extension method.
		/// </returns>
		public static bool IsNotWithin(
			this UInt32 @this,
			[NotNull] UInt32Range range,
			EndpointExclusivity exclusivity = EndpointExclusivity.Inclusive)
		{
			range.IsNotNull(nameof(range));

			return range
				.IsNotWithin(
					@this,
					exclusivity);
		}

		/// <summary>
		///		Extension method that allows for <see cref="IntegralRangeBase{TIntegralType}.Constrain"/> 
		///		to be called on a <see cref="UInt32"/> subject with the range and exclusivity passed as a
		///		parameter, rather than on the <see cref="IntegralRangeBase{TIntegralType}"/> object 
		///		with a <see cref="UInt32"/> parameter.
		/// </summary>
		/// <param name="this">
		///		The subject <see cref="UInt32"/> value in which to check against the <paramref name="range"/>
		///		parameter to constrain a value within a range with an implicit inclusive comparison mode.
		/// </param>
		/// <param name="range">
		///		An instance of the type <see cref="UInt32Range"/>, describing a range of numeric values in 
		///		which the <paramref name="this"/> subject is to be compared against.
		/// </param>
		/// <exception cref="ArgumentNullException">
		///		Thrown when the specified <paramref name="range"/> is <see langword="null"/>.
		///	</exception>
		/// <returns>
		///		A <see cref="UInt32"/> value that is the <paramref name="this"/> subject value adjusted to
		///		force the range of possible values to be within the provided <paramref cref="range"/> 
		///		parameter, using <see cref="EndpointExclusivity.Inclusive"/> as the comparison mode.
		/// </returns>
		public static UInt32 Constrain(
			this UInt32 @this,
			[NotNull] UInt32Range range)
		{
			range.IsNotNull(nameof(range));

			return range
				.Constrain(
					@this);

		}
	}
}
namespace Ccr.Dnc.Core.Numerics
{
	public interface INonIntegralRange
		: INumericRange
	{
		decimal Minimum { get; }

		decimal Maximum { get; }
	}
}

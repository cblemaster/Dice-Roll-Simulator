
namespace Simulator.Models;

public sealed class Dice
{
    private readonly IEnumerable<RollResult> _diceResult = [];
    private readonly int _modifier;

    public Dice(uint sides, uint count, int modifier)
    {
        if (!sides.IsValidSides())
        {
            // TODO...
        }
        else if (!count.IsValidCount())
        {
            // TODO...
        }
        else if (!modifier.IsValidModifier())
        {
            // TODO...
        }
        else
        {
            for (int i = 0; i < count - 1; i++)
            {
                _diceResult = _diceResult.Append(new Die(sides).Roll());
            }
            _modifier = modifier;
        }
    }

    public TallyResult TallyDice()
    {
        uint diceTotal = (uint)_diceResult.Sum(d => d.Result);
        string dieResults = string.Join(" ", _diceResult.Select(d => d.Result.ToString()));
        int rollTotal = (int)diceTotal + _modifier;
        return new(dieResults, diceTotal, _modifier, rollTotal);
    }
}

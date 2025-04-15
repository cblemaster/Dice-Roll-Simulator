
namespace Simulator.Models;

internal sealed class DiceResult
{
    internal uint Sides { get; init; }
    internal uint Count { get; init; }
    internal int Modifier { get; init; }
    internal int Result { get; init; }

    internal DiceResult(uint sides, uint count, int modifier)
    {
        // TODO: validate sides and count
        Sides = sides;
        Count = count;
        Modifier = modifier;
    }
    
    public override string ToString()
    {
        string mod = string.Empty;
        if (Modifier > 0)
        {
            mod = $" + {Modifier}";
        }
        else if (Modifier < 0)
        {
            mod = $" - {Modifier}";
        }

        return $"{Count}d{Sides}{mod} = {Result}";
    }
}


namespace Simulator.Models.Results;

public sealed class Roll(uint count, uint sides, int modifier, IEnumerable<uint> rolls)
{
    private uint Count { get; } = count;
    private uint Sides { get; } = sides;
    public int Modifier { get; } = modifier;
    private IEnumerable<uint> Rolls { get; } = rolls;

    public uint RollsSum => (uint)Rolls.Sum(r => (int)r);
    public int FinalResult => (int)RollsSum + Modifier;

    public string ToDefinition()
    {
        string s = $"{Count}d{Sides}";
        if (Modifier > 0)
        {
            s = $"{s} + {Math.Abs(Modifier)}";
        }
        else if (Modifier < 0)
        {
            s = $"{s} - {Math.Abs(Modifier)}";
        }
        return s;
    }
    public string ToRollsJoined(string separator) => string.Join(separator, Rolls);
}

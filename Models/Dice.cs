
namespace Models;

internal sealed class Dice
{
    private readonly Random _random = new();

    internal uint Sides { get; }    // TODO: encapsulate sides, count, and mod; they are on every class
    internal uint Count { get; }
    internal int Modifier { get; }

    private Dice(uint sides, uint count, int modifier)
    {
        Sides = sides;
        Count = count;
        Modifier = modifier;
    }

    internal static Dice Create(DiceRequest request) =>
        new(request.Sides, request.Count, request.Modifier);

    internal DiceResult RollDice()  // TODO: special cases for d2, d3, d100
    {
        List<uint> rolls = [];
        for (int i = 0; i < Count; i++)
        {
            uint roll = (uint)_random.Next(1, (int)Sides + 1);
            rolls.Add(roll);
        }

        return DiceResult.Create(Sides, Count, Modifier, rolls);
    }
}

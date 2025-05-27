
namespace Models;

internal sealed class Dice
{
    private readonly Random _random = new();
    private static readonly uint[] _validSides = { 2, 3, 4, 6, 8, 10, 12, 20, 100 };
    
    internal uint Sides { get; }
    internal uint Count { get; }
    internal int Modifier { get; }
    internal IEnumerable<uint> Rolls { get; private set; } = [];

    private Dice(uint sides, uint count, int modifier)
    {
        Sides = sides;
        Count = count;
        Modifier = modifier;
    }

    internal static Dice Create(uint sides, uint count, int modifier) =>
        !_validSides.Contains(sides)
            ? throw new ArgumentException($"Invalid die sides. Valid die sides are {string.Join(',', _validSides)}", nameof(sides))

            : count is 0 or > 10
                ? throw new ArgumentException("Invalid count. Count must be between one(1) and ten(10) inclusive.", nameof(count))

                : modifier is < (-100) or > 100
                        ? throw new ArgumentException("Invalid modifier. Modifier must be between -100 and +100 inclusive.", nameof(modifier))

                        : new(sides, count, modifier);

    internal void Roll()
    {
        List<uint> rolls = [];
        for (int i = 0; i < Count; i++)
        {
            uint roll = (uint)_random.Next(1, (int)Sides + 1);
            rolls.Add(roll);
        }
        Rolls = rolls;
        // TODO: special cases for d2, d3, d100
    }

    internal string DiceToString() => string.Join(", ", Rolls);
    internal string ModifierToString()
    {
        string modifierString = Modifier switch
        {
            > 0 => $"+{Modifier}",
            < 0 => $"-{Modifier}",
            _ => string.Empty
        };
        return modifierString.TrimEnd();
    }
    internal uint DiceTotal() => (uint)Rolls.Sum(d => (int)d);
    internal int GrandTotal() => (int)DiceTotal() + Modifier;
    
    public override string ToString()
    {
        string modifier = ModifierToString();
        string definition = $"{Count}d{Sides} {modifier}";
        string dice = DiceToString();
        string diceTotal = DiceTotal().ToString();
        string grandTotal = GrandTotal().ToString();

        return $"{definition}\n\n{dice}\n\nDice Total: {diceTotal}\nModifier: {modifier}\nTOTAL: {grandTotal}";
    }
}

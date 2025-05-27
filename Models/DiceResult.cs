
namespace Models;

internal sealed class DiceResult
{
    internal uint Sides { get; }
    internal uint Count { get; }
    internal int Modifier { get; }
    internal IReadOnlyCollection<uint> Rolls { get; }

    private DiceResult(uint sides, uint count, int modifier, IEnumerable<uint> rolls)
    {
        Sides = sides;
        Count = count;
        Modifier = modifier;
        Rolls = rolls.ToList().AsReadOnly();
    }

    internal static DiceResult Create(uint sides, uint count, int modifier, IEnumerable<uint> rolls) =>
        new(sides, count, modifier, rolls);

    // TODO: Move this into extension methods
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

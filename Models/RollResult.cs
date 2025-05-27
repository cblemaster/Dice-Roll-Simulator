
namespace Models;

internal sealed class RollResult
{
    private RollDefinition RollDefinition { get; }
    private IReadOnlyCollection<uint> Rolls { get; }

    private RollResult(RollDefinition rollDefinition, IEnumerable<uint> rolls)
    {
        RollDefinition = rollDefinition;
        Rolls = rolls.ToList().AsReadOnly();
    }

    internal static RollResult Create(RollDefinition rollDefinition, IEnumerable<uint> rolls) =>
        new(rollDefinition, rolls);

    private string DiceToString() => string.Join(", ", Rolls);
    private string ModifierToString()
    {
        char sign = default!;
        switch (RollDefinition.Modifier)
        {
            case > 0:
                sign = '+';
                break;
            case < 0:
                sign = '-';
                break;
            default:
                break;
        }

        return $"{sign}{RollDefinition.Modifier}";
    }
    private uint DiceTotal() => (uint)Rolls.Sum(d => (int)d);
    private int GrandTotal() => (int)DiceTotal() + RollDefinition.Modifier;
    public override string ToString()   // TODO: This is a presentation concern
    {
        string modifier = ModifierToString();
        string definition = $"{RollDefinition.Count}d{RollDefinition.Sides} {modifier}";
        string dice = DiceToString();
        string diceTotal = DiceTotal().ToString();
        string grandTotal = GrandTotal().ToString();

        return $"{definition}\n\n{dice}\n\nDice Total: {diceTotal}\nModifier: {modifier}\nTOTAL: {grandTotal}";
    }
}

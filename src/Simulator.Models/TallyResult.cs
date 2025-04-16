
namespace Simulator.Models;

public sealed class TallyResult(string dieResults, uint diceTotal, int modifier, int rollTotal)
{
    public string DieResults { get; } = dieResults;
    public uint DiceTotal { get; } = diceTotal;
    public int Modifier { get; } = modifier;
    public int RollTotal { get; } = rollTotal;
}


namespace Simulator.Models;

public sealed class TallyResult
{
    private readonly string _dieResults;
    private readonly uint _diceTotal;
    private readonly int _modifier;
    private readonly int _rollTotal;

    internal TallyResult(string dieResults, uint diceTotal, int modifier, int rollTotal)
    {
        _dieResults = dieResults;
        _diceTotal = diceTotal;
        _modifier = modifier;
        _rollTotal = rollTotal;
    }
}

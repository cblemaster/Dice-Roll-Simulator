
namespace Simulator.Models;

internal sealed class RollResult
{
    private readonly uint _sides;

    internal uint Result { get; }

    internal RollResult(uint sides, uint result)
    {
        _sides = sides;
        Result = result;
    }
}

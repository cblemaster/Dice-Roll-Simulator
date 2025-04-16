
namespace Simulator.Models;

internal sealed class Die
{
    private readonly uint _sides;

    internal Die(uint sides) => _sides = sides;  // TODO: validate

    internal RollResult Roll()
    {
        Random rand = new();
        int result = rand.Next(1, (int)_sides + 1);
        return new(_sides, (uint)result);
    }
}


namespace Models;

internal sealed class DiceRequest
{
    private static readonly uint[] _validSides = [2, 3, 4, 6, 8, 10, 12, 20, 100];

    internal uint Sides { get; }
    internal uint Count { get; }
    internal int Modifier { get; }

    private DiceRequest(uint sides, uint count, int modifier)
    {
        Sides = sides;
        Count = count;
        Modifier = modifier;
    }

    internal static DiceRequest Create(uint sides, uint count, int modifier) =>
        !_validSides.Contains(sides)
            ? throw new ArgumentException($"Invalid die sides. Valid die sides are {string.Join(',', _validSides)}", nameof(sides))

        : modifier is < (-100) or > 100
                ? throw new ArgumentException("Invalid modifier. Modifier must be between -100 and +100 inclusive.", nameof(modifier))

                : count is 0 or > 10
                    ? throw new ArgumentException("Invalid count. Count must be between one(1) and ten(10) inclusive.", nameof(count))

                    : new(sides, count, modifier);
    // TODO: Move validation into extension methods
}

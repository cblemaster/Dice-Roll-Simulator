
// if the validation and rules were any more complicated,
//   I would not be ok with the rule definitions living in
//   an static extensions class

namespace Simulator.Models.Extensions;

internal static class IntValidationExtensions
{
    private const uint MIN_COUNT = 1;
    private const uint MAX_COUNT = 10;
    private const int MIN_MODIFIER = -100;
    private const int MAX_MODIFIER = 100;

    internal static bool IsValidSides(this uint sides)
    {
        uint[] validSides = [2, 3, 4, 6, 8, 10, 12, 20, 100];
        return validSides.Contains(sides);
    }

    internal static bool IsValidCount(this uint count) => count is >= MIN_COUNT and <= MAX_COUNT;

    internal static bool IsValidModifier(this int modifier) => modifier is >= MIN_MODIFIER and <= MAX_MODIFIER and not 0;
}

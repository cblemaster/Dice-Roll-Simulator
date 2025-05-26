
namespace Models.ValueObjects;

internal sealed record Sides
{
    internal uint Value { get; }

    private Sides(uint value) => Value = value;

    internal static Sides Create(uint value) =>
        value is 0 or > 10
            ? throw new ArgumentException("Dice count muct be between one(1) and ten(10).", nameof(value))
            : new Sides(value);

    internal static Sides Create(int value) => Create((uint)value);
}

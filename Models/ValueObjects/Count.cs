
namespace Models.ValueObjects;

internal sealed record Count
{
    internal uint Value { get; }

    private Count(uint value) => Value = value;

    internal static Count Create(uint value) =>
        value is 0 or > 10
            ? throw new ArgumentException("Dice count muct be between one(1) and ten(10).", nameof(value))
            : new Count(value);

    internal static Count Create(int value) => Create((uint)value);
}

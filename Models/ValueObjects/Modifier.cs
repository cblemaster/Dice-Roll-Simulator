
namespace Models.ValueObjects;

internal sealed record Modifier
{
    internal int Value { get; }

    private Modifier(int value) => Value = value;

    internal static Modifier Create(int value) =>
        value is 0 or > 10
            ? throw new ArgumentException("Dice count muct be between one(1) and ten(10).", nameof(value))
            : new Modifier(value);
}


namespace Models;

internal sealed class Dice
{
    private readonly Random _random = new();

    private RollDefinition RollDefinition { get; }

    private Dice(RollDefinition rollDefinition) => RollDefinition = rollDefinition;

    internal static Dice Create(RollDefinition rollDefinition) => new(rollDefinition);

    internal RollResult RollDice()
    {
        List<uint> rolls = [];
        for (int i = 0; i < RollDefinition.Count; i++)
        {
            uint roll;
            if (RollDefinition.Sides == 2)
            {
                // PH rules: roll d4, pick odd or even to be one, otherwise two
                uint tempRoll = SingleRoll(4);
                roll = tempRoll % 2 == 0 ? 1u : 2;
            }
            else if (RollDefinition.Sides == 3)
            {
                // PH rules: roll d6, divide by two, round up
                uint tempRoll = SingleRoll(6);
                roll = (uint)Math.Ceiling((decimal)tempRoll / 2);
            }
            else if (RollDefinition.Sides == 100)
            {
                // PH rules: d10 sides are 0-9
                // if both are 0, then 100
                // otherwise, one die is tens and the other is ones
                int leftRoll = _random.Next(0, 10);
                int rightRoll = _random.Next(0, 10);
                roll = leftRoll == rightRoll && rightRoll == 0
                    ? 100u
                    : (uint)((leftRoll * 10) + rightRoll);
            }
            else
            {
                roll = SingleRoll(RollDefinition.Sides);
            }

            rolls.Add(roll);
        }

        return RollResult.Create(RollDefinition, rolls);
    }

    private uint SingleRoll(uint sides) => (uint)_random.Next(1, (int)sides + 1);
}

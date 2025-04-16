
namespace Simulator.Models;

public sealed class Dice
{
    private uint Sides { get; }
    private uint Count { get; }
    private int Modifier { get; }

    public Dice(uint sides, uint count, int modifier)
    {
        if (!sides.IsValidSides())
        {
            // TODO...
        }
        else if (!count.IsValidCount())
        {
            // TODO...
        }
        else if (!modifier.IsValidModifier())
        {
            // TODO...
        }
        else
        {
            Sides = sides;
            Count = count;
            Modifier = modifier;
        }
    }

    public TallyResult TallyDice()
    {
        uint diceTotal = 0;
        string dieResults = string.Empty;
        int rollTotal = 0;

        for (int i = 0; i < Count - 1; i++)
        {
            uint roll;

            if (Sides == 2)
            {
                roll = (uint)(GetRandom(Sides * 2) % 2 == 0 ? 1 : 2);
            }
            else if (Sides == 3)
            {
                uint result = GetRandom(Sides * 2);
                decimal resultHalf = (decimal)result / 2;
                int resultHalfWholeNumber = (int)result / 2;
                decimal resultFraction = resultHalf - resultHalfWholeNumber;

                if (resultFraction >= 0.5m)
                {
                    result++;
                }

                roll = (uint)result;
            }
            else
            {
                roll = (uint)GetRandom(Sides);
            }

            diceTotal += roll;
            dieResults += $"{roll} ";
            rollTotal += (int)roll;
        }

        rollTotal += Modifier;

        return new(dieResults, diceTotal, Modifier, rollTotal);

        static uint GetRandom(uint max)
        {
            Random rand = new();
            return (uint)rand.Next(1, (int)(max + 1));
        }
    }
}

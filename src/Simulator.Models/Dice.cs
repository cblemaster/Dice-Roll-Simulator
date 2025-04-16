
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
                uint rand = GetRandom(Sides * 2);
                decimal halfRandWithFraction = (decimal)rand / 2;
                int halfRandWholeNumber = (int)rand / 2;
                decimal fraction = halfRandWithFraction - halfRandWholeNumber;

                if (fraction >= 0.5m)
                {
                    rand++;
                }

                roll = (uint)rand;
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

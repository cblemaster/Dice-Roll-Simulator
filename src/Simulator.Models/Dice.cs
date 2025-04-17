
namespace Simulator.Models;

public sealed class Dice
{
    private uint Count { get; }
    private uint Sides { get; }
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
            Count = count;
            Sides = sides;
            Modifier = modifier;
        }
    }

    public RollResult Roll()
    {
        List<uint> rolls = [];

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
            else if (Sides == 100)
            {
                Random rand = new();
                uint hundreds = (uint)rand.Next(0, 10);
                uint tens = (uint)rand.Next(0, 10);

                if (hundreds == tens && tens == 0)
                {
                    roll = 100;
                }
                else
                {
                    roll = (uint)(hundreds * 10 + tens);
                }
            }
            else
            {
                roll = (uint)GetRandom(Sides);
            }
            rolls.Add(roll);
        }
        
        return new(Count, Sides, Modifier, rolls);

        static uint GetRandom(uint max)
        {
            Random rand = new();
            return (uint)rand.Next(1, (int)(max + 1));
        }
    }
}

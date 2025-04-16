
namespace Simulator.Models;

internal sealed class Die
{
    private uint Sides { get; set; }

    internal Die(uint sides)
    {
        if (!sides.IsValidSides())
        {
            // TODO...
        }
        else
        {
            Sides = sides;
        }   
    }

    internal RollResult Roll()
    {
        int result;
        if (Sides is 2 or 3)
        {
            result = GetRandom((int)(Sides * 2));

            if (Sides == 2)
            {
                result = result % 2 == 0 ? 1 : 2;
            }
            else if (Sides == 3)
            {
                result = (int)Math.Round((decimal)result / 2, MidpointRounding.ToEven);
            }
        }
        else
        {
            result = GetRandom((int)Sides);
        }

        return new(Sides, (uint)result);

        static int GetRandom(int sides)
        {
            Random rand = new();
            return rand.Next(1, sides + 1);
        }
    }
}

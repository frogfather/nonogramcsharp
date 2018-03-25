using System;
namespace Nonogram
{
    public struct ClueData
    {
        public int value;
        public string colour;

        public ClueData(int clueValue, string clueColour)
        {
            value = clueValue;
            colour = clueColour;
        }
    }
}

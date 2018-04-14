using System;
namespace Nonogram
{
    public struct SpaceData
    {
        public int start;
        public int length;

        public SpaceData(int sStart, int sLength, string bColour)
        {
            start = sStart;
            length = sLength;
        }
    }
}

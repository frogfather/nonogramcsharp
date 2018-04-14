using System;
namespace Nonogram
{            
    public struct BlockData
    {
        public int start;
        public int length;
        public string colour;

        public BlockData(int bStart, int bLength,  string bColour)
        {
            start = bStart;
            length = bLength;
            colour = bColour;
        }

    }
}

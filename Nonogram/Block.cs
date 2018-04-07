using System;
using System.Collections.Generic;
namespace Nonogram
{
    public class Block
    {
        public Block(int length, int start, string colour)
        {
            _blockLength = length;
            _blockStart = start;
            _blockColour = colour;
            _blockClues = new List<Clue>();
        }

        int _blockLength;
        int _blockStart;
        string _blockColour;
        List<Clue> _blockClues;
    }
}

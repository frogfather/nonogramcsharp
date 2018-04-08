using System;
using System.Collections.Generic;
namespace Nonogram
{
    public class Block
    {
        public Block(int length, int start, string colour)
        {
            BlockLength = length;
            BlockStart = start;
            _blockClues = new List<Clue>();
        }

        public int BlockLength
        {
            get;
            set;
        }
       
        public int BlockStart
        {
            get;
            set;
        }

        public string BlockColour
        {
            get;
            set;
        }

        public void AddClue(Clue clue)
        {
            if (!_blockClues.Contains(clue))
            {
                _blockClues.Add(clue);
            }
        }

        public Clue GetClue(int index)
        {
            if (index > -1 && index < _blockClues.Count)
            {
                return _blockClues[index];
            }
            else
            {
                return null;
            }
        }

        List<Clue> _blockClues;
    }
}

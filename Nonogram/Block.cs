using System;
using System.Collections.Generic;
namespace Nonogram
{
    public class Block
    {
        public Block(BlockData options)
        {
            BlockLength = options.length;
            BlockStart = options.start;
            BlockColour = options.colour;
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

        public int GetClueCount() => _blockClues.Count;

        public void AddClue(Clue clue)
        {
            if (!_blockClues.Contains(clue))
            {
                _blockClues.Add(clue);
            }
        }

        public void RemoveClue(Clue clue)//need tests for this!
        {
            int cluePos = _blockClues.IndexOf(clue);
                if (cluePos>-1)
            {
                _blockClues.RemoveAt(cluePos);
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

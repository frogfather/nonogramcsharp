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
            _blockClues = new Clues();
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


        public Clues AllClues()
        {
            return _blockClues;
        }

        public Clue GetClue(int index)
        {
            if (index > -1 && index < _blockClues.GetClueCount())
            {
                return _blockClues.getClue(index);
            }
            else
            {
                return null;
            }
        }

        Clues _blockClues;
    }
}

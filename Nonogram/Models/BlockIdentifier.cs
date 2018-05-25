using System;
namespace Nonogram
{
    public class BlockIdentifier
    {
        public BlockIdentifier(Clues clues, Blocks blocks, Spaces spaces, int elementLength)
        {
            _blocks = blocks;
            _clues = clues;
            _spaces = spaces;
            int clueCount = _clues.GetClueCount();
            _cluePositions = new int[clueCount];
            for (int i = 0; i < clueCount;i++)            
            {
                _cluePositions[i] = elementLength - _clues.GetClueLength(i);
            }
            
        }

        public void IdentifyBlocks()
        {
            bool positionsToTest = true;
            while (positionsToTest)
            {
                if (ArrangementIsLegal()) { UpdateBlocks(); }
                positionsToTest = FindNextCluePosition();
            }
        }

        private void UpdateBlocks()
        {
            //can we avoid having to test legality of each clue and block again?
            //for each block, if the arrangement is legal and a clue is overlapping it then that block can be that clue
        }

        private bool ArrangementIsLegal()
        {
            bool arrLegal = true;
            int clueNo = 0;
            bool clueLegal;

            foreach (Block block in _blocks)
            {
                clueLegal = false;
                int blockEnd = block.BlockStart + block.BlockLength - 1;
                while (!clueLegal && clueNo < _clues.GetClueCount())
                {                                                            
                    clueLegal = ClueCoversBlock(_clues.getClue(clueNo),block,_cluePositions[clueNo]) && ClueInSpace(_clues.getClue(clueNo),_spaces,_cluePositions[clueNo]);
                    if (!clueLegal) { clueNo += 1; }
                }
                arrLegal = (clueNo < _clues.GetClueCount());
            }

            if (arrLegal)
            {
                Console.WriteLine("arrangement legal: ");
                Console.Write("blocks: ");
                for (int blk = 0; blk < _blocks.GetBlockCount();blk++)
                {
                    Console.Write(_blocks.GetBlock(blk).BlockStart+":"+_blocks.GetBlock(blk).BlockLength+", ");
                }
                Console.WriteLine("---");
                Console.Write("clues: ");
                for (int i = 0; i < _cluePositions.Length; i++)
                {
                    Console.Write(_cluePositions[i] +":"+ _clues.getClue(i).Number + ", ");
                }
                Console.WriteLine("***");
            }

            return arrLegal;
        }

        private bool ClueCoversBlock(Clue clue, Block block, int clueStart)
        {
            int clueEnd = clueStart + clue.Number -1;
            int blockEnd = block.BlockStart + block.BlockLength - 1;
            return (clueStart <= block.BlockStart && clueEnd >= blockEnd && clue.Colour == block.BlockColour);
        }

        private bool ClueInSpace(Clue clue, Spaces spaces, int clueStart)
        {
            //is this clue completely within a space?
            foreach(Space space in spaces)
            {
                //we just need one to be true
                if (clueStart >= space.SpaceStart && clueStart + clue.Number <= space.SpaceStart + space.SpaceLength) { return true; }
            }
            return false;
        }

        private bool RoomToMoveClue(int clueNo)
        {
            //for a given clue, is there space to the left of it?
            //if clue(n) is at position x what space is there to its left
            if (clueNo >= _clues.GetClueCount()) { return false; }
            int cluePos = _cluePositions[clueNo];
            int clueEnd = cluePos + _clues.GetClueLength(clueNo, clueNo)-1;
            int spaceToLeft = 0;
            if (clueNo > 0)
            {
                spaceToLeft = clueEnd + 1 - _clues.GetClueLength(clueNo - 1, clueNo) - _cluePositions[clueNo - 1];
            }
            else
            {
                spaceToLeft = cluePos;
            }

            return spaceToLeft > 0;
        }

        private bool FindNextCluePosition()
        {            
            //moves the clue positions to the next available space
            //if we can move the first clue then do so, otherwise move the next etc
            int clueToMove = 0;
            bool canMoveClue = false;
            bool done = false;

            while (!done)
            {
                canMoveClue = RoomToMoveClue(clueToMove);
                done = canMoveClue || clueToMove == _clues.GetClueCount();
                if (!canMoveClue){clueToMove += 1;}
            }
            if (canMoveClue) { MoveClue(clueToMove); }
            return canMoveClue;
        }

        private void MoveClue(int clueNo)
        {
            //move specified clue. All clues before it should move to as close as possible to the clue that has been moved
            _cluePositions[clueNo] -= 1;
            int clueEnd = _cluePositions[clueNo] + _clues.GetClueLength(clueNo, clueNo)-1;
            if (clueNo > 0)
            {
                for (int i = 0; i < clueNo;i++)
                {
                    _cluePositions[i] = clueEnd + 1 - _clues.GetClueLength(i, clueNo);
                }
            }
        }

        int[] _cluePositions; //holds the current positions of each clue
        Blocks _blocks;
        Clues _clues;
        Spaces _spaces;
    }
}

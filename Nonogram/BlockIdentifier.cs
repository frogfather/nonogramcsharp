using System;
namespace Nonogram
{
    public class BlockIdentifier
    {
        public BlockIdentifier(Clues clues, Blocks blocks, int elementLength)
        {
            _blocks = blocks;
            _clues = clues;
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
            //for each block, if the arrangement is legal and a clue is overlapping it then that block can be that clue

        }

        private bool ArrangementIsLegal()
        {
            bool arrLegal = false;
            //block must have same colour opposite
            //cross must not have clue opposite
            arrLegal = true; //for testing
            return arrLegal;
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

    }
}

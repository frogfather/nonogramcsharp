using System;
using System.Collections.Generic;
namespace Nonogram
{
    public class BlockIdentifier
    {
        /// <summary>
        /// This class takes a Clues object, a Spaces object and a Blocks object and 
        /// for each block determines which clues that block could legally be
        /// </summary>

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

        /// <summary>
        /// The only public method. It iterates through each legal position of the clues and
        /// checks to see if that arrangement is legal
        /// </summary>

        public void IdentifyBlocks()
        {
            Clues[] permittedClues = new Clues[_blocks.GetBlockCount()]; //temporary array to hold clues
            InitialisePermittedClues(permittedClues); //the array initially has null values. This sets them to empty Clues
            bool positionsToTest = true;
            while (positionsToTest)
            {
                ClearPermittedClues(permittedClues);
                if (ArrangementIsLegal(permittedClues)) { UpdateBlocks(permittedClues); }
                positionsToTest = FindNextCluePosition();
            }
        }

        /// <summary>
        /// Sets each element of the permitted clues array to a new empty Clues object
        /// </summary>

        private void InitialisePermittedClues(Clues[] clueList)
        {
            for (int i = 0; i < clueList.Length; i++)
            {
                clueList[i] = new Clues();
            }
        }

        /// <summary>
        /// Empties each Clues object in the array
        /// </summary>

        private void ClearPermittedClues(Clues[] clueList)
        {
            foreach(Clues clues in clueList)
            {                
                clues.RemoveAll();
            }
        }


        /// <summary>
        /// Adds to each block any clues that could legally be that block
        /// </summary>

        private void UpdateBlocks(Clues[] clueList)
        {
            for (int blockNo = 0; blockNo < _blocks.GetBlockCount(); blockNo++)
            {
                foreach(Clue clue in clueList[blockNo])
                {
                    _blocks.GetBlock(blockNo).AllClues().AddClue(clue);
                }

            }
        }

        /// <summary>
        /// Checks whether the position of the clues is legal
        /// </summary>
        ///<remarks>
        /// For an arrangement of clues and blocks to be legal the following rules are applied:
        /// 1) Each block must be entirely covered by a clue (it can be longer than the block)
        /// 2) The clue must be in a space
        /// The methods ClueCoversBlock and ClueInSpace are called to check this for each clue
        /// </remarks>

        private bool ArrangementIsLegal(Clues[] clueList)
        {
            bool arrLegal = true;
            int clueNo = 0;
            bool clueLegal;
            //we should check the clues are legal first
            if (!CluesFitInSpaces(_clues, _spaces, _cluePositions)) { return false; }

            for (int blockNo = 0; blockNo < _blocks.GetBlockCount();blockNo++)
            {
                clueLegal = false;
                int blockEnd = _blocks.GetBlock(blockNo).BlockStart + _blocks.GetBlockLength() - 1;
                while (!clueLegal && clueNo < _clues.GetClueCount())
                {                                                            
                    clueLegal = ClueCoversBlock(_clues.getClue(clueNo),_blocks.GetBlock(blockNo),_cluePositions[clueNo]);
                    if (clueLegal)
                    {
                        //update the temporary list
                        clueList[blockNo].AddClue(_clues.getClue(clueNo));
                    }
                    else
                    { 
                        clueNo += 1; 
                    }
                }
            }
            arrLegal = (clueNo < _clues.GetClueCount());

            return arrLegal;
        }

        /// <summary>
        /// Checks that the supplied clue covers the supplied block completely. The clue can be longer than the block
        /// </summary>

        private bool ClueCoversBlock(Clue clue, Block block, int clueStart)
        {
            int clueEnd = clueStart + clue.Number -1;
            int blockEnd = block.BlockStart + block.BlockLength - 1;
            return (clueStart <= block.BlockStart && clueEnd >= blockEnd && clue.Colour == block.BlockColour);
        }

        /// <summary>
        /// Checks that the clue is entirely within a space (i.e. not opposite a cross square)
        /// </summary>

        private bool CluesFitInSpaces(Clues clues, Spaces spaces, int[] cluePositions)
        {
            for (int clueNo = 0; clueNo < clues.GetClueCount(); clueNo++)
            {
                if (!ClueFitsInSpace(clues.getClue(clueNo), spaces, cluePositions[clueNo])){ return false;}
            }
            return true;
        }

        private bool ClueFitsInSpace(Clue clue, Spaces spaces, int clueStart)
        {
            //is this clue completely within a space?
            foreach(Space space in spaces)
            {
                //we just need one to be true
                if (clueStart >= space.SpaceStart && clueStart + clue.Number <= space.SpaceStart + space.SpaceLength) { return true; }
            }
            return false;
        }

        /// <summary>
        /// When moving the clues checks whether there is room to move a particular clue. If not the next clue is moved
        /// If no clues can be moved then all possible clue positions have been tried
        /// </summary>

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


        /// <summary>
        /// Returns true if there is another available position for the clues
        /// It starts with clue 0 and checks if it can be moved. If not it moves to clue 1 and so on. If no clues can 
        /// be moved then there are no more positions for the clues and the method returns false.
        /// </summary>

        private bool FindNextCluePosition()
        {            
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

        /// <summary>
        /// Moves the specified clue. All clues before this one are then moved as close as possible to it
        /// </summary>

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

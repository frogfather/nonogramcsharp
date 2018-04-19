using System;
using System.Collections.Generic;
using System.Collections;
namespace Nonogram
{
    public static class Autosolve
    {

        //Methods below should be private
        //There should be an overall 'Solve' method that takes the game object in and modifies it
        //
        //LayoutIsLegal - compares supplied layout to ref one. Need to remember how this worked
        //GetBlockInfo - block probably needs to be a class
        //LargestBlockEqualsLargestClue (uses getBlockInfo)
        //OverallClueLength 
        //GetDistinctSpaces (needs amended for coloured puzzles)
        //GetSpaceRound
        //BlocksMapToClues
        //CluesWillFit
        //ClueDistribution
        //IdentifyBlocks
        //SingleClue
        //EdgeProximity
        //Overlap

        public static void Solve(Game gameToSolve)
        {
            int cellsToSolve = gameToSolve.Grid().GetLength(true) * gameToSolve.Grid().GetLength(false);
            int totalSolvedCells = 0;
            int solvedThisRound = 0;

            //we want to recursively call all the methods until the number of 
            //solved cells is 0.
            //Overlap
            //Edge Proximity
            //Single Clue
            //Identify Blocks

        }

        private static int Overlap(Game gameToSolve)
        {
            int totalSolved = 0;
            int solved = 0;
            //this iterates through each row and column in the game
            //and checks for points where cells must be filled in
            int elementLength = gameToSolve.Grid().GetLength(true); //number of rows

            for (int element = 0; element < elementLength; element++)
            {
                Clues currentElementClues = gameToSolve.Rows().getClueSet(element);
                Blocks currentElementBlocks = gameToSolve.Grid().GetBlocks(element, true);
                Spaces currentSpaces = gameToSolve.Grid().GetSpaces(element, true);

                solved = CellRowOverlap(gameToSolve.Grid(), currentElementClues, element, elementLength, true);
                totalSolved += solved;
                solved = 0;
            }

            elementLength = gameToSolve.Grid().GetLength(false); //number of columns
            for (int element = 0; element < elementLength; element++)
            {
                Clues currentElementClues = gameToSolve.Cols().getClueSet(element);
                Blocks currentElementBlocks = gameToSolve.Grid().GetBlocks(element, true);
                Spaces currentSpaces = gameToSolve.Grid().GetSpaces(element, true);

                solved = CellRowOverlap(gameToSolve.Grid(), currentElementClues, element, elementLength, false);
                totalSolved += solved;
                solved = 0;
            }
            return totalSolved;
        }

        private static int CellRowOverlap(Grid grid, Clues clues, int element, int elementLength, bool isRow)
        {
            int solved = 0;


            //this method has not been written yet

            return solved;
        }

        private static bool CluesWillFitInSpaces(Clues clues, Spaces spaces, Blocks blocks)
        {

            List<Space> spaceList = new List<Space>();
            List<Clue> clueList = new List<Clue>();
            //first put all the spaces into spacelist
            //and all the clues into clueList
            foreach(Space space in spaces)
            {
                spaceList.Add(space);
            }
            foreach(Clue clue in clues)
            {
                clueList.Add(clue);
            }

            bool matchFound = false;
            bool finished = false;
            while (!finished)

            {
                //move the next clue into the last space
                spaceList[spaceList.Count].AddClue(clueList[0]);
                if (clueList.Count > 0)
                {
                    clueList.RemoveAt(0);    
                }

                for (int i = spaceList.Count - 1; i >= 0;i--)
                {
                    // for each space, if the clues are too long to fit, move the first one out
                    //need to adjust this in case more than one clue needs moved out!
                    if (spaceList[i].GetClueLength() > spaceList[i].SpaceLength && i > 0)
                    {
                        //we need to move the first clue to the next space
                        spaceList[i - 1].AddClue(spaceList[i].RemoveClue(0));

                    }
                }

            }


            return false;
        }

        private static bool CluesWillFitInSpace(Space space, Blocks blocks)
        {
            //this takes a single space and checks if the clues will fit in it
            //if there is a block in the space then this needs taken into account too
            if (space.GetClueLength() > space.SpaceLength)
            {
                return false;
            }

            if (blocks.getBlockCount() == 0)
            {
                if (space.SpaceLength >= space.GetClueLength())
                {
                    return true;
                }
            }

            //if we've got this far there are blocks and things get complicated.

            //arrange the clues to cover the blocks if possible
            int blockNo = 0;
            int blockLength = blocks.getBlock(0).BlockLength;
            int blockStart = blocks.getBlock(0).BlockStart;
            int clueStart = 0;
            int clueLength;

            string blockColour = blocks.getBlock(0).BlockColour;
            string clueColour;
            string lastClueColour = "none";
            bool clueFits;

            for (int clueNo = 0; clueNo < space.GetClueCount(); clueNo++)
            {

                clueLength = space.GetClue(clueNo).Number;
                clueColour = space.GetClue(clueNo).Colour;
                clueFits = false;

                if (lastClueColour == clueColour) { clueStart += 1; } //same colours need a space between

                if (clueStart + clueLength -1 < blockStart)
                {
                    
                }


                while ((clueColour != blockColour || blockLength > clueLength) && (blockNo < blocks.getBlockCount()))
                {
                    clueStart = blockStart + blockLength; //the start of the clue is the first free space after the block
                    if (clueColour == blockColour) { clueStart += 1; }//if the block is the same colour as the clue we need a space between

                    blockNo += 1;
                    if (blockNo < blocks.getBlockCount())
                    {
                        blockLength = blocks.getBlock(blockNo).BlockLength;
                        blockStart = blocks.getBlock(blockNo).BlockStart;
                        blockColour = blocks.getBlock(blockNo).BlockColour;
                    }
                    else
                    {
                        blockColour = "none";
                    }
                }


                //now we should have the start position which may be before a block or after all the blocks
                if ((blockColour != "none") && (clueStart + clueLength < blockStart + blockLength))
                {                    
                    clueStart = blockStart - (clueLength - blockLength);
                }

                //the clue is placed. If it's on a block we know it covers that block
                if ((clueStart + clueLength - 1) > space.SpaceLength) { return false; } //out of bounds

                clueStart += clueLength;
                if (blockNo < blocks.getBlockCount() - 1) { blockNo += 1; }

                lastClueColour = clueColour;
            }

            return false;
        }

        private static bool Update(Grid grid, int col, int row, string value)
        {
            if (grid.GetCell(col, row).AutoValue != value)
            {
                grid.GetCell(col, row).AutoValue = value;
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

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

            if (blocks.getBlockCount() = 0)
            {
                if (space.SpaceLength >= space.GetClueLength())
                {
                    return true;
                }
            }

            //if we've got this far there are blocks and things get complicated.

            //make a list of strings to represent the space
            //fill it with " "
            List<string> spaceModel = new List<string>(); //set this up with the arrangement of blocks
            List<string> testModel = new List<string>(); //we put our clues in here
            for (int i = 0; i < space.SpaceLength; i++)
            {
                spaceModel.Add("clear");
                testModel.Add("clear");
            }
            //now add any blocks that are within this space
            foreach (Block block in blocks)
            {
                if (block.BlockStart >= space.SpaceStart && block.BlockStart < space.SpaceStart + space.SpaceLength)
                {
                    for (int i = block.BlockStart; i < block.BlockStart + block.BlockLength; i++)
                    {
                        spaceModel[i] = block.BlockColour;
                    }
                }
            }
            //arrange the clues to cover the blocks if possible
            int blockNo = 0;
            int blockLength = blocks.getBlock(blockNo).BlockLength;
            int blockStart = blocks.getBlock(blockNo).BlockStart;
            string blockColour = blocks.getBlock(blockNo).BlockColour;
            string lastBlockColour;
            int clueStart;
            int clueLength;
            int firstFreeSpace = 0;
            string clueColour;
            bool cluesDoFit = false;

            for (int clueNo = 0; clueNo < space.GetClueCount(); clueNo++)
            {
                //get the length of the clue and the length of the block
                //if block is longer then fail
                //we want to start as far left as possible while still covering the end of the block
                //need to keep track of where the end of the current clue is
                clueLength = space.GetClue(clueNo).Number;
                clueColour = space.GetClue(clueNo).Colour;
                while (clueColour != blockColour || blockLength > clueLength) 
                {
                    firstFreeSpace = blockStart + blockLength; //move the marker past the current block
                    //find a block that is the same colour and size (or smaller) than the current clue
                    if (blockNo < blocks.getBlockCount() - 1)
                    {
                        blockNo += 1;
                        blockLength = blocks.getBlock(blockNo).BlockLength;
                        blockStart = blocks.getBlock(blockNo).BlockStart;
                        blockColour = blocks.getBlock(blockNo).BlockColour;
                    }
                }



                {
                    clueStart = blockStart - (clueLength - blockLength);
                    if (clueStart < firstFreeSpace){ clueStart = firstFreeSpace; }

                    if (clueStart + clueLength > space.SpaceLength) { return false;} //out of bounds
                }

                if (clueNo > 0 && space.GetClue(clueNo - 1).Colour == space.GetClue(clueNo).Colour)
                {
                    clueStart += 1;
                }



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

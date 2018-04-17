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
            if (space.GetClueLength()>space.SpaceLength)
            {
                return false;
            }
            //make a list of strings to represent the space
            //fill it with " "
            List<string> spaceModel = new List<string>();
            for (int i = 0; i < space.SpaceLength;i++)
            {
                spaceModel.Add(" ");
            }
            //now add any blocks that are within this space
            foreach(Block block in blocks)
            {
                if(block.BlockStart >= space.SpaceStart && block.BlockStart < space.SpaceStart+space.SpaceLength)
                {
                    for (int i = block.BlockStart; i< block.BlockStart+block.BlockLength,i++)
                    {
                        spaceModel[i] = block.BlockColour;
                    }
                }
            }
            //now what?

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

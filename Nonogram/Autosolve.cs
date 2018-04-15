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
            //want to see if 

            //this method has not been written yet

            return solved;
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

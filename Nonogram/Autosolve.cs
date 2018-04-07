using System;
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
            int cellsToSolve = gameToSolve.Grid().GetRowCount() * gameToSolve.Grid().GetColCount();
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
            //check each row first
            //then each column
            //row is easy
            int elementLength = AutoUtilities.GetElementLength(gameToSolve.Grid(), true);
            for (int element = 0; element < gameToSolve.Grid().GetRowCount(); element++)
            {
                Clues currentElementClues = gameToSolve.Rows().getClueSet(element);
                solved = CellRowOverlap(gameToSolve.Grid(), currentElementClues, element, elementLength, true);
                totalSolved += solved;
                solved = 0;
            }
            elementLength = AutoUtilities.GetElementLength(gameToSolve.Grid(), false);
            for (int element = 0; element < gameToSolve.Grid().GetColCount(); element++)
            {
                Clues currentElementClues = gameToSolve.Cols().getClueSet(element);
                solved = CellRowOverlap(gameToSolve.Grid(), currentElementClues, element, elementLength, false);
                totalSolved += solved;
                solved = 0;
            }
            return totalSolved;
        }

        private static int CellRowOverlap(Grid grid, Clues clues, int element, int elementLength, bool isRow)
        {
            int solved = 0;
            Display.Log("Overlap element: " + element + " length: " + elementLength + " isRow = " + isRow);
            //need to know what blocks are already filled in


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

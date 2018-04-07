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
            for (int i = 0; i < gameToSolve.Grid().GetRowCount();i++)
            {
                CellRow currentRow = gameToSolve.Grid().GetCellRow(i);
                Clues currentRowClues = gameToSolve.Rows().getClueSet(i);
                solved = CellRowOverlap(currentRow,currentRowClues);

                totalSolved += solved;
                solved = 0;
            }

            return totalSolved;
        }

        private static int CellRowOverlap(CellRow row, Clues clues)
        {
            int solved = 0;
                     


            return solved;
        }
    }
}

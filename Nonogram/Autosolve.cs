using System;
using System.Collections.Generic;
using System.Collections;
namespace Nonogram
{
    public static class Autosolve
    {

        //Methods below should be private

        //LayoutIsLegal - compares supplied layout to ref one. Need to remember how this worked
        //LargestBlockEqualsLargestClue (uses getBlockInfo)
        //GetSpaceRound
        //BlocksMapToClues
        //ClueDistribution
        //IdentifyBlocks


        public static void Solve(Game gameToSolve)
        {
            int cellsToSolve = gameToSolve.Grid().GetLength(true) * gameToSolve.Grid().GetLength(false);
            int totalSolvedCells = 0;
            int solvedThisRound;
            int loopCount = 0;
            do
            {
                solvedThisRound = 0;
                Console.WriteLine("Overlap: ");
                solvedThisRound += MethodRunner(gameToSolve, "Overlap");
                Console.WriteLine("Single clue");
                solvedThisRound += MethodRunner(gameToSolve, "SingleClue");
                Console.WriteLine("Edge Proximity");
                solvedThisRound += MethodRunner(gameToSolve, "EdgeProximity");
                Console.WriteLine("Identify Blocks - move elsewhere later");
                solvedThisRound += MethodRunner(gameToSolve, "IdentifyBlocks");

                totalSolvedCells += solvedThisRound;
                loopCount += 1;
                Console.WriteLine("End loop no " + loopCount);
            } while (solvedThisRound > 0);




            //Identify Blocks
        }

        private static int MethodRunner(Game gameToSolve, String methodToCall)
        {
            //handles iteration through all rows and columns using the requested method
            int totalSolved = 0;
            int solved = 0;
            int elementLength;
            int elementCount;
            bool isRow = true;
            string elementType = "row";
            Clues currentElementClues;

            for (int loopCount = 0; loopCount < 2; loopCount++)
            {
                elementLength = gameToSolve.Grid().GetLength(isRow);
                elementCount = gameToSolve.Grid().GetCount(isRow);
                Console.WriteLine(elementType + ": ");
                for (int element = 0; element < elementCount; element++)
                {
                    if (isRow)
                    {
                        currentElementClues = gameToSolve.Rows().getClueSet(element);
                    }
                    else
                    {
                        currentElementClues = gameToSolve.Cols().getClueSet(element);
                    }

                    switch (methodToCall)
                    {
                        case "Overlap":
                            solved = Overlap(gameToSolve.Grid(), currentElementClues, element, elementLength, isRow);
                            break;
                        case "SingleClue":
                            solved = SingleClue(gameToSolve.Grid(), currentElementClues, element, elementLength, isRow);
                            break;
                        case "EdgeProximity":
                            solved = EdgeProximity(gameToSolve.Grid(), currentElementClues, element, elementLength, isRow);
                            break;
                        default:
                            Console.WriteLine("unknown method called");
                            break;
                    }

                    Console.WriteLine("Solved on " + elementType + " " + element + ": " + solved);
                    totalSolved += solved;
                    solved = 0;
                }
                isRow = false;
                elementType = "column";
            }
            return totalSolved;
        }


        private static int Overlap(Grid grid, Clues clues, int element, int elementLength, bool isRow)
        {
            int filled = 0;
            int firstFree = grid.GetFirstFreeCell(element, isRow);
            int lastFree = grid.GetLastFreeCell(element, isRow);
            int rowToUpdate;
            int colToUpdate;

            for (int clueNo = 0; clueNo < clues.GetClueCount(); clueNo++)
            {
                //this needs adapted to take account of filled cells
                int endClueLeft = firstFree - 1 + clues.GetClueLength(0, clueNo);
                int startClueRight = lastFree + 1 - clues.GetClueLength(clueNo, clues.GetClueCount() - 1);
                if (startClueRight <= endClueLeft)
                {
                    for (int cellNo = startClueRight; cellNo <= endClueLeft; cellNo++)
                    {
                        rowToUpdate = (isRow) ? element : cellNo;
                        colToUpdate = (isRow) ? cellNo : element;
                        if (Update(grid, colToUpdate, rowToUpdate, clues.getClue(clueNo).Colour)) { filled += 1; }
                    }
                }
            }
            return filled;
        }

        private static int SingleClue(Grid grid, Clues clues, int element, int elementLength, bool isRow)
        {
            return 0;
        }

        public static int EdgeProximity(Grid grid, Clues clues, int element, int elementLength, bool isRow)
        {
            return 0;
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

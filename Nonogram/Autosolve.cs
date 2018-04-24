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

            Overlap(gameToSolve);
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
            Console.WriteLine("Rows: ");
            for (int element = 0; element < elementLength; element++)
            {
                Clues currentElementClues = gameToSolve.Rows().getClueSet(element);
                Blocks currentElementBlocks = gameToSolve.Grid().GetBlocks(element, true);
                Spaces currentSpaces = gameToSolve.Grid().GetSpaces(element, true);

                solved = IdentifyFilledCells(gameToSolve.Grid(), currentElementClues, currentElementBlocks, element, elementLength, true);
                Console.WriteLine("Solved on row "+element+": "+solved);
                totalSolved += solved;
                solved = 0;
            }

            elementLength = gameToSolve.Grid().GetLength(false); //number of columns
            Console.WriteLine("Columns: ");
            for (int element = 0; element < elementLength; element++)
            {
                Clues currentElementClues = gameToSolve.Cols().getClueSet(element);
                Blocks currentElementBlocks = gameToSolve.Grid().GetBlocks(element, false);
                Spaces currentSpaces = gameToSolve.Grid().GetSpaces(element, false);

                solved = IdentifyFilledCells(gameToSolve.Grid(), currentElementClues, currentElementBlocks, element, elementLength, false);
                Console.WriteLine("Solved on column " + element + ": " + solved);
                totalSolved += solved;
                solved = 0;
            }
            return totalSolved;
        }

        private static int IdentifyFilledCells(Grid grid, Clues clues, Blocks blocks,int element, int elementLength, bool isRow)
        {
            int filled = 0;
            int firstFree = grid.GetFirstFreeCell(element,isRow);
            int lastFree = grid.GetLastFreeCell(element, isRow);
            for (int clueNo = 0; clueNo < clues.GetClueCount(); clueNo++)
            {
                //this needs adapted to take account of filled cells
                int endClueLeft = firstFree-1 + clues.GetClueLength(0, clueNo);
                int startClueRight = lastFree +1 - clues.GetClueLength(clueNo, clues.GetClueCount()-1);
                if (startClueRight <= endClueLeft)
                {
                    for (int cellNo = startClueRight; cellNo <= endClueLeft;cellNo++)
                    {
                        int rowToUpdate;
                        int colToUpdate;
                        if (isRow)
                        {
                            rowToUpdate = element;
                            colToUpdate = cellNo;
                        }
                        else
                        {
                            rowToUpdate = cellNo;
                            colToUpdate = element;
                        }
                        if (Update(grid, colToUpdate, rowToUpdate, clues.getClue(clueNo).Colour)) { filled += 1; }
                    }
                }
            }


            return filled;
        }

        public static bool CluesWillFitInSpaces(Clues clues, Spaces spaces, Blocks blocks)
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

            bool finished = false;
            while (!finished)

            {
                //move the next clue into the last space
                if (clueList.Count > 0)
                {
                    spaceList[spaceList.Count - 1].AddClue(clueList[0]);
                    clueList.RemoveAt(0);    
                }

                for (int i = spaceList.Count - 1; i >= 0;i--)
                {
                    // for each space, if the clues are too long to fit, move the first one out
                    while (!CluesWillFitInSpace(spaceList[i],blocks))
                    {
                        //we need to move the first clue to the next space. If we're in space0 we can't and the test fails
                        if (i == 0) { return false; }
                        spaceList[i - 1].AddClue(spaceList[i].RemoveClue(0));    

                    }
                }
                finished = clueList.Count == 0;
            }

            return true;
        }

        private static bool CluesWillFitInSpace(Space space, Blocks blocks)
        {
            //this takes a single space and checks if the clues will fit in it
            //if there is a block in the space then this needs taken into account too
            int startPos = 0;
            if (space.GetClueLength() > space.SpaceLength)
            {
                return false;
            }

            if (blocks.getBlockCount() == 0 && space.SpaceLength >= space.GetClueLength())
            {                
                return true;
            }

            //if we've got this far there are blocks and things get complicated.
            string lastClueColour = "";

            for (int clueNo = 0; clueNo < space.GetClueCount(); clueNo++)
            {
                //new method find clue position - returns clue position if clue fits and -1 if it cannot
                if (lastClueColour == space.GetClue(clueNo).Colour) { startPos += 1; }
                startPos = ClueFitPosition(space, blocks, clueNo, startPos);
                if (startPos == -1){ return false; }
                // if the clue fits update the start position
                startPos += space.GetClue(clueNo).Number;
                lastClueColour = space.GetClue(clueNo).Colour;
            }
            //if we get out of the loop above then the clues all fit
            return true;
        }

        private static int ClueFitPosition(Space space, Blocks blocks, int clueNo, int startPos)
        {
            int endPos;
            int fitPosition = -1;
            // can the specified clue fit into the space at all. 
            // if yes, return position, if not return -1
            if (clueNo >= space.GetClueCount()) { return -1; }
            if (startPos >= space.SpaceLength) { return -1; }
            if (blocks.getBlockCount() == 0 && space.GetClue(clueNo).Number < space.SpaceLength) { return startPos; }
            //is space before startPos occupied by a block?
            foreach (Block block in blocks)
            {
                if (block.BlockStart+block.BlockLength-1 == startPos -1 && block.BlockColour == space.GetClue(clueNo).Colour)
                {
                    startPos += 1;
                }
            }
            //that gives the start position. Now see if the clue can fit either in free space or by overlapping a block

            foreach (Block block in blocks)
            {
                endPos = startPos + space.GetClue(clueNo).Number - 1; //last space filled by the clue
                //is there a block at that position?
                if (block.BlockStart <= endPos + 1 && block.BlockStart+block.BlockLength > endPos)
                {
                    //block either touching or overlapping our clue
                    if (block.BlockStart == endPos+1 && block.BlockColour != space.GetClue(clueNo).Colour)
                    {                        
                        //block starts one space after clue but they are different colours so this is legal
                        break;
                    }
                    else
                    {                        
                        //if the block is the same colour see if we can overlap
                        if (block.BlockColour == space.GetClue(clueNo).Colour)
                        {
                            if (block.BlockLength <= space.GetClue(clueNo).Number)
                            {
                                //block smaller or same size as clue. Arrange clue so end of clue == end of block
                                startPos = block.BlockStart - (space.GetClue(clueNo).Number - block.BlockLength);
                            }
                            else
                            {
                                //block is longer than clue. Cannot overlap Move startpos to end of block + 1
                                startPos = block.BlockStart + block.BlockLength + 1;
                            }
                        }
                        else
                        {
                            //block is a different colour. Move startpos to the end of the block touching it
                            startPos = block.BlockStart + block.BlockLength;
                        }
                    }
                }
            }
            fitPosition = startPos;
            if (startPos + space.GetClue(clueNo).Number > space.SpaceLength) { fitPosition = -1; }                        
            return fitPosition;
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

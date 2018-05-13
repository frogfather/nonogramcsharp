﻿using System;
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
                Console.WriteLine("End loop no "+loopCount);
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
            Blocks currentElementBlocks;
            Spaces currentSpaces;

            for (int loopCount = 0; loopCount < 2; loopCount++)
            {
                elementLength = gameToSolve.Grid().GetLength(isRow); 
                elementCount = gameToSolve.Grid().GetCount(isRow); 
                Console.WriteLine(elementType+": ");
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

                    currentElementBlocks = gameToSolve.Grid().GetBlocks(element, isRow);
                    currentSpaces = gameToSolve.Grid().GetSpaces(element, isRow);
                    switch (methodToCall)
                    {
                        case "Overlap":
                            solved = Overlap(gameToSolve.Grid(), currentElementClues, currentElementBlocks, element, elementLength, isRow);
                            break;
                        case "SingleClue":
                            solved = SingleClue(gameToSolve.Grid(), currentElementClues, currentElementBlocks, element, elementLength, isRow);
                            break;
                        case "EdgeProximity":
                            solved = EdgeProximity(gameToSolve.Grid(), currentElementClues, currentElementBlocks, element, elementLength, isRow);
                            break;
                        case "IdentifyBlocks":
                            IdentifyBlocks(gameToSolve.Grid(), currentElementClues, currentElementBlocks, element, elementLength,isRow);
                            break;
                        default:
                            Console.WriteLine("unknown method called");
                            break;
                    }

                    Console.WriteLine("Solved on "+elementType+ " " + element + ": " + solved);
                    totalSolved += solved;
                    solved = 0;
                }
                isRow = false;
                elementType = "column";
            }
            return totalSolved;
        }


        private static int Overlap(Grid grid, Clues clues, Blocks blocks,int element, int elementLength, bool isRow)
        {
            int filled = 0;
            int firstFree = grid.GetFirstFreeCell(element,isRow);
            int lastFree = grid.GetLastFreeCell(element, isRow);
            int rowToUpdate;
            int colToUpdate;

            for (int clueNo = 0; clueNo < clues.GetClueCount(); clueNo++)
            {
                //this needs adapted to take account of filled cells
                int endClueLeft = firstFree-1 + clues.GetClueLength(0, clueNo);
                int startClueRight = lastFree +1 - clues.GetClueLength(clueNo, clues.GetClueCount()-1);
                if (startClueRight <= endClueLeft)
                {
                    for (int cellNo = startClueRight; cellNo <= endClueLeft;cellNo++)
                    {
                        rowToUpdate = (isRow) ? element : cellNo;
                        colToUpdate = (isRow) ? cellNo : element;
                        if (Update(grid, colToUpdate, rowToUpdate, clues.getClue(clueNo).Colour)) { filled += 1; }
                    }
                }
            }
            return filled;
        }

        private static int SingleClue(Grid grid, Clues clues, Blocks blocks, int element, int elementLength, bool isRow)
        {
            int filled = 0;
            int blocksStart;
            int blocksEnd;
            int rowToUpdate;
            int colToUpdate;
            Clue clue;
            //we know there is only one clue. If there is more than one block then the space between them must be filled in.
            if(blocks.GetBlockCount()>0 && clues.GetClueCount() == 1)
            {
                blocksStart = blocks.GetBlock(0).BlockStart;
                blocksEnd = blocks.GetBlock(blocks.GetBlockCount() - 1).BlockStart + blocks.GetBlock(blocks.GetBlockCount() - 1).BlockLength - 1;
                clue = clues.getClue(0);
                for (int cellNo = grid.GetFirstFreeCell(element, isRow); cellNo <= grid.GetLastFreeCell(element, isRow); cellNo++)
                {
                    rowToUpdate = (isRow) ? element : cellNo;
                    colToUpdate = (isRow) ? cellNo : element;

                    if (cellNo >= blocksStart && cellNo <= blocksEnd)
                    {
                        if (Update(grid, colToUpdate, rowToUpdate, clue.Colour)) { filled += 1; }
                    }
                    else if (cellNo < blocksEnd - clue.Number + 1 || cellNo > blocksStart + clue.Number - 1)
                    {
                        if (Update(grid, colToUpdate, rowToUpdate, "cross")) { filled += 1; }
                    }
                }
            }
            return filled;
        }

        public static int EdgeProximity(Grid grid, Clues clues, Blocks blocks, int element, int elementLength, bool isRow)
        {
            int filled = 0;
            int rowToUpdate;
            int colToUpdate;
            bool atStart = true;
            int fillFrom =-1;
            int fillTo = -1;
            //Cross out cells which logically cannot be filled because there's too big a gap between the first block and the edge of the element.
            if (blocks.GetBlockCount() > 0 && clues.GetClueCount()>0)
            {
                for (int loopCount = 0; loopCount < 2; loopCount++)
                {
                    if (atStart && blocks.GetBlock(0).BlockColour ==clues.getClue(0).Colour)
                    {
                        fillFrom = blocks.GetBlock(0).BlockStart - clues.getClue(0).Number;
                        fillTo =   fillFrom + blocks.GetBlock(0).BlockLength - 1;
                        fillFrom = (fillFrom < 0) ? 0 : fillFrom;

                    }
                    else if (!atStart && blocks.GetBlock(blocks.GetBlockCount()-1).BlockColour == clues.getClue(clues.GetClueCount()-1).Colour)
                    {
                        fillFrom = blocks.GetBlock(blocks.GetBlockCount()-1).BlockStart + clues.getClue(clues.GetClueCount()-1).Number;
                        fillTo = fillFrom + blocks.GetBlock(blocks.GetBlockCount()-1).BlockLength;
                        fillTo = (fillTo > elementLength-1) ? elementLength-1 : fillTo;
                    }

                    if ((fillFrom == 0 && fillTo >= 0)||(fillTo == elementLength && fillFrom <= elementLength))
                    {
                        for (int cellNo = fillFrom; cellNo <= fillTo;cellNo++)
                        {
                            rowToUpdate = (isRow) ? element : cellNo;
                            colToUpdate = (isRow) ? cellNo : element;
                            if (Update(grid, colToUpdate, rowToUpdate, "cross")) { filled += 1; }
                        }
                    }
                    atStart = false;
                }
            }
            return filled;
        }

        public static void IdentifyBlocks(Grid grid, Clues clues, Blocks blocks, int element, int elementLength, bool isRow)
        {
            if (blocks.GetBlockCount()>0 && !clues.AllCluesSolved())
            {
                Clues cluesBefore = new Clues();
                Clues cluesAfter = new Clues();
                Blocks blocksAfter = new Blocks();
                Blocks blocksBefore = new Blocks();
                int currentClueMaxEnd = -1; //furthest right the current clue can go and still legally match the current block.
                int currentClueMinStart = -1; //furthest left the current clue can go and still legally match the current block;
                blocksAfter.RemoveAll();
                foreach(Block testBlock in blocks){blocksAfter.AddBlock(testBlock);}
                //for each block, the only question we need to ask is 'can this block legally fit here?'
                for (int blockNo = 0; blockNo < blocks.GetBlockCount();blockNo++)
                {
                    if(blocksAfter.GetBlockCount()>0){blocksAfter.RemoveBlock(0);}
                    cluesAfter.RemoveAll();
                    cluesBefore.RemoveAll();
                    foreach (Clue testClue in clues){ cluesAfter.AddClue(testClue); }
                    for (int clueNo = 0; clueNo < clues.GetClueCount(); clueNo++)
                    {                        
                        currentClueMaxEnd = GetClueMatchPos(blocks.GetBlock(blockNo), clues, clueNo, true);
                        //this returns the LAST space that the previous clues can fit into
                        currentClueMinStart = GetClueMatchPos(blocks.GetBlock(blockNo), clues, clueNo, false);
                        //this returns the FIRST space that the next clues can fit into

                        if (cluesAfter.GetClueCount() > 0) { cluesAfter.RemoveClue(0); }
                        if (blocks.GetBlock(blockNo).BlockLength <= clues.getClue(clueNo).Number)
                        {
                            
                        }
                        else
                        {
                            Console.WriteLine("Clue "+ clueNo + " is shorter than current block");
                        }
                        cluesBefore.AddClue(clues.getClue(clueNo));
                    }
                    blocksBefore.AddBlock(blocks.GetBlock(blockNo));
                }
                
            }
        }

        public static bool CluesWillFitInSpace(int start, int end, Blocks blocks, Clues clues)
        {            
            if (clues.GetClueLength() < blocks.GetBlockLength()) { return false; } //blocks longer than clues
            if (clues.GetClueLength() > end - start + 1) { return false;} // clues won't fit into this space
            if (blocks.GetBlockCount() == 0) { return true; }
            //will the provided clues fit in the specified space?
            Dictionary<Clue, int> cluePositions = new Dictionary<Clue, int>();
            //add the clues as close together as they'll fit. Start at length - cluelength
            int startPos = end - start + 1 - clues.GetClueLength();
            string prevColour = "none";
            for (int i = 0; i < clues.GetClueCount();i++)
            {
                if (prevColour == clues.getClue(i).Colour) { startPos += 1; }
                cluePositions.Add(clues.getClue(i),startPos);
                startPos += clues.getClue(i).Number;
                prevColour = clues.getClue(i).Colour;
            }
            //this sets things up. Now see if all clues are either in free space or entirely over blocks

        }

        public static int GetClueMatchPos(Block block, Clues clues, int clueId, bool start)
        {
            int positionToReturn = -1;

            if (block.BlockLength > clues.getClue(clueId).Number) { positionToReturn = -1; }
            if (block.BlockColour != clues.getClue(clueId).Colour) { positionToReturn = -1; }
            if (start) 
            { 
                positionToReturn = block.BlockStart - 1;
                if (clueId > 0 && clues.getClue(clueId).Colour == clues.getClue(clueId - 1).Colour) { positionToReturn -= 1;}
            }
            else
            {
                positionToReturn = block.BlockStart + block.BlockLength;
                if (clueId < clues.GetClueCount() - 1 && clues.getClue(clueId).Colour == clues.getClue(clueId + 1).Colour) { positionToReturn += 1; }
            }

            return positionToReturn;
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

            if (blocks.GetBlockCount() == 0 && space.SpaceLength >= space.GetClueLength())
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
            if (blocks.GetBlockCount() == 0 && space.GetClue(clueNo).Number < space.SpaceLength) { return startPos; }
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

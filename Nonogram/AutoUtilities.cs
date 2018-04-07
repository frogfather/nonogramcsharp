using System;
using System.Collections.Generic;
namespace Nonogram
{
    public static class AutoUtilities
    {
        //this class contains utilities for auto solving
        //CompareArrays - not sure if needed here - may be compare Lists anyway
        //GetLargestClue  - already have that in Clues class
        //GetLastFreeCell 
        //GetFirstFreeCell

        public static int GetElementLength(Grid grid, Boolean isRow)
        {
            if (isRow)
            {
                return grid.GetColCount();
            }
            else
            {
                return grid.GetRowCount();
            }

        }

        public static List<Block> GetBlockInfo(Grid grid, int element, bool isRow)
        {
            List<Block> blockArray = new List<Block>();
            //returns filled in blocks - each block has a length, start, colour and array of clues
            int elementLength = GetElementLength(grid, isRow);
            int blockStart = 0;
            int blockLength = 0;
            string blockColour = "";
            string elementColour;
            string nextElementColour;

            for (int i = 0; i < elementLength; i++)
            {
                //examine each cell in the row or column
                if (isRow)
                {
                    elementColour = grid.GetCell(i, element).AutoValue;
                    if (i < elementLength - 1)
                    {
                        nextElementColour = grid.GetCell(i + 1, element).AutoValue;
                    }
                    else
                    {
                        nextElementColour = "clear";
                    }
                }
                else
                {
                    elementColour = grid.GetCell(element, i).AutoValue;
                    if (i < elementLength -1)
                    {
                        nextElementColour = grid.GetCell(element, i+1).AutoValue;
                    }
                    else
                    {
                        nextElementColour = "clear";
                    }
                }
                if (i == 0)
                {
                    blockColour = elementColour;
                }

                if (elementColour != "cross" && elementColour != "clear")
                {
                    blockLength += 1;
                    blockColour = elementColour;
                }

                if (elementColour != nextElementColour && blockLength > 0)
                {
                    AddBlock(blockArray,blockStart,blockLength,blockColour);
                }
            }

            return blockArray;
        }

        public static void AddBlock(List<Block> blockList, int blockStart, int blockLength, string blockColour)
        {
            blockList.Add(new Block(blockLength,blockStart,blockColour));
        }

    }
}

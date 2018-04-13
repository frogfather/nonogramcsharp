using System;
using System.Collections.Generic;
namespace Nonogram
{
    public class Grid
    {
        public Grid(int rows, int columns)
        {
            _grid = new List<CellRow>();
            for (var i = 0; i < rows; i++)
            {
                _grid.Add(new CellRow(i, columns));
            }
        }

        public CellRow GetCellRow(int rowNumber)
        {
            if ((rowNumber < _grid.Count) && (rowNumber >= 0))
            {
                return _grid[rowNumber];
            }
            else
            {
                return null;
            }
        }

        public Cell GetCell(int column, int row)
        {
            return _grid[row].GetCell(column);
        }

        public int GetLength(bool row)
        {
            if (row)
            {
                return GetRowCount();
            }
            else
            {
                return GetColCount();
            }
        }

        private int GetRowCount()
        {
            return _grid.Count;
        }

        private int GetColCount()
        {
            if (_grid.Count > 0)
            {
                return _grid[0].GetColCount();
            }
            else
            {
                return 0;
            }
        }

        public int GetFirstFreeCell(int element, bool isRow)
        {
            int freeCellPos = -1;
            int elementLength;
            string elementAutoValue;
            if (isRow)
            {
                elementLength = GetColCount();
            }
            else
            {
                elementLength = GetRowCount();
            }

            for (int i = 0; i < elementLength; i++)
            {
                if (isRow)
                {
                    elementAutoValue = GetCell(i, element).AutoValue;
                }
                else
                {
                    elementAutoValue = GetCell(element, i).AutoValue;
                }
                if (elementAutoValue != "cross")
                {
                    freeCellPos = i;
                    break;
                }
            }
            return freeCellPos;
        }

        public int GetLastFreeCell(int element, bool isRow)
        {
            int freeCellPos = -1;
            int elementLength;
            string elementAutoValue;
            if (isRow)
            {
                elementLength = GetColCount();
            }
            else
            {
                elementLength = GetRowCount();
            }

            for (int i = elementLength-1; i >= 0; i--)
            {
                if (isRow)
                {
                    elementAutoValue = GetCell(i, element).AutoValue;
                }
                else
                {
                    elementAutoValue = GetCell(element, i).AutoValue;
                }
                if (elementAutoValue != "cross")
                {
                    freeCellPos = i;
                    break;
                }
            }
            return freeCellPos;
        }

        public Blocks GetBlocks(int element, bool isRow)
        {
            List<BlockData> options = new List<BlockData>();

            int elementLength;
            int blockStart = 0;
            int blockLength = 0;
            string blockColour = "";
            string elementColour;
            string nextElementColour;

            if (isRow)
            {
                elementLength = GetColCount();
            }
            else
            {
                elementLength = GetRowCount();
            }

            for (int i = 0; i < elementLength; i++)
            {
                //examine each cell in the row or column
                if (isRow)
                {
                    elementColour = GetCell(i, element).AutoValue;
                    if (i < elementLength - 1)
                    {
                        nextElementColour = GetCell(i + 1, element).AutoValue;
                    }
                    else
                    {
                        nextElementColour = "clear";
                    }
                }
                else
                {
                    elementColour = GetCell(element, i).AutoValue;
                    if (i < elementLength - 1)
                    {
                        nextElementColour = GetCell(element, i + 1).AutoValue;
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
                    if (blockLength == 0)
                    {
                        blockStart = i;
                    }
                    blockLength += 1;
                    blockColour = elementColour;
                }

                if (elementColour != nextElementColour && blockLength > 0)
                {
                    options.Add(new BlockData(blockStart, blockLength, blockColour));
                    blockLength = 0;
                }
            }

            return new Blocks(options);
        }


        private List<CellRow> _grid;

    }
}

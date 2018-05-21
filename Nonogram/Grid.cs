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
                return GetColCount();
            }
            else
            {
                return GetRowCount();
            }
        }

        public int GetCount(bool row)
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

        public string GetElementColour(int position, int element, int elementLength, bool isRow)
        {
            if (position >= elementLength) 
            {
                return "cross";
            }

            if (isRow)
            {                
                return GetCell(position, element).AutoValue;
            }
            return GetCell(element, position).AutoValue;
        }

        public int GetElementLength(bool isRow)
        {
            if (isRow)
            {
                return GetColCount();
            }
            else
            {
                return GetRowCount();
            }

        }

        public bool AllCellsClear(int element, bool isRow)
        {
            int eLength = GetElementLength(isRow);
            for (int i = 0; i < eLength ; i++)   
            {
                if (GetElementColour(i, element, eLength, isRow) != "clear") { return false; }
            }
            return true;
        }

        private List<CellRow> _grid;

    }
}

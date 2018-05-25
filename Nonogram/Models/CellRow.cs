using System;
using System.Collections.Generic;
namespace Nonogram
{
    public class CellRow
    {
        public CellRow(int rowNumber, int columns)
        {
            _cellRow = new List<Cell>();
            for (int i = 0; i < columns; i++)
            {
                //create a new cell and add it to the cells array
                _cellRow.Add(new Cell(rowNumber, i));
            }
        }

        public Cell GetCell(int columnNumber)
        {
            if ((columnNumber > -1) && (columnNumber < _cellRow.Count))
            {
                return _cellRow[columnNumber];
            }
            else
            {
                return null;
            }

        }
        public int GetColCount()
        {
            return _cellRow.Count;
        }

        private List<Cell> _cellRow;
    }
}

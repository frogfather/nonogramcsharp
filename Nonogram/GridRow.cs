using System;
using System.Collections.Generic;
namespace Nonogram
{
    public class GridRow
    {
        public GridRow(int rowNumber, int columns)
        {
            _gameRow = new List<Cell>();
            for (int i = 0; i < columns; i++)
            {
                //create a new cell and add it to the cells array
                _gameRow.Add(new Cell(rowNumber, i));
            }
        }

        public Cell GetCell(int columnNumber)
        {
            if ((columnNumber > -1) && (columnNumber < _gameRow.Count))
            {
                return _gameRow[columnNumber];
            }
            else
            {
                return null;
            }

        }
        public int GetColCount()
        {
            return _gameRow.Count;
        }

        private List<Cell> _gameRow;
    }
}

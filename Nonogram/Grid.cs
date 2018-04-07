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

        public int GetRowCount()
        {
            return _grid.Count;
        }

        public int GetColCount()
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

        private List<CellRow> _grid;

    }
}

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

        public CellRow getCellRow(int rowNumber)
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
        public int getRowCount()
        {
            return _grid.Count;
        }
        private List<CellRow> _grid;

    }
}

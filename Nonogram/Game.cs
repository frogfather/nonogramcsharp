using System;
using System.Collections.Generic;
namespace Nonogram
{
    public class Game
    {
        //need to pass in info for grid (rows and columns)
        //and info for rows (list of list of clueData)
        //and info for columns (same as above)
        public Game(GameData options)
        {
            _grid = new Grid(options.rows, options.columns);
            _rows = new Rows(options.rowData);
            _columns = new Columns(options.columnData);
        }

        public CellRow getGridCellRow(int index)//returns the specified row of cells
        {
            if (index >= 0 && index < _grid.getRowCount())
            {
                return _grid.getCellRow(index);
            }
            else
            {
                return null;
            }
        }

        public Rows Rows()
        {
            return _rows;
        }
        public Columns Cols()
        {
            return _columns;
        }

        public Clues getClueSetRow(int index) //return the Clues object representing the clues for that row
        {
            if (index >=0 && index < _rows.rowCount())
            {
                return _rows.getClueSet(index);
            }
            else
            {
                return null;
            }
        }



        private Grid _grid;
        private Rows _rows;
        private Columns _columns;
    }
}

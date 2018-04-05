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

        public CellRow GetGridCellRow(int index)//returns the specified row of cells
        {
            if (index >= 0 && index < _grid.GetRowCount())
            {
                return _grid.GetCellRow(index);
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

        public Grid Grid()
        {
            return _grid;
        }

        public Clues GetClueSetRow(int index) //return the Clues object representing the clues for that row
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

        public int GetMaxRowClues()
        {
            //look at the clueRow property and find the longest clues
            int maxClueLength = 0;
            foreach (Clues clueRow in Rows())
            {
                if (clueRow.getClueCount() > maxClueLength)
                {
                    maxClueLength = clueRow.getClueCount();
                }
            }
            return maxClueLength;
        }

        public int GetMaxColClues()
        {
            //look at the clueRow property and find the longest clues
            int maxClueLength = 0;
            foreach (Clues clueCol in Cols())
            {
                if (clueCol.getClueCount() > maxClueLength)
                {
                    maxClueLength = clueCol.getClueCount();
                }
            }
            return maxClueLength;
        }


        private Grid _grid;
        private Rows _rows;
        private Columns _columns;
    }
}

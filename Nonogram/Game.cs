using System;
using System.Collections.Generic;
namespace Nonogram
{
    public class Game
    {
        //need to pass in info for grid (rows and columns)
        //and info for rows (list of list of clueData)
        //and info for columns (same as above)
        public Game(int gameRows, int gameCols)
        {
            _grid = new Grid(gameRows, gameCols);
            _rows = new List<Clues>();
            _columns = new List<Clues>();
        }
        private Grid _grid;
        private List<Clues> _rows;
        private List<Clues> _columns;
    }
}

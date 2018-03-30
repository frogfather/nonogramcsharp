using System;
using System.Collections.Generic;
namespace Nonogram
{
    public struct GameData
    {
        public List<List<ClueData>> rowData;
        public List<List<ClueData>> columnData;
        public int rows;
        public int columns;

        public GameData(GameData options)
        {
            rowData = options.rowData;
            columnData = options.columnData;
            rows = options.rows;
            columns = options.columns;
        }
    }
}

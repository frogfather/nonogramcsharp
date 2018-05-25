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

        public GameData(List<List<ClueData>> rowInfo, List<List<ClueData>> colInfo, int rowcount, int colcount)
        {
            rowData = rowInfo;
            columnData = colInfo;
            rows = rowcount;
            columns = colcount;
        }
    }
}

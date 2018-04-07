using System;
using System.Collections.Generic;
namespace Nonogram
{
    public static class PuzzleData
    {

        public static GameData PuzzleOne()
        {
            //eventually this will take a JSON object and convert it to GameData
            GameData options = new GameData();
            List<List<ClueData>> rowData = new List<List<ClueData>>();
            List<List<ClueData>> colData = new List<List<ClueData>>();

            List<ClueData> clueRow1 = new List<ClueData>();
            clueRow1.Add(new ClueData(5, "black"));
            List<ClueData> clueRow2 = new List<ClueData>();
            clueRow2.Add(new ClueData(1, "black"));
            List<ClueData> clueRow3 = new List<ClueData>();
            clueRow3.Add(new ClueData(5, "black"));
            List<ClueData> clueRow4 = new List<ClueData>();
            clueRow4.Add(new ClueData(1, "black"));
            List<ClueData> clueRow5 = new List<ClueData>();
            clueRow5.Add(new ClueData(5, "black"));

            rowData.Add(clueRow1);
            rowData.Add(clueRow2);
            rowData.Add(clueRow3);
            rowData.Add(clueRow4);
            rowData.Add(clueRow5);

            List<ClueData> clueCol1 = new List<ClueData>();
            clueCol1.Add(new ClueData(3, "black"));
            clueCol1.Add(new ClueData(1, "black"));
            List<ClueData> clueCol2 = new List<ClueData>();
            clueCol2.Add(new ClueData(1, "black"));
            clueCol2.Add(new ClueData(1, "black"));
            clueCol2.Add(new ClueData(1, "black"));
            List<ClueData> clueCol3 = new List<ClueData>();
            clueCol3.Add(new ClueData(1, "black"));
            clueCol3.Add(new ClueData(1, "black"));
            clueCol3.Add(new ClueData(1, "black"));
            List<ClueData> clueCol4 = new List<ClueData>();
            clueCol4.Add(new ClueData(1, "black"));
            clueCol4.Add(new ClueData(1, "black"));
            clueCol4.Add(new ClueData(1, "black"));
            List<ClueData> clueCol5 = new List<ClueData>();
            clueCol5.Add(new ClueData(1, "black"));
            clueCol5.Add(new ClueData(3, "black"));

            colData.Add(clueCol1);
            colData.Add(clueCol2);
            colData.Add(clueCol3);
            colData.Add(clueCol4);
            colData.Add(clueCol5);

            options.rowData = rowData;
            options.columnData = colData;
            options.columns = 5;
            options.rows = 5;
            return options;
        }

        public static GameData PuzzleTwo()
        {
            //eventually this will take a JSON object and convert it to GameData
            GameData options = new GameData();
            List<List<ClueData>> rowData = new List<List<ClueData>>();
            List<List<ClueData>> colData = new List<List<ClueData>>();

            List<ClueData> clueRow1 = new List<ClueData>();
            clueRow1.Add(new ClueData(3, "black"));
            List<ClueData> clueRow2 = new List<ClueData>();
            clueRow2.Add(new ClueData(3, "black"));
            clueRow2.Add(new ClueData(1, "black"));
            List<ClueData> clueRow3 = new List<ClueData>();
            clueRow3.Add(new ClueData(2, "black"));
            clueRow3.Add(new ClueData(2, "black"));
            clueRow3.Add(new ClueData(1, "black"));
            clueRow3.Add(new ClueData(1, "black"));
            List<ClueData> clueRow4 = new List<ClueData>();
            clueRow4.Add(new ClueData(1, "black"));
            clueRow4.Add(new ClueData(1, "black"));
            clueRow4.Add(new ClueData(1, "black"));
            clueRow4.Add(new ClueData(2, "black"));
            clueRow4.Add(new ClueData(4, "black"));
            List<ClueData> clueRow5 = new List<ClueData>();
            clueRow5.Add(new ClueData(1, "black"));
            clueRow5.Add(new ClueData(6, "black"));
            clueRow5.Add(new ClueData(2, "black"));
            clueRow5.Add(new ClueData(7, "black"));
            List<ClueData> clueRow6 = new List<ClueData>();
            clueRow6.Add(new ClueData(2, "black"));
            clueRow6.Add(new ClueData(6, "black"));
            clueRow6.Add(new ClueData(3, "black"));
            List<ClueData> clueRow7 = new List<ClueData>();
            clueRow7.Add(new ClueData(10, "black"));
            clueRow7.Add(new ClueData(1, "black"));
            List<ClueData> clueRow8 = new List<ClueData>();
            clueRow8.Add(new ClueData(4, "black"));
            List<ClueData> clueRow9 = new List<ClueData>();
            clueRow9.Add(new ClueData(4, "black"));
            List<ClueData> clueRow10 = new List<ClueData>();
            clueRow10.Add(new ClueData(8, "black"));
            List<ClueData> clueRow11 = new List<ClueData>();
            clueRow11.Add(new ClueData(1, "black"));
            clueRow11.Add(new ClueData(2, "black"));
            clueRow11.Add(new ClueData(2, "black"));
            List<ClueData> clueRow12 = new List<ClueData>();
            clueRow12.Add(new ClueData(1, "black"));
            clueRow12.Add(new ClueData(6, "black"));
            clueRow12.Add(new ClueData(2, "black"));
            List<ClueData> clueRow13 = new List<ClueData>();
            clueRow13.Add(new ClueData(1, "black"));
            clueRow13.Add(new ClueData(1, "black"));
            clueRow13.Add(new ClueData(2, "black"));
            clueRow13.Add(new ClueData(1, "black"));
            List<ClueData> clueRow14 = new List<ClueData>();
            clueRow14.Add(new ClueData(2, "black"));
            clueRow13.Add(new ClueData(1, "black"));
            clueRow14.Add(new ClueData(2, "black"));
            clueRow14.Add(new ClueData(2, "black"));
            List<ClueData> clueRow15 = new List<ClueData>();
            clueRow15.Add(new ClueData(4, "black"));
            clueRow15.Add(new ClueData(5, "black"));

            rowData.Add(clueRow1);
            rowData.Add(clueRow2);
            rowData.Add(clueRow3);
            rowData.Add(clueRow4);
            rowData.Add(clueRow5);
            rowData.Add(clueRow6);
            rowData.Add(clueRow7);
            rowData.Add(clueRow8);
            rowData.Add(clueRow9);
            rowData.Add(clueRow10);
            rowData.Add(clueRow11);
            rowData.Add(clueRow12);
            rowData.Add(clueRow13);
            rowData.Add(clueRow14);
            rowData.Add(clueRow15);

            List<ClueData> clueCol1 = new List<ClueData>();
            clueCol1.Add(new ClueData(2, "black"));
            List<ClueData> clueCol2 = new List<ClueData>();
            clueCol2.Add(new ClueData(1, "black"));
            clueCol2.Add(new ClueData(2, "black"));
            clueCol2.Add(new ClueData(2, "black"));
            List<ClueData> clueCol3 = new List<ClueData>();
            clueCol3.Add(new ClueData(1, "black"));
            clueCol3.Add(new ClueData(2, "black"));
            clueCol3.Add(new ClueData(5, "black"));
            List<ClueData> clueCol4 = new List<ClueData>();
            clueCol4.Add(new ClueData(1, "black"));
            clueCol4.Add(new ClueData(1, "black"));
            clueCol4.Add(new ClueData(1, "black"));
            clueCol4.Add(new ClueData(1, "black"));
            List<ClueData> clueCol5 = new List<ClueData>();
            clueCol5.Add(new ClueData(3, "black"));
            clueCol5.Add(new ClueData(1, "black"));
            clueCol5.Add(new ClueData(4, "black"));
            List<ClueData> clueCol6 = new List<ClueData>();
            clueCol6.Add(new ClueData(2, "black"));
            clueCol6.Add(new ClueData(6, "black"));
            clueCol6.Add(new ClueData(1, "black"));
            List<ClueData> clueCol7 = new List<ClueData>();
            clueCol7.Add(new ClueData(12, "black"));
            List<ClueData> clueCol8 = new List<ClueData>();
            clueCol8.Add(new ClueData(2, "black"));
            clueCol8.Add(new ClueData(8, "black"));
            List<ClueData> clueCol9 = new List<ClueData>();
            clueCol9.Add(new ClueData(1, "black"));
            clueCol9.Add(new ClueData(7, "black"));
            clueCol9.Add(new ClueData(1, "black"));
            List<ClueData> clueCol10 = new List<ClueData>();
            clueCol10.Add(new ClueData(3, "black"));
            clueCol10.Add(new ClueData(2, "black"));
            clueCol10.Add(new ClueData(1, "black"));
            clueCol10.Add(new ClueData(2, "black"));
            List<ClueData> clueCol11 = new List<ClueData>();
            clueCol11.Add(new ClueData(1, "black"));
            clueCol11.Add(new ClueData(1, "black"));
            clueCol11.Add(new ClueData(2, "black"));
            clueCol11.Add(new ClueData(2, "black"));
            List<ClueData> clueCol12 = new List<ClueData>();
            clueCol12.Add(new ClueData(2, "black"));
            clueCol12.Add(new ClueData(1, "black"));
            clueCol12.Add(new ClueData(2, "black"));
            clueCol12.Add(new ClueData(2, "black"));
            List<ClueData> clueCol13 = new List<ClueData>();
            clueCol13.Add(new ClueData(1, "black"));
            clueCol13.Add(new ClueData(1, "black"));
            clueCol13.Add(new ClueData(2, "black"));
            clueCol13.Add(new ClueData(1, "black"));
            List<ClueData> clueCol14 = new List<ClueData>();
            clueCol14.Add(new ClueData(5, "black"));
            clueCol14.Add(new ClueData(2, "black"));
            List<ClueData> clueCol15 = new List<ClueData>();
            clueCol15.Add(new ClueData(3, "black"));
            clueCol15.Add(new ClueData(2, "black"));
            List<ClueData> clueCol16 = new List<ClueData>();
            clueCol16.Add(new ClueData(1, "black"));
            clueCol16.Add(new ClueData(1, "black"));
            List<ClueData> clueCol17 = new List<ClueData>();
            clueCol17.Add(new ClueData(1, "black"));
            List<ClueData> clueCol18 = new List<ClueData>();
            clueCol18.Add(new ClueData(1, "black"));
            List<ClueData> clueCol19 = new List<ClueData>();
            clueCol19.Add(new ClueData(1, "black"));
            List<ClueData> clueCol20 = new List<ClueData>();
            clueCol20.Add(new ClueData(1, "black"));

            colData.Add(clueCol1);
            colData.Add(clueCol2);
            colData.Add(clueCol3);
            colData.Add(clueCol4);
            colData.Add(clueCol5);
            colData.Add(clueCol6);
            colData.Add(clueCol7);
            colData.Add(clueCol8);
            colData.Add(clueCol9);
            colData.Add(clueCol10);
            colData.Add(clueCol11);
            colData.Add(clueCol12);
            colData.Add(clueCol13);
            colData.Add(clueCol14);
            colData.Add(clueCol15);
            colData.Add(clueCol16);
            colData.Add(clueCol17);
            colData.Add(clueCol18);
            colData.Add(clueCol19);
            colData.Add(clueCol20);

            options.rowData = rowData;
            options.columnData = colData;
            options.columns = 20;
            options.rows = 15;
            return options;
        }


    }
}

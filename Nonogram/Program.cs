using System;
using System.Collections.Generic;
namespace Nonogram
{
    public class Program
    {
        static void Main(string[] args)
        {

            GameData options = new GameData();

            //new game 3 columns by 4 rows
            List<List<ClueData>> rowData = new List<List<ClueData>>();
            List<List<ClueData>> colData = new List<List<ClueData>>();

            List<ClueData> clueRow1 = new List<ClueData>();
            clueRow1.Add(new ClueData(2, "black"));
            List<ClueData> clueRow2 = new List<ClueData>();
            clueRow2.Add(new ClueData(1, "black"));
            clueRow2.Add(new ClueData(1, "black"));
            List<ClueData> clueRow3 = new List<ClueData>();
            clueRow3.Add(new ClueData(1, "black"));
            List<ClueData> clueRow4 = new List<ClueData>();
            clueRow4.Add(new ClueData(3, "black"));

            rowData.Add(clueRow1);
            rowData.Add(clueRow2);
            rowData.Add(clueRow3);
            rowData.Add(clueRow4);

            List<ClueData> clueCol1 = new List<ClueData>();
            clueCol1.Add(new ClueData(1, "black"));
            List<ClueData> clueCol2 = new List<ClueData>();
            clueCol2.Add(new ClueData(2, "black"));
            clueCol2.Add(new ClueData(1, "black"));
            List<ClueData> clueCol3 = new List<ClueData>();
            clueCol3.Add(new ClueData(1, "black"));

            colData.Add(clueCol1);
            colData.Add(clueCol2);
            colData.Add(clueCol3);

            options.rowData = rowData;
            options.columnData = colData;
            options.columns = 3;
            options.rows = 4;

            Game myGame = new Game(options);

            for (int i = 0; i < myGame.Grid().GetRowCount(); i++)
            {
                for (int colNo = 0; colNo < myGame.Grid().GetColCount(); colNo++)
                {
                    //+=OnValueChanged is equivalent to += new ValueChangedDelegate(OnValueChanged)
                    myGame.GetGridCellRow(i).GetCell(colNo).ValueChanged += OnValueChanged;
                }
            }


            Console.WriteLine("Game has " + myGame.Grid().GetColCount() +" columns and " + myGame.Grid().GetRowCount() + " rows");
            myGame.Grid().GetCellRow(1).GetCell(2).UserValue = "Cabbage";

            Console.WriteLine("Row clues");
            foreach(Clues clueRow in myGame.Rows())//add enumerator
            {
                Console.Write("rows ");
                foreach(Clue clue in clueRow)
                {
                    Console.Write(clue.Number + ",");
                }
                Console.WriteLine("");
            }
            foreach (Clues clueCol in myGame.Cols())//add enumerator
            {
                Console.Write("cols ");
                foreach (Clue clue in clueCol)
                {
                    Console.Write(clue.Number + ",");
                }
                Console.WriteLine("");
            }

        }

        static void OnValueChanged(object sender, ValueChangedEventArgs args)
        {
            if (sender is Cell)
            {   
                Console.WriteLine($"Cell {((Cell)sender).CellColumn}:{((Cell)sender).CellRow} changing value from {args.OldValue} to {args.NewValue}");                    
            }

        }
    }
}

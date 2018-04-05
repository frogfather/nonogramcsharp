using System;
using System.Collections.Generic;
namespace Nonogram
{
    public class Program
    {
        static void Main(string[] args)
        {

            //we should retrieve the data as a JSON object, convert to GameData and use it to construct the game
            //if we're already in a game we need to load that game.
            //the history can be done by a local csv file. That can be 
            //loaded into a stringlist (maybe). 
            //headings:
            //col, row, from, to
            //undo involves changing the specified cell to 
            //the value in the 'from' column
            //and moving down one line in the file

            Game myGame = new Game(GetTestGame());
            SetChangeHandlers(myGame);


        }

        private static void PrintGameToConsole()
        {
                            
        }

        private static GameData GetTestGame()
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

        static void SetChangeHandlers(Game currentGame)
        {
            for (int i = 0; i < currentGame.Grid().GetRowCount(); i++)
            {
                for (int colNo = 0; colNo < currentGame.Grid().GetColCount(); colNo++)
                {
                    //+=OnValueChanged is equivalent to += new ValueChangedDelegate(OnValueChanged)
                    currentGame.GetGridCellRow(i).GetCell(colNo).ValueChanged += OnValueChanged;
                }
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

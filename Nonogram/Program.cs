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

            Game myGame = new Game(PuzzleData.PuzzleTwo());
            SetChangeHandlers(myGame);
            Autosolve.Solve(myGame);
            Display.PrintGame(myGame,true);
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

using System;
using System.Collections.Generic;
namespace Nonogram
{
    public class Program
    {
        static void Main(string[] args)
        {

            //we should retrieve the data as a JSON object, convert to GameData and use it to construct the game

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

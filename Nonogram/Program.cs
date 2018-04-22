using System;
using System.Collections.Generic;
namespace Nonogram
{
    public class Program
    {
        static void Main(string[] args)
        {

            //we should retrieve the data as a JSON object, convert to GameData and use it to construct the game

            SpaceData spaceData = new SpaceData(0, 16);
            List<SpaceData> spaceOptions = new List<SpaceData>();
            Spaces spaces1;

            BlockData block1data = new BlockData(2, 2, "black");
            BlockData block2data = new BlockData(5, 2, "black");
            BlockData block3data = new BlockData(10, 3, "black");
            List<BlockData> blockOptions = new List<BlockData>();
            Blocks blocks1;

            ClueData clue1data = new ClueData(5, "black");
            ClueData clue2data = new ClueData(4, "black");
            ClueData clue3data = new ClueData(4, "black");
            List<ClueData> clueOptions = new List<ClueData>();
            Clues clues1;


            spaceOptions.Add(spaceData);
            blockOptions.Add(block1data);
            blockOptions.Add(block2data);
            blockOptions.Add(block3data);
            clueOptions.Add(clue1data);
            clueOptions.Add(clue2data);
            clueOptions.Add(clue3data);

            spaces1 = new Spaces(spaceOptions);
            clues1 = new Clues(clueOptions);
            blocks1 = new Blocks(blockOptions);

            if (Autosolve.CluesWillFitInSpaces(clues1, spaces1, blocks1))
            {
                Console.WriteLine( "These clues fit ");
            }
            else
            {
                Console.WriteLine("These clues don't fit");
            }

            //Game myGame = new Game(PuzzleData.PuzzleTwo());
            //SetChangeHandlers(myGame);
            //Autosolve.Solve(myGame);
            //Display.PrintGame(myGame,true);
        }


        static void SetChangeHandlers(Game currentGame)
        {
            for (int i = 0; i < currentGame.Grid().GetLength(true); i++)
            {
                for (int colNo = 0; colNo < currentGame.Grid().GetLength(false); colNo++)
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

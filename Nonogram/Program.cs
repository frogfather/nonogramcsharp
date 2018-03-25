using System;
using System.Collections.Generic;
namespace Nonogram
{
    public class Program
    {
        static void Main(string[] args)
        {
            Grid myGrid = new Grid(6,10);
            for (int i = 0; i < myGrid.getRowCount(); i++)
            {
                for (int colNo = 0; colNo < myGrid.getGridRow(i).GetColCount(); colNo++)
                {
                    //+=OnValueChanged is equivalent to += new ValueChangedDelegate(OnValueChanged)
                    myGrid.getGridRow(i).GetCell(colNo).ValueChanged += OnValueChanged; 
                }
            }
            List<ClueData> clueOptions = new List<ClueData>();
            clueOptions.Add(new ClueData(4,"black"));
            clueOptions.Add(new ClueData(7, "green"));
            clueOptions.Add(new ClueData(3, "blue"));
            Clues testClues = new Clues(clueOptions);                            
            myGrid.getGridRow(4).GetCell(3).UserValue = "cross";
            Console.WriteLine(testClues.getClue(2).Number);
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

using System;
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
                    Console.WriteLine("row: " + myGrid.getGridRow(i).GetCell(colNo).CellRow + " col: " + myGrid.getGridRow(i).GetCell(colNo).CellColumn);
                    //+=OnValueChanged is equivalent to += new ValueChangedDelegate(OnValueChanged)
                    myGrid.getGridRow(i).GetCell(colNo).ValueChanged += OnValueChanged; 
                }
            }
            myGrid.getGridRow(4).GetCell(3).UserValue = "cross";
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

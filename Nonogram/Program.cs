using System;
namespace Nonogram
{
    public class Program
    {
        static void Main(string[] args)
        {
            Grid myGrid = new Grid(6,10);
            for (int i = 0; i < myGrid.getRowCount(); i++){
                for (int colNo = 0; colNo < myGrid.getGridRow(i).GetColCount(); colNo++)
                    Console.WriteLine("row: "+myGrid.getGridRow(i).GetGameRowItem(colNo).CellRow + " col: " + myGrid.getGridRow(i).GetGameRowItem(colNo).CellColumn);
            }   
        }
    }
}

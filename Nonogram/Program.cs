using System;
namespace Nonogram
{
    public class Program
    {
        static void Main(string[] args)
        {
            GridRow myGridRow = new GridRow(7);
            for (int i = 0; i < 7; i++){
                Console.WriteLine(myGridRow.GetGameRowItem(i).CellColumn);
                Console.WriteLine(myGridRow.GetGameRowItem(i).CellRow);
            }
        }
    }
}

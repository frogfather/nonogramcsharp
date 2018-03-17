using System;
namespace Nonogram
{
    public class Program
    {
        static void Main(string[] args)
        {
            GridRow myGridRow = new GridRow(7);
            Console.WriteLine(myGridRow.GetGameRowItem(4).CellColumn);
            Console.WriteLine(myGridRow.GetGameRowItem(4).CellRow);
        }
    }
}

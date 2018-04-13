using System;
namespace Nonogram
{
    public static class Display
    {

        public static void Log(string message) => Console.WriteLine(message);

        public static void PrintGame(Game currentGame, Boolean auto)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //get the max row clues. The column clues and the grid
            //will start where they end
            int maxColClueCount = currentGame.GetMaxColClues();
            int maxRowClueCount = currentGame.GetMaxRowClues();
            string offsetString = "";
            string rowToPrint = "";

            for (int i = 0; i < maxRowClueCount; i++)
            {
                offsetString += "  ";
            }

            //first print the column clues
            //need to go from 1 to maxCol
            for (int i = 0; i < maxColClueCount; i++)
            {
                rowToPrint = offsetString;

                for (int col = 0; col < currentGame.Cols().colCount(); col++)
                {
                    int currentColClueCount = currentGame.Cols().getClueSet(col).getClueCount();
                    if (currentColClueCount >= maxColClueCount - i)
                    {
                        string clueValue = currentGame.Cols().getClueSet(col).getClue(i - (maxColClueCount - currentColClueCount)).Number.ToString();
                        if (clueValue.Length == 1)
                        {
                            clueValue = " " + clueValue;
                        }
                        rowToPrint += clueValue;
                    }
                    else
                    {
                        rowToPrint += "  ";
                    }
                }
                Console.WriteLine(rowToPrint);
            }

            //now print the row clues AND the grid row
            for (int row = 0; row < currentGame.Grid().GetLength(true); row++)
            {
                rowToPrint = "";

                //for each row, if the number of clues is < maxRow we fill with spaces
                for (int i = 0; i < maxRowClueCount; i++)
                {
                    int currentRowClueCount = currentGame.Rows().getClueSet(row).getClueCount();
                    if (currentRowClueCount >= (maxRowClueCount - i))
                    {
                        string clueValue = currentGame.GetClueSetRow(row).getClue(i - (maxRowClueCount - currentRowClueCount)).Number.ToString();
                        if (clueValue.Length == 1)
                        {
                            clueValue = " " + clueValue;
                        }
                        rowToPrint += clueValue;
                    }
                    else
                    {
                        rowToPrint += "  ";
                    }
                }
                rowToPrint += " ";
                //then add the blocks
                string selValue;
                for (int cell = 0; cell < currentGame.Cols().colCount(); cell++)
                {
                    if (auto)
                    {
                        selValue = currentGame.Grid().GetCellRow(row).GetCell(cell).AutoValue;
                    }
                    else
                    {
                        selValue = currentGame.Grid().GetCellRow(row).GetCell(cell).UserValue;
                    }

                    if (selValue == "black")
                    {
                        rowToPrint += "\u25A3 ";
                    }
                    else
                    {
                        rowToPrint += "\u25A1 ";
                    }

                }
                Console.WriteLine(rowToPrint);
            }
     
        } 
    }
}

using System;
using System.Collections.Generic;
namespace Nonogram
{
    public class Columns
    {
        public Columns(List<List<ClueData>> columnOptions)
        {
            //creates a list of Clues objects which is in itself a list of Clue opjects
            //Clues object should be renamed ClueLine or something more descriptive
        }
        private List<Clues> columnClues = new List<Clues>();
    }
}

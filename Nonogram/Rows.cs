using System;
using System.Collections.Generic;
namespace Nonogram
{
    public class Rows
    {
        public Rows(List<List<ClueData>> rowOptions)
        {
            //creates a list of Clues objects which is in itself a list of Clue opjects
            //Clues object should be renamed ClueLine or something more descriptive

        }

        private List<Clues> rowClues = new List<Clues>();
    }
};

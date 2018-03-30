using System;
using System.Collections.Generic;
namespace Nonogram
{
    public class Rows
    {
        public Rows(List<List<ClueData>> rowOptions)
        {
            foreach (List<ClueData> clueSet in rowOptions)
            {
                _rowClues.Add(new Clues(clueSet));
            }

        }

        public Clues getClueSet(int index)
        {
            if (index >= 0 && index < _rowClues.Count)
            {
                return _rowClues[index];
            }
            else
            {
                return null;
            }

        }

        public int rowCount()
        {
            return _rowClues.Count;
        }

        private List<Clues> _rowClues = new List<Clues>();
    }
};

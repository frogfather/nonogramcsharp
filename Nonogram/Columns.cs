using System;
using System.Collections.Generic;
namespace Nonogram
{
    public class Columns
    {
        public Columns(List<List<ClueData>> columnOptions)
        {
            foreach (List<ClueData> clueSet in columnOptions)
            {
                _columnClues.Add(new Clues(clueSet));
            }
        }

        public Clues getClueSet(int index)
        {
            if (index >= 0 && index < _columnClues.Count)
            {
                return _columnClues[index];
            }
            else
            {
                return null;
            }

        }

        public int colCount()
        {
            return _columnClues.Count;
        }

        private List<Clues> _columnClues = new List<Clues>();
    }
}

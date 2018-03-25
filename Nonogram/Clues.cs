using System;
using System.Collections.Generic;
namespace Nonogram
{
    public class Clues
    {
        //creates new clue objects and adds them to a list
        public Clues(List<ClueData> options)
        {
            foreach (ClueData item in options)
            {
                _clueList.Add(new Clue(item.value, item.colour));
            }
        }

        public Clue getClue(int index)
        {
            if (index >= 0 && index < _clueList.Count)
                {
                return _clueList[index];
                }
                else
                {
                    return null;
                }

        }

        private List<Clue> _clueList = new List<Clue>();
    }
}

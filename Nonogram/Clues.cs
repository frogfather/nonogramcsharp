using System;
using System.Collections;
using System.Collections.Generic;
namespace Nonogram
{
    public class Clues : IEnumerable
    {
        public IEnumerator GetEnumerator() => _clueList.GetEnumerator();

        public Clues(List<ClueData> options)//takes in list of clueData structs and adds new clue objects to _clueList
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

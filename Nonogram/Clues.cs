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

        public Clues()
        {
            //empty list
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

        public void AddClue(Clue clue)
        {
            _clueList.Add(clue);
        }

        public Clue RemoveClue(int index)
        {
            if (index > 0 && index < _clueList.Count)
            {
                Clue selected = getClue(index);
                _clueList.RemoveAt(index);
                return selected;
            }
            else
            {
                return null;
            }
        }

        public int GetClueCount()
        {
            return _clueList.Count;
        }

        public int GetLargestUnsolvedCluePos()
        {
            int largestPos = -1;
            int largestValue = 0;
            for (int i = 0; i < _clueList.Count; i++)
            {
                if(_clueList[i].Solved == false && _clueList[i].Number > largestValue){
                    largestPos = i;
                }
            }
            return largestPos;
        }


        private List<Clue> _clueList = new List<Clue>();
    }
}

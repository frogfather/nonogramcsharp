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
            if (index >= 0 && index < _clueList.Count)
            {
                Clue selected = getClue(index);
                _clueList.RemoveAt(index);
                return selected;
            }
            return null;

        }

        public void RemoveAll()
        {
            _clueList.Clear();
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

        public bool AllCluesSolved()
        {
            foreach(Clue clue in _clueList)
            {
                if (clue.Solved == false) { return false; }
            }
            return true;
        }

        public int GetClueLength(int startAt = 0, int endAt = -1)
        {
            if (endAt == -1)
            {
                endAt = _clueList.Count-1;
            }
            if (endAt > _clueList.Count-1)
            {
                endAt = _clueList.Count-1;
            }
            if (startAt > endAt)
            {
                return 0;
            }
            int totalLength = 0;
            string lastColour = "";
            for (int i = startAt; i <= endAt; i++)
            {
                totalLength += getClue(i).Number;
                if (lastColour == getClue(i).Colour)
                {
                    totalLength += 1;
                }
                lastColour = getClue(i).Colour;
            }
            return totalLength;
        }


        private List<Clue> _clueList = new List<Clue>();
    }
}

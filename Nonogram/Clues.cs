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

        public int getClueCount()
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


        public int GetoverallClueLength()
        {
            int totalLength = 0;
            string lastColour = "";
            for (int i = 0; i < getClueCount(); i++)
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

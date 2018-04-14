using System;
using System.Collections.Generic;
namespace Nonogram
{
    public class Space
    {
        public Space(SpaceData options)
        {
            SpaceLength = options.length;
            SpaceStart = options.start;
            _spaceClues = new List<Clue>();
        }

        public int SpaceLength
        {
            get;
            set;
        }

        public int SpaceStart
        {
            get;
            set;
        }

        public int GetClueCount() => _spaceClues.Count;

        public void AddClue(Clue clue)
        {
            if (!_spaceClues.Contains(clue))
            {
                _spaceClues.Add(clue);
            }
        }

        public Clue GetClue(int index)
        {
            if (index > -1 && index < _spaceClues.Count)
            {
                return _spaceClues[index];
            }
            else
            {
                return null;
            }
        }


        List<Clue> _spaceClues;

    }
}

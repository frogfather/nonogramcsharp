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
            _spaceClues = new Clues();
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

        public int GetClueCount() => _spaceClues.GetClueCount();

        public void AddClue(Clue clue)
        {
            _spaceClues.AddClue(clue);
        }

        public Clue RemoveClue(int index)
        {
            return _spaceClues.RemoveClue(index);
        }

        public Clue GetClue(int index)
        {
            return _spaceClues.getClue(index);
        }

        public int GetClueLength()
        {
            return _spaceClues.GetClueLength();
        }

        Clues _spaceClues;

    }
}

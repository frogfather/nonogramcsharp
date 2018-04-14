using System;
using System.Collections;
using System.Collections.Generic;

namespace Nonogram
{
    public class Spaces : IEnumerable;
    {
        public IEnumerator GetEnumerator() => _spaceList.GetEnumerator();

        public Spaces(List<SpaceData> options)
        {
            foreach(SpaceData item in options)
            {
                _spaceList.Add(new Space(item));
            }
        }


        public void addSpace(SpaceData spaceInfo)
        {
            _spaceList.Add(new Space(spaceInfo));
        }


        public Space getSpace(int index)
        {
            if (index >= 0 && index < _spaceList.Count)
            {
                return _spaceList[index];
            }
            else
            {
                return null;
            }

        }

        public int getSpaceCount()
        {
            return _spaceList.Count;
        }


        private List<Space> _spaceList = new List<Space>();
    }
}

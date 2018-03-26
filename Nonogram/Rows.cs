using System;
using System.Collections.Generic;
namespace Nonogram
{
    public class Rows
    {
        //we need to feed a List of Lists of ClueData into the constructor
        public Rows(List<List<ClueData>> rowOptions);
        {
            foreach (List<ClueData> item in rowOptions)
            {
                
            }
        }

        private List<Clues> rowList = new List<Clues>();
    }
}

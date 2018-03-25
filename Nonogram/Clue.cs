using System;
namespace Nonogram
{
    public class Clue
    {
        public Clue()
        {
        }

        public string Colour
        {
            get
            {
                return _colour;   
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _colour = value;
                }
            }
        }

        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                if(!(value < 1))
                {
                    _number = value;    
                }
            }
        }

        public bool Solved
        {
            get;
            set;
        }

        private string _colour;
        private int _number;
    }
}

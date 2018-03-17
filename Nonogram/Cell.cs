using System;
namespace Nonogram
{
    public class Cell
    {
        public Cell(int row, int column)
        {
            _row = row;
            _column = column;
        }

        public int CellColumn
        {
            get
            {
                return _column;
            }
            set
            {
                if (value > 0)
                {
                    _column = value;
                }
            }
        }
        public int CellRow
        {
            get
            {
                return _row;
            }
            set
            {
                if (value > 0)
                {
                    _row = value;
                }
            }
        }

        public string BackgroundColour
        {
            get
            {
                return _backgroundColour;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {   
                    //should check if it's a hex value
                    _backgroundColour = value;
                }
            }
        }

        public string UserValue
        {
            get; set;
        }

        public string AutoValue
        {
            get; set;
        }

        public bool ShowUser
        {
            get; set;
        }

        public bool isTestValue
        {
            get; set;
        }

        private int _column;
        private int _row;
        private string _backgroundColour; //check it is a colour?
    }
}

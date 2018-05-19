using System;
namespace Nonogram
{
    public class Cell
    {
        public Cell(int row, int column)
        {
            _row = row;
            _column = column;
            _userValue = "clear";
            AutoValue = "clear";
            _clues = new Clues();
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
            get
            {
                return _userValue;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    if (_userValue != value)
                    {
                        ValueChangedEventArgs args = new ValueChangedEventArgs();
                        args.OldValue = _userValue;
                        args.NewValue = value;
                        //event handler to signal that value has changed
                        if (ValueChanged != null)
                        {
                            ValueChanged(this,args);      
                        }

                    }

                    _userValue = value;
                }
            }
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

        public event ValueChangedDelegate ValueChanged;
        private int _column;
        private int _row;
        private string _userValue;
        private string _backgroundColour; //check it is a colour?
        private Clues _clues;
    }
}

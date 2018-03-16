using System;
namespace Nonogram
{
    public class Cell
    {
        public Cell()
        {
        }

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (value > 0)
                {
                    _width = value;
                }
            }
        }
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (value > 0)
                {
                    _height = value;
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
                    _backgroundColour = value;
                }
            }
        }

        //pattern should be an enum. 
        //or should it be more abstract?

        private int _width;
        private int _height;
        private string _backgroundColour; //check it is a colour?
        private string _pattern; 
    }
}

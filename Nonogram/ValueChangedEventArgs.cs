using System;
namespace Nonogram
{
    public class ValueChangedEventArgs : EventArgs
    {
        public string OldValue { get; set; }
        public string NewValue{ get; set; }
    }
}

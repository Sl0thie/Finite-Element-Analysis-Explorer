using System;

namespace Finite_Element_Analysis_Explorer
{
    internal class ValueChangedEventArgs : EventArgs
    {
        public decimal Value { get; set; }

        public ValueChangedEventArgs(decimal value)
        {
            Value = value;
        }
    }
}

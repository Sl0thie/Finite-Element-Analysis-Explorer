using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

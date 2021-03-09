using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finite_Element_Analysis_Explorer
{
    internal struct Codes
    {
        internal Codes(int _x, int _y, int _m)
        {
            x = _x;
            y = _y;
            m = _m;
        }

        internal Codes(Codes codes)
        {
            x = codes.x;
            y = codes.y;
            m = codes.m;
        }

        private int x;
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        private int y;
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        private int m;
        public int M
        {
            get { return m; }
            set { m = value; }
        }
    }
}
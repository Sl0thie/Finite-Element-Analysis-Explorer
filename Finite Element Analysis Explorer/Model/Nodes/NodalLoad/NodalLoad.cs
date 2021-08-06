namespace Finite_Element_Analysis_Explorer
{
    internal struct NodalLoad
    {
        public NodalLoad(decimal _x, decimal _y, decimal _m)
        {
            x = _x;
            y = _y;
            m = _m;
        }

        public NodalLoad(NodalLoad forces)
        {
            x = forces.x;
            y = forces.y;
            m = forces.m;
        }

        private decimal x;

        internal decimal X
        {
            get { return x; }
            set { x = value; }
        }

        private decimal y;

        internal decimal Y
        {
            get { return y; }
            set { y = value; }
        }

        private decimal m;

        internal decimal M
        {
            get { return m; }
            set { m = value; }
        }
    }
}

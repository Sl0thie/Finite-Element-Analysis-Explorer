namespace Finite_Element_Analysis_Explorer
{
    internal struct NodalLoad
    {
        public NodalLoad(decimal x, decimal y, decimal m)
        {
            this.x = x;
            this.y = y;
            this.m = m;
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

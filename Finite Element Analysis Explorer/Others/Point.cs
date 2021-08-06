using System.Numerics;

namespace Finite_Element_Analysis_Explorer
{
    internal struct Point
    {
        internal Point(decimal x, decimal y, decimal m)
        {
            this.x = x;
            this.y = y;
            this.m = m;
            location = new Vector2((float)this.x, (float)this.y); // Reverse the sign here and also at the node creation to flip the y axis.
        }

        internal Point(Point position)
        {
            x = position.x;
            y = position.y;
            m = position.m;
            location = new Vector2((float)x, (float)y);
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

        private Vector2 location;

        internal Vector2 Location
        {
            get { return location; }
        }
    }
}
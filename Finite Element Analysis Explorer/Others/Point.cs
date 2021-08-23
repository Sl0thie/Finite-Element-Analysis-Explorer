using System.Numerics;

namespace Finite_Element_Analysis_Explorer
{
    /// <summary>
    /// Point struct.
    /// </summary>
    internal struct Point
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct.
        /// </summary>
        /// <param name="x">x.</param>
        /// <param name="y">y.</param>
        /// <param name="m">m.</param>
        internal Point(decimal x, decimal y, decimal m)
        {
            this.x = x;
            this.y = y;
            this.m = m;
            location = new Vector2((float)this.x, (float)this.y); // Reverse the sign here and also at the node creation to flip the y axis.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct.
        /// </summary>
        /// <param name="position">position.</param>
        internal Point(Point position)
        {
            x = position.x;
            y = position.y;
            m = position.m;
            location = new Vector2((float)x, (float)y);
        }

        private decimal x;

        /// <summary>
        /// Gets or sets the X value.
        /// </summary>
        internal decimal X
        {
            get { return x; }
            set { x = value; }
        }

        private decimal y;

        /// <summary>
        /// Gets or sets the Y value.
        /// </summary>
        internal decimal Y
        {
            get { return y; }
            set { y = value; }
        }

        private decimal m;

        /// <summary>
        /// Gets or sets the M value.
        /// </summary>
        internal decimal M
        {
            get { return m; }
            set { m = value; }
        }

        private Vector2 location;

        /// <summary>
        /// Gets the location.
        /// </summary>
        internal Vector2 Location
        {
            get { return location; }
        }
    }
}
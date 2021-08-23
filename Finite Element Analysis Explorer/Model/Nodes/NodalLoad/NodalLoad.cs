namespace Finite_Element_Analysis_Explorer
{
    /// <summary>
    /// NodalLoad struct.
    /// </summary>
    internal struct NodalLoad
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NodalLoad"/> struct.
        /// </summary>
        /// <param name="x">The X value.</param>
        /// <param name="y">The Y value.</param>
        /// <param name="m">The M value.</param>
        public NodalLoad(decimal x, decimal y, decimal m)
        {
            this.x = x;
            this.y = y;
            this.m = m;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NodalLoad"/> struct.
        /// </summary>
        /// <param name="forces">The forces.</param>
        public NodalLoad(NodalLoad forces)
        {
            x = forces.x;
            y = forces.y;
            m = forces.m;
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
    }
}

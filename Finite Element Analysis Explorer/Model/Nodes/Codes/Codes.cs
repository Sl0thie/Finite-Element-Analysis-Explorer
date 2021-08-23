namespace Finite_Element_Analysis_Explorer
{
    /// <summary>
    /// Codes struct.
    /// </summary>
    internal struct Codes
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Codes"/> struct.
        /// </summary>
        /// <param name="x">The X value.</param>
        /// <param name="y">The Y value.</param>
        /// <param name="m">The M value.</param>
        internal Codes(int x, int y, int m)
        {
            this.x = x;
            this.y = y;
            this.m = m;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Codes"/> struct.
        /// </summary>
        /// <param name="codes">A codes struct.</param>
        internal Codes(Codes codes)
        {
            x = codes.x;
            y = codes.y;
            m = codes.m;
        }

        private int x;

        /// <summary>
        /// Gets or sets the X value.
        /// </summary>
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        private int y;

        /// <summary>
        /// Gets or sets the Y value.
        /// </summary>
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        private int m;

        /// <summary>
        /// Gets or sets the M value.
        /// </summary>
        public int M
        {
            get { return m; }
            set { m = value; }
        }
    }
}
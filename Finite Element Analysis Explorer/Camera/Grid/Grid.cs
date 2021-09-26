namespace Finite_Element_Analysis_Explorer
{
    /// <summary>
    /// Grid class contains properties and methods for the camera's grid.
    /// </summary>
    internal class Grid
    {
        private float sizeNormal = 1f;
        private float sizeMinor = 0.1f;
        private float sizeMajor = 10f;

        /// <summary>
        /// Gets or sets the grid size for normal lines.
        /// </summary>
        internal float SizeNormal
        {
            get
            {
                return sizeNormal;
            }

            set
            {
                sizeNormal = value;
            }
        }

        /// <summary>
        /// Gets or sets the grid size for the minor grid.
        /// </summary>
        internal float SizeMinor
        {
            get
            {
                return sizeMinor;
            }

            set
            {
                sizeMinor = value;
            }
        }

        /// <summary>
        /// Gets or sets the grid size for the major grid.
        /// </summary>
        internal float SizeMajor
        {
            get
            {
                return sizeMajor;
            }

            set
            {
                sizeMajor = value;
            }
        }
    }
}
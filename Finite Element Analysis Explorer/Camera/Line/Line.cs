namespace Finite_Element_Analysis_Explorer
{
    /// <summary>
    /// Line class contains properties for the camera's line.
    /// </summary>
    internal class Line
    {
        private float unit;

        /// <summary>
        /// Gets or sets the line unit.
        /// </summary>
        internal float Unit
        {
            get
            {
                return unit;
            }

            set
            {
                unit = value;
                ConstraintWidth = unit * 2;
                ConstraintRadius = unit * 5;
                LengthLDLArrow = unit * 8;
                LengthForceArrow = unit * 15;

                if (unit < Camera.LowerBound)
                {
                    Camera.UpdateLengthType();
                }

                if (unit > Camera.UpperBound)
                {
                    Camera.UpdateLengthType();
                }
            }
        }

        /// <summary>
        /// Gets the constrain radius.
        /// </summary>
        internal float ConstraintRadius { get; private set; }

        /// <summary>
        /// Gets the constrain width.
        /// </summary>
        internal float ConstraintWidth { get; private set; }

        /// <summary>
        /// Gets the line length of the DLArrow.
        /// </summary>
        internal float LengthLDLArrow { get; private set; }

        /// <summary>
        /// Gets the line length of the Force Arrow.
        /// </summary>
        internal float LengthForceArrow { get; private set; }
    }
}

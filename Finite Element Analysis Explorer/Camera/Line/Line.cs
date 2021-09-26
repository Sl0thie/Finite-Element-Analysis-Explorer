namespace Finite_Element_Analysis_Explorer
{
    /// <summary>
    /// Line class contains properties for the camera's line.
    /// </summary>
    internal class Line
    {
        private float unit;
        private float constraintRadius;
        private float constraintWidth;
        private float lengthLDLArrow;
        private float lengthForceArrow;

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
        internal float ConstraintRadius
        {
            get
            {
                return constraintRadius;
            }

            private set
            {
                constraintRadius = value;
            }
        }

        /// <summary>
        /// Gets the constrain width.
        /// </summary>
        internal float ConstraintWidth
        {
            get
            {
                return constraintWidth;
            }

            private set
            {
                constraintWidth = value;
            }
        }

        /// <summary>
        /// Gets the line length of the DLArrow.
        /// </summary>
        internal float LengthLDLArrow
        {
            get
            {
                return lengthLDLArrow;
            }

            private set
            {
                lengthLDLArrow = value;
            }
        }

        /// <summary>
        /// Gets the line length of the Force Arrow.
        /// </summary>
        internal float LengthForceArrow
        {
            get
            {
                return lengthForceArrow;
            }

            private set
            {
                lengthForceArrow = value;
            }
        }
    }
}
namespace Finite_Element_Analysis_Explorer
{
    /// <summary>
    /// Constraints struct.
    /// </summary>
    internal struct Constraints
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Constraints"/> struct.
        /// </summary>
        /// <param name="x">The X value.</param>
        /// <param name="y">The Y value.</param>
        /// <param name="m">The M value.</param>
        internal Constraints(bool x, bool y, bool m)
        {
            this.x = x;
            this.y = y;
            this.m = m;

            if (this.x)
            {
                if (this.y)
                {
                    if (this.m)
                    {
                        constraintType = ConstraintType.Fixed;
                    }
                    else
                    {
                        constraintType = ConstraintType.Pinned;
                    }
                }
                else
                {
                    if (this.m)
                    {
                        constraintType = ConstraintType.Unknown;
                    }
                    else
                    {
                        constraintType = ConstraintType.RollerY;
                    }
                }
            }
            else
            {
                if (this.y)
                {
                    if (this.m)
                    {
                        constraintType = ConstraintType.Unknown;
                    }
                    else
                    {
                        constraintType = ConstraintType.RollerX;
                    }
                }
                else
                {
                    if (this.m)
                    {
                        constraintType = ConstraintType.Unknown;
                    }
                    else
                    {
                        constraintType = ConstraintType.Free;
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Constraints"/> struct.
        /// </summary>
        /// <param name="constraints">A constraints struct.</param>
        internal Constraints(Constraints constraints)
        {
            x = constraints.x;
            y = constraints.y;
            m = constraints.m;

            if (x)
            {
                if (y)
                {
                    if (m)
                    {
                        constraintType = ConstraintType.Fixed;
                    }
                    else
                    {
                        constraintType = ConstraintType.Pinned;
                    }
                }
                else
                {
                    if (m)
                    {
                        constraintType = ConstraintType.TrackLeft;
                    }
                    else
                    {
                        constraintType = ConstraintType.RollerY;
                    }
                }
            }
            else
            {
                if (y)
                {
                    if (m)
                    {
                        constraintType = ConstraintType.TrackBottom;
                    }
                    else
                    {
                        constraintType = ConstraintType.RollerX;
                    }
                }
                else
                {
                    if (m)
                    {
                        constraintType = ConstraintType.Unknown;
                    }
                    else
                    {
                        constraintType = ConstraintType.Free;
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Constraints"/> struct.
        /// </summary>
        /// <param name="constraintType">The constraint type.</param>
        internal Constraints(ConstraintType constraintType)
        {
            this.constraintType = constraintType;
            x = false;
            y = false;
            m = false;
            switch (constraintType)
            {
                case ConstraintType.Free:
                    x = false;
                    y = false;
                    m = false;
                    break;
                case ConstraintType.FixedBottom:
                case ConstraintType.Fixed:
                    x = true;
                    y = true;
                    m = true;
                    break;
                case ConstraintType.FixedTop:
                    x = true;
                    y = true;
                    m = true;
                    break;
                case ConstraintType.FixedLeft:
                    x = true;
                    y = true;
                    m = true;
                    break;
                case ConstraintType.FixedRight:
                    x = true;
                    y = true;
                    m = true;
                    break;
                case ConstraintType.PinnedBottom:
                case ConstraintType.Pinned:
                    x = true;
                    y = true;
                    m = false;
                    break;
                case ConstraintType.PinnedTop:
                    x = true;
                    y = true;
                    m = false;
                    break;
                case ConstraintType.PinnedLeft:
                    x = true;
                    y = true;
                    m = false;
                    break;
                case ConstraintType.PinnedRight:
                    x = true;
                    y = true;
                    m = false;
                    break;
                case ConstraintType.RollerBottom:
                case ConstraintType.RollerX:
                    x = false;
                    y = true;
                    m = false;
                    break;
                case ConstraintType.RollerTop:
                    x = false;
                    y = true;
                    m = false;
                    break;
                case ConstraintType.RollerLeft:
                case ConstraintType.RollerY:
                    x = true;
                    y = false;
                    m = false;
                    break;
                case ConstraintType.RollerRight:
                    x = false;
                    y = true;
                    m = true;
                    break;
                case ConstraintType.TrackBottom:
                    x = false;
                    y = true;
                    m = true;
                    break;
                case ConstraintType.TrackTop:
                    x = true;
                    y = true;
                    m = true;
                    break;
                case ConstraintType.TrackLeft:
                    x = true;
                    y = false;
                    m = true;
                    break;
                case ConstraintType.TrackRight:
                    x = true;
                    y = false;
                    m = true;
                    break;
                case ConstraintType.Unknown:
                default:
                    break;
            }
        }

        private bool x;

        /// <summary>
        /// Gets or sets a value indicating whether the X axis is constrained.
        /// </summary>
        public bool X
        {
            get { return x; }
            set { x = value; }
        }

        private bool y;

        /// <summary>
        /// Gets or sets a value indicating whether the Y axis is constrained.
        /// </summary>
        public bool Y
        {
            get { return y; }
            set { y = value; }
        }

        private bool m;

        /// <summary>
        /// Gets or sets a value indicating whether the M axis is constrained.
        /// </summary>
        public bool M
        {
            get { return m; }
            set { m = value; }
        }

        private ConstraintType constraintType;

        /// <summary>
        /// Gets or sets the constraint type.
        /// </summary>
        public ConstraintType ConstraintType
        {
            get { return constraintType; }
            set { constraintType = value; }
        }
    }
}
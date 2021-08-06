namespace Finite_Element_Analysis_Explorer
{
    internal struct Constraints
    {
        internal Constraints(bool _x, bool _y, bool _m)
        {
            x = _x;
            y = _y;
            m = _m;

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
                if (y)
                {
                    if (m)
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

        internal Constraints(ConstraintType _constraintType)
        {
            constraintType = _constraintType;
            x = false;
            y = false;
            m = false;
            switch (_constraintType)
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

        public bool X
        {
            get { return x; }
            set { x = value; }
        }

        private bool y;

        public bool Y
        {
            get { return y; }
            set { y = value; }
        }

        private bool m;

        public bool M
        {
            get { return m; }
            set { m = value; }
        }

        private ConstraintType constraintType;

        public ConstraintType ConstraintType
        {
            get { return constraintType; }
            set { constraintType = value; }
        }
    }
}
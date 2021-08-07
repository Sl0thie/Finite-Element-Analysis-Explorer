using System;
using System.Diagnostics;
using System.Numerics;

namespace Finite_Element_Analysis_Explorer
{
    internal class Node
    {
        #region Constructor

        internal void Output()
        {
            Debug.WriteLine("NODE " + index + " " + isPrimary);
            Debug.WriteLine("  Position X:" + position.X + "  Y:" + position.Y + "  M:" + position.M);
            Debug.WriteLine("  Codes:" + codes.X + " " + codes.Y + " " + codes.M);
            Debug.WriteLine("  Constraint:" + constraints);
            Debug.WriteLine("  Load X:" + load.X + "  Y:" + load.Y + "  M:" + load.M);
            Debug.WriteLine("  Super Position X:" + superPosition.X + "  Y:" + superPosition.Y + "  M:" + superPosition.M);
        }

        internal Node()
        {
        }

        internal Node(int index, Point position, Codes codes, Constraints constraints, NodalLoad newLoad, bool isPrimary)
        {
            this.index = index;
            this.position = position;
            positionDisplaced = this.position;
            location = new Vector2((float)positionDisplaced.X, (float)positionDisplaced.Y);
            this.codes = codes;
            Constraints = constraints;
            Load = newLoad;
            this.isPrimary = isPrimary;
        }

        #endregion

        #region Properties

        #region Operations

        private int index;

        internal int Index
        {
            get { return index; }
        }

        private bool isPrimary = false;

        internal bool IsPrimary
        {
            get { return isPrimary; }
            set { isPrimary = value; }
        }

        private bool isValid = false;

        internal bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        private Codes codes;

        internal Codes Codes
        {
            get { return codes; }
            set { codes = value; }
        }

        #endregion

        #region Constraints

        private Constraints constraints;

        internal Constraints Constraints
        {
            get
            {
                return constraints;
            }

            set
            {
                constraints = value;
                UpdateConstraints();
            }
        }

        #endregion

        #region Location

        private Point position;

        internal Point Position
        {
            get
            {
                return position;
            }

            set
            {
                position = new Point(value);
                positionDisplaced = new Point(position.X + positionDisplaced.X, position.Y + positionDisplaced.Y, 0);
            }
        }

        private Vector2 location;

        public Vector2 Location
        {
            get { return location; }
            set { location = value; }
        }

        #endregion

        #region Load

        private NodalLoad load;

        internal NodalLoad Load
        {
            get
            {
                return load;
            }

            set
            {
                load = value;
                UpdateNodalForces();
            }
        }

        /// <summary>
        /// Should be zero?.
        /// </summary>
        private NodalLoad jointLoad;

        internal NodalLoad JointLoad
        {
            get
            {
                return jointLoad;
            }

            set
            {
                jointLoad = value;
            }
        }

        private NodalLoad loadReaction;

        internal NodalLoad LoadReaction
        {
            get
            {
                return loadReaction;
            }

            set
            {
                loadReaction = value;
                UpdateNodalForces();
            }
        }

        private NodalLoad loadOriginal;

        public NodalLoad LoadOriginal
        {
            get { return loadOriginal; }
            set { loadOriginal = value; }
        }

        #endregion

        #region Displacement

        private Point displacement = new Point(0, 0, 0);

        internal Point Displacement
        {
            get
            {
                return displacement;
            }

            set
            {
                displacement = value;
            }
        }

        private Point positionDisplaced = new Point(0, 0, 0);

        internal Point PositionDisplaced
        {
            get { return positionDisplaced; }
            set { positionDisplaced = value; }
        }

        #endregion

        #region Superposition

        private NodalLoad superPosition;

        internal NodalLoad SuperPosition
        {
            get
            {
                return superPosition;
            }

            set
            {
                superPosition = value;
            }
        }

        #endregion

        #region Graphics

        private Vector2 forceUnit;

        internal Vector2 ForceUnit
        {
            get { return forceUnit; }
            set { forceUnit = value; }
        }

        private Vector2 forceUnitRight;

        internal Vector2 ForceUnitRight
        {
            get { return forceUnitRight; }
            set { forceUnitRight = value; }
        }

        private Vector2 forceUnitLeft;

        internal Vector2 ForceUnitLeft
        {
            get { return forceUnitLeft; }
            set { forceUnitLeft = value; }
        }

        private Vector2 forceLine;

        public Vector2 ForceLine
        {
            get { return forceLine; }
            set { forceLine = value; }
        }

        private Vector2 reactionUnit;

        internal Vector2 ReactionUnit
        {
            get { return reactionUnit; }
            set { reactionUnit = value; }
        }

        private Vector2 reactionUnitRight;

        internal Vector2 ReactionUnitRight
        {
            get { return reactionUnitRight; }
            set { reactionUnitRight = value; }
        }

        private Vector2 reactionUnitLeft;

        internal Vector2 ReactionUnitLeft
        {
            get { return reactionUnitLeft; }
            set { reactionUnitLeft = value; }
        }

        private Vector2 reactionLine;

        public Vector2 ReactionLine
        {
            get { return reactionLine; }
            set { reactionLine = value; }
        }

        private float forceMagnitude = 0;
        private float reactionMagnitude = 0;

        #endregion

        #endregion

        #region Methods

        internal void UpdateDisplacement()
        {
            positionDisplaced = new Point(position.X + (displacement.X * (decimal)Options.DisplacementFactor), position.Y + (displacement.Y * (decimal)Options.DisplacementFactor), position.M + (displacement.M * (decimal)Options.DisplacementFactor));
            location = new Vector2((float)positionDisplaced.X, (float)positionDisplaced.Y);
        }

        internal void UpdateConstraints()
        {
            if (constraints.ConstraintType == ConstraintType.Free)
            {
                if (Model.Nodes.NodesWithConstraints.ContainsKey(index))
                {
                    Node tmpNode;
                    Model.Nodes.NodesWithConstraints.TryRemove(index, out tmpNode);
                }
            }
            else
            {
                if (!Model.Nodes.NodesWithConstraints.ContainsKey(index))
                {
                    Node tmpNode = Model.Nodes.NodesWithConstraints.GetOrAdd(index, this);
                }
            }
        }

        internal void UpdateNodalForces()
        {
            if (Math.Abs(load.X) + Math.Abs(load.Y) == 0)
            {
                if (Model.Nodes.NodesWithNodalLoads.ContainsKey(index))
                {
                    Node tmpNode;
                    Model.Nodes.NodesWithNodalLoads.TryRemove(index, out tmpNode);
                }
            }
            else
            {
                forceUnit = Vector2.Normalize(new Vector2(-(float)load.X, -(float)load.Y));
                forceUnitRight = Vector2.TransformNormal(forceUnit, Matrix3x2.CreateRotation((float)Math.PI / 4));
                forceUnitLeft = Vector2.TransformNormal(forceUnit, Matrix3x2.CreateRotation(-(float)Math.PI / 4));
                forceMagnitude = (float)DMath.Sqrt((load.X * load.X) + (load.Y * load.Y));
                if (!Model.Nodes.NodesWithNodalLoads.ContainsKey(index))
                {
                    Node tmpNode = Model.Nodes.NodesWithNodalLoads.GetOrAdd(index, this);
                }
                else
                {
                    Node tmpNode;
                    Model.Nodes.NodesWithNodalLoads.TryRemove(index, out tmpNode);
                    tmpNode = Model.Nodes.NodesWithNodalLoads.GetOrAdd(index, this);
                }

                UpdateNodeGraphics();
            }

            if (Math.Abs(loadReaction.X) + Math.Abs(loadReaction.Y) == 0)
            {
                if (Model.Nodes.NodesWithReactions.ContainsKey(index))
                {
                    Node tmpNode;
                    Model.Nodes.NodesWithReactions.TryRemove(index, out tmpNode);
                }
            }
            else
            {
                reactionUnit = Vector2.Normalize(new Vector2(-(float)loadReaction.X, -(float)loadReaction.Y));
                reactionUnitRight = Vector2.TransformNormal(reactionUnit, Matrix3x2.CreateRotation((float)Math.PI / 4));
                reactionUnitLeft = Vector2.TransformNormal(reactionUnit, Matrix3x2.CreateRotation(-(float)Math.PI / 4));
                reactionMagnitude = (float)DMath.Sqrt((loadReaction.X * loadReaction.X) + (loadReaction.Y * loadReaction.Y));
                if (!Model.Nodes.NodesWithReactions.ContainsKey(index))
                {
                    Node tmpNode = Model.Nodes.NodesWithReactions.GetOrAdd(index, this);
                }
            }
        }

        internal void UpdateNodeGraphics()
        {
            reactionLine = reactionUnit * reactionMagnitude * (float)Options.ReactionsFactor;
            forceLine = forceUnit * forceMagnitude * (float)Options.ForcesFactor;
        }

        #endregion

    }
}
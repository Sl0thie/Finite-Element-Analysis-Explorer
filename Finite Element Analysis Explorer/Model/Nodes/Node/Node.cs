namespace Finite_Element_Analysis_Explorer
{
    using System;
    using System.Diagnostics;
    using System.Numerics;

    /// <summary>
    /// Node class.
    /// </summary>
    internal class Node
    {
        #region Constructor

        /// <summary>
        /// Outputs the object to the debug output.
        /// </summary>
        internal void Output()
        {
            Debug.WriteLine("NODE " + index + " " + isPrimary);
            Debug.WriteLine("  Position X:" + position.X + "  Y:" + position.Y + "  M:" + position.M);
            Debug.WriteLine("  Codes:" + codes.X + " " + codes.Y + " " + codes.M);
            Debug.WriteLine("  Constraint:" + constraints);
            Debug.WriteLine("  Load X:" + load.X + "  Y:" + load.Y + "  M:" + load.M);
            Debug.WriteLine("  Super Position X:" + superPosition.X + "  Y:" + superPosition.Y + "  M:" + superPosition.M);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        internal Node()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="index">The index of the node.</param>
        /// <param name="position">The position of the node.</param>
        /// <param name="codes">The codes of the node.</param>
        /// <param name="constraints">The constraints of the node.</param>
        /// <param name="newLoad">The load of the node.</param>
        /// <param name="isPrimary">True if a primary node.</param>
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

        /// <summary>
        /// Gets the index of the node.
        /// </summary>
        internal int Index
        {
            get { return index; }
        }

        private bool isPrimary = false;

        /// <summary>
        /// Gets or sets a value indicating whether the node is primary.
        /// </summary>
        internal bool IsPrimary
        {
            get { return isPrimary; }
            set { isPrimary = value; }
        }

        private bool isValid = false;

        /// <summary>
        /// Gets or sets a value indicating whether the node is valid.
        /// </summary>
        internal bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        private Codes codes;

        /// <summary>
        /// Gets or sets the codes of the node.
        /// </summary>
        internal Codes Codes
        {
            get { return codes; }
            set { codes = value; }
        }

        #endregion

        #region Constraints

        private Constraints constraints;

        /// <summary>
        /// Gets or sets the constraints or the node.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the position of the node.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the location of the node.
        /// </summary>
        public Vector2 Location
        {
            get { return location; }
            set { location = value; }
        }

        #endregion

        #region Load

        private NodalLoad load;

        /// <summary>
        /// Gets or sets the nodal load on the node.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the joint load of the node.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the load reaction of the node.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the original load of the node.
        /// </summary>
        public NodalLoad LoadOriginal
        {
            get { return loadOriginal; }
            set { loadOriginal = value; }
        }

        #endregion

        #region Displacement

        private Point displacement = new Point(0, 0, 0);

        /// <summary>
        /// Gets or sets the displacement of the node.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the displaced position of the node.
        /// </summary>
        internal Point PositionDisplaced
        {
            get { return positionDisplaced; }
            set { positionDisplaced = value; }
        }

        #endregion

        #region Superposition

        private NodalLoad superPosition;

        /// <summary>
        /// Gets or sets the super position of the node.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the force unit.
        /// </summary>
        internal Vector2 ForceUnit
        {
            get { return forceUnit; }
            set { forceUnit = value; }
        }

        private Vector2 forceUnitRight;

        /// <summary>
        /// Gets or sets the force unit right.
        /// </summary>
        internal Vector2 ForceUnitRight
        {
            get { return forceUnitRight; }
            set { forceUnitRight = value; }
        }

        private Vector2 forceUnitLeft;

        /// <summary>
        /// Gets or sets the force unit left.
        /// </summary>
        internal Vector2 ForceUnitLeft
        {
            get { return forceUnitLeft; }
            set { forceUnitLeft = value; }
        }

        private Vector2 forceLine;

        /// <summary>
        /// Gets or sets the force line.
        /// </summary>
        public Vector2 ForceLine
        {
            get { return forceLine; }
            set { forceLine = value; }
        }

        private Vector2 reactionUnit;

        /// <summary>
        /// Gets or sets the reaction unit.
        /// </summary>
        internal Vector2 ReactionUnit
        {
            get { return reactionUnit; }
            set { reactionUnit = value; }
        }

        private Vector2 reactionUnitRight;

        /// <summary>
        /// Gets or sets the reaction unit right.
        /// </summary>
        internal Vector2 ReactionUnitRight
        {
            get { return reactionUnitRight; }
            set { reactionUnitRight = value; }
        }

        private Vector2 reactionUnitLeft;

        /// <summary>
        /// Gets or sets the reaction unit left.
        /// </summary>
        internal Vector2 ReactionUnitLeft
        {
            get { return reactionUnitLeft; }
            set { reactionUnitLeft = value; }
        }

        private Vector2 reactionLine;

        /// <summary>
        /// Gets or sets the reaction line.
        /// </summary>
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

        /// <summary>
        /// Updates the displacement.
        /// </summary>
        internal void UpdateDisplacement()
        {
            positionDisplaced = new Point(position.X + (displacement.X * (decimal)Options.Display.DisplacementFactor), position.Y + (displacement.Y * (decimal)Options.Display.DisplacementFactor), position.M + (displacement.M * (decimal)Options.Display.DisplacementFactor));
            location = new Vector2((float)positionDisplaced.X, (float)positionDisplaced.Y);
        }

        /// <summary>
        /// Updates the constraints.
        /// </summary>
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

        /// <summary>
        /// Updates the nodal forces.
        /// </summary>
        internal void UpdateNodalForces()
        {
            // Check if the node has any loads.
            if (Math.Abs(load.X) + Math.Abs(load.Y) == 0)
            {
                // If no load then try and remove from the NodesWithLodalLoads collection.
                if (Model.Nodes.NodesWithNodalLoads.ContainsKey(index))
                {
                    Node tmpNode;
                    Model.Nodes.NodesWithNodalLoads.TryRemove(index, out tmpNode);
                }
            }
            else
            {
                // Otherwise try and add the node to the NodesWithLodalLoads collection and calculate the properties.
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

            if (Math.Abs(load.M) == 0)
            {
                if (Model.Nodes.NodesWithMomentForces.ContainsKey(index))
                {
                    Node tmpNode;
                    Model.Nodes.NodesWithMomentForces.TryRemove(index, out tmpNode);
                }
            }
            else
            {
                if (!Model.Nodes.NodesWithMomentForces.ContainsKey(index))
                {
                    Node tmpNode = Model.Nodes.NodesWithMomentForces.GetOrAdd(index, this);
                }
            }

            // Also check if the node has any reactions.
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

            if (Math.Abs(loadReaction.M) == 0)
            {
                if (Model.Nodes.NodesWithMomentReactions.ContainsKey(index))
                {
                    Node tmpNode;
                    Model.Nodes.NodesWithMomentReactions.TryRemove(index, out tmpNode);
                }
            }
            else
            {
                if (!Model.Nodes.NodesWithMomentReactions.ContainsKey(index))
                {
                    Node tmpNode = Model.Nodes.NodesWithMomentReactions.GetOrAdd(index, this);
                }
            }

            


        }

        /// <summary>
        /// Updates the node graphics.
        /// </summary>
        internal void UpdateNodeGraphics()
        {
            reactionLine = reactionUnit * reactionMagnitude * (float)Options.Display.ReactionsFactor;
            forceLine = forceUnit * forceMagnitude * (float)Options.Display.ForcesFactor;
        }

        #endregion

    }
}
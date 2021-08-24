namespace Finite_Element_Analysis_Explorer
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Numerics;
    using System.Threading.Tasks;

    /// <summary>
    /// Member class.
    /// </summary>
    internal class Member
    {
        #region Constructor

        private object thisLock = new object();

        /// <summary>
        /// Outputs the member to the debug console.
        /// </summary>
        internal void Output()
        {
            Debug.WriteLine("MEMBER " + index);
            Debug.WriteLine("  nodeNear :" + nodeNear.Index + "  nodeFar:" + nodeFar.Index + "  section:" + section);
            Debug.WriteLine("  length:" + length + "  angle:" + angle);
            Debug.WriteLine("  nodeNear X : " + nodeNear.Position.X + " Y : " + nodeNear.Position.Y);
            Debug.WriteLine("  nodeFar  X : " + nodeFar.Position.X + " Y : " + nodeFar.Position.Y);
            Debug.WriteLine("  totalSegments:" + totalSegments + "  LDLNear X:" + LDLNear + "  LDLFar:" + LDLFar);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Member"/> class.
        /// </summary>
        internal Member()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Member"/> class.
        /// </summary>
        /// <param name="index">The index of the member.</param>
        /// <param name="nodeNear">The near node of the member.</param>
        /// <param name="nodeFar">The far node of the member.</param>
        /// <param name="section">The section of the member.</param>
        /// <param name="totalSegments">The number of sections in the member.</param>
        /// <param name="lDLNear">The IDL of the near side.</param>
        /// <param name="lDLFar">The IDL of the far side.</param>
        internal Member(int index, Node nodeNear, Node nodeFar, Section section, int totalSegments, decimal lDLNear, decimal lDLFar)
        {
            // Check if the member is already in the collection.
            if (Model.Members.ContainsKey(index))
            {
                Debug.WriteLine("ERROR: Member Constructor - Member already exists!");
            }
            else
            {
                // Add to the collection.
                Model.Members.TryAdd(index, this);
            }

            try
            {
                this.index = index;
                this.nodeNear = nodeNear;
                this.nodeFar = nodeFar;
                centerPoint = new Vector2((this.nodeNear.Position.Location.X + this.nodeFar.Position.Location.X) / 2, (this.nodeNear.Position.Location.Y + this.nodeFar.Position.Location.Y) / 2);
                this.section = section;
                this.totalSegments = totalSegments;
                LDLNear = lDLNear;
                LDLFar = lDLFar;

                Task.Run(() => ProcessProperties(this.nodeNear.Position.X, this.nodeNear.Position.Y, this.nodeFar.Position.X, this.nodeFar.Position.Y));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error Member Construction " + ex.Message);
                WService.ReportException(ex);
            }
        }

        #endregion

        #region Properties

        #region Objects

        private int index;

        /// <summary>
        /// Gets the index of the member.
        /// </summary>
        internal int Index
        {
            get
            {
                return index;
            }
        }

        private Node nodeNear;

        /// <summary>
        /// Gets the near node of the member.
        /// </summary>
        internal Node NodeNear
        {
            get
            {
                return nodeNear;
            }
        }

        private Node nodeFar;

        /// <summary>
        /// Gets the far node of th member.
        /// </summary>
        internal Node NodeFar
        {
            get
            {
                return nodeFar;
            }
        }

        private Segment segmentNear;

        /// <summary>
        /// Gets or sets the near segment.
        /// </summary>
        public Segment SegmentNear
        {
            get { return segmentNear; }
            set { segmentNear = value; }
        }

        private Segment segmentFar;

        /// <summary>
        /// Gets or sets the far segment.
        /// </summary>
        public Segment SegmentFar
        {
            get { return segmentFar; }
            set { segmentFar = value; }
        }

        private Section section;

        /// <summary>
        /// Gets or sets the section.
        /// </summary>
        internal Section Section
        {
            get
            {
                return section;
            }

            set
            {
                section = value;
                Task.Run(() => ProcessProperties(nodeNear.Position.X, nodeNear.Position.Y, nodeFar.Position.X, nodeFar.Position.Y));
            }
        }

        private ConcurrentDictionary<int, Segment> segments = new ConcurrentDictionary<int, Segment>();

        /// <summary>
        /// Gets the segments dictionary.
        /// </summary>
        internal ConcurrentDictionary<int, Segment> Segments
        {
            get
            {
                lock (segments)
                {
                    return segments;
                }
            }
        }

        private bool dataReady = false;

        /// <summary>
        /// Gets or sets a value indicating whether the data is ready.
        /// </summary>
        public bool DataReady
        {
            get { return dataReady; }
            set { dataReady = value; }
        }

        #endregion

        #region Construction

        private decimal length;

        /// <summary>
        /// Gets the length.
        /// </summary>
        internal decimal Length
        {
            get
            {
                return length;
            }
        }

        private decimal lengthXAxis;

        /// <summary>
        /// Gets the length of the X axis.
        /// </summary>
        internal decimal LengthXAxis
        {
            get
            {
                return lengthXAxis;
            }
        }

        private decimal lengthYAxis;

        /// <summary>
        /// Gets the length of the Y axis.
        /// </summary>
        internal decimal LengthYAxis
        {
            get
            {
                return lengthYAxis;
            }
        }

        private int angleMultiplyer = 0; // Needs better fix.
        private decimal angle;

        /// <summary>
        /// Gets the angle of the member.
        /// </summary>
        internal decimal Angle
        {
            get
            {
                return angle;
            }
        }

        private int totalSegments;

        /// <summary>
        /// Gets or sets the number of segments within the member.
        /// </summary>
        internal int TotalSegments
        {
            get
            {
                return totalSegments;
            }

            set
            {
                totalSegments = value;
                Task.Run(() => ProcessProperties(nodeNear.Position.X, nodeNear.Position.Y, nodeFar.Position.X, nodeFar.Position.Y));
            }
        }

        private decimal lDLNear;

        /// <summary>
        /// Gets or sets the near LDL.
        /// </summary>
        internal decimal LDLNear
        {
            get
            {
                return lDLNear;
            }

            set
            {
                lDLNear = value;
                CheckLinearLoad();
                Task.Run(() => ProcessProperties(nodeNear.Position.X, nodeNear.Position.Y, nodeFar.Position.X, nodeFar.Position.Y));
            }
        }

        private decimal lDLFar;

        /// <summary>
        /// Gets or sets the far LDL.
        /// </summary>
        internal decimal LDLFar
        {
            get
            {
                return lDLFar;
            }

            set
            {
                lDLFar = value;
                CheckLinearLoad();
                Task.Run(() => ProcessProperties(nodeNear.Position.X, nodeNear.Position.Y, nodeFar.Position.X, nodeFar.Position.Y));
            }
        }

        // Should be replaced with segments later.
        private Vector2 centerPoint;

        /// <summary>
        /// Gets or sets the center point of the member.
        /// </summary>
        public Vector2 CenterPoint
        {
            get { return centerPoint; }
            set { centerPoint = value; }
        }

        #endregion

        #region Displaced Properties

        private decimal lengthDisplaced;

        /// <summary>
        /// Gets the length of displacement.
        /// </summary>
        public decimal LengthDisplaced
        {
            get { return lengthDisplaced; }
        }

        private decimal lengthDisplacedXAxis;

        /// <summary>
        /// Gets the length of displacement on the X axis.
        /// </summary>
        internal decimal LengthDisplacedXAxis
        {
            get
            {
                return lengthDisplacedXAxis;
            }
        }

        private decimal lengthDisplacedYAxis;

        /// <summary>
        /// Gets the length of displacement on the Y axis.
        /// </summary>
        internal decimal LengthDisplacedYAxis
        {
            get
            {
                return lengthDisplacedYAxis;
            }
        }

        private decimal angleDisplaced;

        /// <summary>
        /// Gets the angle of displacement.
        /// </summary>
        public decimal AngleDisplaced
        {
            get { return angleDisplaced; }
        }

        private decimal lengthDifference;

        /// <summary>
        /// Gets the difference in length.
        /// </summary>
        public decimal LengthDifference
        {
            get { return lengthDifference; }
        }

        private decimal lengthDifferenceXAxis;

        /// <summary>
        /// Gets the difference in length on the X axis.
        /// </summary>
        internal decimal LengthDifferenceXAxis
        {
            get
            {
                return lengthDifferenceXAxis;
            }
        }

        private decimal lengthDifferenceYAxis;

        /// <summary>
        /// Gets the difference in length on the Y axis.
        /// </summary>
        internal decimal LengthDifferenceYAxis
        {
            get
            {
                return lengthDifferenceYAxis;
            }
        }

        private decimal angleDifference;

        /// <summary>
        /// Gets the angle of difference.
        /// </summary>
        public decimal AngleDifference
        {
            get { return angleDifference; }
        }

        private decimal lengthRatio;

        /// <summary>
        /// Gets or sets the length ratio.
        /// </summary>
        public decimal LengthRatio
        {
            get { return lengthRatio; }
            set { lengthRatio = value; }
        }

        #endregion

        #region Cost

        private decimal memberCost;

        /// <summary>
        /// Gets or sets the cost of the member.
        /// </summary>
        public decimal MemberCost
        {
            get { return memberCost; }
            set { memberCost = value; }
        }

        private decimal materialCost;

        /// <summary>
        /// Gets or sets the cost of materials for the member.
        /// </summary>
        public decimal MaterialCost
        {
            get { return materialCost; }
            set { materialCost = value; }
        }

        private decimal nodeCost;

        /// <summary>
        /// Gets or sets the cost of the nodes for the member.
        /// </summary>
        public decimal NodeCost
        {
            get { return nodeCost; }
            set { nodeCost = value; }
        }

        #endregion

        #region Stress/Strain

        private decimal normalStress;

        /// <summary>
        /// Gets or sets the normal stress for the member.
        /// </summary>
        public decimal NormalStress
        {
            get { return normalStress; }
            set { normalStress = value; }
        }

        #endregion

        #endregion

        #region Methods

        #region Create Segments

        private void ProcessProperties(decimal nearX, decimal nearY, decimal farX, decimal farY)
        {
            lengthXAxis = Math.Abs(farX - nearX);
            lengthYAxis = Math.Abs(farY - nearY);

            length = DMath.Sqrt((lengthXAxis * lengthXAxis) + (lengthYAxis * lengthYAxis));

            if (farY > nearY)
            {
                angle = (decimal)Math.Atan2((double)lengthYAxis, (double)lengthXAxis);
                angleMultiplyer = 1;
            }
            else if (farY < nearY)
            {
                angle = -(decimal)Math.Atan2((double)lengthYAxis, (double)lengthXAxis);
                angleMultiplyer = -1;
            }
            else
            {
                angle = 0;
                angleMultiplyer = 0;
            }

            CheckLinearLoad();

            CreateSegments();

            CalculateCosts();

            // AssignNeighbours();
            dataReady = true;
        }

        private void CalculateCosts()
        {
            memberCost = 0;
            materialCost = 0;
            nodeCost = 0;
            materialCost = section.CostPerLength * length;
            memberCost = section.CostPerLength * length;
            switch (nodeNear.Constraints.ConstraintType)
            {
                case ConstraintType.Fixed:
                case ConstraintType.FixedBottom:
                case ConstraintType.FixedLeft:
                case ConstraintType.FixedRight:
                case ConstraintType.FixedTop:
                    memberCost += section.CostNodeFixed;
                    nodeCost += section.CostNodeFixed;
                    break;
                case ConstraintType.Free:
                    memberCost += section.CostNodeFree;
                    nodeCost += section.CostNodeFree;
                    break;
                case ConstraintType.Pinned:
                case ConstraintType.PinnedBottom:
                case ConstraintType.PinnedLeft:
                case ConstraintType.PinnedRight:
                case ConstraintType.PinnedTop:
                    memberCost += section.CostNodePinned;
                    nodeCost += section.CostNodePinned;
                    break;
                case ConstraintType.RollerBottom:
                case ConstraintType.RollerLeft:
                case ConstraintType.RollerRight:
                case ConstraintType.RollerTop:
                case ConstraintType.RollerX:
                case ConstraintType.RollerY:
                    memberCost += section.CostNodeRoller;
                    nodeCost += section.CostNodeRoller;
                    break;
                case ConstraintType.TrackBottom:
                case ConstraintType.TrackLeft:
                case ConstraintType.TrackRight:
                case ConstraintType.TrackTop:
                    memberCost += section.CostNodeTrack;
                    nodeCost += section.CostNodeTrack;
                    break;
                case ConstraintType.Unknown:
                    break;
            }

            switch (nodeFar.Constraints.ConstraintType)
            {
                case ConstraintType.Fixed:
                case ConstraintType.FixedBottom:
                case ConstraintType.FixedLeft:
                case ConstraintType.FixedRight:
                case ConstraintType.FixedTop:
                    memberCost += section.CostNodeFixed;
                    nodeCost += section.CostNodeFixed;
                    break;
                case ConstraintType.Free:
                    memberCost += section.CostNodeFree;
                    nodeCost += section.CostNodeFree;
                    break;
                case ConstraintType.Pinned:
                case ConstraintType.PinnedBottom:
                case ConstraintType.PinnedLeft:
                case ConstraintType.PinnedRight:
                case ConstraintType.PinnedTop:
                    memberCost += section.CostNodePinned;
                    nodeCost += section.CostNodePinned;
                    break;
                case ConstraintType.RollerBottom:
                case ConstraintType.RollerLeft:
                case ConstraintType.RollerRight:
                case ConstraintType.RollerTop:
                case ConstraintType.RollerX:
                case ConstraintType.RollerY:
                    memberCost += section.CostNodeRoller;
                    nodeCost += section.CostNodeRoller;
                    break;
                case ConstraintType.TrackBottom:
                case ConstraintType.TrackLeft:
                case ConstraintType.TrackRight:
                case ConstraintType.TrackTop:
                    memberCost += section.CostNodeTrack;
                    nodeCost += section.CostNodeTrack;
                    break;
                case ConstraintType.Unknown:
                    break;
            }
        }

        private void CheckLinearLoad()
        {
            if (Math.Abs(lDLNear) + Math.Abs(lDLFar) != 0)
            {
                try
                {
                    if (!Model.Members.MembersWithLinearLoads.ContainsKey(index))
                    {
                        Model.Members.MembersWithLinearLoads.TryAdd(index, this);
                    }
                }
                catch (Exception ex)
                {
                    WService.ReportException(ex);
                }
            }
            else
            {
                try
                {
                    if (Model.Members.MembersWithLinearLoads.ContainsKey(index))
                    {
                        Member tmpMember = new Member();
                        Model.Members.MembersWithLinearLoads.TryRemove(index, out tmpMember);
                    }
                }
                catch (Exception ex)
                {
                    WService.ReportException(ex);
                }
            }
        }

        private void CreateSegments()
        {
            lock (thisLock)
            {
                segments.Clear();
                Segment firstSegment = null;

                decimal xDiv = lengthXAxis / totalSegments;
                decimal yDiv;
                if (angleMultiplyer == 0)
                {
                    yDiv = 0;
                }
                else
                {
                    yDiv = lengthYAxis / (totalSegments * angleMultiplyer);
                }

                int subSectionsIteration = 1;
                int nextNodeIndex = (index * 1000) + 3;
                int segmentIndex = 0;
                int previousSegmentIndex = -1;

                Node lastNodeFar = NodeNear;

                // LDL
                decimal lastW = lDLNear;
                decimal wSeg = (lDLFar - lDLNear) / totalSegments;

                while (subSectionsIteration < totalSegments)
                {
                    Node nextNode = null;
                    decimal posX = lastNodeFar.Position.X + xDiv;
                    decimal posY = lastNodeFar.Position.Y + yDiv;
                    nextNode = Model.Nodes.GetOrAdd(new Tuple<decimal, decimal>(posX, posY), new Node(nextNodeIndex, new Point(posX, posY, 0), new Codes(), new Constraints(ConstraintType.Free), new NodalLoad(0, 0, 0), false));
                    nextNodeIndex++;
                    Segment nextSegment = new Segment(segmentIndex, this, lastNodeFar, nextNode, section, lastW, lastW + wSeg, previousSegmentIndex);
                    segments.TryAdd(nextSegment.Index, nextSegment);

                    if (firstSegment is null)
                    {
                        firstSegment = nextSegment;
                    }

                    previousSegmentIndex = nextSegment.Index;
                    segmentIndex++;
                    subSectionsIteration++;
                    lastW += wSeg;
                    lastNodeFar = nextNode;
                }

                Segment lastSegment = new Segment(segmentIndex, this, lastNodeFar, NodeFar, section, lastW, lastW + wSeg, previousSegmentIndex);
                segments.TryAdd(lastSegment.Index, lastSegment);
                segmentIndex++;

                if (firstSegment is null)
                {
                    firstSegment = lastSegment;
                }

                segmentNear = firstSegment;
                segmentFar = lastSegment;

                // Add segment to member tiles
                foreach (KeyValuePair<int, Segment> item in Model.Members[index].Segments)
                {
                    Tuple<int, int> position = new Tuple<int, int>(Convert.ToInt32(item.Value.CenterPointDisplaced.X / Model.Members.GridSize), Convert.ToInt32(item.Value.CenterPointDisplaced.Y / Model.Members.GridSize));
                    List<Tuple<int, int>> iTmp = null;

                    if (Model.Members.MemberTiles.ContainsKey(position))
                    {
                        iTmp = Model.Members.MemberTiles[position];
                        iTmp.Add(new Tuple<int, int>(index, item.Value.Index));
                    }
                    else
                    {
                        List<Tuple<int, int>> newList = new List<Tuple<int, int>>
                        {
                            new Tuple<int, int>(index, item.Value.Index),
                        };

                        if (!Model.Members.MemberTiles.TryAdd(position, newList))
                        {
                            Debug.WriteLine("Segment TryAdd Failed. " + index + " " + position.ToString() + " " + newList.ToString());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Updates the properties from the matrix.
        /// </summary>
        internal void UpdatePropertiesFromMatrix()
        {
            lengthDisplacedXAxis = Math.Abs(nodeFar.PositionDisplaced.X - nodeNear.PositionDisplaced.X);
            lengthDisplacedYAxis = Math.Abs(nodeFar.PositionDisplaced.Y - nodeNear.PositionDisplaced.Y);

            lengthDifferenceXAxis = lengthDisplacedXAxis - lengthXAxis;
            lengthDifferenceYAxis = lengthDisplacedYAxis - lengthYAxis;

            lengthDisplaced = DMath.Sqrt((lengthDisplacedXAxis * lengthDisplacedXAxis) + (lengthDisplacedYAxis * lengthDisplacedYAxis));
            angleDisplaced = Convert.ToDecimal(Math.Atan2(nodeNear.PositionDisplaced.Location.Y - nodeFar.PositionDisplaced.Location.Y, nodeNear.PositionDisplaced.Location.X - nodeFar.PositionDisplaced.Location.X));

            lengthDifference = lengthDisplaced - length;
            angleDifference = AngleDisplaced - angle;
            lengthRatio = lengthDifference / length;

            normalStress = segmentNear.NormalStress;
        }

        #endregion

        #endregion
    }
}

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Threading.Tasks;

namespace Finite_Element_Analysis_Explorer
{
    internal class Member
    {
        #region Constructor

        private object thisLock = new object();

        internal void Output()
        {
            Debug.WriteLine("MEMBER " + index);
            Debug.WriteLine("  nodeNear :" + nodeNear.Index + "  nodeFar:" + nodeFar.Index + "  section:" + section);
            Debug.WriteLine("  length:" + length + "  angle:" + angle);
            Debug.WriteLine("  nodeNear X : " + nodeNear.Position.X + " Y : " + nodeNear.Position.Y);
            Debug.WriteLine("  nodeFar  X : " + nodeFar.Position.X + " Y : " + nodeFar.Position.Y);
            Debug.WriteLine("  totalSegments:" + totalSegments + "  LDLNear X:" + LDLNear + "  LDLFar:" + LDLFar);
        }

        internal Member()
        {
        }

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

                // Output();
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

        internal int Index
        {
            get
            {
                return index;
            }
        }

        private Node nodeNear;

        internal Node NodeNear
        {
            get
            {
                return nodeNear;
            }
        }

        private Node nodeFar;

        internal Node NodeFar
        {
            get
            {
                return nodeFar;
            }
        }

        private Segment segmentNear;

        public Segment SegmentNear
        {
            get { return segmentNear; }
            set { segmentNear = value; }
        }

        private Segment segmentFar;

        public Segment SegmentFar
        {
            get { return segmentFar; }
            set { segmentFar = value; }
        }

        private Section section;

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

        public bool DataReady
        {
            get { return dataReady; }
            set { dataReady = value; }
        }

        #endregion

        #region Construction

        private decimal length;

        internal decimal Length
        {
            get
            {
                return length;
            }
        }

        private decimal lengthXAxis;

        internal decimal LengthXAxis
        {
            get
            {
                return lengthXAxis;
            }
        }

        private decimal lengthYAxis;

        internal decimal LengthYAxis
        {
            get
            {
                return lengthYAxis;
            }
        }

        private int angleMultiplyer = 0; // Needs better fix.
        private decimal angle;

        internal decimal Angle
        {
            get
            {
                return angle;
            }
        }

        private int totalSegments;

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

        public Vector2 CenterPoint
        {
            get { return centerPoint; }
            set { centerPoint = value; }
        }

        #endregion

        #region Displaced Properties

        private decimal lengthDisplaced;

        public decimal LengthDisplaced
        {
            get { return lengthDisplaced; }
        }

        private decimal lengthDisplacedXAxis;

        internal decimal LengthDisplacedXAxis
        {
            get
            {
                return lengthDisplacedXAxis;
            }
        }

        private decimal lengthDisplacedYAxis;

        internal decimal LengthDisplacedYAxis
        {
            get
            {
                return lengthDisplacedYAxis;
            }
        }

        private decimal angleDisplaced;

        public decimal AngleDisplaced
        {
            get { return angleDisplaced; }
        }

        private decimal lengthDifference;

        public decimal LengthDifference
        {
            get { return lengthDifference; }
        }

        private decimal lengthDifferenceXAxis;

        internal decimal LengthDifferenceXAxis
        {
            get
            {
                return lengthDifferenceXAxis;
            }
        }

        private decimal lengthDifferenceYAxis;

        internal decimal LengthDifferenceYAxis
        {
            get
            {
                return lengthDifferenceYAxis;
            }
        }

        private decimal angleDifference;

        public decimal AngleDifference
        {
            get { return angleDifference; }
        }

        private decimal lengthRatio;

        public decimal LengthRatio
        {
            get { return lengthRatio; }
            set { lengthRatio = value; }
        }

        #endregion

        #region Cost

        private decimal memberCost;

        public decimal MemberCost
        {
            get { return memberCost; }
            set { memberCost = value; }
        }

        private decimal materialCost;

        public decimal MaterialCost
        {
            get { return materialCost; }
            set { materialCost = value; }
        }

        private decimal nodeCost;

        public decimal NodeCost
        {
            get { return nodeCost; }
            set { nodeCost = value; }
        }

        #endregion

        #region Stress/Strain

        private decimal normalStress;

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
            materialCost = this.section.CostPerLength * length;
            memberCost = this.section.CostPerLength * length;
            switch (nodeNear.Constraints.ConstraintType)
            {
                case ConstraintType.Fixed:
                case ConstraintType.FixedBottom:
                case ConstraintType.FixedLeft:
                case ConstraintType.FixedRight:
                case ConstraintType.FixedTop:
                    memberCost += this.section.CostNodeFixed;
                    nodeCost += this.section.CostNodeFixed;
                    break;
                case ConstraintType.Free:
                    memberCost += this.section.CostNodeFree;
                    nodeCost += this.section.CostNodeFree;
                    break;
                case ConstraintType.Pinned:
                case ConstraintType.PinnedBottom:
                case ConstraintType.PinnedLeft:
                case ConstraintType.PinnedRight:
                case ConstraintType.PinnedTop:
                    memberCost += this.section.CostNodePinned;
                    nodeCost += this.section.CostNodePinned;
                    break;
                case ConstraintType.RollerBottom:
                case ConstraintType.RollerLeft:
                case ConstraintType.RollerRight:
                case ConstraintType.RollerTop:
                case ConstraintType.RollerX:
                case ConstraintType.RollerY:
                    memberCost += this.section.CostNodeRoller;
                    nodeCost += this.section.CostNodeRoller;
                    break;
                case ConstraintType.TrackBottom:
                case ConstraintType.TrackLeft:
                case ConstraintType.TrackRight:
                case ConstraintType.TrackTop:
                    memberCost += this.section.CostNodeTrack;
                    nodeCost += this.section.CostNodeTrack;
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
                    memberCost += this.section.CostNodeFixed;
                    nodeCost += this.section.CostNodeFixed;
                    break;
                case ConstraintType.Free:
                    memberCost += this.section.CostNodeFree;
                    nodeCost += this.section.CostNodeFree;
                    break;
                case ConstraintType.Pinned:
                case ConstraintType.PinnedBottom:
                case ConstraintType.PinnedLeft:
                case ConstraintType.PinnedRight:
                case ConstraintType.PinnedTop:
                    memberCost += this.section.CostNodePinned;
                    nodeCost += this.section.CostNodePinned;
                    break;
                case ConstraintType.RollerBottom:
                case ConstraintType.RollerLeft:
                case ConstraintType.RollerRight:
                case ConstraintType.RollerTop:
                case ConstraintType.RollerX:
                case ConstraintType.RollerY:
                    memberCost += this.section.CostNodeRoller;
                    nodeCost += this.section.CostNodeRoller;
                    break;
                case ConstraintType.TrackBottom:
                case ConstraintType.TrackLeft:
                case ConstraintType.TrackRight:
                case ConstraintType.TrackTop:
                    memberCost += this.section.CostNodeTrack;
                    nodeCost += this.section.CostNodeTrack;
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
                    nextNode = Model.Nodes.GetOrAdd(new Tuple<decimal, decimal>(posX, posY), new Node(nextNodeIndex, new Finite_Element_Analysis_Explorer.Point(posX, posY, 0), new Codes(), new Constraints(ConstraintType.Free), new NodalLoad(0, 0, 0), false));
                    nextNodeIndex++;
                    Segment nextSegment = new Segment(segmentIndex, this, lastNodeFar, nextNode, section, lastW, lastW + wSeg, previousSegmentIndex);
                    segments.TryAdd(nextSegment.Index, nextSegment);

                    if (ReferenceEquals(null, firstSegment))
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

                if (ReferenceEquals(null, firstSegment))
                {
                    firstSegment = lastSegment;
                }

                segmentNear = firstSegment;
                segmentFar = lastSegment;

                // Add segment to member tiles
                foreach (var item in Model.Members[index].Segments)
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
                        List<Tuple<int, int>> newList = new List<Tuple<int, int>>();
                        newList.Add(new Tuple<int, int>(index, item.Value.Index));

                        if (!Model.Members.MemberTiles.TryAdd(position, newList))
                        {
                            Debug.WriteLine("Segment TryAdd Failed. " + index + " " + position.ToString() + " " + newList.ToString());
                        }
                    }
                }
            }
        }

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

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

        private Object thisLock = new Object();

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

        internal Member(int _index, Node _nodeNear, Node _nodeFar, Section _section, int _totalSegments, decimal _LDLNear, decimal _LDLFar)
        {
            //Check if the member is already in the collection.
            if (Model.Members.ContainsKey(_index))
            {
                Debug.WriteLine("ERROR: Member Constructor - Member already exists!");
            }
            else
            {
                //Add to the collection.
                Model.Members.TryAdd(_index, this);
            }




            try
            {
                index = _index;
                nodeNear = _nodeNear;
                nodeFar = _nodeFar;
                centerPoint = new Vector2((nodeNear.Position.Location.X + nodeFar.Position.Location.X) / 2, (nodeNear.Position.Location.Y + nodeFar.Position.Location.Y) / 2);
                section = _section;
                totalSegments = _totalSegments;
                LDLNear = _LDLNear;
                LDLFar = _LDLFar;

                Task.Run(() => ProcessProperties(nodeNear.Position.X, nodeNear.Position.Y, nodeFar.Position.X, nodeFar.Position.Y));

                //Output();
            }
            catch (Exception ex) { Debug.WriteLine("Error Member Construction " + ex.Message); }
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

        //private IList<Segment> segments = new List<Segment>();
        //internal IList<Segment> Segments
        //{
        //    get
        //    {
        //        lock (segments)
        //        {
        //            return segments;
        //        }
        //    }
        //}

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

        private int angleMultiplyer = 0; //Needs better fix.
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
            get { return totalSegments; }
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

        //Should be replaced with segments later.
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

        private void ProcessProperties(decimal NearX, decimal NearY, decimal FarX, decimal FarY)
        {
            lengthXAxis = Math.Abs(FarX - NearX);
            lengthYAxis = Math.Abs(FarY - NearY);

            length = DMath.Sqrt((lengthXAxis * lengthXAxis) + (lengthYAxis * lengthYAxis));

            if (FarY > NearY)
            {
                angle = (decimal)Math.Atan2((double)lengthYAxis, (double)lengthXAxis);
                angleMultiplyer = 1;
            }
            else if (FarY < NearY)
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

            //Model.Members.AddNewElementToTiles(index,centerPoint);


            //AssignNeighbours();

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
                catch { }
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
                catch { }
            }
        }

        private void CreateSegments()
        {
            lock (thisLock)
            {
                segments.Clear();

                //segments = new ConcurrentBag<Segment>();

                Segment firstSegment = null;

                decimal XDiv = lengthXAxis / totalSegments;
                decimal YDiv; // / (totalSegments * angleMultiplyer);
                if (angleMultiplyer == 0)
                {
                    YDiv = 0;
                }
                else
                {
                    YDiv = lengthYAxis / (totalSegments * angleMultiplyer);
                }

                int subSectionsIteration = 1;
                int nextNodeIndex = (index * 1000) + 3;
                int segmentIndex = 0;
                int previousSegmentIndex = -1;


                Node lastNodeFar = NodeNear;

                //LDL
                decimal LastW = lDLNear;
                decimal WSeg = (lDLFar - lDLNear) / totalSegments;

                while (subSectionsIteration < totalSegments)
                {
                    Node NextNode = null;
                    decimal PosX = lastNodeFar.Position.X + XDiv;
                    decimal PosY = lastNodeFar.Position.Y + YDiv;
                    NextNode = Model.Nodes.GetOrAdd(new Tuple<decimal, decimal>(PosX, PosY), new Node(nextNodeIndex, new Finite_Element_Analysis_Explorer.Point(PosX, PosY, 0), new Codes(), new Constraints(ConstraintType.Free), new NodalLoad(0, 0, 0), false));
                    nextNodeIndex++;
                    Segment NextSegment = new Segment(segmentIndex, this, lastNodeFar, NextNode, section, LastW, LastW + WSeg, previousSegmentIndex);
                    segments.TryAdd(NextSegment.Index, NextSegment);

                    if (ReferenceEquals(null, firstSegment))
                    {
                        firstSegment = NextSegment;
                    }

                    previousSegmentIndex = NextSegment.Index;
                    segmentIndex++;
                    subSectionsIteration++;
                    LastW = LastW + WSeg;
                    lastNodeFar = NextNode;
                }

                Segment lastSegment = new Segment(segmentIndex, this, lastNodeFar, NodeFar, section, LastW, LastW + WSeg, previousSegmentIndex);
                segments.TryAdd(lastSegment.Index, lastSegment);
                segmentIndex++;

                if (ReferenceEquals(null, firstSegment))
                {
                    firstSegment = lastSegment;
                }

                segmentNear = firstSegment;
                segmentFar = lastSegment;



                //Add segment to member tiles
                foreach (var item in Model.Members[index].Segments)
                {

                    Tuple<int, int> Position = new Tuple<int, int>(Convert.ToInt32(item.Value.CenterPointDisplaced.X / Model.Members.GridSize), Convert.ToInt32(item.Value.CenterPointDisplaced.Y / Model.Members.GridSize));
                    List<Tuple<int, int>> ITmp = null;

                    if (Model.Members.MemberTiles.ContainsKey(Position))
                    {
                        //Debug.WriteLine("Update Position " + index + " " + item.Key + " " + Position.ToString() + " " + item.Value.CenterPointDisplaced.ToString());

                        ITmp = Model.Members.MemberTiles[Position];
                        ITmp.Add(new Tuple<int, int>(index, item.Value.Index));
                    }
                    else
                    {
                        //Debug.WriteLine("New    Position " + index + " " + item.Key + " " + Position.ToString() + " " + item.Value.CenterPointDisplaced.ToString());
                        //List<int> NewList = new List<int>();
                        List<Tuple<int, int>> NewList = new List<Tuple<int, int>>();
                        NewList.Add(new Tuple<int, int>(index, item.Value.Index));
                        //MemberTiles.TryAdd(Position, NewList);

                        if (!Model.Members.MemberTiles.TryAdd(Position, NewList)) { Debug.WriteLine("Segment TryAdd Failed. " + index + " " + Position.ToString() + " " + NewList.ToString()); }
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

using System.Collections.Concurrent;
using System.Diagnostics;

namespace Finite_Element_Analysis_Explorer
{
    internal static class Model
    {
        #region Operations

        // static Model()
        // {
        //    members = new MemberCollection();
        //    nodes = new NodeConcurrentCollection();
        //    sections = new SectionCollection();
        //    materials = new MaterialCollection();
        //    sectionProfiles = new SectionProfileCollection();
        // }
        #endregion

        #region Properties

        #region Collections

        internal static volatile int TotalMembers;

        // internal static volatile int TotalNodes;
        // internal static volatile int TotalSegments;
        private static MemberCollection members = new MemberCollection();

        internal static MemberCollection Members
        {
            get
            {
                return members;
            }
        }

        private static NodeConcurrentCollection nodes = new NodeConcurrentCollection();

        internal static NodeConcurrentCollection Nodes
        {
            get
            {
                return nodes;
            }
        }

        private static SectionCollection sections = new SectionCollection();

        internal static SectionCollection Sections
        {
            get
            {
                return sections;
            }
        }

        private static MaterialCollection materials = new MaterialCollection();

        internal static MaterialCollection Materials
        {
            get
            {
                return materials;
            }
        }

        private static SectionProfileCollection sectionProfiles = new SectionProfileCollection();

        internal static SectionProfileCollection SectionProfiles
        {
            get
            {
                return sectionProfiles;
            }
        }

        #endregion

        internal static ConcurrentBag<Segment> SegmentsWithLinearLoad = new ConcurrentBag<Segment>();

        private static decimal largestLinear;

        internal static decimal LargestLinear
        {
            get { return largestLinear; }
            set { largestLinear = value; }
        }

        #region Equlibrim Properties

        private static decimal forceX;

        public static decimal ForceX
        {
            get { return forceX; }
            set { forceX = value; }
        }

        private static decimal reactionX;

        public static decimal ReactionX
        {
            get { return reactionX; }
            set { reactionX = value; }
        }

        private static decimal forceY;

        public static decimal ForceY
        {
            get { return forceY; }
            set { forceY = value; }
        }

        private static decimal reactionY;

        public static decimal ReactionY
        {
            get { return reactionY; }
            set { reactionY = value; }
        }

        private static decimal forceM;

        public static decimal ForceM
        {
            get { return forceM; }
            set { forceM = value; }
        }

        private static decimal reactionM;

        public static decimal ReactionM
        {
            get { return reactionM; }
            set { reactionM = value; }
        }

        #endregion

        #region Cost

        private static decimal totalCost;

        public static decimal TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }

        private static decimal materialCost;

        public static decimal MaterialCost
        {
            get { return materialCost; }
            set { materialCost = value; }
        }

        private static decimal nodeCost;

        public static decimal NodeCost
        {
            get { return nodeCost; }
            set { nodeCost = value; }
        }

        private static decimal transportCost;

        public static decimal TransportCost
        {
            get { return transportCost; }
            set { transportCost = value; }
        }

        private static decimal elevationCost;

        public static decimal ElevationCost
        {
            get { return elevationCost; }
            set { elevationCost = value; }
        }

        #endregion

        #endregion

        #region Methods

        internal static void UpdatePanelPage()
        {
            switch (App.CurrentPageState)
            {
                case PageState.Construction:
                    if (ReferenceEquals(null, Model.members.CurrentMember))
                    {
                        Construction.Current.ShowModel();
                    }
                    else
                    {
                        Construction.Current.ShowMember();
                    }

                    break;

                case PageState.FileLoading:

                    break;

                case PageState.Sections:
                    Construction.Current.ShowSection();
                    break;

                case PageState.Results:
                    if (ReferenceEquals(null, Model.members.CurrentMember))
                    {
                        Results.Current.ShowModel();
                    }
                    else
                    {
                        Results.Current.ShowMember();
                    }

                    break;

                case PageState.Solver:

                    break;

                case PageState.Unknown:

                    break;
            }
        }

        internal static void UpdateColors()
        {
            switch (App.CurrentPageState)
            {
                case PageState.Construction:
                    ConstructionDisplay.Current.UpdateColors();
                    break;

                case PageState.FileLoading:

                    break;

                case PageState.Results:
                    ResultsDisplay.Current.UpdateColors();
                    break;

                case PageState.Solver:

                    break;

                case PageState.Unknown:

                    break;
            }
        }

        /// <summary>
        /// Reset the Model. Exclude the Materials Collection to reduce the workload.
        /// </summary>
        internal static void Reset()
        {
            Camera.Reset();
            members.Reset();
            nodes.Reset();
        }

        /// <summary>
        /// Check the model for defects.
        /// </summary>
        internal static void Check()
        {
        }

        /// <summary>
        /// Relocate the model to a better position.
        /// </summary>
        internal static void Relocate()
        {
        }

        internal static void Output()
        {
            Debug.WriteLine("Model Totals:");
            Debug.WriteLine("  " + members.Count + " members");
            Debug.WriteLine("  " + nodes.Count + " nodes");
            Debug.WriteLine("  " + sections.Count + " sections");
            Debug.WriteLine("  " + materials.Count + " materials");
            Debug.WriteLine(string.Empty);

            foreach (var item in Model.Members)
            {
                item.Value.Output();

                foreach (var nextItem in item.Value.Segments)
                {
                    nextItem.Value.Output();
                }
            }

            foreach (var item in Model.Nodes)
            {
                item.Value.Output();
            }
        }

        #endregion

        /// <summary>
        /// Shrink the model to reduce the indexes. and find lost nodes.
        /// </summary>
        #region Shrink Model

        public static bool Shrink()
        {
            // Search for unassigned nodes.
            foreach (var node in nodes)
            {
                node.Value.IsValid = false;
            }

            foreach (var member in members)
            {
                foreach (var segment in member.Value.Segments)
                {
                    segment.Value.NodeNear.IsValid = true;
                    segment.Value.NodeFar.IsValid = true;
                }
            }

            foreach (var node in nodes)
            {
                if (node.Value.IsValid == false)
                {
                    Model.nodes.RemoveNode(node.Value);
                }
            }

            return true;
        }

        #endregion
    }
}
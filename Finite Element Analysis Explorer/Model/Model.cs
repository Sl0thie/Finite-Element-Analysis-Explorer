namespace Finite_Element_Analysis_Explorer
{
    using System.Collections.Concurrent;
    using System.Diagnostics;

    /// <summary>
    /// Model static class to manage the structural model.
    /// </summary>
    internal static class Model
    {
        private static int totalMembers;
        private static MemberCollection members = new MemberCollection();
        private static NodeConcurrentCollection nodes = new NodeConcurrentCollection();
        private static SectionCollection sections = new SectionCollection();
        private static MaterialCollection materials = new MaterialCollection();
        private static SectionProfileCollection sectionProfiles = new SectionProfileCollection();
        private static ConcurrentBag<Segment> segmentsWithLinearLoad = new ConcurrentBag<Segment>();
        private static decimal largestLinear;
        private static decimal forceX;
        private static decimal reactionX;
        private static decimal forceY;
        private static decimal reactionY;
        private static decimal forceM;
        private static decimal reactionM;
        private static decimal totalCost;
        private static decimal materialCost;
        private static decimal nodeCost;
        private static decimal transportCost;
        private static decimal elevationCost;
        private static bool isReportBasic;

        /// <summary>
        /// Gets or sets the total number of members.
        /// </summary>
        internal static int TotalMembers
        {
            get
            {
                return totalMembers;
            }

            set
            {
                totalMembers = value;
            }
        }

        /// <summary>
        /// Gets the members collection.
        /// </summary>
        internal static MemberCollection Members
        {
            get
            {
                return members;
            }
        }

        /// <summary>
        /// Gets the nodes collection.
        /// </summary>
        internal static NodeConcurrentCollection Nodes
        {
            get
            {
                return nodes;
            }
        }

        /// <summary>
        /// Gets the sections collection.
        /// </summary>
        internal static SectionCollection Sections
        {
            get
            {
                return sections;
            }
        }

        /// <summary>
        /// Gets the materials collection.
        /// </summary>
        internal static MaterialCollection Materials
        {
            get
            {
                return materials;
            }
        }

        /// <summary>
        /// Gets the section profiles collection.
        /// </summary>
        internal static SectionProfileCollection SectionProfiles
        {
            get
            {
                return sectionProfiles;
            }
        }

        /// <summary>
        /// Gets or sets the segments with load concurrent bag.
        /// </summary>
        internal static ConcurrentBag<Segment> SegmentsWithLinearLoad
        {
            get
            {
                return segmentsWithLinearLoad;
            }

            set
            {
                segmentsWithLinearLoad = value;
            }
        }

        /// <summary>
        /// Gets or sets the largest linear load.
        /// </summary>
        internal static decimal LargestLinear
        {
            get { return largestLinear; }
            set { largestLinear = value; }
        }

        #region Equilibrium Properties

        /// <summary>
        /// Gets or sets the force X.
        /// </summary>
        public static decimal ForceX
        {
            get { return forceX; }
            set { forceX = value; }
        }

        /// <summary>
        /// Gets or sets the reaction X.
        /// </summary>
        public static decimal ReactionX
        {
            get { return reactionX; }
            set { reactionX = value; }
        }

        /// <summary>
        /// Gets or sets the force Y.
        /// </summary>
        public static decimal ForceY
        {
            get { return forceY; }
            set { forceY = value; }
        }

        /// <summary>
        /// Gets or sets the reaction Y.
        /// </summary>
        public static decimal ReactionY
        {
            get { return reactionY; }
            set { reactionY = value; }
        }

        /// <summary>
        /// Gets or sets the force M.
        /// </summary>
        public static decimal ForceM
        {
            get { return forceM; }
            set { forceM = value; }
        }

        /// <summary>
        /// Gets or sets the reaction M.
        /// </summary>
        public static decimal ReactionM
        {
            get { return reactionM; }
            set { reactionM = value; }
        }

        #endregion

        #region Cost

        /// <summary>
        /// Gets or sets the total cost.
        /// </summary>
        public static decimal TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }

        /// <summary>
        /// Gets or sets the material cost.
        /// </summary>
        public static decimal MaterialCost
        {
            get { return materialCost; }
            set { materialCost = value; }
        }

        /// <summary>
        /// Gets or sets the node cost.
        /// </summary>
        public static decimal NodeCost
        {
            get { return nodeCost; }
            set { nodeCost = value; }
        }

        /// <summary>
        /// Gets or sets the transport cost.
        /// </summary>
        public static decimal TransportCost
        {
            get { return transportCost; }
            set { transportCost = value; }
        }

        /// <summary>
        /// Gets or sets the elevation cost.
        /// </summary>
        public static decimal ElevationCost
        {
            get { return elevationCost; }
            set { elevationCost = value; }
        }

        #endregion

        #region Reports

        /// <summary>
        /// Gets or sets a value indicating whether the report is basic.
        /// </summary>
        public static bool IsReportBasic
        {
            get
            {
                return isReportBasic;
            }

            set
            {
                isReportBasic = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the panel page.
        /// </summary>
        internal static void UpdatePanelPage()
        {
            switch (App.CurrentPageState)
            {
                case PageState.Construction:
                    if (members.CurrentMember is null)
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
                    if (members.CurrentMember is null)
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

        /// <summary>
        /// Outputs the model to debug console.
        /// </summary>
        internal static void Output()
        {
            Debug.WriteLine("Model Totals:");
            Debug.WriteLine("  " + members.Count + " members");
            Debug.WriteLine("  " + nodes.Count + " nodes");
            Debug.WriteLine("  " + sections.Count + " sections");
            Debug.WriteLine("  " + materials.Count + " materials");
            Debug.WriteLine(string.Empty);

            foreach (System.Collections.Generic.KeyValuePair<int, Member> item in Members)
            {
                item.Value.Output();

                foreach (System.Collections.Generic.KeyValuePair<int, Segment> nextItem in item.Value.Segments)
                {
                    nextItem.Value.Output();
                }
            }

            foreach (System.Collections.Generic.KeyValuePair<System.Tuple<decimal, decimal>, Node> item in Nodes)
            {
                item.Value.Output();
            }
        }

        #endregion

        #region Shrink Model

        /// <summary>
        /// Shrink the model to reduce the indexes. and find lost nodes.
        /// </summary>
        /// <returns>True if successful.</returns>
        public static bool Shrink()
        {
            // Search for unassigned nodes.
            foreach (System.Collections.Generic.KeyValuePair<System.Tuple<decimal, decimal>, Node> node in nodes)
            {
                node.Value.IsValid = false;
            }

            foreach (System.Collections.Generic.KeyValuePair<int, Member> member in members)
            {
                foreach (System.Collections.Generic.KeyValuePair<int, Segment> segment in member.Value.Segments)
                {
                    segment.Value.NodeNear.IsValid = true;
                    segment.Value.NodeFar.IsValid = true;
                }
            }

            foreach (System.Collections.Generic.KeyValuePair<System.Tuple<decimal, decimal>, Node> node in nodes)
            {
                if (node.Value.IsValid == false)
                {
                    nodes.RemoveNode(node.Value);
                }
            }

            return true;
        }

        #endregion
    }
}
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Finite_Element_Analysis_Explorer
{
    /// <summary>
    /// Model static class to manage the structural model.
    /// </summary>
    internal static class Model
    {
        #region Properties

        #region Collections

        /// <summary>
        /// Gets or sets the total number of members.
        /// </summary>
        internal static int TotalMembers { get; set; }

        private static MemberCollection members = new MemberCollection();

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

        private static NodeConcurrentCollection nodes = new NodeConcurrentCollection();

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

        private static SectionCollection sections = new SectionCollection();

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

        private static MaterialCollection materials = new MaterialCollection();

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

        private static SectionProfileCollection sectionProfiles = new SectionProfileCollection();

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

        #endregion

        private static ConcurrentBag<Segment> segmentsWithLinearLoad = new ConcurrentBag<Segment>();

        /// <summary>
        /// Gets or sets the segments with load concurrent bag.
        /// </summary>
        internal static ConcurrentBag<Segment> SegmentsWithLinearLoad { get => segmentsWithLinearLoad; set => segmentsWithLinearLoad = value; }

        private static decimal largestLinear;

        /// <summary>
        /// Gets or sets the largest linear load.
        /// </summary>
        internal static decimal LargestLinear
        {
            get { return largestLinear; }
            set { largestLinear = value; }
        }

        #region Equilibrium Properties

        private static decimal forceX;

        /// <summary>
        /// Gets or sets the force X.
        /// </summary>
        public static decimal ForceX
        {
            get { return forceX; }
            set { forceX = value; }
        }

        private static decimal reactionX;

        /// <summary>
        /// Gets or sets the reaction X.
        /// </summary>
        public static decimal ReactionX
        {
            get { return reactionX; }
            set { reactionX = value; }
        }

        private static decimal forceY;

        /// <summary>
        /// Gets or sets the force Y.
        /// </summary>
        public static decimal ForceY
        {
            get { return forceY; }
            set { forceY = value; }
        }

        private static decimal reactionY;

        /// <summary>
        /// Gets or sets the reaction Y.
        /// </summary>
        public static decimal ReactionY
        {
            get { return reactionY; }
            set { reactionY = value; }
        }

        private static decimal forceM;

        /// <summary>
        /// Gets or sets the force M.
        /// </summary>
        public static decimal ForceM
        {
            get { return forceM; }
            set { forceM = value; }
        }

        private static decimal reactionM;

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

        private static decimal totalCost;

        /// <summary>
        /// Gets or sets the total cost.
        /// </summary>
        public static decimal TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }

        private static decimal materialCost;

        /// <summary>
        /// Gets or sets the material cost.
        /// </summary>
        public static decimal MaterialCost
        {
            get { return materialCost; }
            set { materialCost = value; }
        }

        private static decimal nodeCost;

        /// <summary>
        /// Gets or sets the node cost.
        /// </summary>
        public static decimal NodeCost
        {
            get { return nodeCost; }
            set { nodeCost = value; }
        }

        private static decimal transportCost;

        /// <summary>
        /// Gets or sets the transport cost.
        /// </summary>
        public static decimal TransportCost
        {
            get { return transportCost; }
            set { transportCost = value; }
        }

        private static decimal elevationCost;

        /// <summary>
        /// Gets or sets the elevation cost.
        /// </summary>
        public static decimal ElevationCost
        {
            get { return elevationCost; }
            set { elevationCost = value; }
        }

        #endregion

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
        /// Update the colors.
        /// </summary>
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

        #region Shrink Model

        /// <summary>
        /// Shrink the model to reduce the indexes. and find lost nodes.
        /// </summary>
        /// <returns>True if successful.</returns>
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
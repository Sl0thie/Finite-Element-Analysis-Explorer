namespace Finite_Element_Analysis_Explorer
{
    using System;
    using Microsoft.Graphics.Canvas.Geometry;
    using Newtonsoft.Json;
    using Windows.UI;

    /// <summary>
    /// Section class.
    /// </summary>
    internal class Section
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Section"/> class.
        /// </summary>
        internal Section()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Section"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="e">e.</param>
        /// <param name="i">i.</param>
        /// <param name="area">area.</param>
        /// <param name="density">density.</param>
        /// <param name="costPerLength">costPerLength.</param>
        /// <param name="alpha">alpha.</param>
        /// <param name="red">red.</param>
        /// <param name="green">green.</param>
        /// <param name="blue">blue.</param>
        /// <param name="linetype">line type.</param>
        /// <param name="lineWeight">lineWeight.</param>
        /// <param name="nearCapStyle">nearCapStyle.</param>
        /// <param name="farCapStyle">farCapStyle.</param>
        /// <param name="costVerticalTransport">costVerticalTransport.</param>
        /// <param name="costHorizontalTransport">costHorizontalTransport.</param>
        /// <param name="costNodeFree">costNodeFree.</param>
        /// <param name="costNodeFixed">costNodeFixed.</param>
        /// <param name="costNodePinned">costNodePinned.</param>
        /// <param name="costNodeRoller">costNodeRoller.</param>
        /// <param name="costNodeTrack">costNodeTrack.</param>
        /// <param name="sectionProfile">sectionProfile.</param>
        /// <param name="sectionProfileProperty1">sectionProfileProperty1.</param>
        /// <param name="sectionProfileProperty2">sectionProfileProperty2.</param>
        /// <param name="sectionProfileProperty3">sectionProfileProperty3.</param>
        /// <param name="sectionProfileProperty4">sectionProfileProperty4.</param>
        /// <param name="sectionProfileProperty5">sectionProfileProperty5.</param>
        /// <param name="sectionProfileProperty6">sectionProfileProperty6.</param>
        /// <param name="sectionProfileProperty7">sectionProfileProperty7.</param>
        /// <param name="material">material.</param>
        /// <param name="maintenancePerLength">maintenancePerLength.</param>
        /// <param name="maintenanceNodeFree">maintenanceNodeFree.</param>
        /// <param name="maintenanceFixed">maintenanceFixed.</param>
        /// <param name="maintenancePinned">maintenancePinned.</param>
        /// <param name="maintenanceRoller">maintenanceRoller.</param>
        /// <param name="maintenanceTrack">maintenanceTrack.</param>
        /// <param name="factorVerticalTransport">factorVerticalTransport.</param>
        /// <param name="factorHorizontalTransport">factorHorizontalTransport.</param>
        internal Section(
            string name,
            decimal e,
            decimal i,
            decimal area,
            decimal density,
            decimal costPerLength,
            int alpha,
            int red,
            int green,
            int blue,
            CanvasDashStyle linetype,
            float lineWeight,
            CanvasCapStyle nearCapStyle,
            CanvasCapStyle farCapStyle,
            decimal costVerticalTransport,
            decimal costHorizontalTransport,
            decimal costNodeFree,
            decimal costNodeFixed,
            decimal costNodePinned,
            decimal costNodeRoller,
            decimal costNodeTrack,
            string sectionProfile,
            decimal sectionProfileProperty1,
            decimal sectionProfileProperty2,
            decimal sectionProfileProperty3,
            decimal sectionProfileProperty4,
            decimal sectionProfileProperty5,
            decimal sectionProfileProperty6,
            decimal sectionProfileProperty7,
            string material,
            decimal maintenancePerLength,
            decimal maintenanceNodeFree,
            decimal maintenanceFixed,
            decimal maintenancePinned,
            decimal maintenanceRoller,
            decimal maintenanceTrack,
            decimal factorVerticalTransport,
            decimal factorHorizontalTransport)
        {
            this.name = name;
            this.e = e;
            this.i = i;
            this.area = area;
            this.density = density;
            this.costPerLength = costPerLength;
            this.alpha = alpha;
            this.red = red;
            this.green = green;
            this.blue = blue;
            line = linetype;
            this.lineWeight = lineWeight;
            this.nearCapStyle = nearCapStyle;
            this.farCapStyle = farCapStyle;

            this.costVerticalTransport = costVerticalTransport;
            this.costHorizontalTransport = costHorizontalTransport;
            this.costNodeFree = costNodeFree;
            this.costNodeFixed = costNodeFixed;
            this.costNodePinned = costNodePinned;
            this.costNodeRoller = costNodeRoller;
            this.costNodeTrack = costNodeTrack;

            this.sectionProfile = sectionProfile;
            this.sectionProfileProperty1 = sectionProfileProperty1;
            this.sectionProfileProperty2 = sectionProfileProperty2;
            this.sectionProfileProperty3 = sectionProfileProperty3;
            this.sectionProfileProperty4 = sectionProfileProperty4;
            this.sectionProfileProperty5 = sectionProfileProperty5;
            this.sectionProfileProperty6 = sectionProfileProperty6;
            this.sectionProfileProperty7 = sectionProfileProperty7;
            this.material = material;

            this.maintenancePerLength = maintenancePerLength;
            this.maintenanceNodeFree = maintenanceNodeFree;
            this.maintenanceFixed = maintenanceFixed;
            this.maintenancePinned = maintenancePinned;
            this.maintenanceRoller = maintenanceRoller;
            this.maintenanceTrack = maintenanceTrack;
            this.factorVerticalTransport = factorVerticalTransport;
            this.factorHorizontalTransport = factorHorizontalTransport;

            UpdateCanvasStrokeStyle();
            UpdateColor();
        }

        private string name;

        /// <summary>
        /// Gets or sets the section name.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private decimal e;

        /// <summary>
        /// Gets or sets the E. Young’s modulus/Modulus of elasticity.
        /// https://en.wikipedia.org/wiki/Young%27s_modulus.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        internal decimal E
        {
            get { return e; }
            set { e = value; }
        }

        private decimal i;

        /// <summary>
        /// Gets or sets the I. Second moment of area.
        /// https://en.wikipedia.org/wiki/Second_moment_of_area.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        internal decimal I
        {
            get { return i; }
            set { i = value; }
        }

        private decimal area;

        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        internal decimal Area
        {
            get { return area; }
            set { area = value; }
        }

        private decimal density;

        /// <summary>
        /// Gets or sets the density.
        /// https://en.wikipedia.org/wiki/Density.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        internal decimal Density
        {
            get { return density; }
            set { density = value; }
        }

        private int alpha;

        /// <summary>
        /// Gets or sets the alpha.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        internal int Alpha
        {
            get { return alpha; }
            set { alpha = value; }
        }

        private int red;

        /// <summary>
        /// Gets or sets the red.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        internal int Red
        {
            get { return red; }
            set { red = value; }
        }

        private int green;

        /// <summary>
        /// Gets or sets the green.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        internal int Green
        {
            get { return green; }
            set { green = value; }
        }

        private int blue;

        /// <summary>
        /// Gets or sets the blue.
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        internal int Blue
        {
            get
            {
                return blue;
            }

            set
            {
                blue = value;
                UpdateColor();
            }
        }

        private Color color;

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        [JsonIgnore]
        internal Color Color
        {
            get { return color; }
            set { color = value; }
        }

        private CanvasDashStyle line = CanvasDashStyle.Solid;

        /// <summary>
        /// Gets or sets the line.
        /// </summary>
        internal CanvasDashStyle Line
        {
            get { return line; }
            set { line = value; }
        }

        private CanvasCapStyle nearCapStyle = CanvasCapStyle.Round;

        /// <summary>
        /// Gets or sets the near cap style.
        /// </summary>
        internal CanvasCapStyle NearCapStyle
        {
            get { return nearCapStyle; }
            set { nearCapStyle = value; }
        }

        private CanvasCapStyle farCapStyle = CanvasCapStyle.Round;

        /// <summary>
        /// Gets or sets the far cap style.
        /// </summary>
        internal CanvasCapStyle FarCapStyle
        {
            get { return farCapStyle; }
            set { farCapStyle = value; }
        }

        private float lineWeight = 1.5f;

        /// <summary>
        /// Gets or sets the line weight.
        /// </summary>
        internal float LineWeight
        {
            get { return lineWeight; }
            set { lineWeight = value; }
        }

        private decimal costPerLength = 0;

        /// <summary>
        /// Gets or sets the cost per length.
        /// </summary>
        internal decimal CostPerLength
        {
            get { return costPerLength; }
            set { costPerLength = value; }
        }

        private decimal costVerticalTransport = 0;

        /// <summary>
        /// Gets or sets the cost for vertical transport.
        /// </summary>
        public decimal CostVerticalTransport
        {
            get { return costVerticalTransport; }
            set { costVerticalTransport = value; }
        }

        private decimal costHorizontalTransport = 0;

        /// <summary>
        /// Gets or sets the cost for horizontal transport.
        /// </summary>
        public decimal CostHorizontalTransport
        {
            get { return costHorizontalTransport; }
            set { costHorizontalTransport = value; }
        }

        private decimal costNodeFree = 0;

        /// <summary>
        /// Gets or sets the cost for a free node.
        /// </summary>
        public decimal CostNodeFree
        {
            get { return costNodeFree; }
            set { costNodeFree = value; }
        }

        private decimal costNodeFixed = 0;

        /// <summary>
        /// Gets or sets the cost for a fixed node.
        /// </summary>
        public decimal CostNodeFixed
        {
            get { return costNodeFixed; }
            set { costNodeFixed = value; }
        }

        private decimal costNodePinned = 0;

        /// <summary>
        /// Gets or sets the cost for a pinned node.
        /// </summary>
        public decimal CostNodePinned
        {
            get { return costNodePinned; }
            set { costNodePinned = value; }
        }

        private decimal costNodeRoller = 0;

        /// <summary>
        /// Gets or sets the cost for a roller node.
        /// </summary>
        public decimal CostNodeRoller
        {
            get { return costNodeRoller; }
            set { costNodeRoller = value; }
        }

        private decimal costNodeTrack = 0;

        /// <summary>
        /// Gets or sets the cost for an track node.
        /// </summary>
        public decimal CostNodeTrack
        {
            get { return costNodeTrack; }
            set { costNodeTrack = value; }
        }

        private string sectionProfile = "Solid Rectangle";

        /// <summary>
        /// Gets or sets the section profile.
        /// </summary>
        public string SectionProfile
        {
            get { return sectionProfile; }
            set { sectionProfile = value; }
        }

        private decimal sectionProfileProperty1 = 0m;

        /// <summary>
        /// Gets or sets the section profile property 1.
        /// </summary>
        public decimal SectionProfileProperty1
        {
            get { return sectionProfileProperty1; }
            set { sectionProfileProperty1 = value; }
        }

        private decimal sectionProfileProperty2 = 0m;

        /// <summary>
        /// Gets or sets the section profile property 2.
        /// </summary>
        public decimal SectionProfileProperty2
        {
            get { return sectionProfileProperty2; }
            set { sectionProfileProperty2 = value; }
        }

        private decimal sectionProfileProperty3 = 0m;

        /// <summary>
        /// Gets or sets the section profile property 3.
        /// </summary>
        public decimal SectionProfileProperty3
        {
            get { return sectionProfileProperty3; }
            set { sectionProfileProperty3 = value; }
        }

        private decimal sectionProfileProperty4 = 0m;

        /// <summary>
        /// Gets or sets the section profile property 4.
        /// </summary>
        public decimal SectionProfileProperty4
        {
            get { return sectionProfileProperty4; }
            set { sectionProfileProperty4 = value; }
        }

        private decimal sectionProfileProperty5 = 0m;

        /// <summary>
        /// Gets or sets the section profile property 5.
        /// </summary>
        public decimal SectionProfileProperty5
        {
            get { return sectionProfileProperty5; }
            set { sectionProfileProperty5 = value; }
        }

        private decimal sectionProfileProperty6 = 0m;

        /// <summary>
        /// Gets or sets the section profile property 6.
        /// </summary>
        public decimal SectionProfileProperty6
        {
            get { return sectionProfileProperty6; }
            set { sectionProfileProperty6 = value; }
        }

        private decimal sectionProfileProperty7 = 0m;

        /// <summary>
        /// Gets or sets the section profile property 7.
        /// </summary>
        public decimal SectionProfileProperty7
        {
            get { return sectionProfileProperty7; }
            set { sectionProfileProperty7 = value; }
        }

        private string material = "Default";

        /// <summary>
        /// Gets or sets the material.
        /// </summary>
        public string Material
        {
            get { return material; }
            set { material = value; }
        }

        private float miterLimit;

        /// <summary>
        /// Gets or sets the miter limit.
        /// </summary>
        public float MiterLimit
        {
            get { return miterLimit; }
            set { miterLimit = value; }
        }

        private float dashOffset;

        /// <summary>
        /// Gets or sets the dash offset.
        /// </summary>
        public float DashOffset
        {
            get { return dashOffset; }
            set { dashOffset = value; }
        }

        private CanvasLineJoin lineJoin = CanvasLineJoin.Round;

        /// <summary>
        /// Gets or sets the line join.
        /// </summary>
        public CanvasLineJoin LineJoin
        {
            get { return lineJoin; }
            set { lineJoin = value; }
        }

        private CanvasStrokeStyle lineStyle = new CanvasStrokeStyle();

        /// <summary>
        /// Gets or sets the line style.
        /// </summary>
        [JsonIgnore]
        public CanvasStrokeStyle LineStyle
        {
            get { return lineStyle; }
            set { lineStyle = value; }
        }

        private decimal maintenancePerLength;

        /// <summary>
        /// Gets or sets the maintenance per length.
        /// </summary>
        public decimal MaintenancePerLength
        {
            get { return maintenancePerLength; }
            set { maintenancePerLength = value; }
        }

        private decimal maintenanceNodeFree;

        /// <summary>
        /// Gets or sets the maintenance node free cost.
        /// </summary>
        public decimal MaintenanceNodeFree
        {
            get { return maintenanceNodeFree; }
            set { maintenanceNodeFree = value; }
        }

        private decimal maintenanceFixed;

        /// <summary>
        /// Gets or sets the maintenance node fixed cost.
        /// </summary>
        public decimal MaintenanceFixed
        {
            get { return maintenanceFixed; }
            set { maintenanceFixed = value; }
        }

        private decimal maintenancePinned;

        /// <summary>
        /// Gets or sets the maintenance node pinned cost.
        /// </summary>
        public decimal MaintenancePinned
        {
            get { return maintenancePinned; }
            set { maintenancePinned = value; }
        }

        private decimal maintenanceRoller;

        /// <summary>
        /// Gets or sets the maintenance node roller cost.
        /// </summary>
        public decimal MaintenanceRoller
        {
            get { return maintenanceRoller; }
            set { maintenanceRoller = value; }
        }

        private decimal maintenanceTrack;

        /// <summary>
        /// Gets or sets the maintenance node track cost.
        /// </summary>
        public decimal MaintenanceTrack
        {
            get { return maintenanceTrack; }
            set { maintenanceTrack = value; }
        }

        private decimal factorVerticalTransport;

        /// <summary>
        /// Gets or sets the factor vertical transport.
        /// </summary>
        public decimal FactorVerticalTransport
        {
            get { return factorVerticalTransport; }
            set { factorVerticalTransport = value; }
        }

        private decimal factorHorizontalTransport;

        /// <summary>
        /// Gets or sets the factor horizontal transport.
        /// </summary>
        public decimal FactorHorizontalTransport
        {
            get { return factorHorizontalTransport; }
            set { factorHorizontalTransport = value; }
        }

        private void UpdateCanvasStrokeStyle()
        {
            try
            {
                LineStyle.DashCap = CanvasCapStyle.Round;
                LineStyle.DashOffset = dashOffset;
                LineStyle.DashStyle = line;
                LineStyle.EndCap = CanvasCapStyle.Round;
                LineStyle.LineJoin = lineJoin;
                LineStyle.MiterLimit = miterLimit;
                LineStyle.StartCap = nearCapStyle;
            }
            catch (Exception ex)
            {
                WService.ReportException(ex);
            }
        }

        private void UpdateColor()
        {
            color = Color.FromArgb((byte)alpha, (byte)red, (byte)green, (byte)blue);
        }

        /// <summary>
        /// Disposes the section.
        /// </summary>
        public void Dispose()
        {
            lineStyle.Dispose();
        }
    }
}
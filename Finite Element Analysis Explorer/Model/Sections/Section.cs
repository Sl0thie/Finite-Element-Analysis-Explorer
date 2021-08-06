using Microsoft.Graphics.Canvas.Geometry;
using Windows.UI;

namespace Finite_Element_Analysis_Explorer
{
    internal class Section
    {
        internal Section(
            string name,
            decimal e,
            decimal i,
            decimal area,
            decimal density,
            decimal costPerLength,
            byte alpha,
            byte red,
            byte green,
            byte blue,
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

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private decimal e;

        internal decimal E
        {
            get { return e; }
            set { e = value; }
        }

        private decimal i;

        internal decimal I
        {
            get { return i; }
            set { i = value; }
        }

        private decimal area;

        internal decimal Area
        {
            get { return area; }
            set { area = value; }
        }

        private decimal density;

        internal decimal Density
        {
            get { return density; }
            set { density = value; }
        }

        private byte alpha;

        internal byte Alpha
        {
            get { return alpha; }
            set { alpha = value; }
        }

        private byte red;

        internal byte Red
        {
            get { return red; }
            set { red = value; }
        }

        private byte green;

        internal byte Green
        {
            get { return green; }
            set { green = value; }
        }

        private byte blue;

        internal byte Blue
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

        internal Color Color
        {
            get { return color; }
            set { color = value; }
        }

        private CanvasDashStyle line = CanvasDashStyle.Solid;

        internal CanvasDashStyle Line
        {
            get { return line; }
            set { line = value; }
        }

        private CanvasCapStyle nearCapStyle = CanvasCapStyle.Round;

        internal CanvasCapStyle NearCapStyle
        {
            get { return nearCapStyle; }
            set { nearCapStyle = value; }
        }

        private CanvasCapStyle farCapStyle = CanvasCapStyle.Round;

        internal CanvasCapStyle FarCapStyle
        {
            get { return farCapStyle; }
            set { farCapStyle = value; }
        }

        private float lineWeight = 1.5f;

        internal float LineWeight
        {
            get { return lineWeight; }
            set { lineWeight = value; }
        }

        private decimal costPerLength = 0;

        internal decimal CostPerLength
        {
            get { return costPerLength; }
            set { costPerLength = value; }
        }

        private decimal costVerticalTransport = 0;

        public decimal CostVerticalTransport
        {
            get { return costVerticalTransport; }
            set { costVerticalTransport = value; }
        }

        private decimal costHorizontalTransport = 0;

        public decimal CostHorizontalTransport
        {
            get { return costHorizontalTransport; }
            set { costHorizontalTransport = value; }
        }

        private decimal costNodeFree = 0;

        public decimal CostNodeFree
        {
            get { return costNodeFree; }
            set { costNodeFree = value; }
        }

        private decimal costNodeFixed = 0;

        public decimal CostNodeFixed
        {
            get { return costNodeFixed; }
            set { costNodeFixed = value; }
        }

        private decimal costNodePinned = 0;

        public decimal CostNodePinned
        {
            get { return costNodePinned; }
            set { costNodePinned = value; }
        }

        private decimal costNodeRoller = 0;

        public decimal CostNodeRoller
        {
            get { return costNodeRoller; }
            set { costNodeRoller = value; }
        }

        private decimal costNodeTrack = 0;

        public decimal CostNodeTrack
        {
            get { return costNodeTrack; }
            set { costNodeTrack = value; }
        }

        private string sectionProfile = "Solid Rectangle";

        public string SectionProfile
        {
            get { return sectionProfile; }
            set { sectionProfile = value; }
        }

        private decimal sectionProfileProperty1 = 0m;

        public decimal SectionProfileProperty1
        {
            get { return sectionProfileProperty1; }
            set { sectionProfileProperty1 = value; }
        }

        private decimal sectionProfileProperty2 = 0m;

        public decimal SectionProfileProperty2
        {
            get { return sectionProfileProperty2; }
            set { sectionProfileProperty2 = value; }
        }

        private decimal sectionProfileProperty3 = 0m;

        public decimal SectionProfileProperty3
        {
            get { return sectionProfileProperty3; }
            set { sectionProfileProperty3 = value; }
        }

        private decimal sectionProfileProperty4 = 0m;

        public decimal SectionProfileProperty4
        {
            get { return sectionProfileProperty4; }
            set { sectionProfileProperty4 = value; }
        }

        private decimal sectionProfileProperty5 = 0m;

        public decimal SectionProfileProperty5
        {
            get { return sectionProfileProperty5; }
            set { sectionProfileProperty5 = value; }
        }

        private decimal sectionProfileProperty6 = 0m;

        public decimal SectionProfileProperty6
        {
            get { return sectionProfileProperty6; }
            set { sectionProfileProperty6 = value; }
        }

        private decimal sectionProfileProperty7 = 0m;

        public decimal SectionProfileProperty7
        {
            get { return sectionProfileProperty7; }
            set { sectionProfileProperty7 = value; }
        }

        private string material = "Default";

        public string Material
        {
            get { return material; }
            set { material = value; }
        }

        private float miterLimit;

        public float MiterLimit
        {
            get { return miterLimit; }
            set { miterLimit = value; }
        }

        private float dashOffset;

        public float DashOffset
        {
            get { return dashOffset; }
            set { dashOffset = value; }
        }

        private CanvasLineJoin lineJoin = CanvasLineJoin.Round;

        public CanvasLineJoin LineJoin
        {
            get { return lineJoin; }
            set { lineJoin = value; }
        }

        private CanvasStrokeStyle lineStyle = new CanvasStrokeStyle();

        public CanvasStrokeStyle LineStyle
        {
            get { return lineStyle; }
            set { lineStyle = value; }
        }

        private decimal maintenancePerLength;

        public decimal MaintenancePerLength
        {
            get { return maintenancePerLength; }
            set { maintenancePerLength = value; }
        }

        private decimal maintenanceNodeFree;

        public decimal MaintenanceNodeFree
        {
            get { return maintenanceNodeFree; }
            set { maintenanceNodeFree = value; }
        }

        private decimal maintenanceFixed;

        public decimal MaintenanceFixed
        {
            get { return maintenanceFixed; }
            set { maintenanceFixed = value; }
        }

        private decimal maintenancePinned;

        public decimal MaintenancePinned
        {
            get { return maintenancePinned; }
            set { maintenancePinned = value; }
        }

        private decimal maintenanceRoller;

        public decimal MaintenanceRoller
        {
            get { return maintenanceRoller; }
            set { maintenanceRoller = value; }
        }

        private decimal maintenanceTrack;

        public decimal MaintenanceTrack
        {
            get { return maintenanceTrack; }
            set { maintenanceTrack = value; }
        }

        private decimal factorVerticalTransport;

        public decimal FactorVerticalTransport
        {
            get { return factorVerticalTransport; }
            set { factorVerticalTransport = value; }
        }

        private decimal factorHorizontalTransport;

        public decimal FactorHorizontalTransport
        {
            get { return factorHorizontalTransport; }
            set { factorHorizontalTransport = value; }
        }

        private void UpdateCanvasStrokeStyle()
        {
            LineStyle.DashCap = CanvasCapStyle.Round;
            LineStyle.DashOffset = dashOffset;
            LineStyle.DashStyle = line;
            LineStyle.EndCap = (CanvasCapStyle)FileManager.LocalSettings.Values["LineGridNormalEndCap"];
            LineStyle.LineJoin = lineJoin;
            LineStyle.MiterLimit = miterLimit;
            LineStyle.StartCap = nearCapStyle;
        }

        private void UpdateColor()
        {
            color = Color.FromArgb(alpha, red, green, blue);
        }

        public void Dispose()
        {
            lineStyle.Dispose();
        }
    }
}
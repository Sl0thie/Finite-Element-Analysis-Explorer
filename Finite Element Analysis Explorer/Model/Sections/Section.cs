using Microsoft.Graphics.Canvas.Geometry;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Windows.UI;

namespace Finite_Element_Analysis_Explorer
{
    internal class Section
    {
        internal Section(string _name,
            decimal e,
            decimal i,
            decimal area,
            decimal density,
            decimal _costPerLength,
            byte alpha,
            byte red,
            byte green,
            byte blue,
            CanvasDashStyle linetype,
            float lineWeight,
            CanvasCapStyle nearCapStyle,
            CanvasCapStyle farCapStyle,
            decimal _costVerticalTransport,
            decimal _costHorizontalTransport,
            decimal _costNodeFree,
            decimal _costNodeFixed,
            decimal _costNodePinned,
            decimal _costNodeRoller,
            decimal _costNodeTrack,
            string _sectionProfile,
            decimal _sectionProfileProperty1,
            decimal _sectionProfileProperty2,
            decimal _sectionProfileProperty3,
            decimal _sectionProfileProperty4,
            decimal _sectionProfileProperty5,
            decimal _sectionProfileProperty6,
            decimal _sectionProfileProperty7,
            string _material,
            decimal _MaintenancePerLength,
            decimal _MaintenanceNodeFree,
            decimal _MaintenanceFixed,
            decimal _MaintenancePinned,
            decimal _MaintenanceRoller,
            decimal _MaintenanceTrack,
            decimal _FactorVerticalTransport,
            decimal _FactorHorizontalTransport
            )
        {
            name = _name;
            _e = e;
            _i = i;
            _area = area;
            _density = density;
            costPerLength = _costPerLength;
            _alpha = alpha;
            _red = red;
            _green = green;
            _blue = blue;
            _line = linetype;
            _lineWeight = lineWeight;
            _nearCapStyle = nearCapStyle;
            _farCapStyle = farCapStyle;

            costVerticalTransport = _costVerticalTransport;
            costHorizontalTransport = _costHorizontalTransport;
            costNodeFree = _costNodeFree;
            costNodeFixed = _costNodeFixed;
            costNodePinned = _costNodePinned;
            costNodeRoller = _costNodeRoller;
            costNodeTrack = _costNodeTrack;

            sectionProfile = _sectionProfile;
            sectionProfileProperty1 = _sectionProfileProperty1;
            sectionProfileProperty2 = _sectionProfileProperty2;
            sectionProfileProperty3 = _sectionProfileProperty3;
            sectionProfileProperty4 = _sectionProfileProperty4;
            sectionProfileProperty5 = _sectionProfileProperty5;
            sectionProfileProperty6 = _sectionProfileProperty6;
            sectionProfileProperty7 = _sectionProfileProperty7;
            material = _material;

            maintenancePerLength = _MaintenancePerLength;
            maintenanceNodeFree = _MaintenanceNodeFree;
            maintenanceFixed = _MaintenanceFixed;
            maintenancePinned = _MaintenancePinned;
            maintenanceRoller = _MaintenanceRoller;
            maintenanceTrack = _MaintenanceTrack;
            factorVerticalTransport = _FactorVerticalTransport;
            factorHorizontalTransport = _FactorHorizontalTransport;

            UpdateCanvasStrokeStyle();
            UpdateColor();
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private decimal _e;
        internal decimal E
        {
            get { return _e; }
            set { _e = value; }
        }

        private decimal _i;
        internal decimal I
        {
            get { return _i; }
            set { _i = value; }
        }

        private decimal _area;
        internal decimal Area
        {
            get { return _area; }
            set { _area = value; }
        }

        private decimal _density;
        internal decimal Density
        {
            get { return _density; }
            set { _density = value; }
        }

        private byte _alpha;
        internal byte Alpha
        {
            get { return _alpha; }
            set { _alpha = value; }
        }

        private byte _red;
        internal byte Red
        {
            get { return _red; }
            set { _red = value; }
        }

        private byte _green;
        internal byte Green
        {
            get { return _green; }
            set { _green = value; }
        }

        private byte _blue;
        internal byte Blue
        {
            get { return _blue; }
            set { _blue = value; UpdateColor(); }
        }

        private Color _color;
        internal Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        private CanvasDashStyle _line = CanvasDashStyle.Solid;
        internal CanvasDashStyle Line
        {
            get { return _line; }
            set { _line = value; }
        }

        private CanvasCapStyle _nearCapStyle = CanvasCapStyle.Round;
        internal CanvasCapStyle NearCapStyle
        {
            get { return _nearCapStyle; }
            set { _nearCapStyle = value; }
        }

        private CanvasCapStyle _farCapStyle = CanvasCapStyle.Round;
        internal CanvasCapStyle FarCapStyle
        {
            get { return _farCapStyle; }
            set { _farCapStyle = value; }
        }

        private float _lineWeight = 1.5f;
        internal float LineWeight
        {
            get { return _lineWeight; }
            set { _lineWeight = value; }
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
            LineStyle.DashStyle = _line;
            LineStyle.EndCap = (CanvasCapStyle)FileManager.localSettings.Values["LineGridNormalEndCap"];
            LineStyle.LineJoin = lineJoin;
            LineStyle.MiterLimit = miterLimit;
            LineStyle.StartCap = _nearCapStyle;
        }


        private void UpdateColor()
        {
            _color = Color.FromArgb(_alpha, _red, _green, _blue);
        }

        public void Dispose()
        {
            lineStyle.Dispose();
        }
    }
}
using System.Collections.Generic;
using Microsoft.Graphics.Canvas.Geometry;

namespace Finite_Element_Analysis_Explorer
{
    internal class SectionCollection : Dictionary<string, Section>
    {
        // private KeyValuePair<string, Section> currentKeyPair;

        // public KeyValuePair<string, Section> CurrentKeyPair
        // {
        //    get { return currentKeyPair; }
        //    set { currentKeyPair = value; }
        // }

        // private Section _currentSection = new Section("Default 3", 1, 1, 1, 1, 1, 255, 255, 0, 255, LineType.Solid, 1.5f, CapStyle.Round, CapStyle.Round);
        private Section _currentSection; // = new Section();

        internal Section CurrentSection
        {
            get
            {
                return _currentSection;
            }

            set
            {

                _currentSection = value;

                // if (!object.ReferenceEquals(null, value))
                // {
                //    ////todo: Redundant?
                //    //foreach (var Item in this)
                //    //{
                //    //    Item.Value.Selected = false;
                //    //}
                //    _currentSection = value;
                //    //_currentSection.Selected = true;
                //    //Debug.WriteLine("Setting new Current Section " + value.Name);
                // }
                // else
                // {
                //    _currentSection = value;
                // }
            }
        }

        internal Section LoadLastCurrentSectionSection()
        {
            // Debug.WriteLine("Last Current Section " + Options.LastCurrentSection);
            if (ContainsKey(Options.LastCurrentSectionName))
            {
                try
                {
                    _currentSection = this[Options.LastCurrentSectionName];
                }
                catch
                {
                    if (!ContainsKey("Default"))
                    {
                        AddNewSection("Default", 200000000000m, 0.0001m, 0.001m, 1, 1, 255, 192, 192, 192, CanvasDashStyle.Solid, 1.5f, CanvasCapStyle.Round, CanvasCapStyle.Round, 0, 0, 0, 0, 0, 0, 0, "Rectangle", 0, 0, 0, 0, 0, 0, 0, "Default", 0, 0, 0, 0, 0, 0, 0, 0);
                        _currentSection = this["Default"];
                    }
                    else
                    {
                        _currentSection = this["Default"];
                    }
                }
            }
            else
            {
                AddNewSection("Default", 200000000000m, 0.0001m, 0.001m, 1, 1, 255, 192, 192, 192, CanvasDashStyle.Solid, 1.5f, CanvasCapStyle.Round, CanvasCapStyle.Round, 0, 0, 0, 0, 0, 0, 0, "Rectangle", 0, 0, 0, 0, 0, 0, 0, "Default", 0, 0, 0, 0, 0, 0, 0, 0);
                _currentSection = this["Default"];
            }

            return _currentSection;
        }

        internal void AddNewSection(
            string _name,
            decimal _e,
            decimal _i,
            decimal _area,
            decimal _density,
            decimal _costPerLength,
            byte _alpha,
            byte _red,
            byte _green,
            byte _blue,
            CanvasDashStyle _linetype,
            float _lineweight,
            CanvasCapStyle _nearCapStyle,
            CanvasCapStyle _farCapStyle,
            decimal _CostHorizontalTransport,
            decimal _CostVerticalTransport,
            decimal _CostNodeFixed,
            decimal _CostNodeFree,
            decimal _CostNodePinned,
            decimal _CostNodeRoller,
            decimal _CostNodeTRack,
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
            decimal _FactorHorizontalTransport)
        {
            if (ContainsKey(_name))
            {
                this[_name].Name = _name;
                this[_name].E = _e;
                this[_name].I = _i;
                this[_name].Area = _area;
                this[_name].Density = _density;
                this[_name].CostPerLength = _costPerLength;
                this[_name].Alpha = _alpha;
                this[_name].Red = _red;
                this[_name].Green = _green;
                this[_name].Blue = _blue;
                this[_name].Line = _linetype;
                this[_name].LineWeight = _lineweight;
                this[_name].NearCapStyle = _nearCapStyle;
                this[_name].FarCapStyle = _farCapStyle;
                this[_name].CostHorizontalTransport = _CostHorizontalTransport;
                this[_name].CostVerticalTransport = _CostVerticalTransport;
                this[_name].CostNodeFixed = _CostNodeFixed;
                this[_name].CostNodeFree = _CostNodeFree;
                this[_name].CostNodePinned = _CostNodePinned;
                this[_name].CostNodeRoller = _CostNodeRoller;
                this[_name].CostNodeTrack = _CostNodeTRack;

                this[_name].SectionProfile = _sectionProfile;
                this[_name].SectionProfileProperty1 = _sectionProfileProperty1;
                this[_name].SectionProfileProperty2 = _sectionProfileProperty2;
                this[_name].SectionProfileProperty3 = _sectionProfileProperty3;
                this[_name].SectionProfileProperty4 = _sectionProfileProperty4;
                this[_name].SectionProfileProperty5 = _sectionProfileProperty5;
                this[_name].Material = _material;

                this[_name].MaintenancePerLength = _MaintenancePerLength;
                this[_name].MaintenanceNodeFree = _MaintenanceNodeFree;
                this[_name].MaintenanceFixed = _MaintenanceFixed;
                this[_name].MaintenancePinned = _MaintenancePinned;
                this[_name].MaintenanceRoller = _MaintenanceRoller;
                this[_name].MaintenanceTrack = _MaintenanceTrack;
                this[_name].FactorVerticalTransport = _FactorVerticalTransport;
                this[_name].FactorHorizontalTransport = _FactorHorizontalTransport;
            }
            else
            {
                // Debug.WriteLine("Creating Section " + _lineweight);
                Section newSection = new Section(
                    _name,
                    _e,
                    _i,
                    _area,
                    _density,
                    _costPerLength,
                    _alpha,
                    _red,
                    _green,
                    _blue,
                    _linetype,
                    _lineweight,
                    _nearCapStyle,
                    _farCapStyle,
                    _CostHorizontalTransport,
                    _CostVerticalTransport,
                    _CostNodeFixed,
                    _CostNodeFree,
                    _CostNodePinned,
                    _CostNodeRoller,
                    _CostNodeTRack,
                    _sectionProfile,
                    _sectionProfileProperty1,
                    _sectionProfileProperty2,
                    _sectionProfileProperty3,
                    _sectionProfileProperty4,
                    _sectionProfileProperty5,
                    _sectionProfileProperty6,
                    _sectionProfileProperty7,
                    _material,
                    _MaintenancePerLength,
                    _MaintenanceNodeFree,
                    _MaintenanceFixed,
                    _MaintenancePinned,
                    _MaintenanceRoller,
                    _MaintenanceTrack,
                    _FactorVerticalTransport,
                    _FactorHorizontalTransport);
                Add(_name, newSection);
            }
        }

        internal void Reset()
        {
            this.Clear();
        }
    }
}
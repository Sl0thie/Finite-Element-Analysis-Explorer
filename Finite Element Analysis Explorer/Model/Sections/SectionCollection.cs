namespace Finite_Element_Analysis_Explorer
{
    using Microsoft.Graphics.Canvas.Geometry;
    using System.Collections.Generic;

    /// <summary>
    /// SectionCollection class.
    /// </summary>
    internal class SectionCollection : Dictionary<string, Section>
    {
        private Section currentSection;

        /// <summary>
        /// Gets or sets the current section.
        /// </summary>
        internal Section CurrentSection
        {
            get
            {
                return currentSection;
            }

            set
            {
                currentSection = value;
            }
        }

        /// <summary>
        /// Loads the last current section.
        /// </summary>
        /// <returns>The section last loaded.</returns>
        internal Section LoadLastCurrentSectionSection()
        {
            if (ContainsKey(Options.LastCurrentSectionName))
            {
                try
                {
                    currentSection = this[Options.LastCurrentSectionName];
                }
                catch
                {
                    if (!ContainsKey("Default"))
                    {
                        AddNewSection("Default", 200000000000m, 0.0001m, 0.001m, 1, 1, 255, 192, 192, 192, CanvasDashStyle.Solid, 1.5f, CanvasCapStyle.Round, CanvasCapStyle.Round, 0, 0, 0, 0, 0, 0, 0, "Rectangle", 0, 0, 0, 0, 0, 0, 0, "Default", 0, 0, 0, 0, 0, 0, 0, 0);
                        currentSection = this["Default"];
                    }
                    else
                    {
                        currentSection = this["Default"];
                    }
                }
            }
            else
            {
                AddNewSection("Default", 200000000000m, 0.0001m, 0.001m, 1, 1, 255, 192, 192, 192, CanvasDashStyle.Solid, 1.5f, CanvasCapStyle.Round, CanvasCapStyle.Round, 0, 0, 0, 0, 0, 0, 0, "Rectangle", 0, 0, 0, 0, 0, 0, 0, "Default", 0, 0, 0, 0, 0, 0, 0, 0);
                currentSection = this["Default"];
            }

            return currentSection;
        }

        /// <summary>
        /// Adds a new section.
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
        /// <param name="lineweight">lineWeight.</param>
        /// <param name="nearCapStyle">nearCapStyle.</param>
        /// <param name="farCapStyle">farCapStyle.</param>
        /// <param name="costHorizontalTransport">costHorizontalTransport.</param>
        /// <param name="costVerticalTransport">costVerticalTransport.</param>
        /// <param name="costNodeFixed">costNodeFixed.</param>
        /// <param name="costNodeFree">costNodeFree.</param>
        /// <param name="costNodePinned">costNodePinned.</param>
        /// <param name="costNodeRoller">costNodeRoller.</param>
        /// <param name="costNodeTRack">costNodeTrack.</param>
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
        internal void AddNewSection(
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
            float lineweight,
            CanvasCapStyle nearCapStyle,
            CanvasCapStyle farCapStyle,
            decimal costHorizontalTransport,
            decimal costVerticalTransport,
            decimal costNodeFixed,
            decimal costNodeFree,
            decimal costNodePinned,
            decimal costNodeRoller,
            decimal costNodeTRack,
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
            if (ContainsKey(name))
            {
                this[name].Name = name;
                this[name].E = e;
                this[name].I = i;
                this[name].Area = area;
                this[name].Density = density;
                this[name].CostPerLength = costPerLength;
                this[name].Alpha = alpha;
                this[name].Red = red;
                this[name].Green = green;
                this[name].Blue = blue;
                this[name].Line = linetype;
                this[name].LineWeight = lineweight;
                this[name].NearCapStyle = nearCapStyle;
                this[name].FarCapStyle = farCapStyle;
                this[name].CostHorizontalTransport = costHorizontalTransport;
                this[name].CostVerticalTransport = costVerticalTransport;
                this[name].CostNodeFixed = costNodeFixed;
                this[name].CostNodeFree = costNodeFree;
                this[name].CostNodePinned = costNodePinned;
                this[name].CostNodeRoller = costNodeRoller;
                this[name].CostNodeTrack = costNodeTRack;

                this[name].SectionProfile = sectionProfile;
                this[name].SectionProfileProperty1 = sectionProfileProperty1;
                this[name].SectionProfileProperty2 = sectionProfileProperty2;
                this[name].SectionProfileProperty3 = sectionProfileProperty3;
                this[name].SectionProfileProperty4 = sectionProfileProperty4;
                this[name].SectionProfileProperty5 = sectionProfileProperty5;
                this[name].Material = material;

                this[name].MaintenancePerLength = maintenancePerLength;
                this[name].MaintenanceNodeFree = maintenanceNodeFree;
                this[name].MaintenanceFixed = maintenanceFixed;
                this[name].MaintenancePinned = maintenancePinned;
                this[name].MaintenanceRoller = maintenanceRoller;
                this[name].MaintenanceTrack = maintenanceTrack;
                this[name].FactorVerticalTransport = factorVerticalTransport;
                this[name].FactorHorizontalTransport = factorHorizontalTransport;
            }
            else
            {
                Section newSection = new Section(
                    name,
                    e,
                    i,
                    area,
                    density,
                    costPerLength,
                    alpha,
                    red,
                    green,
                    blue,
                    linetype,
                    lineweight,
                    nearCapStyle,
                    farCapStyle,
                    costHorizontalTransport,
                    costVerticalTransport,
                    costNodeFixed,
                    costNodeFree,
                    costNodePinned,
                    costNodeRoller,
                    costNodeTRack,
                    sectionProfile,
                    sectionProfileProperty1,
                    sectionProfileProperty2,
                    sectionProfileProperty3,
                    sectionProfileProperty4,
                    sectionProfileProperty5,
                    sectionProfileProperty6,
                    sectionProfileProperty7,
                    material,
                    maintenancePerLength,
                    maintenanceNodeFree,
                    maintenanceFixed,
                    maintenancePinned,
                    maintenanceRoller,
                    maintenanceTrack,
                    factorVerticalTransport,
                    factorHorizontalTransport);
                Add(name, newSection);
            }
        }

        /// <summary>
        /// Resets the dictionary.
        /// </summary>
        internal void Reset()
        {
            Clear();
        }
    }
}
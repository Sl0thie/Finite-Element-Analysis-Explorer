namespace Finite_Element_Analysis_Explorer
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class SectionSelection : UserControl
    {

        private bool dataLock = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="SectionSelection"/> class.
        /// </summary>
        public SectionSelection()
        {
            this.InitializeComponent();
            listView_Sections.ItemsSource = Model.Sections;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ShowSection(Model.Members.CurrentMember.Section.Name);
            dataLock = false;
        }

        private void ShowSection(string SectionName)
        {
            if (Model.Sections.ContainsKey(SectionName))
            {
                Section tmpSection = Model.Sections[SectionName];
                textBox_SectionName.Text = tmpSection.Name;
                SingleValue_YoungsModulus.Title = "Young's Modulus (E)";
                SingleValue_YoungsModulus.UnitType = UnitType.Force;
                SingleValue_YoungsModulus.SetTheValue(tmpSection.E);
                SingleValue_MomentOfInertia.Title = "Moment of Inertia (I)";
                SingleValue_MomentOfInertia.UnitType = UnitType.MomentOfInertia;
                SingleValue_MomentOfInertia.SetTheValue(tmpSection.I);
                SingleValue_Area.Title = "Area";
                SingleValue_Area.UnitType = UnitType.Area;
                SingleValue_Area.SetTheValue(tmpSection.Area);
                SingleValue_Density.Title = "Density";
                SingleValue_Density.UnitType = UnitType.Density;
                SingleValue_Density.SetTheValue(tmpSection.Density);
                SingleValue_CostPerMeter.Title = "Cost/Length";
                SingleValue_CostPerMeter.UnitType = UnitType.Money;
                SingleValue_CostPerMeter.SetTheValue(tmpSection.CostPerLength);
                SingleValue_CostVerticalTransport.Title = "Vertical Trnasport";
                SingleValue_CostVerticalTransport.UnitType = UnitType.Money;
                SingleValue_CostVerticalTransport.SetTheValue(tmpSection.CostVerticalTransport);
                SingleValue_CostHorizontalTransport.Title = "Horizontal Transport";
                SingleValue_CostHorizontalTransport.UnitType = UnitType.Money;
                SingleValue_CostHorizontalTransport.SetTheValue(tmpSection.CostHorizontalTransport);
                SingleValue_CostNodeFree.Title = "Free Node Cost";
                SingleValue_CostNodeFree.UnitType = UnitType.Money;
                SingleValue_CostNodeFree.SetTheValue(tmpSection.CostNodeFree);
                SingleValue_CostNodeFixed.Title = "Fixed Node Cost";
                SingleValue_CostNodeFixed.UnitType = UnitType.Money;
                SingleValue_CostNodeFixed.SetTheValue(tmpSection.CostNodeFixed);
                SingleValue_CostNodePinned.Title = "Pinned Node Cost";
                SingleValue_CostNodePinned.UnitType = UnitType.Money;
                SingleValue_CostNodePinned.SetTheValue(tmpSection.CostNodePinned);
                SingleValue_CostNodeRoller.Title = "Roller Node Cost";
                SingleValue_CostNodeRoller.UnitType = UnitType.Money;
                SingleValue_CostNodeRoller.SetTheValue(tmpSection.CostNodeRoller);
                SingleValue_CostNodeTrack.Title = "Track Node Cost";
                SingleValue_CostNodeTrack.UnitType = UnitType.Money;
                SingleValue_CostNodeTrack.SetTheValue(tmpSection.CostNodeTrack);
                SingleValue_ColorAlpha.Title = "Alpha";
                SingleValue_ColorAlpha.UnitType = UnitType.Unitless;
                SingleValue_ColorAlpha.SetTheValue(tmpSection.Alpha);
                SingleValue_ColorRed.Title = "Red";
                SingleValue_ColorRed.UnitType = UnitType.Unitless;
                SingleValue_ColorRed.SetTheValue(tmpSection.Red);
                SingleValue_ColorGreen.Title = "Green";
                SingleValue_ColorGreen.UnitType = UnitType.Unitless;
                SingleValue_ColorGreen.SetTheValue(tmpSection.Green);
                SingleValue_ColorBlue.Title = "Blue";
                SingleValue_ColorBlue.UnitType = UnitType.Unitless;
                SingleValue_ColorBlue.SetTheValue(tmpSection.Blue);
                SingleValue_LineWeight.Title = "Line Width";
                SingleValue_LineWeight.UnitType = UnitType.Unitless;
                SingleValue_LineWeight.SetTheValue((decimal)tmpSection.LineWeight);
                rectangle_Color.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(tmpSection.Alpha, tmpSection.Red, tmpSection.Green, tmpSection.Blue));
                comboBox_LineStyle.SelectedItem = tmpSection.Line;
                ComboBox_FarCapStyle.SelectedValue = tmpSection.FarCapStyle;
                comboBox_NearCapStyle.SelectedValue = tmpSection.NearCapStyle;
            }
        }

        private void ListView_Sections_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listView_Sections.SelectedItem is object)
            {
                KeyValuePair<string, Section> kvp = (KeyValuePair<string, Section>)listView_Sections.SelectedItem;
                if (!string.IsNullOrEmpty(kvp.Key.Trim()))
                {
                    Model.Members.CurrentMember.Section = Model.Sections[kvp.Key.Trim()];
                    Model.Sections.CurrentSection = Model.Sections[kvp.Key.Trim()];

                    ShowSection(kvp.Key.Trim());
                    Model.UpdatePanelPage();
                }
            }
        }

        private void TextBox_SectionName_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            //if (e.Key.ToString() == "Enter")
            //{
            //    Debug.WriteLine("textBox_SectionName_KeyDown Enter : " + textBox_SectionName.Text);
            //    if (!Model.Sections.ContainsKey(textBox_SectionName.Text))
            //    {
            //        Model.Sections.AddNewSection(textBox_SectionName.Text,
            //            SingleValue_YoungsModulus.NewValue,
            //            SingleValue_MomentOfInertia.NewValue,
            //            SingleValue_Area.NewValue,
            //            SingleValue_Density.NewValue,
            //            SingleValue_CostPerMeter.NewValue,
            //            (byte)SingleValue_ColorAlpha.NewValue,
            //            (byte)SingleValue_ColorRed.NewValue,
            //            (byte)SingleValue_ColorGreen.NewValue,
            //            (byte)SingleValue_ColorBlue.NewValue,
            //            (LineType)0,
            //            (float)SingleValue_LineWeight.NewValue,
            //            (CapStyle)0,
            //            (CapStyle)0,
            //            SingleValue_CostHorizontalTransport.NewValue,
            //            SingleValue_CostVerticalTransport.NewValue,
            //            SingleValue_CostNodeFixed.NewValue,
            //            SingleValue_CostNodeFree.NewValue,
            //            SingleValue_CostNodePinned.NewValue,
            //            SingleValue_CostNodeRoller.NewValue,
            //            SingleValue_CostNodeTrack.NewValue


            //            );

            //        listView_Sections.ItemsSource = null;
            //        listView_Sections.ItemsSource = Model.Sections;

            //    }
            //}
        }

        private void UpdateCurrentSection()
        {
            if (!string.IsNullOrEmpty(textBox_SectionName.Text.Trim())) 
            {
                return;
            }

            if (!dataLock)
            {
                if (Model.Sections.ContainsKey(textBox_SectionName.Text.Trim()))
                {
                    Section tmpSection = Model.Sections[textBox_SectionName.Text.Trim()];
                    Model.Sections.CurrentSection = tmpSection;
                    tmpSection.Alpha = (byte)SingleValue_ColorAlpha.NewValue;
                    tmpSection.Area = SingleValue_Area.NewValue;
                    tmpSection.Blue = (byte)SingleValue_ColorBlue.NewValue;
                    tmpSection.CostHorizontalTransport = SingleValue_CostHorizontalTransport.NewValue;
                    tmpSection.CostNodeFixed = SingleValue_CostNodeFixed.NewValue;
                    tmpSection.CostNodeFree = SingleValue_CostNodeFree.NewValue;
                    tmpSection.CostNodePinned = SingleValue_CostNodePinned.NewValue;
                    tmpSection.CostNodeRoller = SingleValue_CostNodeRoller.NewValue;
                    tmpSection.CostNodeTrack = SingleValue_CostNodeTrack.NewValue;
                    tmpSection.CostPerLength = SingleValue_CostPerMeter.NewValue;
                    tmpSection.CostVerticalTransport = SingleValue_CostVerticalTransport.NewValue;
                    tmpSection.Density = SingleValue_Density.NewValue;
                    tmpSection.E = SingleValue_YoungsModulus.NewValue;
                    tmpSection.Green = (byte)SingleValue_ColorGreen.NewValue;
                    tmpSection.I = SingleValue_MomentOfInertia.NewValue;
                    tmpSection.LineWeight = (float)SingleValue_LineWeight.NewValue;
                    tmpSection.Name = (string)textBox_SectionName.Text;
                    tmpSection.Red = (byte)SingleValue_ColorRed.NewValue;

                    ShowSection(textBox_SectionName.Text.Trim());
                }
            }
        }

        #region Update Events

        private void SingleValue_YoungsModulus_ValueChanged(object sender, EventArgs e)
        {
            UpdateCurrentSection();
        }

        private void SingleValue_MomentOfInertia_ValueChanged(object sender, EventArgs e)
        {
            UpdateCurrentSection();
        }

        private void SingleValue_Area_ValueChanged(object sender, EventArgs e)
        {
            UpdateCurrentSection();
        }

        private void SingleValue_Density_ValueChanged(object sender, EventArgs e)
        {
            UpdateCurrentSection();
        }

        private void SingleValue_CostPerMeter_ValueChanged(object sender, EventArgs e)
        {
            UpdateCurrentSection();
        }

        private void SingleValue_CostVerticalTransport_ValueChanged(object sender, EventArgs e)
        {
            UpdateCurrentSection();
        }

        private void SingleValue_CostHorizontalTransport_ValueChanged(object sender, EventArgs e)
        {
            UpdateCurrentSection();
        }

        private void SingleValue_CostNodeFree_ValueChanged(object sender, EventArgs e)
        {
            UpdateCurrentSection();
        }

        private void SingleValue_CostNodeFixed_ValueChanged(object sender, EventArgs e)
        {
            UpdateCurrentSection();
        }

        private void SingleValue_CostNodePinned_ValueChanged(object sender, EventArgs e)
        {
            UpdateCurrentSection();
        }

        private void SingleValue_CostNodeRoller_ValueChanged(object sender, EventArgs e)
        {
            UpdateCurrentSection();
        }

        private void SingleValue_CostNodeTrack_ValueChanged(object sender, EventArgs e)
        {
            UpdateCurrentSection();
        }

        private void SingleValue_ColorAlpha_ValueChanged(object sender, EventArgs e)
        {
            UpdateCurrentSection();
        }

        private void SingleValue_ColorRed_ValueChanged(object sender, EventArgs e)
        {
            UpdateCurrentSection();
        }

        private void SingleValue_ColorGreen_ValueChanged(object sender, EventArgs e)
        {
            UpdateCurrentSection();
        }

        private void SingleValue_ColorBlue_ValueChanged(object sender, EventArgs e)
        {
            UpdateCurrentSection();
        }

        private void ComboBox_LineStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCurrentSection();
        }

        private void SingleValue_LineWeight_ValueChanged(object sender, EventArgs e)
        {
            UpdateCurrentSection();
        }

        #endregion
    }
}

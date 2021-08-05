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

namespace Finite_Element_Analysis_Explorer
{
    public sealed partial class SectionSelection : UserControl
    {

        private bool dataLock = true;

        public SectionSelection()
        {
            this.InitializeComponent();
            listView_Sections.ItemsSource = Model.Sections;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Debug.WriteLine("UserControl_Loaded " + Model.Members.CurrentMember.Section.Name);
            ShowSection(Model.Members.CurrentMember.Section.Name);
            dataLock = false;
        }

        private void ShowSection(string SectionName)
        {
            //Debug.WriteLine("ShowSection " + SectionName);

            if (Model.Sections.ContainsKey(SectionName))
            {
                Section tmpSection = Model.Sections[SectionName];


                textBox_SectionName.Text = tmpSection.Name;


                singleValue_YoungsModulus.Title = "Young's Modulus (E)";
                singleValue_YoungsModulus.UnitType = UnitType.Force;
                singleValue_YoungsModulus.SetTheValue(tmpSection.E);
                singleValue_MomentOfInertia.Title = "Moment of Inertia (I)";
                singleValue_MomentOfInertia.UnitType = UnitType.MomentOfInertia;
                singleValue_MomentOfInertia.SetTheValue(tmpSection.I);
                singleValue_Area.Title = "Area";
                singleValue_Area.UnitType = UnitType.Area;
                singleValue_Area.SetTheValue(tmpSection.Area);
                singleValue_Density.Title = "Density";
                singleValue_Density.UnitType = UnitType.Density;
                singleValue_Density.SetTheValue(tmpSection.Density);

                singleValue_CostPerMeter.Title = "Cost/Length";
                singleValue_CostPerMeter.UnitType = UnitType.Money;
                singleValue_CostPerMeter.SetTheValue(tmpSection.CostPerLength);
                singleValue_CostVerticalTransport.Title = "Vertical Trnasport";
                singleValue_CostVerticalTransport.UnitType = UnitType.Money;
                singleValue_CostVerticalTransport.SetTheValue(tmpSection.CostVerticalTransport);
                singleValue_CostHorizontalTransport.Title = "Horizontal Transport";
                singleValue_CostHorizontalTransport.UnitType = UnitType.Money;
                singleValue_CostHorizontalTransport.SetTheValue(tmpSection.CostHorizontalTransport);
                singleValue_CostNodeFree.Title = "Free Node Cost";
                singleValue_CostNodeFree.UnitType = UnitType.Money;
                singleValue_CostNodeFree.SetTheValue(tmpSection.CostNodeFree);
                singleValue_CostNodeFixed.Title = "Fixed Node Cost";
                singleValue_CostNodeFixed.UnitType = UnitType.Money;
                singleValue_CostNodeFixed.SetTheValue(tmpSection.CostNodeFixed);
                singleValue_CostNodePinned.Title = "Pinned Node Cost";
                singleValue_CostNodePinned.UnitType = UnitType.Money;
                singleValue_CostNodePinned.SetTheValue(tmpSection.CostNodePinned);
                singleValue_CostNodeRoller.Title = "Roller Node Cost";
                singleValue_CostNodeRoller.UnitType = UnitType.Money;
                singleValue_CostNodeRoller.SetTheValue(tmpSection.CostNodeRoller);
                singleValue_CostNodeTrack.Title = "Track Node Cost";
                singleValue_CostNodeTrack.UnitType = UnitType.Money;
                singleValue_CostNodeTrack.SetTheValue(tmpSection.CostNodeTrack);


                singleValue_ColorAlpha.Title = "Alpha";
                singleValue_ColorAlpha.UnitType = UnitType.Unitless;
                singleValue_ColorAlpha.SetTheValue(tmpSection.Alpha);
                singleValue_ColorRed.Title = "Red";
                singleValue_ColorRed.UnitType = UnitType.Unitless;
                singleValue_ColorRed.SetTheValue(tmpSection.Red);
                singleValue_ColorGreen.Title = "Green";
                singleValue_ColorGreen.UnitType = UnitType.Unitless;
                singleValue_ColorGreen.SetTheValue(tmpSection.Green);
                singleValue_ColorBlue.Title = "Blue";
                singleValue_ColorBlue.UnitType = UnitType.Unitless;
                singleValue_ColorBlue.SetTheValue(tmpSection.Blue);




                singleValue_LineWeight.Title = "Line Width";
                singleValue_LineWeight.UnitType = UnitType.Unitless;
                //Debug.WriteLine("Line Width " + tmpSection.LineWeight);
                singleValue_LineWeight.SetTheValue((decimal)tmpSection.LineWeight);

                //singleValue_LineWeight.Title = "Line Weight";
                //singleValue_LineWeight.UnitType = UnitType.Unitless;
                //singleValue_LineWeight.SetValue((decimal)tmpSection.LineWeight);



                rectangle_Color.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(tmpSection.Alpha, tmpSection.Red, tmpSection.Green, tmpSection.Blue));

                comboBox_LineStyle.SelectedItem = tmpSection.Line;
                comboBox_FarCapStyle.SelectedValue = tmpSection.FarCapStyle;
                comboBox_NearCapStyle.SelectedValue = tmpSection.NearCapStyle;



            }
        }

        private void ListView_Sections_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Debug.WriteLine("listView_Sections_SelectionChanged : " + listView_Sections.SelectedItem);

            if (listView_Sections.SelectedItem is object)
            {
                KeyValuePair<string, Section> kvp = (KeyValuePair<string, Section>)listView_Sections.SelectedItem;
                if (!string.IsNullOrEmpty(kvp.Key.Trim()))
                {
                    Model.Members.CurrentMember.Section = Model.Sections[kvp.Key.Trim()];
                    Model.Sections.CurrentSection = Model.Sections[kvp.Key.Trim()];

                    ShowSection(kvp.Key.Trim());
                    Model.UpdatePanelPage();

                    //Debug.WriteLine("Listview Change Fired " + kvp.Key.Trim());

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
            //            singleValue_YoungsModulus.NewValue,
            //            singleValue_MomentOfInertia.NewValue,
            //            singleValue_Area.NewValue,
            //            singleValue_Density.NewValue,
            //            singleValue_CostPerMeter.NewValue,
            //            (byte)singleValue_ColorAlpha.NewValue,
            //            (byte)singleValue_ColorRed.NewValue,
            //            (byte)singleValue_ColorGreen.NewValue,
            //            (byte)singleValue_ColorBlue.NewValue,
            //            (LineType)0,
            //            (float)singleValue_LineWeight.NewValue,
            //            (CapStyle)0,
            //            (CapStyle)0,
            //            singleValue_CostHorizontalTransport.NewValue,
            //            singleValue_CostVerticalTransport.NewValue,
            //            singleValue_CostNodeFixed.NewValue,
            //            singleValue_CostNodeFree.NewValue,
            //            singleValue_CostNodePinned.NewValue,
            //            singleValue_CostNodeRoller.NewValue,
            //            singleValue_CostNodeTrack.NewValue


            //            );

            //        listView_Sections.ItemsSource = null;
            //        listView_Sections.ItemsSource = Model.Sections;

            //    }
            //}
        }

        private void UpdateCurrentSection()
        {
            //Debug.WriteLine("UpdateCurrentSection : " + textBox_SectionName.Text);

            if (!string.IsNullOrEmpty(textBox_SectionName.Text.Trim())) { return; }

            if (!dataLock)
            {
                if (Model.Sections.ContainsKey(textBox_SectionName.Text.Trim()))
                {
                    Section tmpSection = Model.Sections[textBox_SectionName.Text.Trim()];


                    //Debug.WriteLine("singleValue_ColorAlpha.NewValue " + singleValue_ColorAlpha.NewValue);
                    //Debug.WriteLine("singleValue_Area.NewValue " + singleValue_Area.NewValue);
                    //Debug.WriteLine("singleValue_ColorBlue.NewValue " + singleValue_ColorBlue.NewValue);
                    //Debug.WriteLine("singleValue_CostHorizontalTransport.NewValue " + singleValue_CostHorizontalTransport.NewValue);
                    //Debug.WriteLine("singleValue_CostNodeFixed.NewValue " + singleValue_CostNodeFixed.NewValue);
                    //Debug.WriteLine("singleValue_CostNodeFree.NewValue " + singleValue_CostNodeFree.NewValue);
                    //Debug.WriteLine("singleValue_CostNodePinned.NewValue " + singleValue_CostNodePinned.NewValue);
                    //Debug.WriteLine("singleValue_CostNodeRoller.NewValue " + singleValue_CostNodeRoller.NewValue);
                    //Debug.WriteLine("singleValue_CostNodeTrack.NewValue " + singleValue_CostNodeTrack.NewValue);
                    //Debug.WriteLine("singleValue_CostPerMeter.NewValue " + singleValue_CostPerMeter.NewValue);
                    //Debug.WriteLine("singleValue_CostVerticalTransport.NewValue " + singleValue_CostVerticalTransport.NewValue);

                    //Debug.WriteLine("singleValue_Density.NewValue" + singleValue_Density.NewValue);
                    //Debug.WriteLine("singleValue_YoungsModulus.NewValue " + singleValue_YoungsModulus.NewValue);
                    //Debug.WriteLine("singleValue_ColorGreen.NewValue " + singleValue_ColorGreen.NewValue);
                    //Debug.WriteLine("singleValue_MomentOfInertia.NewValue " + singleValue_MomentOfInertia.NewValue);
                    //Debug.WriteLine("singleValue_LineWeight.NewValue " + singleValue_LineWeight.NewValue);
                    //Debug.WriteLine("textBox_SectionName.Text " + textBox_SectionName.Text);
                    //Debug.WriteLine("singleValue_ColorRed.NewValue " + singleValue_ColorRed.NewValue);


                    Model.Sections.CurrentSection = tmpSection;
                    tmpSection.Alpha = (byte)singleValue_ColorAlpha.NewValue;
                    tmpSection.Area = singleValue_Area.NewValue;
                    tmpSection.Blue = (byte)singleValue_ColorBlue.NewValue;
                    tmpSection.CostHorizontalTransport = singleValue_CostHorizontalTransport.NewValue;
                    tmpSection.CostNodeFixed = singleValue_CostNodeFixed.NewValue;
                    tmpSection.CostNodeFree = singleValue_CostNodeFree.NewValue;
                    tmpSection.CostNodePinned = singleValue_CostNodePinned.NewValue;
                    tmpSection.CostNodeRoller = singleValue_CostNodeRoller.NewValue;
                    tmpSection.CostNodeTrack = singleValue_CostNodeTrack.NewValue;
                    tmpSection.CostPerLength = singleValue_CostPerMeter.NewValue;
                    tmpSection.CostVerticalTransport = singleValue_CostVerticalTransport.NewValue;
                    tmpSection.Density = singleValue_Density.NewValue;
                    tmpSection.E = singleValue_YoungsModulus.NewValue;
                    //tmpSection.FarCapStyle = (CapStyle)comboBox_FarCapStyle.SelectedValue;
                    tmpSection.Green = (byte)singleValue_ColorGreen.NewValue;
                    tmpSection.I = singleValue_MomentOfInertia.NewValue;
                    //tmpSection.Line = (LineType)comboBox_LineStyle.SelectedValue;
                    tmpSection.LineWeight = (float)singleValue_LineWeight.NewValue;
                    tmpSection.Name = (string)textBox_SectionName.Text;
                    //tmpSection.NearCapStyle = (CapStyle)comboBox_NearCapStyle.SelectedValue;
                    tmpSection.Red = (byte)singleValue_ColorRed.NewValue;

                    ShowSection(textBox_SectionName.Text.Trim());




                }







                //if(textBox_SectionName.Text.Trim() == "") { return; }
                //if (!dataLock)
                //{
                //    if (!object.ReferenceEquals(null, Model.Members.CurrentMember.Section))
                //    {
                //        Debug.WriteLine("UpdateCurrentSection : Updating " + textBox_SectionName.Text);

                //        Model.Sections.CurrentSection = Model.Members.CurrentMember.Section;
                //        Model.Members.CurrentMember.Section.Alpha = (byte)singleValue_ColorAlpha.NewValue;
                //        Model.Members.CurrentMember.Section.Area = singleValue_Area.NewValue;
                //        Model.Members.CurrentMember.Section.Blue = (byte)singleValue_ColorBlue.NewValue;
                //        Model.Members.CurrentMember.Section.CostHorizontalTransport = singleValue_CostHorizontalTransport.NewValue;
                //        Model.Members.CurrentMember.Section.CostNodeFixed = singleValue_CostNodeFixed.NewValue;
                //        Model.Members.CurrentMember.Section.CostNodeFree = singleValue_CostNodeFree.NewValue;
                //        Model.Members.CurrentMember.Section.CostNodePinned = singleValue_CostNodePinned.NewValue;
                //        Model.Members.CurrentMember.Section.CostNodeRoller = singleValue_CostNodeRoller.NewValue;
                //        Model.Members.CurrentMember.Section.CostNodeTRack = singleValue_CostNodeTrack.NewValue;
                //        Model.Members.CurrentMember.Section.CostPerLength = singleValue_CostPerMeter.NewValue;
                //        Model.Members.CurrentMember.Section.CostVerticalTransport = singleValue_CostVerticalTransport.NewValue;
                //        Model.Members.CurrentMember.Section.Density = singleValue_Density.NewValue;
                //        Model.Members.CurrentMember.Section.E = singleValue_YoungsModulus.NewValue;
                //        //Model.Members.CurrentMember.Section.FarCapStyle = (CapStyle)comboBox_FarCapStyle.SelectedValue;
                //        Model.Members.CurrentMember.Section.Green = (byte)singleValue_ColorGreen.NewValue;
                //        Model.Members.CurrentMember.Section.I = singleValue_MomentOfInertia.NewValue;
                //        //Model.Members.CurrentMember.Section.Line = (LineType)comboBox_LineStyle.SelectedValue;
                //        Model.Members.CurrentMember.Section.LineWeight = (float)singleValue_LineWeight.NewValue;
                //        Model.Members.CurrentMember.Section.Name = (string)textBox_SectionName.Text;
                //        //Model.Members.CurrentMember.Section.NearCapStyle = (CapStyle)comboBox_NearCapStyle.SelectedValue;
                //        Model.Members.CurrentMember.Section.Red = (byte)singleValue_ColorRed.NewValue;

                //        ShowSection(textBox_SectionName.Text);
                //    }
                //}
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

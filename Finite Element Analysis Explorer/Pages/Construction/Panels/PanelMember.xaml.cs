using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Finite_Element_Analysis_Explorer
{
    /// <summary>
    /// PanelMember page.
    /// </summary>
    public sealed partial class PanelMember : Page
    {
        /// <summary>
        /// Gets or sets the current panel member page.
        /// </summary>
        internal static PanelMember Current { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PanelMember"/> class.
        /// </summary>
        public PanelMember()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Current = this;

            if (Model.Members.CurrentMember is object)
            {
                TextBlock_Title.Text = "MEMBER " + Model.Members.CurrentMember.Index;

                doubleValue_LocationX.UnitType = UnitType.Length;
                doubleValue_LocationX.DisplayOnly = true;
                doubleValue_LocationX.Axis = 1;
                doubleValue_LocationX.SetValue(Model.Members.CurrentMember.NodeNear.Position.X, Model.Members.CurrentMember.NodeFar.Position.X);

                doubleValue_LocationY.UnitType = UnitType.Length;
                doubleValue_LocationY.DisplayOnly = true;
                doubleValue_LocationY.Axis = 2;
                doubleValue_LocationY.SetValue(Model.Members.CurrentMember.NodeNear.Position.Y, Model.Members.CurrentMember.NodeFar.Position.Y);

                doubleValue_LoadsX.UnitType = UnitType.Force;
                doubleValue_LoadsX.DisplayOnly = false;
                doubleValue_LoadsX.Axis = 1;
                doubleValue_LoadsX.SetValue(Model.Members.CurrentMember.NodeNear.Load.X, Model.Members.CurrentMember.NodeFar.Load.X);

                doubleValue_LoadsY.UnitType = UnitType.Force;
                doubleValue_LoadsY.DisplayOnly = false;
                doubleValue_LoadsY.Axis = 2;
                doubleValue_LoadsY.SetValue(Model.Members.CurrentMember.NodeNear.Load.Y, Model.Members.CurrentMember.NodeFar.Load.Y);

                doubleValue_LoadsM.UnitType = UnitType.Moment;
                doubleValue_LoadsM.DisplayOnly = false;
                doubleValue_LoadsM.Axis = 3;
                doubleValue_LoadsM.SetValue(-Model.Members.CurrentMember.NodeNear.Load.M, Model.Members.CurrentMember.NodeFar.Load.M);

                doubleValue_Linear.UnitType = UnitType.ForcePerLength;
                doubleValue_Linear.DisplayOnly = false;
                doubleValue_Linear.Axis = 4;
                doubleValue_Linear.SetValue(Model.Members.CurrentMember.LDLNear, Model.Members.CurrentMember.LDLFar);

                SingleValue_NoOfSegments.Title = "Number of Segments";
                SingleValue_NoOfSegments.UnitType = UnitType.Unitless;
                SingleValue_NoOfSegments.SetTheValue(Model.Members.CurrentMember.TotalSegments);

                valueDisplay_Length.Title = "Length";
                valueDisplay_Length.DisplayOnly = true;
                valueDisplay_Length.UnitType = UnitType.Length;
                valueDisplay_Length.SetTheValue(Model.Members.CurrentMember.Length);

                valueDisplay_LengthX.Title = "Length (X axis)";
                valueDisplay_LengthX.DisplayOnly = true;
                valueDisplay_LengthX.UnitType = UnitType.Length;
                valueDisplay_LengthX.SetTheValue(Model.Members.CurrentMember.LengthXAxis);

                valueDisplay_LengthY.Title = "Length (Y axis)";
                valueDisplay_LengthY.DisplayOnly = true;
                valueDisplay_LengthY.UnitType = UnitType.Length;
                valueDisplay_LengthY.SetTheValue(Model.Members.CurrentMember.LengthYAxis);

                valueDisplay_Angle.Title = "Angle";
                valueDisplay_Angle.DisplayOnly = true;
                valueDisplay_Angle.UnitType = UnitType.Angle;
                valueDisplay_Angle.SetTheValue(Model.Members.CurrentMember.Angle);

                TextBlock_TitleSectionName.Text = Model.Members.CurrentMember.Section.Name;
                TextBlock_TitleMaterialName.Text = Model.Members.CurrentMember.Section.Material;
                TextBlock_TitleProfileName.Text = Model.Members.CurrentMember.Section.SectionProfile;

                valueDisplay_Area.Title = "Section Area";
                valueDisplay_Area.DisplayOnly = true;
                valueDisplay_Area.UnitType = UnitType.Area;
                valueDisplay_Area.SetTheValue(Model.Members.CurrentMember.Section.Area);

                valueDisplay_Density.Title = "Density";
                valueDisplay_Density.DisplayOnly = true;
                valueDisplay_Density.UnitType = UnitType.Density;
                valueDisplay_Density.SetTheValue(Model.Members.CurrentMember.Section.Density);

                valueDisplay_Volume.Title = "Volume";
                valueDisplay_Volume.DisplayOnly = true;
                valueDisplay_Volume.UnitType = UnitType.Volume;
                valueDisplay_Volume.SetTheValue(Model.Members.CurrentMember.Length * Model.Members.CurrentMember.Section.Area);

                valueDisplay_Mass.Title = "Mass";
                valueDisplay_Mass.DisplayOnly = true;
                valueDisplay_Mass.UnitType = UnitType.Mass;
                valueDisplay_Mass.SetTheValue(Model.Members.CurrentMember.Length * Model.Members.CurrentMember.Section.Area * Model.Members.CurrentMember.Section.Density);

                valueDisplay_YoungsModulus.Title = "Elastic Modulus (E)";
                valueDisplay_YoungsModulus.DisplayOnly = true;
                valueDisplay_YoungsModulus.UnitType = UnitType.Pressure;
                valueDisplay_YoungsModulus.SetTheValue(Model.Members.CurrentMember.Section.E);

                valueDisplay_MomentOfInertia.Title = "Moment of Inertia (I)";
                valueDisplay_MomentOfInertia.DisplayOnly = true;
                valueDisplay_MomentOfInertia.UnitType = UnitType.MomentOfInertia;
                valueDisplay_MomentOfInertia.SetTheValue(Model.Members.CurrentMember.Section.I);

                valueDisplay_CostPerLength.Title = "Construction Cost";
                valueDisplay_CostPerLength.DisplayOnly = true;
                valueDisplay_CostPerLength.UnitType = UnitType.Money;
                valueDisplay_CostPerLength.SetTheValue(Model.Members.CurrentMember.MemberCost);
            }
        }

        /// <summary>
        /// Hides the section list.
        /// </summary>
        public void HideSectionList()
        {
            flyOut_SelectSection.Hide();
            Construction.Current.ShowMember();
        }

        private void Button_DeleteMember_Click(object sender, RoutedEventArgs e)
        {
            Model.Members.RemoveMember(Model.Members.CurrentMember.Index);

            // CurrentSelectionState = SelectionState.Ready;
            Model.Members.CurrentMember = null;
            Construction.Current.ShowModel();
        }

        private void DoubleValue_LoadsX_NearValueChanged(object sender, EventArgs e)
        {
            Model.Members.CurrentMember.NodeNear.Load = new Finite_Element_Analysis_Explorer.NodalLoad(doubleValue_LoadsX.NearValue, Model.Members.CurrentMember.NodeNear.Load.Y, Model.Members.CurrentMember.NodeNear.Load.M);
            doubleValue_LoadsX.SetValue(doubleValue_LoadsX.NearValue, doubleValue_LoadsX.FarValue);
        }

        private void DoubleValue_LoadsX_FarValueChanged(object sender, EventArgs e)
        {
            Model.Members.CurrentMember.NodeFar.Load = new Finite_Element_Analysis_Explorer.NodalLoad(doubleValue_LoadsX.FarValue, Model.Members.CurrentMember.NodeFar.Load.Y, Model.Members.CurrentMember.NodeFar.Load.M);
            doubleValue_LoadsX.SetValue(doubleValue_LoadsX.NearValue, doubleValue_LoadsX.FarValue);
        }

        private void DoubleValue_LoadsX_ValueChanged(object sender, EventArgs e)
        {
            Model.Members.CurrentMember.NodeNear.Load = new Finite_Element_Analysis_Explorer.NodalLoad(doubleValue_LoadsX.NearValue, Model.Members.CurrentMember.NodeNear.Load.Y, Model.Members.CurrentMember.NodeNear.Load.M);
            doubleValue_LoadsX.SetValue(doubleValue_LoadsX.NearValue, doubleValue_LoadsX.FarValue);
            Model.Members.CurrentMember.NodeFar.Load = new Finite_Element_Analysis_Explorer.NodalLoad(doubleValue_LoadsX.FarValue, Model.Members.CurrentMember.NodeFar.Load.Y, Model.Members.CurrentMember.NodeFar.Load.M);
            doubleValue_LoadsX.SetValue(doubleValue_LoadsX.NearValue, doubleValue_LoadsX.FarValue);
        }

        private void DoubleValue_LoadsY_NearValueChanged(object sender, EventArgs e)
        {
            Model.Members.CurrentMember.NodeNear.Load = new Finite_Element_Analysis_Explorer.NodalLoad(Model.Members.CurrentMember.NodeNear.Load.X, doubleValue_LoadsY.NearValue, Model.Members.CurrentMember.NodeNear.Load.M);
            doubleValue_LoadsY.SetValue(doubleValue_LoadsY.NearValue, doubleValue_LoadsY.FarValue);
        }

        private void DoubleValue_LoadsY_FarValueChanged(object sender, EventArgs e)
        {
            Model.Members.CurrentMember.NodeFar.Load = new Finite_Element_Analysis_Explorer.NodalLoad(Model.Members.CurrentMember.NodeFar.Load.X, doubleValue_LoadsY.FarValue, Model.Members.CurrentMember.NodeFar.Load.M);
            doubleValue_LoadsY.SetValue(doubleValue_LoadsY.NearValue, doubleValue_LoadsY.FarValue);
        }

        private void DoubleValue_LoadsY_ValueChanged(object sender, EventArgs e)
        {
            Model.Members.CurrentMember.NodeNear.Load = new Finite_Element_Analysis_Explorer.NodalLoad(Model.Members.CurrentMember.NodeNear.Load.X, doubleValue_LoadsY.NearValue, Model.Members.CurrentMember.NodeNear.Load.M);
            doubleValue_LoadsY.SetValue(doubleValue_LoadsY.NearValue, doubleValue_LoadsY.FarValue);
            Model.Members.CurrentMember.NodeFar.Load = new Finite_Element_Analysis_Explorer.NodalLoad(Model.Members.CurrentMember.NodeFar.Load.X, doubleValue_LoadsY.FarValue, Model.Members.CurrentMember.NodeFar.Load.M);
            doubleValue_LoadsY.SetValue(doubleValue_LoadsY.NearValue, doubleValue_LoadsY.FarValue);
        }

        private void DoubleValue_LoadsM_NearValueChanged(object sender, EventArgs e)
        {
            Model.Members.CurrentMember.NodeNear.Load = new Finite_Element_Analysis_Explorer.NodalLoad(Model.Members.CurrentMember.NodeNear.Load.X, Model.Members.CurrentMember.NodeNear.Load.Y, -doubleValue_LoadsM.NearValue);
            doubleValue_LoadsM.SetValue(-doubleValue_LoadsM.NearValue, doubleValue_LoadsM.FarValue);
        }

        private void DoubleValue_LoadsM_FarValueChanged(object sender, EventArgs e)
        {
            Model.Members.CurrentMember.NodeFar.Load = new Finite_Element_Analysis_Explorer.NodalLoad(Model.Members.CurrentMember.NodeFar.Load.X, Model.Members.CurrentMember.NodeFar.Load.Y, doubleValue_LoadsM.FarValue);
            doubleValue_LoadsM.SetValue(doubleValue_LoadsM.NearValue, doubleValue_LoadsM.FarValue);
        }

        private void DoubleValue_LoadsM_ValueChanged(object sender, EventArgs e)
        {
            Model.Members.CurrentMember.NodeNear.Load = new Finite_Element_Analysis_Explorer.NodalLoad(Model.Members.CurrentMember.NodeNear.Load.X, Model.Members.CurrentMember.NodeNear.Load.Y, doubleValue_LoadsM.NearValue);
            Model.Members.CurrentMember.NodeFar.Load = new Finite_Element_Analysis_Explorer.NodalLoad(Model.Members.CurrentMember.NodeFar.Load.X, Model.Members.CurrentMember.NodeFar.Load.Y, doubleValue_LoadsM.FarValue);

            doubleValue_LoadsM.SetValue(doubleValue_LoadsM.NearValue, doubleValue_LoadsM.FarValue);
            doubleValue_LoadsM.SetValue(doubleValue_LoadsM.NearValue, doubleValue_LoadsM.FarValue);
        }

        private void DoubleValue_Linear_NearValueChanged(object sender, EventArgs e)
        {
            Model.Members.CurrentMember.LDLNear = doubleValue_Linear.NearValue;
            doubleValue_Linear.SetValue(Model.Members.CurrentMember.LDLNear, Model.Members.CurrentMember.LDLFar);
        }

        private void DoubleValue_Linear_FarValueChanged(object sender, EventArgs e)
        {
            Model.Members.CurrentMember.LDLFar = doubleValue_Linear.FarValue;
            doubleValue_Linear.SetValue(Model.Members.CurrentMember.LDLNear, Model.Members.CurrentMember.LDLFar);
        }

        private void DoubleValue_Linear_ValueChanged(object sender, EventArgs e)
        {
            Model.Members.CurrentMember.LDLNear = doubleValue_Linear.NearValue;
            Model.Members.CurrentMember.LDLFar = doubleValue_Linear.FarValue;
            doubleValue_Linear.SetValue(Model.Members.CurrentMember.LDLNear, Model.Members.CurrentMember.LDLFar);
            doubleValue_Linear.SetValue(Model.Members.CurrentMember.LDLNear, Model.Members.CurrentMember.LDLFar);
        }

        private void SingleValue_NoOfSegments_ValueChanged(object sender, EventArgs e)
        {
            Model.Members.CurrentMember.TotalSegments = (int)SingleValue_NoOfSegments.NewValue;
            SingleValue_NoOfSegments.SetTheValue(Model.Members.CurrentMember.TotalSegments);
        }

        private void FontIcon_TitleIconSection_Tapped(object sender, TappedRoutedEventArgs e)
        {
            flyOut_SelectSection.ShowAt(Button_Save);
        }

        private void StackPanel_KeyDown(object sender, KeyRoutedEventArgs e)
        {
        }

        private void FontIcon_TitleIconLoads_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MenuFlyout nextMenuFlyoutForceOptions = new MenuFlyout();
            MenuFlyoutItem itemClearLoadsThisMember = new MenuFlyoutItem()
            {
                Text = "Clear Loads - This Member",
            };
            itemClearLoadsThisMember.Click += ItemClearLoadsThisMember_Click;
            MenuFlyoutItem itemClearLoadsThisSection = new MenuFlyoutItem()
            {
                Text = "Clear Loads - This Section",
            };
            itemClearLoadsThisSection.Click += ItemClearLoadsThisSection_Click;
            MenuFlyoutItem itemClearLoadsAllMembers = new MenuFlyoutItem()
            {
                Text = "Clear Loads - All Members",
            };
            itemClearLoadsAllMembers.Click += ItemClearLoadsAllMembers_Click;
            MenuFlyoutItem itemCopyToThisSection = new MenuFlyoutItem()
            {
                Text = "Copy to - This Section",
            };
            itemCopyToThisSection.Click += ItemCopyToThisSection_Click;
            MenuFlyoutItem itemCopyToAllMembers = new MenuFlyoutItem()
            {
                Text = "Copy to - All Members",
            };
            itemCopyToAllMembers.Click += ItemCopyToAllMembers_Click;

            nextMenuFlyoutForceOptions.Items.Add(itemClearLoadsThisMember);
            nextMenuFlyoutForceOptions.Items.Add(itemClearLoadsThisSection);
            nextMenuFlyoutForceOptions.Items.Add(itemClearLoadsAllMembers);
            nextMenuFlyoutForceOptions.Items.Add(itemCopyToThisSection);
            nextMenuFlyoutForceOptions.Items.Add(itemCopyToAllMembers);
            nextMenuFlyoutForceOptions.ShowAt((FrameworkElement)sender);
        }

        private void ItemCopyToAllMembers_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ItemCopyToThisSection_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ItemClearLoadsAllMembers_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ItemClearLoadsThisSection_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ItemClearLoadsThisMember_Click(object sender, RoutedEventArgs e)
        {
        }

        #region Common Menus

        #region Help Menu

        private void Button_Help_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowHelpAsync();
        }

        #endregion

        #region Settings Menu

        private void MenuFlyout_SettingsGeneral_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowSettingsGeneral();
        }

        private void MenuFlyout_SettingsSolver_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowSettingsSolver();
        }

        private void MenuFlyout_SettingsColors_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowSettingsColors();
        }

        #endregion

        #region File Menu

        private void MenuFlyout_New_Click(object sender, RoutedEventArgs e)
        {
            // New File.
            FileManager.NewFile();
        }

        private async void MenuFlyout_Open_Click(object sender, RoutedEventArgs e)
        {
            // Open file.
            if (await FileManager.PickFileToLoad())
            {
                await FileManager.LoadFile();
            }
        }

        private async void MenuFlyout_Save_Click(object sender, RoutedEventArgs e)
        {
            // Save File.
            await FileManager.SaveFile();
        }

        private async void MenuFlyout_SaveAs_Click(object sender, RoutedEventArgs e)
        {
            // Save file as.
            if (await FileManager.PickFileToSave())
            {
                await FileManager.SaveFile();
            }
        }

        private void MenuFlyout_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        #endregion

        #region Changes per Page

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Solve_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowSolver();
        }

        private void Button_Construction_Click(object sender, RoutedEventArgs e)
        {
            FileManager.LoadLastFileAsync();
        }

        private void Button_Results_Click(object sender, RoutedEventArgs e)
        {
            Solver.Current.ShowResults();
        }

        private void Button_Sections_Click(object sender, RoutedEventArgs e)
        {
            Construction.Current.ShowSections();
        }

        private void Button_Reports_Click(object sender, RoutedEventArgs e)
        {
        }

        #endregion

        #endregion

    }
}

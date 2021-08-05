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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace Finite_Element_Analysis_Explorer
{
    public sealed partial class ConstraintsDisplay : UserControl
    {
        public ConstraintsDisplay()
        {
            this.InitializeComponent();
        }

        private bool displayOnly = false;
        public bool DisplayOnly
        {
            get { return displayOnly; }
            set { displayOnly = value; }
        }

        private void Image_NodeNear_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                MenuFlyout nextMenuFlyout = new MenuFlyout();

                MenuFlyoutItem itemFreeBottomNear = new MenuFlyoutItem();
                itemFreeBottomNear.Text = "    Free";
                itemFreeBottomNear.FontFamily = new FontFamily("Segoe UI Symbol");
                itemFreeBottomNear.Click += ItemNear_Click;

                MenuFlyoutItem itemFixedBottomNear = new MenuFlyoutItem();
                itemFixedBottomNear.Text = "△ Fixed";
                itemFixedBottomNear.FontFamily = new FontFamily("Segoe UI Symbol");
                itemFixedBottomNear.Click += ItemNear_Click;

                MenuFlyoutItem itemFixedTopNear = new MenuFlyoutItem();
                itemFixedTopNear.Text = "▽ Fixed";
                itemFixedTopNear.FontFamily = new FontFamily("Segoe UI Symbol");
                itemFixedTopNear.Click += ItemNear_Click;

                MenuFlyoutItem itemFixedLeftNear = new MenuFlyoutItem();
                itemFixedLeftNear.Text = "▷ Fixed";
                itemFixedLeftNear.FontFamily = new FontFamily("Segoe UI Symbol");
                itemFixedLeftNear.Click += ItemNear_Click;

                MenuFlyoutItem itemFixedRightNear = new MenuFlyoutItem();
                itemFixedRightNear.Text = "◁ Fixed";
                itemFixedRightNear.FontFamily = new FontFamily("Segoe UI Symbol");
                itemFixedRightNear.Click += ItemNear_Click;

                MenuFlyoutItem itemPinnedBottomNear = new MenuFlyoutItem();
                itemPinnedBottomNear.Text = "△ Pinned";
                itemPinnedBottomNear.FontFamily = new FontFamily("Segoe UI Symbol");
                itemPinnedBottomNear.Click += ItemNear_Click;

                MenuFlyoutItem itemPinnedTopNear = new MenuFlyoutItem();
                itemPinnedTopNear.Text = "▽ Pinned";
                itemPinnedTopNear.FontFamily = new FontFamily("Segoe UI Symbol");
                itemPinnedTopNear.Click += ItemNear_Click;

                MenuFlyoutItem itemPinnedLeftNear = new MenuFlyoutItem();
                itemPinnedLeftNear.Text = "▷ Pinned";
                itemPinnedLeftNear.FontFamily = new FontFamily("Segoe UI Symbol");
                itemPinnedLeftNear.Click += ItemNear_Click;

                MenuFlyoutItem itemPinnedRightNear = new MenuFlyoutItem();
                itemPinnedRightNear.Text = "◁ Pinned";
                itemPinnedRightNear.FontFamily = new FontFamily("Segoe UI Symbol");
                itemPinnedRightNear.Click += ItemNear_Click;

                MenuFlyoutItem itemRollerBottomNear = new MenuFlyoutItem();
                itemRollerBottomNear.Text = "△ Roller (x-axis)";
                itemRollerBottomNear.FontFamily = new FontFamily("Segoe UI Symbol");
                itemRollerBottomNear.Click += ItemNear_Click;

                MenuFlyoutItem itemRollerTopNear = new MenuFlyoutItem();
                itemRollerTopNear.Text = "▽ Roller (x-axis)";
                itemRollerTopNear.FontFamily = new FontFamily("Segoe UI Symbol");
                itemRollerTopNear.Click += ItemNear_Click;

                MenuFlyoutItem itemRollerLeftNear = new MenuFlyoutItem();
                itemRollerLeftNear.Text = "▷ Roller (y-axis)";
                itemRollerLeftNear.FontFamily = new FontFamily("Segoe UI Symbol");
                itemRollerLeftNear.Click += ItemNear_Click;

                MenuFlyoutItem itemRollerRightNear = new MenuFlyoutItem();
                itemRollerRightNear.Text = "◁ Roller (y-axis)";
                itemRollerRightNear.FontFamily = new FontFamily("Segoe UI Symbol");
                itemRollerRightNear.Click += ItemNear_Click;

                MenuFlyoutItem itemTrackBottomNear = new MenuFlyoutItem();
                itemTrackBottomNear.Text = "△ Track (x-axis)";
                itemTrackBottomNear.FontFamily = new FontFamily("Segoe UI Symbol");
                itemTrackBottomNear.Click += ItemNear_Click;

                MenuFlyoutItem itemTrackTopNear = new MenuFlyoutItem();
                itemTrackTopNear.Text = "▽ Track (x-axis)";
                itemTrackTopNear.FontFamily = new FontFamily("Segoe UI Symbol");
                itemTrackTopNear.Click += ItemNear_Click;

                MenuFlyoutItem itemTrackLeftNear = new MenuFlyoutItem();
                itemTrackLeftNear.Text = "▷ Track (y-axis)";
                itemTrackLeftNear.FontFamily = new FontFamily("Segoe UI Symbol");
                itemTrackLeftNear.Click += ItemNear_Click;

                MenuFlyoutItem itemTrackRightNear = new MenuFlyoutItem();
                itemTrackRightNear.Text = "◁ Track (y-axis)";
                itemTrackRightNear.FontFamily = new FontFamily("Segoe UI Symbol");
                itemTrackRightNear.Click += ItemNear_Click;

                nextMenuFlyout.Items.Add(itemFreeBottomNear);

                nextMenuFlyout.Items.Add(itemFixedBottomNear);
                nextMenuFlyout.Items.Add(itemFixedTopNear);
                nextMenuFlyout.Items.Add(itemFixedLeftNear);
                nextMenuFlyout.Items.Add(itemFixedRightNear);

                nextMenuFlyout.Items.Add(itemPinnedBottomNear);
                nextMenuFlyout.Items.Add(itemPinnedTopNear);
                nextMenuFlyout.Items.Add(itemPinnedLeftNear);
                nextMenuFlyout.Items.Add(itemPinnedRightNear);

                nextMenuFlyout.Items.Add(itemRollerBottomNear);
                nextMenuFlyout.Items.Add(itemRollerTopNear);
                nextMenuFlyout.Items.Add(itemRollerLeftNear);
                nextMenuFlyout.Items.Add(itemRollerRightNear);

                nextMenuFlyout.Items.Add(itemTrackBottomNear);
                nextMenuFlyout.Items.Add(itemTrackTopNear);
                nextMenuFlyout.Items.Add(itemTrackLeftNear);
                nextMenuFlyout.Items.Add(itemTrackRightNear);

                nextMenuFlyout.ShowAt((FrameworkElement)sender);
            }
        }

        private void ItemNear_Click(object sender, RoutedEventArgs e)
        {

            if (Model.Members.CurrentMember is object)
            {
                if (!displayOnly)
                {
                    MenuFlyoutItem tmpItem = (MenuFlyoutItem)e.OriginalSource;
                    //Debug.WriteLine(tmpItem.Text);

                    switch (tmpItem.Text)
                    {
                        case "    Free":
                            Model.Members.CurrentMember.NodeNear.Constraints = new Constraints(ConstraintType.Free);
                            break;
                        case "△ Fixed":
                            Model.Members.CurrentMember.NodeNear.Constraints = new Constraints(ConstraintType.FixedBottom);
                            break;
                        case "▽ Fixed":
                            Model.Members.CurrentMember.NodeNear.Constraints = new Constraints(ConstraintType.FixedTop);
                            break;
                        case "▷ Fixed":
                            Model.Members.CurrentMember.NodeNear.Constraints = new Constraints(ConstraintType.FixedLeft);
                            break;
                        case "◁ Fixed":
                            Model.Members.CurrentMember.NodeNear.Constraints = new Constraints(ConstraintType.FixedRight);
                            break;
                        case "△ Pinned":
                            Model.Members.CurrentMember.NodeNear.Constraints = new Constraints(ConstraintType.PinnedBottom);
                            break;
                        case "▽ Pinned":
                            Model.Members.CurrentMember.NodeNear.Constraints = new Constraints(ConstraintType.PinnedTop);
                            break;
                        case "▷ Pinned":
                            Model.Members.CurrentMember.NodeNear.Constraints = new Constraints(ConstraintType.PinnedLeft);
                            break;
                        case "◁ Pinned":
                            Model.Members.CurrentMember.NodeNear.Constraints = new Constraints(ConstraintType.PinnedRight);
                            break;
                        case "△ Roller (x-axis)":
                            Model.Members.CurrentMember.NodeNear.Constraints = new Constraints(ConstraintType.RollerBottom);
                            break;
                        case "▽ Roller (x-axis)":
                            Model.Members.CurrentMember.NodeNear.Constraints = new Constraints(ConstraintType.RollerTop);
                            break;
                        case "▷ Roller (y-axis)":
                            Model.Members.CurrentMember.NodeNear.Constraints = new Constraints(ConstraintType.RollerLeft);
                            break;
                        case "◁ Roller (y-axis)":
                            Model.Members.CurrentMember.NodeNear.Constraints = new Constraints(ConstraintType.RollerBottom);
                            break;
                        case "△ Track (x-axis)":
                            Model.Members.CurrentMember.NodeNear.Constraints = new Constraints(ConstraintType.TrackBottom);
                            break;
                        case "▽ Track (x-axis)":
                            Model.Members.CurrentMember.NodeNear.Constraints = new Constraints(ConstraintType.TrackTop);
                            break;
                        case "▷ Track (y-axis)":
                            Model.Members.CurrentMember.NodeNear.Constraints = new Constraints(ConstraintType.TrackLeft);
                            break;
                        case "◁ Track (y-axis)":
                            Model.Members.CurrentMember.NodeNear.Constraints = new Constraints(ConstraintType.TrackRight);
                            break;
                    }
                    Construction.Current.Refresh();
                }
            }
            else
            {

            }


            


            
        }

        private void ItemFar_Click(object sender, RoutedEventArgs e)
        {

            if (Model.Members.CurrentMember is object)
            {

                if (!displayOnly)
                {
                    MenuFlyoutItem tmpItem = (MenuFlyoutItem)e.OriginalSource;
                    //Debug.WriteLine(tmpItem.Text);

                    switch (tmpItem.Text)
                    {
                        case "    Free":
                            Model.Members.CurrentMember.NodeFar.Constraints = new Constraints(ConstraintType.Free);
                            break;
                        case "△ Fixed":
                            Model.Members.CurrentMember.NodeFar.Constraints = new Constraints(ConstraintType.FixedBottom);
                            break;
                        case "▽ Fixed":
                            Model.Members.CurrentMember.NodeFar.Constraints = new Constraints(ConstraintType.FixedTop);
                            break;
                        case "▷ Fixed":
                            Model.Members.CurrentMember.NodeFar.Constraints = new Constraints(ConstraintType.FixedLeft);
                            break;
                        case "◁ Fixed":
                            Model.Members.CurrentMember.NodeFar.Constraints = new Constraints(ConstraintType.FixedRight);
                            break;
                        case "△ Pinned":
                            Model.Members.CurrentMember.NodeFar.Constraints = new Constraints(ConstraintType.PinnedBottom);
                            break;
                        case "▽ Pinned":
                            Model.Members.CurrentMember.NodeFar.Constraints = new Constraints(ConstraintType.PinnedTop);
                            break;
                        case "▷ Pinned":
                            Model.Members.CurrentMember.NodeFar.Constraints = new Constraints(ConstraintType.PinnedLeft);
                            break;
                        case "◁ Pinned":
                            Model.Members.CurrentMember.NodeFar.Constraints = new Constraints(ConstraintType.PinnedRight);
                            break;
                        case "△ Roller (x-axis)":
                            Model.Members.CurrentMember.NodeFar.Constraints = new Constraints(ConstraintType.RollerBottom);
                            break;
                        case "▽ Roller (x-axis)":
                            Model.Members.CurrentMember.NodeFar.Constraints = new Constraints(ConstraintType.RollerTop);
                            break;
                        case "▷ Roller (y-axis)":
                            Model.Members.CurrentMember.NodeFar.Constraints = new Constraints(ConstraintType.RollerLeft);
                            break;
                        case "◁ Roller (y-axis)":
                            Model.Members.CurrentMember.NodeFar.Constraints = new Constraints(ConstraintType.RollerBottom);
                            break;
                        case "△ Track (x-axis)":
                            Model.Members.CurrentMember.NodeFar.Constraints = new Constraints(ConstraintType.TrackBottom);
                            break;
                        case "▽ Track (x-axis)":
                            Model.Members.CurrentMember.NodeFar.Constraints = new Constraints(ConstraintType.TrackTop);
                            break;
                        case "▷ Track (y-axis)":
                            Model.Members.CurrentMember.NodeFar.Constraints = new Constraints(ConstraintType.TrackLeft);
                            break;
                        case "◁ Track (y-axis)":
                            Model.Members.CurrentMember.NodeFar.Constraints = new Constraints(ConstraintType.TrackRight);
                            break;
                    }
                    Construction.Current.Refresh();
                }
            }
            else
            {

            }
        }

        private void Image_NodeFar_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!displayOnly)
            {
                MenuFlyout nextMenuFlyout = new MenuFlyout();

                MenuFlyoutItem itemFreeBottomFar = new MenuFlyoutItem();
                itemFreeBottomFar.Text = "    Free";
                itemFreeBottomFar.FontFamily = new FontFamily("Segoe UI Symbol");
                itemFreeBottomFar.Click += ItemFar_Click;

                MenuFlyoutItem itemFixedBottomFar = new MenuFlyoutItem();
                itemFixedBottomFar.Text = "△ Fixed";
                itemFixedBottomFar.FontFamily = new FontFamily("Segoe UI Symbol");
                itemFixedBottomFar.Click += ItemFar_Click;

                MenuFlyoutItem itemFixedTopFar = new MenuFlyoutItem();
                itemFixedTopFar.Text = "▽ Fixed";
                itemFixedTopFar.FontFamily = new FontFamily("Segoe UI Symbol");
                itemFixedTopFar.Click += ItemFar_Click;

                MenuFlyoutItem itemFixedLeftFar = new MenuFlyoutItem();
                itemFixedLeftFar.Text = "▷ Fixed";
                itemFixedLeftFar.FontFamily = new FontFamily("Segoe UI Symbol");
                itemFixedLeftFar.Click += ItemFar_Click;

                MenuFlyoutItem itemFixedRightFar = new MenuFlyoutItem();
                itemFixedRightFar.Text = "◁ Fixed";
                itemFixedRightFar.FontFamily = new FontFamily("Segoe UI Symbol");
                itemFixedRightFar.Click += ItemFar_Click;

                MenuFlyoutItem itemPinnedBottomFar = new MenuFlyoutItem();
                itemPinnedBottomFar.Text = "△ Pinned";
                itemPinnedBottomFar.FontFamily = new FontFamily("Segoe UI Symbol");
                itemPinnedBottomFar.Click += ItemFar_Click;

                MenuFlyoutItem itemPinnedTopFar = new MenuFlyoutItem();
                itemPinnedTopFar.Text = "▽ Pinned";
                itemPinnedTopFar.FontFamily = new FontFamily("Segoe UI Symbol");
                itemPinnedTopFar.Click += ItemFar_Click;

                MenuFlyoutItem itemPinnedLeftFar = new MenuFlyoutItem();
                itemPinnedLeftFar.Text = "▷ Pinned";
                itemPinnedLeftFar.FontFamily = new FontFamily("Segoe UI Symbol");
                itemPinnedLeftFar.Click += ItemFar_Click;

                MenuFlyoutItem itemPinnedRightFar = new MenuFlyoutItem();
                itemPinnedRightFar.Text = "◁ Pinned";
                itemPinnedRightFar.FontFamily = new FontFamily("Segoe UI Symbol");
                itemPinnedRightFar.Click += ItemFar_Click;

                MenuFlyoutItem itemRollerBottomFar = new MenuFlyoutItem();
                itemRollerBottomFar.Text = "△ Roller (x-axis)";
                itemRollerBottomFar.FontFamily = new FontFamily("Segoe UI Symbol");
                itemRollerBottomFar.Click += ItemFar_Click;

                MenuFlyoutItem itemRollerTopFar = new MenuFlyoutItem();
                itemRollerTopFar.Text = "▽ Roller (x-axis)";
                itemRollerTopFar.FontFamily = new FontFamily("Segoe UI Symbol");
                itemRollerTopFar.Click += ItemFar_Click;

                MenuFlyoutItem itemRollerLeftFar = new MenuFlyoutItem();
                itemRollerLeftFar.Text = "▷ Roller (y-axis)";
                itemRollerLeftFar.FontFamily = new FontFamily("Segoe UI Symbol");
                itemRollerLeftFar.Click += ItemFar_Click;

                MenuFlyoutItem itemRollerRightFar = new MenuFlyoutItem();
                itemRollerRightFar.Text = "◁ Roller (y-axis)";
                itemRollerRightFar.FontFamily = new FontFamily("Segoe UI Symbol");
                itemRollerRightFar.Click += ItemFar_Click;

                MenuFlyoutItem itemTrackBottomFar = new MenuFlyoutItem();
                itemTrackBottomFar.Text = "△ Track (x-axis)";
                itemTrackBottomFar.FontFamily = new FontFamily("Segoe UI Symbol");
                itemTrackBottomFar.Click += ItemFar_Click;

                MenuFlyoutItem itemTrackTopFar = new MenuFlyoutItem();
                itemTrackTopFar.Text = "▽ Track (x-axis)";
                itemTrackTopFar.FontFamily = new FontFamily("Segoe UI Symbol");
                itemTrackTopFar.Click += ItemFar_Click;

                MenuFlyoutItem itemTrackLeftFar = new MenuFlyoutItem();
                itemTrackLeftFar.Text = "▷ Track (y-axis)";
                itemTrackLeftFar.FontFamily = new FontFamily("Segoe UI Symbol");
                itemTrackLeftFar.Click += ItemFar_Click;

                MenuFlyoutItem itemTrackRightFar = new MenuFlyoutItem();
                itemTrackRightFar.Text = "◁ Track (y-axis)";
                itemTrackRightFar.FontFamily = new FontFamily("Segoe UI Symbol");
                itemTrackRightFar.Click += ItemFar_Click;



                nextMenuFlyout.Items.Add(itemFreeBottomFar);

                nextMenuFlyout.Items.Add(itemFixedBottomFar);
                nextMenuFlyout.Items.Add(itemFixedTopFar);
                nextMenuFlyout.Items.Add(itemFixedLeftFar);
                nextMenuFlyout.Items.Add(itemFixedRightFar);

                nextMenuFlyout.Items.Add(itemPinnedBottomFar);
                nextMenuFlyout.Items.Add(itemPinnedTopFar);
                nextMenuFlyout.Items.Add(itemPinnedLeftFar);
                nextMenuFlyout.Items.Add(itemPinnedRightFar);

                nextMenuFlyout.Items.Add(itemRollerBottomFar);
                nextMenuFlyout.Items.Add(itemRollerTopFar);
                nextMenuFlyout.Items.Add(itemRollerLeftFar);
                nextMenuFlyout.Items.Add(itemRollerRightFar);

                nextMenuFlyout.Items.Add(itemTrackBottomFar);
                nextMenuFlyout.Items.Add(itemTrackTopFar);
                nextMenuFlyout.Items.Add(itemTrackLeftFar);
                nextMenuFlyout.Items.Add(itemTrackRightFar);

                nextMenuFlyout.ShowAt((FrameworkElement)sender);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SetNearImage();
            SetFarImage();
        }

        private void SetNearImage()
        {

            if (Model.Members.CurrentMember is object)
            {
                switch (Model.Members.CurrentMember.NodeNear.Constraints.ConstraintType)
                {
                    case ConstraintType.Free:
                        Image_NodeNear.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeFreeBlue.png"));
                        break;
                    case ConstraintType.FixedBottom:
                    case ConstraintType.Fixed:
                        Image_NodeNear.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeFixedTopBlue.png"));
                        break;
                    case ConstraintType.FixedTop:
                        Image_NodeNear.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeFixedBottomBlue.png"));
                        break;
                    case ConstraintType.FixedLeft:
                        Image_NodeNear.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeFixedLeftBlue.png"));
                        break;
                    case ConstraintType.FixedRight:
                        Image_NodeNear.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeFixedRightBlue.png"));
                        break;
                    case ConstraintType.PinnedBottom:
                    case ConstraintType.Pinned:
                        Image_NodeNear.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodePinnedTopBlue.png"));
                        break;
                    case ConstraintType.PinnedTop:
                        Image_NodeNear.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodePinnedBottomBlue.png"));
                        break;
                    case ConstraintType.PinnedLeft:
                        Image_NodeNear.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodePinnedLeftBlue.png"));
                        break;
                    case ConstraintType.PinnedRight:
                        Image_NodeNear.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodePinnedRightBlue.png"));
                        break;
                    case ConstraintType.RollerBottom:
                    case ConstraintType.RollerX:
                        Image_NodeNear.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeRollerTopBlue.png"));
                        break;
                    case ConstraintType.RollerTop:
                        Image_NodeNear.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeRollerBottomBlue.png"));
                        break;
                    case ConstraintType.RollerLeft:
                    case ConstraintType.RollerY:
                        Image_NodeNear.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeRollerLeftBlue.png"));
                        break;
                    case ConstraintType.RollerRight:
                        Image_NodeNear.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeRollerRightBlue.png"));
                        break;
                    case ConstraintType.TrackBottom:
                        Image_NodeNear.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeTrackTopBlue.png"));
                        break;
                    case ConstraintType.TrackTop:
                        Image_NodeNear.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeTrackBottomBlue.png"));
                        break;
                    case ConstraintType.TrackLeft:
                        Image_NodeNear.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeTrackLeftBlue.png"));
                        break;
                    case ConstraintType.TrackRight:
                        Image_NodeNear.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeTrackRightBlue.png"));
                        break;
                    case ConstraintType.Unknown:
                    default:
                        //Not sure?
                        break;
                }
            }
            else
            {
                Image_NodeNear.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeFreeBlue.png"));
            }



            
        }

        private void SetFarImage()
        {

            if (Model.Members.CurrentMember is object)
            {
                switch (Model.Members.CurrentMember.NodeFar.Constraints.ConstraintType)
                {

                    case ConstraintType.Free:
                        Image_NodeFar.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeFreeBlue.png"));
                        break;
                    case ConstraintType.FixedBottom:
                    case ConstraintType.Fixed:
                        Image_NodeFar.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeFixedTopBlue.png"));
                        break;
                    case ConstraintType.FixedTop:
                        Image_NodeFar.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeFixedBottomBlue.png"));
                        break;
                    case ConstraintType.FixedLeft:
                        Image_NodeFar.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeFixedLeftBlue.png"));
                        break;
                    case ConstraintType.FixedRight:
                        Image_NodeFar.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeFixedRightBlue.png"));
                        break;
                    case ConstraintType.PinnedBottom:
                    case ConstraintType.Pinned:
                        Image_NodeFar.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodePinnedTopBlue.png"));
                        break;
                    case ConstraintType.PinnedTop:
                        Image_NodeFar.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodePinnedBottomBlue.png"));
                        break;
                    case ConstraintType.PinnedLeft:
                        Image_NodeFar.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodePinnedLeftBlue.png"));
                        break;
                    case ConstraintType.PinnedRight:
                        Image_NodeFar.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodePinnedRightBlue.png"));
                        break;
                    case ConstraintType.RollerBottom:
                    case ConstraintType.RollerX:
                        Image_NodeFar.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeRollerTopBlue.png"));
                        break;
                    case ConstraintType.RollerTop:
                        Image_NodeFar.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeRollerBottomBlue.png"));
                        break;
                    case ConstraintType.RollerLeft:
                    case ConstraintType.RollerY:
                        Image_NodeFar.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeRollerLeftBlue.png"));
                        break;
                    case ConstraintType.RollerRight:
                        Image_NodeFar.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeRollerRightBlue.png"));
                        break;
                    case ConstraintType.TrackBottom:
                        Image_NodeFar.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeTrackTopBlue.png"));
                        break;
                    case ConstraintType.TrackTop:
                        Image_NodeFar.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeTrackBottomBlue.png"));
                        break;
                    case ConstraintType.TrackLeft:
                        Image_NodeFar.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeTrackLeftBlue.png"));
                        break;
                    case ConstraintType.TrackRight:
                        Image_NodeFar.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeTrackRightBlue.png"));
                        break;
                    case ConstraintType.Unknown:
                    default:
                        //Not sure?
                        break;
                }
            }
            else
            {
                Image_NodeFar.Source = new BitmapImage(new Uri("ms-appx:///Assets/Nodes/NodeFreeBlue.png"));
            }


                
        }

    }
}

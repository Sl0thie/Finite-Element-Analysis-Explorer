﻿using System;
using System.Collections.Generic;
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
    public sealed partial class SectionList : UserControl
    {
        public SectionList()
        {
            this.InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            listView_Sections.ItemsSource = Model.Sections;
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

                    PanelMember.Current.HideSectionList();
                }
            }
        }
    }
}

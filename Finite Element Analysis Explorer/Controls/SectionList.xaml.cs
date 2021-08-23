using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Finite_Element_Analysis_Explorer
{
    /// <summary>
    /// SectionList UserControl provides a list of sections for the user to choose.
    /// </summary>
    public sealed partial class SectionList : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SectionList"/> class.
        /// </summary>
        public SectionList()
        {
            this.InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ListView_Sections.ItemsSource = Model.Sections;
        }

        private void ListView_Sections_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListView_Sections.SelectedItem is object)
            {
                KeyValuePair<string, Section> kvp = (KeyValuePair<string, Section>)ListView_Sections.SelectedItem;
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

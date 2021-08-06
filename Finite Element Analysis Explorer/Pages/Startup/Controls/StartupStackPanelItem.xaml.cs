using Windows.UI.Xaml.Controls;

namespace Finite_Element_Analysis_Explorer
{
    public sealed partial class StartupStackPanelItem : UserControl
    {
        private string description;

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
                TextBlockDescription.Text = description;
            }
        }

        public StartupStackPanelItem(string _description)
        {
            this.InitializeComponent();
            description = _description;
            TextBlockDescription.Text = description;
        }
    }
}

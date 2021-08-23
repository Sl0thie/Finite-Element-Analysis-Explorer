using Windows.UI.Xaml.Controls;

namespace Finite_Element_Analysis_Explorer
{
    /// <summary>
    /// StartupStackPanelItem UserControl.
    /// </summary>
    public sealed partial class StartupStackPanelItem : UserControl
    {
        private string description;

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="StartupStackPanelItem"/> class.
        /// </summary>
        /// <param name="description">description.</param>
        public StartupStackPanelItem(string description)
        {
            this.InitializeComponent();
            this.description = description;
            TextBlockDescription.Text = this.description;
        }
    }
}

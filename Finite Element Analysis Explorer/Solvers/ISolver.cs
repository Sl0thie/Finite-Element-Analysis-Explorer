namespace Finite_Element_Analysis_Explorer
{
    /// <summary>
    /// ISolver interface.
    /// </summary>
    public interface ISolver
    {
        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        Windows.UI.Xaml.Controls.Page Parent
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether there are errors.
        /// </summary>
        bool HasErrors
        {
            get;
            set;
        }

        /// <summary>
        /// Solves the model.
        /// </summary>
        void SolveModel();
    }
}

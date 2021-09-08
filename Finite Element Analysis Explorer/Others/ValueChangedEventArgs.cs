namespace Finite_Element_Analysis_Explorer
{
    using System;

    /// <summary>
    /// ValueChangedEventArgs EventArgs.
    /// </summary>
    internal class ValueChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueChangedEventArgs"/> class.
        /// </summary>
        /// <param name="value">value.</param>
        public ValueChangedEventArgs(decimal value)
        {
            Value = value;
        }
    }
}
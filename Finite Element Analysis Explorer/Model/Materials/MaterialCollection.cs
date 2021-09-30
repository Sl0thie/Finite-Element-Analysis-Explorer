namespace Finite_Element_Analysis_Explorer
{
    using System.Collections.Generic;

    /// <summary>
    /// MaterialCollection class.
    /// </summary>
    internal class MaterialCollection : Dictionary<string, Material>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MaterialCollection"/> class.
        /// </summary>
        public MaterialCollection()
            : base()
        {
        }

        private Material currentMaterial;

        /// <summary>
        /// Gets or sets the current material.
        /// </summary>
        internal Material CurrentMaterial
        {
            get
            {
                return currentMaterial;
            }

            set
            {
                currentMaterial = value;
            }
        }

        /// <summary>
        /// Loads the materials into the collection.
        /// </summary>
        /// <param name="items">A dictionary containing the items.</param>
        public void LoadMaterials(Dictionary<string, Material> items)
        {
            foreach (var item in items)
            {
                this.Add(item.Key, item.Value);
            }

        }
    }
}
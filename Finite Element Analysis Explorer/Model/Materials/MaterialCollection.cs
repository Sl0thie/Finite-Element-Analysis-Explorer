using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finite_Element_Analysis_Explorer
{
    internal class MaterialCollection : Dictionary<string, Material>
    {

        public MaterialCollection() : base()
        {

        }

        private Material currentMaterial;
        internal Material CurrentMaterial
        {
            get { return currentMaterial; }
            set { currentMaterial = value; }
        }
    }
}
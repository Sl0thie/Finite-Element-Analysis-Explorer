using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finite_Element_Analysis_Explorer
{
    public interface ISolver
    {
        Windows.UI.Xaml.Controls.Page Parent
        {
            get;
            set;
        }

        bool HasErrors
        {
            get;
            set;
        }

        void SolveModel();
    }
}

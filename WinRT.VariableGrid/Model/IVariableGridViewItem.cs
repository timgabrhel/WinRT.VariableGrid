using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinRT.VariableGrid.Model
{
    public interface IVariableGridViewItem
    {
        int Width { get; set; }

        int Height { get; set; }
    }
}

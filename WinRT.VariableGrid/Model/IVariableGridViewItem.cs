using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace WinRT.VariableGrid.Model
{
    public interface IVariableGridViewItem
    {
        int ActualWidth { get; }

        int ActualHeight { get; }

        Size SpanSize { get; set; }
    }
}

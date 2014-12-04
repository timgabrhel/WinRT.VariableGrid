using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinRT.VariableGrid.Model;

namespace WinRT.VariableGrid.Controls
{
    public class VariableGridView : GridView
    {
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            var variableItem = item as IVariableGridViewItem;
            if (variableItem != null)
            {
                element.SetValue(Windows.UI.Xaml.Controls.VariableSizedWrapGrid.ColumnSpanProperty, variableItem.Width);
                element.SetValue(Windows.UI.Xaml.Controls.VariableSizedWrapGrid.RowSpanProperty, variableItem.Height);
            }
            else
            {
                element.SetValue(Windows.UI.Xaml.Controls.VariableSizedWrapGrid.ColumnSpanProperty, 170);
                element.SetValue(Windows.UI.Xaml.Controls.VariableSizedWrapGrid.RowSpanProperty, 135);
            }
            base.PrepareContainerForItemOverride(element, item);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
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
                element.SetValue(Windows.UI.Xaml.Controls.VariableSizedWrapGrid.ColumnSpanProperty, variableItem.SpanSize.Width);
                element.SetValue(Windows.UI.Xaml.Controls.VariableSizedWrapGrid.RowSpanProperty, variableItem.SpanSize.Height);

                element.SetValue(HeightProperty, variableItem.ActualHeight);
                element.SetValue(WidthProperty, variableItem.ActualWidth);
            }
            else
            {
                var defaultSize = (CoreApplication.MainView.CoreWindow.Bounds.Width / 2);

                element.SetValue(Windows.UI.Xaml.Controls.VariableSizedWrapGrid.ColumnSpanProperty, defaultSize);
                element.SetValue(Windows.UI.Xaml.Controls.VariableSizedWrapGrid.RowSpanProperty, defaultSize);

                element.SetValue(HeightProperty, defaultSize);
                element.SetValue(WidthProperty, defaultSize);
            }
            base.PrepareContainerForItemOverride(element, item);
        }
    }
}

//-------------------------------------//
//-------------- USINGS ---------------//
//-------------------------------------//
using System.Windows;

namespace Telerik.Windows.Controls.ChartView
{
    public class DataTemplateSelector
    {
        public virtual DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return null;
        }
    }
}
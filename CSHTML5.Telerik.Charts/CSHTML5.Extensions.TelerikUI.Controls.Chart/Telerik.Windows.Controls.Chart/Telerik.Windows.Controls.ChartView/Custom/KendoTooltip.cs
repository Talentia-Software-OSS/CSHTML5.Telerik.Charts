// Telerik.Windows.Controls.RadLegend
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
//using Telerik.Licensing;
using Telerik.Windows;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Controls.ChartView
{

    public class KendoTooltip : Control
    {
        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("ColorProperty", typeof(Brush), typeof(KendoTooltip), null);
        public static readonly DependencyProperty FormatProperty = DependencyProperty.Register("FormatProperty", typeof(string), typeof(KendoTooltip), null);
        
        public Brush Color
        {
            get { return (Brush)this.GetValue(KendoTooltip.ColorProperty); }
            set { this.SetValue(KendoTooltip.ColorProperty, (object)value); }
        }

        public string Format
        {
            get { return (string)this.GetValue(KendoTooltip.FormatProperty); }
            set { this.SetValue(KendoTooltip.FormatProperty, (object)value); }
        }
    }
}
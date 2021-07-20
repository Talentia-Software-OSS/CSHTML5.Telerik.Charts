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

    public class KendoLabel : Control
    {
        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("ColorProperty", typeof(Brush), typeof(KendoLabel), null);
        public static readonly DependencyProperty FormatProperty = DependencyProperty.Register("FormatProperty", typeof(string), typeof(KendoLabel), null);
        
        public Brush Color
        {
            get { return (Brush)this.GetValue(KendoLabel.ColorProperty); }
            set { this.SetValue(KendoLabel.ColorProperty, (object)value); }
        }

        public string Format
        {
            get { return (string)this.GetValue(KendoLabel.FormatProperty); }
            set { this.SetValue(KendoLabel.FormatProperty, (object)value); }
        }
    }
}
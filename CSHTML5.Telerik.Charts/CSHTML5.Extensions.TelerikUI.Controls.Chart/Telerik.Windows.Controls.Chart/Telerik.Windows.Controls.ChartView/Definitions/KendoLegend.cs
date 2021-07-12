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
//using Telerik.Windows.Controls.Legend;

namespace Telerik.Windows.Controls.ChartView
{
    public enum LegendPosition
    {
        Top,
        Bottom,
        Left,
        Right,
        Custom
    }

    public class KendoLegend : Control
    {
        public static readonly DependencyProperty PositionProperty = DependencyProperty.Register("PositionProperty", typeof(LegendPosition), typeof(KendoLegend), new PropertyMetadata(LegendPosition.Right));

        public LegendPosition Position
        {
            get { return (LegendPosition)this.GetValue(KendoLegend.PositionProperty); }
            set { this.SetValue(KendoLegend.PositionProperty, (object)value); }
        }
    }
}
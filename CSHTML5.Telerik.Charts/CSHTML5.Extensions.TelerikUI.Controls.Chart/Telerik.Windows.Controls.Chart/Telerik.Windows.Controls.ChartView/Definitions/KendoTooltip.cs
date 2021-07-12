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
    public enum TooltipPosition
    {
        Top,
        Bottom,
        Left,
        Right,
        Custom
    }

    public class KendoTooltip : Control
    {
        public static readonly DependencyProperty PositionProperty = DependencyProperty.Register("PositionProperty", typeof(TooltipPosition), typeof(KendoTooltip), new PropertyMetadata(TooltipPosition.Right));

        public TooltipPosition Position
        {
            get { return (TooltipPosition)this.GetValue(KendoTooltip.PositionProperty); }
            set { this.SetValue(KendoTooltip.PositionProperty, (object)value); }
        }
    }
}
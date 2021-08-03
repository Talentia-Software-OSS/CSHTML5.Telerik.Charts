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
        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("ColorProperty", typeof(Brush), typeof(KendoLegend), null);
        public static readonly DependencyProperty PositionProperty = DependencyProperty.Register("PositionProperty", typeof(LegendPosition), typeof(KendoLegend), new PropertyMetadata(LegendPosition.Right));
        public static readonly DependencyProperty MarkersHeightProperty = DependencyProperty.Register("MarkersHeightProperty", typeof(int), typeof(KendoLegend), new PropertyMetadata(-1));
        public static readonly DependencyProperty MarkersWidthProperty = DependencyProperty.Register("MarkersWidthProperty", typeof(int), typeof(KendoLegend), new PropertyMetadata(-1));

        public Brush Color
        {
            get { return (Brush)this.GetValue(KendoLegend.ColorProperty); }
            set { this.SetValue(KendoLegend.ColorProperty, (object)value); }
        }
        public int MarkersHeight
        {
            get { return (int)this.GetValue(KendoLegend.MarkersHeightProperty); }
            set { this.SetValue(KendoLegend.MarkersHeightProperty, (int)value); }
        }

        public int MarkersWidth
        {
            get { return (int)this.GetValue(KendoLegend.MarkersWidthProperty); }
            set { this.SetValue(KendoLegend.MarkersWidthProperty, (int)value); }
        }

        public LegendPosition Position
        {
            get { return (LegendPosition)this.GetValue(KendoLegend.PositionProperty); }
            set { this.SetValue(KendoLegend.PositionProperty, (object)value); }
        }
    }
}
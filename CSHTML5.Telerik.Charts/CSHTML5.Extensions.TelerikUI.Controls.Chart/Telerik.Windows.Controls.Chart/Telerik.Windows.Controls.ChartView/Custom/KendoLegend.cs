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
        public static readonly DependencyProperty SeriesColorProperty = DependencyProperty.Register("SeriesColorProperty", typeof(Brush), typeof(KendoLegend), null);
        public static readonly DependencyProperty PositionProperty = DependencyProperty.Register("PositionProperty", typeof(LegendPosition), typeof(KendoLegend), new PropertyMetadata(LegendPosition.Right));

        public Brush Color
        {
            get { return (Brush)this.GetValue(KendoLegend.ColorProperty); }
            set { this.SetValue(KendoLegend.ColorProperty, (object)value); }
        }
        public Brush[] SeriesColor
        {
            get { return (Brush[])this.GetValue(KendoLegend.ColorProperty); }
            set { this.SetValue(KendoLegend.ColorProperty, (object)value); }
        }

        public LegendPosition Position
        {
            get { return (LegendPosition)this.GetValue(KendoLegend.PositionProperty); }
            set { this.SetValue(KendoLegend.PositionProperty, (object)value); }
        }
    }
}
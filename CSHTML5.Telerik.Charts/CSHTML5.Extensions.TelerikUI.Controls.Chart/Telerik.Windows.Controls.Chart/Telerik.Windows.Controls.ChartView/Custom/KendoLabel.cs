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
    public enum LabelPosition
    {
        Above,
        Below,
        Center,
        InsideBase,
        InsideEnd,
        Left,
        OutsideEnd,
        Right,
        Top,
        Bottom,
        Auto,
        Default
    }

    public enum LabelAlignment
    {
        Center,
        Right,
        Left,
        Default,
        // for pie and donnut chart
        Circle,
        Column
    }

    public class KendoLabel : Control
    {
        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("ColorProperty", typeof(Brush), typeof(KendoLabel), null);
        public static readonly DependencyProperty LabelTemplateProperty = DependencyProperty.Register("LabelTemplateProperty", typeof(string), typeof(KendoLabel), null);
        public static readonly DependencyProperty FormatProperty = DependencyProperty.Register("FormatProperty", typeof(string), typeof(KendoLabel), null);
        public static readonly DependencyProperty AlignProperty = DependencyProperty.Register("AlignProperty", typeof(LabelAlignment), typeof(KendoLabel), new PropertyMetadata(LabelAlignment.Default));
        public static readonly DependencyProperty PositionProperty = DependencyProperty.Register("PositionProperty", typeof(LabelPosition), typeof(KendoLabel), new PropertyMetadata(LabelPosition.Default));

        public Brush Color
        {
            get { return (Brush)this.GetValue(KendoLabel.ColorProperty); }
            set { this.SetValue(KendoLabel.ColorProperty, (object)value); }
        }

        public string LabelTemplate
        {
            get { return (string)this.GetValue(KendoLabel.LabelTemplateProperty); }
            set { this.SetValue(KendoLabel.LabelTemplateProperty, (object)value); }
        }

        public string Format
        {
            get { return (string)this.GetValue(KendoLabel.FormatProperty); }
            set { this.SetValue(KendoLabel.FormatProperty, (object)value); }
        }

        public LabelAlignment Align
        {
            get { return (LabelAlignment)this.GetValue(KendoLabel.AlignProperty); }
            set { this.SetValue(KendoLabel.AlignProperty, (object)value); }
        }

        public LabelPosition Position
        {
            get { return (LabelPosition)this.GetValue(KendoLabel.PositionProperty); }
            set { this.SetValue(KendoLabel.PositionProperty, (object)value); }
        }
    }
}
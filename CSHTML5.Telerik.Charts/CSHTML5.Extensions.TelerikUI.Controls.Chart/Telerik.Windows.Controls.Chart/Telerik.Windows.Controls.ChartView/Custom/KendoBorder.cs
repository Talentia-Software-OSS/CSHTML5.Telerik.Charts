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
    public enum KendoDashType
    {
        Dash,
        DashDot,
        Dot,
        LongDash,
        LongDashDot,
        LongDashDotDot,
        Solid
    }

    public class KendoBorder : Control
    {
        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("ColorProperty", typeof(Brush), typeof(KendoBorder), null);
        public static readonly DependencyProperty DashTypeProperty = DependencyProperty.Register("DashTypeProperty", typeof(KendoDashType), typeof(KendoBorder), new PropertyMetadata(KendoDashType.Solid));
        public static readonly DependencyProperty WitdhProperty = DependencyProperty.Register("WitdhProperty", typeof(int), typeof(KendoBorder), new PropertyMetadata(1));

        public static readonly KendoBorder NoBorder = new KendoBorder() { Width = 0 };
        public Brush Color
        {
            get { return (Brush)this.GetValue(KendoBorder.ColorProperty); }
            set { this.SetValue(KendoBorder.ColorProperty, (object)value); }
        }

        public KendoDashType DashType
        {
            get { return (KendoDashType)this.GetValue(KendoBorder.DashTypeProperty); }
            set { this.SetValue(KendoBorder.DashTypeProperty, (KendoDashType)value); }
        }

        public int Witdh
        {
            get { return (int)this.GetValue(KendoBorder.WitdhProperty); }
            set { this.SetValue(KendoBorder.WitdhProperty, (int)value); }
        }
    }
}
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
    public class KendoLegend : Control
    {
        //-------------------------------------//
        //-------------- FIELDS ---------------//
        //-------------------------------------//
        //public static readonly DependencyProperty ItemsPanelProperty = DependencyProperty.Register("ItemsPanel", typeof(ItemsPanelTemplate), typeof(RadLegend), null);

        //public static readonly DependencyProperty ItemTemplateProperty = DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(RadLegend), null);

        //public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register("Items", typeof(LegendItemCollection), typeof(RadLegend), null);

        //public static readonly DependencyProperty DefaultMarkerGeometryProperty = DependencyProperty.Register("DefaultMarkerGeometry", typeof(Geometry), typeof(RadLegend), null);

        //public static readonly DependencyProperty HoverModeProperty = DependencyProperty.Register("HoverMode", typeof(LegendHoverMode), typeof(RadLegend), null);
        /*
         background: "green",
         position: "left",
    labels: {
      font: "20px sans-serif",
      color: "red"
    }*/
        
        public KendoLegend()
        {
            this.DataContextChanged += KendoLegend_DataContextChanged;
        }

        private void KendoLegend_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
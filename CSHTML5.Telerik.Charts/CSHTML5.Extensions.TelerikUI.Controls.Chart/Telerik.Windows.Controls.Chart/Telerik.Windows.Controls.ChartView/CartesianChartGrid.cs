//-------------------------------------//
//-------------- USINGS ---------------//
//-------------------------------------//
using Telerik.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows;
using System;
using System.Windows.Media;
//-------------------------------------//
//-------------------------------------//
//-------------------------------------//

namespace Telerik.Windows.Controls.ChartView
{
    public class CartesianChartGrid : ChartElementPresenter
    {
        //-------------------------------------//
        //-------------- FIELDS ---------------//
        //-------------------------------------//
        public static readonly DependencyProperty MajorLinesVisibilityProperty = DependencyProperty.Register("MajorLinesVisibilityProperty", typeof(GridLineVisibility), typeof(CartesianChartGrid), null);
        public static readonly DependencyProperty MajorYLineDashArrayProperty = DependencyProperty.Register("MajorYLineDashArrayProperty", typeof(DoubleCollection), typeof(CartesianChartGrid), null);
        private GridLineRenderMode _majorYLinesRenderMode;
        public static readonly DependencyProperty MajorYLineStyleProperty = DependencyProperty.Register("MajorYLineStyleProperty", typeof(Style), typeof(CartesianChartGrid), null);
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------ PROPERTIES -------------//
        //-------------------------------------//
        public GridLineVisibility MajorLinesVisibility
        {
            get { return (GridLineVisibility)this.GetValue(CartesianChartGrid.MajorLinesVisibilityProperty); }
            set { this.SetValue(CartesianChartGrid.MajorLinesVisibilityProperty, (object)value); }
        }
        public DoubleCollection MajorYLineDashArray
        {
            get { return (DoubleCollection)this.GetValue(CartesianChartGrid.MajorYLineDashArrayProperty); }
            set { this.SetValue(CartesianChartGrid.MajorYLineDashArrayProperty, (object)value); }
        }
        public GridLineRenderMode MajorYLinesRenderMode
        {
            get { return _majorYLinesRenderMode; }
            set { _majorYLinesRenderMode = value; }
        }
        public Style MajorYLineStyle
        {
            get { return (Style)this.GetValue(CartesianChartGrid.MajorYLineStyleProperty); }
            set { this.SetValue(CartesianChartGrid.MajorYLineStyleProperty, (object)value); }
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------- METHODS ---------------//
        //-------------------------------------//
        public CartesianChartGrid()
        {
            _majorYLinesRenderMode = new GridLineRenderMode();
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

    }
}

//-------------------------------------//
//-------------- USINGS ---------------//
//-------------------------------------//
using Telerik.Windows.Controls.ChartView;
using Telerik.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows;
using System;
//-------------------------------------//
//-------------------------------------//
//-------------------------------------//

namespace Telerik.Windows.Controls
{
    public class RadCartesianChart : RadChartBase
    {
        //-------------------------------------//
        //-------------- FIELDS ---------------//
        //-------------------------------------//
        private PresenterCollection<CartesianSeries> _series;
        private CartesianChartGrid _grid;
        public static readonly DependencyProperty HorizontalAxisProperty = DependencyProperty.Register("HorizontalAxisProperty", typeof(CartesianAxis), typeof(RadCartesianChart), null);
        public static readonly DependencyProperty VerticalAxisProperty = DependencyProperty.Register("VerticalAxisProperty", typeof(CartesianAxis), typeof(RadCartesianChart), null);
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------ PROPERTIES -------------//
        //-------------------------------------//
        public PresenterCollection<CartesianSeries> Series
        {
            get { return _series; }
        }
        public CartesianChartGrid Grid
        {
            get { return _grid; }
            set { _grid = value; }
        }
        public CartesianAxis HorizontalAxis
        {
            get { return (CartesianAxis)this.GetValue(RadCartesianChart.HorizontalAxisProperty); }
            set { this.SetValue(RadCartesianChart.HorizontalAxisProperty, (object)value); }
        }
        public CartesianAxis VerticalAxis
        {
            get { return (CartesianAxis)this.GetValue(RadCartesianChart.VerticalAxisProperty); }
            set { this.SetValue(RadCartesianChart.VerticalAxisProperty, (object)value); }
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------- METHODS ---------------//
        //-------------------------------------//
        public RadCartesianChart()
        {
            this.DefaultStyleKey = typeof(RadCartesianChart);
            _series = new PresenterCollection<CartesianSeries>();
            _grid = null;
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//


        #region Non-Generated methods

        protected kendo_ui_chart.kendo.dataviz.ui.Chart _kendoChart;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _kendoChart = this.GetTemplateChild("KendoChart") as kendo_ui_chart.kendo.dataviz.ui.Chart;
        }

        #endregion

    }
}

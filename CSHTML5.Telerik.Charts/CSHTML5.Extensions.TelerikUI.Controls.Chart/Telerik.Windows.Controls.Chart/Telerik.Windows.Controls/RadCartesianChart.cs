//-------------------------------------//
//-------------- USINGS ---------------//
//-------------------------------------//
using Telerik.Windows.Controls.ChartView;
using System.Windows;
using kendo_ui_chart.kendo.dataviz.ui;
using TypeScriptDefinitionsSupport;
using CSHTML5;
using System.Windows.Media;
using JSConversionHelpers;
using System;
//-------------------------------------//
//-------------------------------------//
//-------------------------------------//

namespace Telerik.Windows.Controls
{
    public class RadCartesianChart : RadChartSeriesBase<CartesianSeries>
    {
        public RadCartesianChart() : base()
        {
            this.DefaultStyleKey = typeof(RadCartesianChart);
        }

        protected override void SetKendoChartSeries(ChartOptions chartOptions)
        {
            base.SetKendoChartSeries(chartOptions);

            //todo: refactor this method into smaller methods. Also, we should probably put the similar code for the two axes in the same places (instead of dealing with one axis, then the other).

            //ChartOptions chartO = new ChartOptions();
            var series = new JSArray<ChartSeriesItem>();

            foreach (CartesianSeries cartesianSeries in _series)
            {
                if (cartesianSeries.ItemsSource != null)
                {
                    ChartSeriesItem seriesItem = new ChartSeriesItem();
                    seriesItem.name = cartesianSeries.SeriesName;
                    seriesItem.type = cartesianSeries.GetChartType();
                    seriesItem.missingValues = "gap";

                    #region attempt at dealing with tooltips in series.
                    //if(cartesianSeries is LineSeries)
                    //{
                    //    //Note: the following does nothing if chartO.tooltip.shared is true.
                    //    //note: The LineSeries is the only one that has the LineSeries.TrackBallInfoTemplate set in the xaml
                    //    seriesItem.tooltip = new ChartSeriesItemTooltip();
                    //    Interop.ExecuteJavaScript("$0.visible = true", seriesItem.tooltip.UnderlyingJSInstance); //todo: find out how to do categoryAxisItem.crosshair.visible = true; without having Bridge break everything by boxing the value even though it is boxed in the generated code.
                    //    seriesItem.tooltip.format = "Close: {0}";
                    //}
                    //if(cartesianSeries.TrackBallInfoTemplate != null)
                    //{
                    //    //find a way to generate a kendo-style template in html here, from the cartesianSeries.TrackBallInfoTemplate.
                    //    //that includes creating the html structure and translating the bindings into something in kendo style.
                    //    // for example, the Text="{Binding DataPoint.Category, StringFormat=Date: \{0:d\} }"
                    //}
                    #endregion

                    // mapped fields
                    var propertyFields = GetPropertyFields(cartesianSeries, seriesItem);
                    // data mapping
                    var res = JSConverters.PrepareSeriesData(cartesianSeries.ItemsSource, propertyFields);
                    seriesItem.data = res;

                    SetKendoSeriesOptions(cartesianSeries, seriesItem);

                    series.Add(seriesItem);
                }
            }

            chartOptions.series = series;
            //_kendoChart.setOptions(chartO);

            if (chartOptions.series.Count != _series.Count)
            {
                throw new System.Exception("Not working");
            }
        }

        protected override void SetOtherOptions(ChartOptions chartO)
        {
            //Setting the chart's background color:
            Brush background = Background;
            if (background != null && background is SolidColorBrush)
            {
                chartO.chartArea = new ChartChartArea();
                chartO.chartArea.background = (string)((SolidColorBrush)background).ConvertToCSSValue();
            }
        }

        //private GetCategoryAxis
        
        protected override void SetKendoSeriesAdditionalOptions(ChartSeries chartSeries, ChartSeriesItem seriesItem)
        {
            base.SetKendoSeriesAdditionalOptions(chartSeries, seriesItem);
            var series = chartSeries as BarSeries;
            if (series != null)
            {
                seriesItem.gap = series.Gap;
                seriesItem.spacing = series.Spacing;
            }
        }
    }
}

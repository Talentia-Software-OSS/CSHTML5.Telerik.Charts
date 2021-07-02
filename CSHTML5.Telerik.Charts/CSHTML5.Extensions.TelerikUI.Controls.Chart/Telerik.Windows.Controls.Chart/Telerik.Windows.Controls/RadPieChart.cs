using JSConversionHelpers;
using kendo_ui_chart.kendo.dataviz.ui;
using System.Collections.Generic;
using Telerik.Windows.Controls.ChartView;
using TypeScriptDefinitionsSupport;

namespace Telerik.Windows.Controls
{
    public class RadPieChart : RadChartSeriesBase<PieSeries>
    {
        public RadPieChart(): base()
        {
            this.DefaultStyleKey = typeof(RadPieChart);
        }

        protected override void SetKendoChartSeries()
        {
            ChartOptions chartO = new ChartOptions();
            chartO.tooltip = new ChartTooltip() { visible = true, format = "{0}%" };

            var series = new JSArray<ChartSeriesItem>();
            foreach (PieSeries pieSeries in _series)
            {
                if (pieSeries.ItemsSource != null)
                {
                    // create seriesItem
                    ChartSeriesItem seriesItem = new ChartSeriesItem();

                    // set series details
                    seriesItem.type = pieSeries.GetChartType();
                    seriesItem.startAngle = pieSeries.StartAngle;

                    // mapped fields
                    DataPropertyMapping categoryMapping = new DataPropertyMapping(pieSeries.CategoryBinding?.PropertyPath ?? "Category");
                    seriesItem.categoryField = categoryMapping.FieldName;

                    DataPropertyMapping valueMapping = new DataPropertyMapping(pieSeries.ValueBinding?.PropertyPath ?? "Value");
                    seriesItem.field = valueMapping.FieldName;

                    // unmapped detail fields
                    DataPropertyMapping colorMapping = new DataPropertyMapping(pieSeries.ColorBinding?.PropertyPath ?? "Color", "color");

                    var propertyFields = new List<DataPropertyMapping>() { categoryMapping, valueMapping, colorMapping };
                    var res = JSConverters.PrepareSeriesData(pieSeries.ItemsSource, propertyFields);
                    seriesItem.data = res;

                    series.Add(seriesItem);
                }
            }

            // add chart to kendo
            chartO.series = series;
            _kendoChart.setOptions(chartO);
        }
    }
}

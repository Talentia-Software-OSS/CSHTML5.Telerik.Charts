using JSConversionHelpers;
using kendo_ui_chart.kendo.dataviz.ui;
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

        protected override void SetKendoChartSeries(ChartOptions chartOptions)
        {
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
                    var propertyFields = SetInSeriesItemAndGetPropertyFields(pieSeries, seriesItem);
                    // data mapping
                    var res = JSConverters.PrepareSeriesData(pieSeries.ItemsSource, propertyFields);
                    seriesItem.data = res;

                    series.Add(seriesItem);
                }
            }

            // add chart to kendo
            chartOptions.series = series;
        }
    }
}
